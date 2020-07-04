using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gym.API.Resources
{

    public class SaveCardResource
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Period { get; set; }
        
        [Required]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Пожалуйста, введите верную цену.")]
        public decimal Price { get; set; }
    }
}