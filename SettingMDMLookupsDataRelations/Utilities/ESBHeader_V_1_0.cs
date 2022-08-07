using System.Runtime.Serialization;

namespace SettingMDMLookupsDataRelations.Utilities
{
  
    [DataContract(Name = "ESBHeader", Namespace = "http://TETCO.SOA.Common.DataContracts.Headers.ESBHeader/ESBHeader/V1.0")]
    public class ESBHeader_V_1_0
    {
        public const string Name = "ESBHeader";

        public const string Namespace = "http://TETCO.SOA.Common.DataContracts.Headers/ESBHeader/V1.0";

        public const string OperationContextKey = "ESBHeader";

        [DataMember(Order = 1, IsRequired = true)]
        public Security_V_1_0 Security { get; set; }

        [DataMember(Order = 2)]
        public Infrastructure_V_1_0 Infrastructure { get; set; }
    }
    
}
