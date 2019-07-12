using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pumox.Services.Companies.Dtos;

namespace Pumox.Services.Companies.Queries.SearchCompany
{
    public class SearchCompanyQuery : IQuery<IEnumerable<CompanyDto>>
    {
        public string Keyword { get; }
        public DateTime? EmployeeDateOfBirthFrom { get; }
        public DateTime? EmployeeDateOfBirthTo { get; }
        public List<string> EmployeeJobTitles { get; }

        [JsonConstructor]
        public SearchCompanyQuery(string keyword, DateTime? employeeDateOfBirthFrom,
            DateTime? employeeDateOfBirthTo, List<string> employeeJobTitles)
        {
            Keyword = keyword;
            EmployeeDateOfBirthFrom = employeeDateOfBirthFrom;
            EmployeeDateOfBirthTo = employeeDateOfBirthTo;
            EmployeeJobTitles = employeeJobTitles;
        }
    }
}