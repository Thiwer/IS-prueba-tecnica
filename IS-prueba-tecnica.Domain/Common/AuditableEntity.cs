﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Domain.Common
{
    public class AuditableEntity
    {
        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
