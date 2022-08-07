using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingMDMLookupsDataRelations.Domain.Entities
{
    public class MinistryMajor
    {
        public int Id { get; set; }
        public int BusinessCode { get; set; }
        public int MINISTRY_MAJOR_CODE { get; set; }
        public string MINISTRY_MAJOR_ARABIC_NAME { get; set; }
        public string MINISTRY_MAJOR_ENGLISH_NAME { get; set; }
        public string MINISTRY_MAJOR_FRENCH_NAME { get; set; }
     
    }
}
