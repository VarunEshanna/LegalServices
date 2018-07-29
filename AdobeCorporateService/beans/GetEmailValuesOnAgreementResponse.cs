namespace LegalService
{
    public class GetEmailValuesOnAgreementResponse
    {
        public string COPSEmail { get; set; }
        public string PAEmail { get; set; }


        public override bool Equals(object obj)
        {
            var other = obj as GetEmailValuesOnAgreementResponse;

            if (other == null)
                return false;

            if (COPSEmail != other.COPSEmail)
                return false;

            if (PAEmail != other.PAEmail)
                return false;

            return true;
        }


        public override int GetHashCode()
        {
            return (COPSEmail == null ? 0 : COPSEmail.GetHashCode()) + (PAEmail == null ? 0 : PAEmail.GetHashCode()) ;
        }
    }
}