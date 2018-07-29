using System;

namespace LegalService
{
    public class GetAdobeCorporateEntityResponse
    {
        public String AdobeCorporateEntity { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as GetAdobeCorporateEntityResponse;

            if (other == null)
                return false;

            if (AdobeCorporateEntity != other.AdobeCorporateEntity)
                return false;

            return true;
        }


        public override int GetHashCode()
        {
            return AdobeCorporateEntity == null ? 0 : AdobeCorporateEntity.GetHashCode();
        }

    }
}