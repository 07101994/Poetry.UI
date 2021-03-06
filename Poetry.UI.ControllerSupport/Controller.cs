﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poetry.UI.ControllerSupport
{
    /// <summary>
    /// Represents a Poetry.UI controller.
    /// 
    /// Note: Not to be inherited by your controller classes as they should be POCOs, annotated with the [Controller] attribute.
    /// </summary>
    public class Controller
    {
        public string Id { get; }
        public Type Type { get; }
        public IEnumerable<ControllerAction> Actions { get; }

        public Controller(string id, Type type, params ControllerAction[] actions)
        {
            Id = id;
            Type = type;
            Actions = actions.ToList().AsReadOnly();
        }
    }
}
