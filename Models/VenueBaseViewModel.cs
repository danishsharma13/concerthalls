﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace F2022A1DS.Models
{
    public class VenueBaseViewModel : VenueAddViewModel
    {
        [Key]
        public int VenueId { get; set; }
    }
}