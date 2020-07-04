using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gym.API.Resources
{

    public class SaveScheduleTrainingResource
    {
        public int IdTrainer { get; set; }

        public string RoomName { get; set; }

        public DateTimeOffset TrainingDateFrom { get; set; }

        public DateTimeOffset TrainingDateTo { get; set; }

        public string IdSpecializationName { get; set; }

        [Required]
        [MaxLength(150)]
        public string Type { get; set; }

        public int Roominess { get; set; }

        public int Engaged { get; set; }

        public bool RecordIsClosed { get; set; }
    }

}