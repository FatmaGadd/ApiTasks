﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Day1.Models
{
    public partial class Course
    {
        [Key]
        public int CrsId { get; set; }
        [Required]
        public string CrsName { get; set; }
        public int Duration { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string description { get; set; }
    }
}