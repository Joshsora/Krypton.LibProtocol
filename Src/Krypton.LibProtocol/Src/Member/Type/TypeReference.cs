﻿using Krypton.LibProtocol.Extensions;

namespace Krypton.LibProtocol.Member.Type
{
    public abstract class TypeReference
    {
        public abstract string Name { get; internal set; }
        public string CamelCaseName => Name.ToCamelCase();
        
        public abstract string TemplateAlias { get; }
    }
}