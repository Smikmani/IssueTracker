using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Data.Entities;
using Project1.ViewModel.Create;
using Project1.ViewModel.Shared;

namespace Project1.Interfaces
{
    public interface ICreateViewModelService
    {
        Task<CreateViewModel> GetCreateViewModel();
        Task<List<SelectItem>> GetTypesSelectItems();
        Task<List<SelectItem>> GetStatusSelectItems();
        Task<List<SelectItem>> GetTeamsSelectItems();
        Task CreateIssue(Issue issue);

    }
}
