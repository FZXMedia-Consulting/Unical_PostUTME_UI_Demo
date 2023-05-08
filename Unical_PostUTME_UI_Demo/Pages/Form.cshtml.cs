using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace Unical_PostUTME_UI_Demo.Pages
{
    public class FormModel : PageModel
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

		}

		[BindProperty]
		public FormInput Input { get; set; }

        public IActionResult OnGet(string jambRegNumber, string pin, FormInput data)
        {
			if (string.IsNullOrEmpty(jambRegNumber) || string.IsNullOrEmpty(pin)) 
				return RedirectToPage("./Index");

			if (data != null)
			{
				Input = data;
			}

			Input.Pin = pin;
			Input.JambRegNumber = jambRegNumber;

			return Page();
		}

		public IActionResult OnPostAsync()
		{
			if (!ModelState.IsValid) return Page();

			return RedirectToPage("./Preview", Input);
		}

		public IEnumerable<SelectListItem> GenderList()
		{
			string genders = "Male, Female";
			return genders.Split(",").Select(x => new SelectListItem
			{
				Text = x.Trim(),
				Value = x.Trim()
			});
		}
    }
}
