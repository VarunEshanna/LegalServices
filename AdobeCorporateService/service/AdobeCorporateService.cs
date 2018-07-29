using System;
using System.Collections.Generic;
using System.Linq;
using AdobeCorporateService.beans;

namespace LegalService
{
    public class AgreementInitiationService
    {
        public GetAdobeCorporateEntityResponse GetAdobeCorporateEntity (GetAdobeCorporateEntityRequest GetAdobeCorporateEntityRequest)
        {
            GetAdobeCorporateEntityResponse GetAdobeCorporateEntityResponse = new GetAdobeCorporateEntityResponse();

            String[] accountCountryList = { "US", "CA" ,"MX", "JP" };
            if (GetAdobeCorporateEntityRequest.isCorporateEntityOverride)
            {
                if (GetAdobeCorporateEntityRequest.MarketSegment.Equals("Commercial")){
                    if (accountCountryList.Any(item => GetAdobeCorporateEntityRequest.AccountCountry.Contains(item)) || 
                        GetAdobeCorporateEntityRequest.AgreementType.Equals("NDA"))
                    {
                        GetAdobeCorporateEntityResponse.AdobeCorporateEntity = "ADUS";
                    }
                    else
                    {
                        GetAdobeCorporateEntityResponse.AdobeCorporateEntity = "ADIR";
                    }
                }
                else
                {
                    GetAdobeCorporateEntityResponse.AdobeCorporateEntity = "ADIR";
                }
            }
            else
            {
                GetAdobeCorporateEntityResponse.AdobeCorporateEntity = "3PTY";
            }
            return GetAdobeCorporateEntityResponse;
        }

        public GetAgreementContractClassResponse GetAgreementContractClass(GetAgreementContractClassRequest GetAgreementContractClassRequest)
        {
            GetAgreementContractClassResponse GetAgreementContractClassResponse = new GetAgreementContractClassResponse();
            String value = null;

            Dictionary<String, String> typeClassMap = new Dictionary<String, String>();
            typeClassMap.Add("NDA","NRG");
            typeClassMap.Add("DMA", "RG");

            typeClassMap.TryGetValue(GetAgreementContractClassRequest.AgreementType, out value);
            GetAgreementContractClassResponse.ContractClass = value;
            return GetAgreementContractClassResponse;
        }

        // -----------------------------------------------------------------------------------------------------------------------------
        public GetAgreementNameResponse GetAgreementName(GetAgreementNameRequest GetAgreementNameRequest)
        {
            GetAgreementNameResponse GetAgreementNameResponse = new GetAgreementNameResponse();
            String AgreementName = "";

            List<String> PartnerNamingFormat = new List<String>();
            PartnerNamingFormat.Add("DMA");
            PartnerNamingFormat.Add("ETLA");
            PartnerNamingFormat.Add("Sales");

            List<String> VolumeNamingFormat = new List<String>();
            VolumeNamingFormat.Add("CLP");
            VolumeNamingFormat.Add("EEA");
            VolumeNamingFormat.Add("VIP");

            if (GetAgreementNameRequest.ContractGroup.Contains("Partner") && PartnerNamingFormat.Contains(GetAgreementNameRequest.RecordType))
            {
                if(GetAgreementNameRequest.ContractingOrganization != null && GetAgreementNameRequest.EndUserOrgination != null)
                {
                    AgreementName = GetAgreementNameRequest.RecordType + " with " + GetAgreementNameRequest.ContractingOrganization + " for " + GetAgreementNameRequest.EndUserOrgination;
                }
                else
                {
                    AgreementName = getAgreementNameFromAccount(GetAgreementNameRequest.AccountName, GetAgreementNameRequest.RecordType);
                }
                
            }
            else if (GetAgreementNameRequest.ContractGroup.Contains("Volume") && VolumeNamingFormat.Contains(GetAgreementNameRequest.RecordType))
            {
                if (GetAgreementNameRequest.MarketingSegment != null && GetAgreementNameRequest.ContractLanguage != null)
                {
                    AgreementName = GetAgreementNameRequest.MarketingSegment + " , " + GetAgreementNameRequest.ContractLanguage;
                }
                else
                {
                    AgreementName = getAgreementNameFromAccount(GetAgreementNameRequest.AccountName, GetAgreementNameRequest.RecordType);
                }
                AgreementName = AgreementNameAddonsForVolumeContractGroups(AgreementName, GetAgreementNameRequest.AgreementCategory, GetAgreementNameRequest.ContractLanguage, GetAgreementNameRequest.ProgramType);
            }
            else
            {
                AgreementName = getAgreementNameFromAccount(GetAgreementNameRequest.AccountName, GetAgreementNameRequest.RecordType);
            }

            GetAgreementNameResponse.AgreementName = AgreementName;
            return GetAgreementNameResponse;
        }

        
        private String getAgreementNameFromAccount(String AccountName, String RecordType)
        {
            String AgreementName = "";
            if (String.IsNullOrEmpty(AccountName))
            {
                AgreementName = RecordType + " for " + AccountName;
            }
            else
            {
                AgreementName = RecordType;
            }
            return AgreementName;
        }

        private String AgreementNameAddonsForVolumeContractGroups(String AgreementName, String AgreementCategory, String ContractLanguage, String ProgramType)
        {
            if (AgreementCategory.Contains("Online")){
                AgreementName = AgreementName + " [ONLINE]";
            }
            else 
            {
                if (!ContractLanguage.Equals("English"))
                {
                    AgreementName = AgreementName + " [Dual Lang]";
                }
            }


            if (ProgramType.Contains("Renewal"))
            {
                AgreementName = AgreementName + " Renewal";
            }

            return AgreementName;
        }

        // -----------------------------------------------------------------------------------------------------------------------------


        public GetEmailValuesOnAgreementResponse GetEmailValuesOnAgreement(GetEmailValuesOnAgreementRequest GetEmailValuesOnAgreementRequest)
        {
            GetEmailValuesOnAgreementResponse GetEmailValuesOnAgreementResponse = new GetEmailValuesOnAgreementResponse();
            List<String> AdobeINCCountries = new List<String>();
            AdobeINCCountries.Add("US");
            AdobeINCCountries.Add("CA");
            List<String> PACountries = new List<String>();
            PACountries.Add("US");
            PACountries.Add("CA");

            if (!String.IsNullOrEmpty(GetEmailValuesOnAgreementRequest.AddressCountry))
            {
                if (AdobeINCCountries.Contains(GetEmailValuesOnAgreementRequest.AddressCountry))
                {
                    GetEmailValuesOnAgreementResponse.COPSEmail = "ECM AdobeINC COPS Email";
                }
                else
                {
                    GetEmailValuesOnAgreementResponse.COPSEmail = "ECM ROW COPS Email";
                }

                if (PACountries.Contains(GetEmailValuesOnAgreementRequest.AddressCountry) || GetEmailValuesOnAgreementRequest.AddressCountry.Equals("JP"))
                {
                    GetEmailValuesOnAgreementResponse.PAEmail = "ECM AdobeIreland PA Email";
                }
                else
                {
                    GetEmailValuesOnAgreementResponse.PAEmail = "ECM AdobeINC PA Email";
                }
            }

            return GetEmailValuesOnAgreementResponse;
        }


        public void populateDealDeskCase()
        {

        }

    }


}
