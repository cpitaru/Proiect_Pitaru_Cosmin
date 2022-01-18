using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Pitaru_Cosmin.Data;

namespace Proiect_Pitaru_Cosmin.Models
{
    public class CategoriiCeaiPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Proiect_Pitaru_CosminContext context,
        Ceai ceai)
        {
            var allCategories = context.Categorie;
            var ceaiCategories = new HashSet<int>(
            ceai.CategoriiCeai.Select(c => c.CategorieID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Assigned = ceaiCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateCeaiCategories(Proiect_Pitaru_CosminContext context,
        string[] selectedCategories, Ceai ceaiToUpdate)
        {
            if (selectedCategories == null)
            {
                ceaiToUpdate.CategoriiCeai = new List<CategorieCeai>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var ceaiCategories = new HashSet<int>
            (ceaiToUpdate.CategoriiCeai.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!ceaiCategories.Contains(cat.ID))
                    {
                        ceaiToUpdate.CategoriiCeai.Add(
                        new CategorieCeai
                        {
                            CeaiID = ceaiToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (ceaiCategories.Contains(cat.ID))
                    {
                        CategorieCeai courseToRemove
                        = ceaiToUpdate
                        .CategoriiCeai
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
