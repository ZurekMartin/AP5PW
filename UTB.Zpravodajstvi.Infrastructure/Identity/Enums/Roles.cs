﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.Zpravodajstvi.Infrastructure.Identity.Enums
{
    /// <summary>
    /// Enumeration for Roles in database (they must match)
    /// enum is not required but may be useful
    /// </summary>
    public enum Roles
    {
        Admin,
        Writer,
        Reader
    }
}
