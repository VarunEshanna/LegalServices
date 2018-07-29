using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dummy
{
   public class Program
    {
        static void Main(string[] args)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.LoadFrom(@"C:\Users\eshanna\source\repos\LegalServices\AdobeCorporateService\bin\Debug\AdobeCorporateService.dll");
            String name = "LegalService.GetAdobeCorporateEntityRequest";
            Type type = Type.GetType(name, true);
            Object[] data = { "DMA","US","Commercial",true};
            Object instance = Activator.CreateInstance(type, data);
            Console.WriteLine(instance);

        }
    }
}
