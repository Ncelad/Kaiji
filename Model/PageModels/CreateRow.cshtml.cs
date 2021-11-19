using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaiji.Model.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kaiji.Pages
{
    public class CreateRowModel : PageModel
    {
        public int CurrentProjectId;
        public Row NewRow = new Row();
        private static CreateRowModel instance = null;

        public static CreateRowModel Instance
        {
            get { if (instance == null) { instance = new CreateRowModel(); } return instance; }
            private set { }
        }


        public void OnPost()
        {
            Instance.NewRow.Title = Request.Form["title"];
            Instance.NewRow.ProjectId = Instance.CurrentProjectId;

            Repository.Create<Row>(Instance.NewRow);
        }

        public IActionResult OnGet(string id)
        {
            if (Url.IsLocalUrl("/CreateRow"))
            {
                Instance.CurrentProjectId = Convert.ToInt32(id);
            }
            return Page();
        }
    }
}
