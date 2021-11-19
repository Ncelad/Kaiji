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
        public int CurrentProjectId;
        public List<Row> rows = null;
        public List<Card> cards = null;

        public IActionResult OnGet(string id)
        {
            if (Url.IsLocalUrl("/ProjectEdit"))
            {
                CurrentProjectId = Convert.ToInt32(id);
                List<Row> r = new List<Row>();
                List<Card> c = new List<Card>();
                foreach (var item in Repository.Read<Row>())
                {
                    if(item.ProjectId == CurrentProjectId)
                    {
                        r.Add(item);
                        foreach (var jtem in Repository.Read<Card>())
                        {
                            if (jtem.RowId == item.Id)
                            {
                                c.Add(jtem);
                            }
                        }
                    }
                }
                cards = c;
                rows = r;
            }
            return Page();
        }
    }
}
