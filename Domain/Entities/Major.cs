using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingMDMLookupsDataRelations.Domain.Entities
{
    public class Major
    {
        public int  Id { get; set; }
        public int BusinessCode { get; set; }
        public int MAJOR_CODE { get; set; }
        public string MAJOR_ARABIC_NAME { get; set; }
        public string MAJOR_ENGLISH_NAME { get; set; }
        public int MINISTRY_MAJOR_CODE { get; set; }
    }
}
