﻿namespace Krypton.LibProtocol.Member.Type
{
    public class GenericAttributeReference : TypeReference
    {
        public override string Name { get; internal set; }
        
        public override string TemplateAlias => "generic_attribute_reference";
    }
}