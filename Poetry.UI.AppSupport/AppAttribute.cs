﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poetry.UI.AppSupport
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AppAttribute : Attribute {
        public string Id { get; }

        public AppAttribute(string id)
        {
            Id = id;
        }
    }
}
