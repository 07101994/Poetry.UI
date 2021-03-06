﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Poetry.UI.TranslationSupport
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TranslationsAttribute : Attribute
    {
        public string Path { get; }

        public TranslationsAttribute(string path)
        {
            Path = path;
        }
    }
}
