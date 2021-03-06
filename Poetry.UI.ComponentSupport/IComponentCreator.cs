﻿using System;
using System.Collections.Generic;

namespace Poetry.UI.ComponentSupport
{
    public interface IComponentCreator
    {
        IEnumerable<Component> Create();
    }
}