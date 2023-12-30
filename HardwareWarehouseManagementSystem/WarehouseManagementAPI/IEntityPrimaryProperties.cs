﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementAPI
{
    public interface IEntityPrimaryProperties
    {
        int Id { get; set; }

        string Name { get; set; }

        string Type { get; set; }
    }
}
