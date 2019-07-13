using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pumox.Core.Domain.Repositories;
using Pumox.Core.Types;
using Pumox.Core.Types.Enums;
using Pumox.Services.Companies.Dtos;

namespace Pumox.Services.Companies.Queries.SearchCompany
{
    public class SearchCompanyHandler : IQueryHandler<SearchCompanyQuery, IEnumerable<CompanyDto>>
    {
        private readonly ICompaniesRepository _companiesRepository;
        
        public SearchCompanyHandler(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        public async Task<IEnumerable<CompanyDto>> HandleAsync(SearchCompanyQuery query)
        {
            var model = new SearchCompanyModel()
            {
                Keyword = query.Keyword,
                EmployeeDateOfBirthFrom = query.EmployeeDateOfBirthFrom,
                EmployeeDateOfBirthTo = query.EmployeeDateOfBirthTo,
            };

            if (model.EmployeeDateOfBirthFrom is null && model.EmployeeDateOfBirthTo != null)
                model.EmployeeDateOfBirthFrom = DateTime.MinValue;
            
            if (model.EmployeeDateOfBirthFrom != null && model.EmployeeDateOfBirthTo is null)
                model.EmployeeDateOfBirthTo = DateTime.MaxValue;
            
            if (query.EmployeeJobTitles != null && query.EmployeeJobTitles.Any())
            {
                var jobTitleEnums = new List<JobTitle>();
                foreach (var queryJobTitle in query.EmployeeJobTitles)
                {
                    if (Enum.TryParse(queryJobTitle, true, out JobTitle jobTitleEnum))
                        jobTitleEnums.Add(jobTitleEnum);
                }

                model.EmployeeJobTitles = jobTitleEnums;
            }

            var companies = await _companiesRepository.SearchAsync(model);

            return companies.Select(c => new CompanyDto()
            {
                Name = c.Name,
                EstablishmentYear = c.EstablishmentYear,
                Employees = c.Employees?.Select(e => new EmployeDto()
                {
                    DateOfBirth = e.DateOfBirth,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle
                }).ToList()
            });
        }
    }
}