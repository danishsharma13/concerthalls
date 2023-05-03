using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2022A1DS.Models
{
    public class VenueEditViewModel
    {
        [Key]
        public int VenueId { get; set; }

        [StringLength(70)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(10)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [StringLength(60)]
        public string Email { get; set; }

        [StringLength(60)]
        public string Website { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Open Date")]
        public DateTime? OpenDate { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Sign-up Password")]
        public string Password { get; set; }

        [StringLength(5)]
        [RegularExpression("[0-9]{3}[A-Z]{2}", ErrorMessage = "Please instead correct format. Example: 123XY")]
        public string PromoCode { get; set; }

        [Range(1, 40000, ErrorMessage = "The range is between 1 to 40,000")]
        public int Capacity { get; set; }
    }
}