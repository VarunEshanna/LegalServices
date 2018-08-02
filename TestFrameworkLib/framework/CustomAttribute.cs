using System;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;
using TestFrameworkLib;

namespace TestFramework
{
    public class CustomAttr : NUnitAttribute, IWrapTestMethod
    {
        public TestCommand Wrap(TestCommand command)
        {
            return new CustomCommand(command);
        }
    }

    internal class CustomCommand : TestCommand
    {
        private static Test innerCommand;
        private TestCommand command;

        public CustomCommand(TestCommand command) : base(innerCommand)
        {
            this.command = command;
        }

        public override TestResult Execute(TestExecutionContext context)
        {
            TestResult testResults = null;
            try
            {
                command.Execute(context);
            }
            catch (Exception ex)
            {
                String msg = ex.Message;
            }
            testResults = context.CurrentResult;
            if (context.CurrentResult.FailCount > 0)
            {
                context.CurrentResult.SetResult(ResultState.Failure);
            }
            else
            {
                context.CurrentResult.SetResult(ResultState.Success);
            }

            TestMethodDataEntity testMethodDataEntity = new TestMethodDataEntity();
            testMethodDataEntity.TestMethodName = context.CurrentTest.MethodName;
            testMethodDataEntity.TestClassName = context.CurrentTest.ClassName;
            testMethodDataEntity.TestDataReference = JsonConvert.SerializeObject(context.CurrentTest.Arguments);
            testMethodDataEntity.Result = (context.CurrentResult.ResultState == ResultState.Success) ? true : false;
            String message = "";
            if (!testMethodDataEntity.Result)
            {
                for (int i = 0; i < context.CurrentResult.AssertionResults.Count; i++)
                {
                    message += context.CurrentResult.AssertionResults[i].Message;

                }
                testMethodDataEntity.Message = message;
                // TODO: Buidling custom error messages
                // Classname, methodname and argument list is available.
                // Based on the argument list get the expected response object
                // Get the actual response object --------------------------------- NEED TO CHECK THIS
                // Get all the properties via reflection
                // Compare and build a custom error message
            }

            MongoDbConnection mongoDbConnection = new MongoDbConnection();
            mongoDbConnection.upsertTestResultsData(testMethodDataEntity);

            return testResults;
        }
    }
}
