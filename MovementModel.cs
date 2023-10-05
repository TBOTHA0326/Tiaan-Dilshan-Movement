using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniProjectDHL.Models
{
    public class MovementModel
    {
        [Required]
        [StringLength(3)]
        [RegularExpression("^[A-Z]{3}$", ErrorMessage = " Please enter 3 capital letters")]
        public string OriginStation { get; set; }

        [Required]
        [StringLength(3)]
        [RegularExpression("^[A-Z]{3}$", ErrorMessage = " Please enter 3 capital letters")]
        public string DestinationStation { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 5, ErrorMessage = "Please enter 5 to 8 alphanumeric characters")]
        [RegularExpression("^[a-zA-Z0-9]{5,8}$", ErrorMessage = "Only alphanumeric characters are allowed")]
        public string MovementName { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MovementDate { get; set; }

    }
}