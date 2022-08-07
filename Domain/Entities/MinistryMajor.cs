using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public  class MinistryMajor
    {
        public int Id { get; set; }
        public int? BusinessCode { get; set; }
        public int? MinistryMajorCode { get; set; }
        public string? MinistryMajorArabicName { get; set; }
        public string? MinistryMajorEnglishName { get; set; }
        public string? MinistryMajorFrenchName { get; set; }
    }
}
