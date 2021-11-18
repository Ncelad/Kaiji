using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaiji.Model.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Kaiji.Pages
{
    public class ProjectEditModel : PageModel
    {
        private Project currentProject = null; 

        public IActionResult OnGet(string obj)
        {
            currentProject = JsonConvert.DeserializeObject<Project>(obj); 
            return Page();
        }
    }
}
