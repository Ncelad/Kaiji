using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaiji.Model.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kaiji.Pages
{
    public class CreateCardModel : PageModel
    {
        public int CurrentRowId;
        public int CurrentProjectId;
        public Card NewCard = new Card();
        private static CreateCardModel instance = null;

        public static CreateCardModel Instance
        {
            get { if (instance == null) { instance = new CreateCardModel(); } return instance; }
            private set { }
        }


        public void OnPost()
        {
            Instance.NewCard.Title = Request.Form["title"];
            Instance.NewCard.Description = Request.Form["description"];
            Instance.NewCard.RowId = Instance.CurrentRowId;

            Repository.Create<Card>(Instance.NewCard);
        }

        public IActionResult OnGet(string RowId, string ProjId)
        {
            if (Url.IsLocalUrl("/CreateCard"))
            {
                Instance.CurrentRowId = Convert.ToInt32(RowId);
                Instance.CurrentProjectId = Convert.ToInt32(ProjId);
            }
            return Page();
        }
    }
}
