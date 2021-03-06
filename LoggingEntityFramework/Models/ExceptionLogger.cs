﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoggingEntityFramework.Models
{
    public class ExceptionLogger
    {
        [Key]
        public Guid Id { get; set; }
        public string ExceptionMessage { get; set; }
        public string ControllerName { get; set; }
        public string ExceptionStackTrace { get; set; }
        public DateTime LogTime { get; set; }

    }
}