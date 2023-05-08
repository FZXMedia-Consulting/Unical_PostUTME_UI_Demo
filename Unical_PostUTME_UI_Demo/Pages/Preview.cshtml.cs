using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Unical_PostUTME_UI_Demo.Pages
{
    public class PreviewModel : PageModel
    {
        public class FormInput
        {
            [Required] public IFormFile Passport { get; set; }
            [Required] public string Pin { get; set; }
            [Required] public string Gender { get; set; }
            [Required] public string FirstName { get; set; }
            [Required] public string SurName { get; set; }
            [Required] public string LastName { get; set; }
            [Required] public string Email { get; set; }
            [Required] public string PhoneNumber { get; set; }
            [Required] public DateTime? BirthDate { get; set; }
            [Required] public string JambRegNumber { get; set; }

            public string FullNames => $"{SurName}, {FirstName} {LastName}";
        }

        [BindProperty]
        public FormInput Input { get; set; }
        public void OnGet(FormInput data)
        {
            Input = data;
        }

        public IActionResult OnPost()
        {
            return Page();
        }

        public IEnumerable<SelectListItem> GenderList(string selected)
        {
            string genders = "Male, Female";
            return genders.Split(",").Select(x => new SelectListItem
            {
                Text = x.Trim(),
                Value = x.Trim(),
                Selected = x.Trim() == selected
            });
        }
    }
}
