using System.Runtime.Serialization;

namespace SettingMDMLookupsDataRelations.Utilities
{
    
    [DataContract(Name = "CarbonIdentity", Namespace = "http://TETCO.SOA.Common.DataContracts.Headers.ESBHeader/CarbonIdentity/V1.0")]
    public class CarbonIdentity_V_1_0
    {
        [DataMember(Order = 1, IsRequired = true)]
        public string Username { get; set; }
    }
    
}
