using System;
using System.Collections.Generic;

namespace AssetManagementSystem
{
    public abstract class Asset
    {
        public int SerialNumber { get; set; }
        public string Name { get; set; }
    }
}