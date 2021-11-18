using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaiji.Model.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kaiji.Pages
{
    public class CreateProjectModel : PageModel
    {
        public Project NewProject = new Project();

        public void OnPost()
        {
            this.NewProject.Title = Request.Form["title"];
            this.NewProject.Description = Request.Form["description"];
            this.NewProject.UserName = IndexModel.instance.CurrentUser.Identity.Name;

            Repository.Create<Project>(NewProject);
        }

        public void OnGet()
        {

        }
    }
}
