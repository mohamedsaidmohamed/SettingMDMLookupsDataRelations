using System.Runtime.Serialization;

namespace SettingMDMLookupsDataRelations.Utilities
{
   
    [DataContract(Name = "Security", Namespace = "http://TETCO.SOA.Common.DataContracts.Headers.ESBHeader/Security/V1.0")]
    public class Security_V_1_0
    {
        [DataMember(Order = 1, IsRequired = true)]
        public SiliconIdentity_V_1_0 SiliconIdentity { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public CarbonIdentity_V_1_0 CarbonIdentity { get; set; }
    }

}
