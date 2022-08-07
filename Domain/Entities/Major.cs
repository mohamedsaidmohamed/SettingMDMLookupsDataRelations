using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public  class Major
    {
        public int Id { get; set; }
        public int? BusinessCode { get; set; }
        public int? MajorCode { get; set; }
        public string? MajorArabicName { get; set; }
        public string? MajorEnglishName { get; set; }
        public int? MinistryMajorCode { get; set; }
    }
}
