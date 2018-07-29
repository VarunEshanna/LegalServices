namespace LegalService
{
    public class GetAgreementContractClassResponse
    {
        public string ContractClass { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as GetAgreementContractClassResponse;

            if (other == null)
                return false;

            if (ContractClass != other.ContractClass)
                return false;

            return true;
        }


        public override int GetHashCode()
        {
            return ContractClass == null ? 0 : ContractClass.GetHashCode();
        }
    }
}