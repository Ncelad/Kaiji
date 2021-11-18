using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Kaiji.Model.DB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kaiji.Pages
{
    public class IndexModel : PageModel
    {
        public static IndexModel instance = null;
        public bool IsSignedIn = false;
        public ClaimsPrincipal CurrentUser;
        public List<Project> projects = null;
        public IWebHostEnvironment Environment;

        private IndexModel()
        {

        }
        public IndexModel(IWebHostEnvironment environment)
        {
            if(instance == null)
            {
                instance = new IndexModel();
            }
            instance.Environment = environment;
        }

        public void OnGet()
        {
            if (instance.IsSignedIn)
            {
                List<Project> p = new List<Project>();
                foreach (var item in Repository.Read<Project>())
                {
                    if (item.UserName == this.CurrentUser.Identity.Name)
                    {
                        p.Add(item);
                    }
                }
                this.projects = p;
                instance.IsSignedIn = false;
            }
        }
    }
}
