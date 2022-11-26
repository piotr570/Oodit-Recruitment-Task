using System.ComponentModel.DataAnnotations;

namespace Oodit.Models
{
    public class InputForm
    {
        [RegularExpression(@"^\[(,?\d)*]$", ErrorMessage = "Error")]
        public string Value { get; set; }
    }
}
