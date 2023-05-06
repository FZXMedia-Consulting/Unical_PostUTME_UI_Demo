using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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


		public void OnGet(string JambRegNumber, string Pin)
        {
			Input = new FormInput { Pin = Pin, JambRegNumber = JambRegNumber };
		}

		public IActionResult OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			return RedirectToPage("./Preview", Input);
		}
    }
}
