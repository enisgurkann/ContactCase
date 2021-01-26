﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCase.ContactApi.Domain
{
    public class ContactInfo 
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }

        public string InfoType { get; set; }
        public string Value { get; set; }

    }
}
