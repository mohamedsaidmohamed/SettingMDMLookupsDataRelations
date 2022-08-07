using System.Runtime.Serialization;

namespace SettingMDMLookupsDataRelations.Utilities
{
   
    [DataContract(Name = "Infrastructure", Namespace = "http://TETCO.SOA.Common.DataContracts.Headers.ESBHeader/Infrastructure/V1.0")]
    public class Infrastructure_V_1_0
    {
        public string IPAddress { get; set; }

        public string MACAddress { get; set; }
    }
  
}
