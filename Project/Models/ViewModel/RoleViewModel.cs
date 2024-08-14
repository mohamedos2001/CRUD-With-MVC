using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModel
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
