﻿using System.Collections.Generic;

namespace Krypton.LibProtocol.Member.Type
{
    public enum GenericPrimitive
    {
        Array
    }
    
    public class GenericPrimitiveTypeReference : PrimitiveTypeReference<GenericPrimitive>, ITypeContainer
    {
        public IList<TypeReference> Generics { get; }
        
        public GenericPrimitiveTypeReference()
        {
            Generics = new List<TypeReference>();
        }

        public void AcquireTypeReference(TypeReference reference)
        {
            Generics.Add(reference);
        }
        
        public override string TemplateAlias => "generic_primitive_type_reference";
    }
}