
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Persistence.Repositories;
using SettingMDMLookupsDataRelations.Utilities;
using System.ServiceModel;

namespace SettingMDMLookupsDataRelations
{
    class Program
    {
        readonly static ESBHeader_V_1_0 header = new() { Security = new Security_V_1_0() { SiliconIdentity = new SiliconIdentity_V_1_0() { Username = "safeer_account", Password = "P@ssw0rd123456" }, CarbonIdentity = new CarbonIdentity_V_1_0() { Username = "tet" } } };
        readonly static MDMServiceSR.MDMClient client = new MDMServiceSR.MDMClient();
        readonly static MDMRepository repo = new MDMRepository();

        static async Task Main(string[] args)
        {
            try {
                Console.WriteLine("Start...");

                var ministryMajors = await GetMinistryMajors();
                foreach (var ministryMajor in ministryMajors)
                {
                    try
                    {
                        var Majors = await GetMajorsByMinistryMajor(ministryMajor.BusinessCode.Value);
                        if (Majors != null)
                        {
                            await repo.UpdateMajors(Majors.Select(x => x.Id).ToList(), ministryMajor.BusinessCode.Value);
                            Console.WriteLine("Done for ministry major : " + ministryMajor.BusinessCode.Value);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                Console.WriteLine("End...");
                Console.ReadLine();
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        #region Helpers


        private static async Task<List<MinistryMajor>> GetMinistryMajors()
        {
            return await repo.GetMinistryMajors();
        }
      

        private static async Task<List<MDMServiceSR.BaseLookup>> GetMajorsByMinistryMajor(int ministryMajorId)
        {
             Task<MDMServiceSR.MDMRelateResponse> majors;
            using (OperationContextScope operationContextScope = new(client.InnerChannel))
            {
                OperationContext.Current.OutgoingMessageHeaders.Add((new MessageHeader<ESBHeader_V_1_0>(header).GetUntypedHeader(ESBHeader_V_1_0.Name, ESBHeader_V_1_0.Namespace)));

                majors =  client.GetSpecilizationsByStudyFieldCodeAsync(new MDMServiceSR.MDMRelateRequest
                    {
                        BusinessCode = ministryMajorId,
                    });


            }
            return (await majors)?.MDMRelatedData;

        }


        #endregion

    }
}

