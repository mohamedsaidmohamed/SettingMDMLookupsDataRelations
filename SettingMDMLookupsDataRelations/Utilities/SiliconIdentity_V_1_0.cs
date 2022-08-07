using System.Runtime.Serialization;

namespace SettingMDMLookupsDataRelations.Utilities
{
   
    [DataContract(Name = "SiliconIdentity", Namespace = "http://TETCO.SOA.Common.DataContracts.Headers.ESBHeader/SiliconIdentity/V1.0")]
    public class SiliconIdentity_V_1_0
    {
        [DataMember(Order = 1, IsRequired = true)]
        public string Username { get; set; }

        [DataMember(Order = 2, IsRequired = true)]
        public string Password { get; set; }
    }

}
