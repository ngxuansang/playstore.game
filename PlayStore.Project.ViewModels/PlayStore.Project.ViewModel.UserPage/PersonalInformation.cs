using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.Project.ViewModels.PlayStore.Project.ViewModel.UserPage
{
    public class PersonalInformation
    {
        [Display(Name = "User name")]
        [Required]
        public string FullName { get; set; }

        [Display(Name = "Date of birth")]
        [Required]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "City")]
        [Required]
        [Range(1, 999999999, ErrorMessage = "City must be selected")]
        public long LocationParentID { get; set; }

        [Display(Name = "State")]
        [Range(1, 999999999, ErrorMessage = "State must be selected")]
        [Required]
        public long LocationID { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
    }
}
