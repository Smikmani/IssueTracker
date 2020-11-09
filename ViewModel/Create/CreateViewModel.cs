using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project1.Data.Entities;
using Project1.ViewModel.Shared;

namespace Project1.ViewModel.Create
{
    public class CreateViewModel
    {
        public Issue Issue { get; set; }
        public List<SelectItem> Types { get; set; }
        public List<SelectItem> Status { get; set; }
        public List<SelectItem> Teams { get; set; }

    }
}
