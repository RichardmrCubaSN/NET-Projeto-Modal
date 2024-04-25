using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjetoModalWeb.Models
{
    public class Departament
    {

        [Key]
        public Guid DeptId { get; set; }

        [DisplayName("Departament Name")]
        [Required(ErrorMessage = "Required Name")]
        public string? DeptName { get; set; }

        [DisplayName("Departament Chef")]
        [Required(ErrorMessage = "Required Chef")]
        public string? DeptChef { get; set; }

        [DisplayName("Departament Sub Chef")]
        [Required(ErrorMessage = "Required Sub Chef")]
        public string? DeptSChef { get; set; }

        [DisplayName("Departament Date")]
        public DateTime DeptDataIn { get; set; } = DateTime.Now;

    }
}
