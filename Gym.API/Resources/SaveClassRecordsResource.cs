using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gym.API.Resources
{

    public class SaveClassRecordsResource
    {
        [Required]
        [MaxLength(150)]
        public string TrainingName { get; set; }

        [Required]
        [MaxLength(150)]
        public string ClientName { get; set; }
    }
}