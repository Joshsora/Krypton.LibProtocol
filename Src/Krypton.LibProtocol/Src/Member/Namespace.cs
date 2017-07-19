﻿using Krypton.LibProtocol.Member.Common;

namespace Krypton.LibProtocol.Member
{
    public class Namespace : NestedMemberContainer, IMember, ICustomizable
    {
        /// <summary>
        /// The target output namespace
        /// </summary>
        [Option("namespace")]
        public string TargetNamespace { get; internal set; }

        /// <summary>
        /// The alias used to reference the Namespace inside the KPDL
        /// </summary>
        public string Name { get; }
        
        internal Namespace(string name, IMemberContainer parent) : base(parent)
        {
            Name = name;
        }
    }
}
