using System;
using System.Collections.Generic;
using Pumox.Core.Types.Enums;

namespace Pumox.Core.Types
{
    public class SearchCompanyModel
    {
        public string Keyword { get; set; }
        public DateTime? EmployeeDateOfBirthFrom { get; set; }
        public DateTime? EmployeeDateOfBirthTo { get; set; }
        public List<JobTitle> EmployeeJobTitles { get; set; } = new List<JobTitle>();
    }
}