// See https://aka.ms/new-console-template for more information

using SettingMDMLookupsDataRelations.Utilities;
using System.ServiceModel;

namespace SettingMDMLookupsDataRelations
{
    class Program
    {
        readonly static ESBHeader_V_1_0 header = new() { Security = new Security_V_1_0() { SiliconIdentity = new SiliconIdentity_V_1_0() { Username = "safeer_account", Password = "P@ssw0rd123456" }, CarbonIdentity = new CarbonIdentity_V_1_0() { Username = "tet" } } };
        readonly static MDMServiceSR.MDMClient client = new MDMServiceSR.MDMClient();

        static  async Task Main(string[] args)
        {
            using (OperationContextScope operationContextScope = new(client.InnerChannel))
            {
                OperationContext.Current.OutgoingMessageHeaders.Add((new MessageHeader<ESBHeader_V_1_0>(header).GetUntypedHeader(ESBHeader_V_1_0.Name, ESBHeader_V_1_0.Namespace)));

              var majors=  await  client.GetSpecilizationsByStudyFieldCodeAsync(new MDMServiceSR.MDMRelateRequest
                {
                    BusinessCode = 2,
                }) ;

            }
        
        }
    }
}

