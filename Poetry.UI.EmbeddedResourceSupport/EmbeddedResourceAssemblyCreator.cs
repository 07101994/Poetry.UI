﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Poetry.UI.EmbeddedResourceSupport
{
    public class EmbeddedResourceAssemblyCreator : IEmbeddedResourceAssemblyCreator
    {
        IEmbeddedResourcePathGenerator EmbeddedResourcePathGenerator { get; }

        public EmbeddedResourceAssemblyCreator(IEmbeddedResourcePathGenerator embeddedResourcePathConverter)
        {
            EmbeddedResourcePathGenerator = embeddedResourcePathConverter;
        }

        public EmbeddedResourceAssembly Create(string basePath, Assembly assembly)
        {
            var assemblyName = assembly.GetName().Name;

            return new EmbeddedResourceAssembly(basePath, assembly.GetManifestResourceNames().Select(resourceName => new EmbeddedResource(EmbeddedResourcePathGenerator.GeneratePath(resourceName.Substring(assemblyName.Length + ".".Length)), () => assembly.GetManifestResourceStream(resourceName))).ToArray());
        }
    }
}
