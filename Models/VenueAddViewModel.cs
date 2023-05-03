using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2022A1DS.Models
{
    public class VenueAddViewModel
    {
        public VenueAddViewModel()
        {
            // Initializing OpenDate to be currentDate - 22 years
            OpenDate = DateTime.Now.AddYears(-22);
        }

        [Required]
        [StringLength(80)]
        public string Company { get; set; }

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

        [DataType(DataType.EmailAddress)]
        [StringLength(60)]
        public string Email { get; set; }

        [DataType(DataType.Url)]
        [StringLength(60)]
        public string Website { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Opened")]
        public DateTime? OpenDate { get; set; }
    }
}