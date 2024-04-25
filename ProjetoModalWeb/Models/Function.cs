using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjetoModalWeb.Models
{
    public class Function
    {
        [Key]
        public Guid FuncId { get; set; }

        [DisplayName("Function Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Required Name")]
        public string? FuncName { get; set; }

        [DisplayName("Function Description")]
        [StringLength(100)]
        [Required(ErrorMessage = "Required Name")]
        public string? FuncDescription { get; set; }

        [DisplayName("Function Date")]
        public DateTime FuncDataIn { get; set; } = DateTime.Now;

    }
}
