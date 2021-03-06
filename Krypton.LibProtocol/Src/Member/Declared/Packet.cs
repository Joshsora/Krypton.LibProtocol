﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using Krypton.LibProtocol.Member.Common;
using Krypton.LibProtocol.Member.Statement;
using Krypton.LibProtocol.Target;

namespace Krypton.LibProtocol.Member.Declared
{
    public class Packet : NestedMemberContainer, IMember, IStatementContainer, ICustomizable, ITemplateType, INameable, IDocumentable
    {
        public string TemplateName => "packet";
        
        /// <summary>
        /// The target output namespace
        /// </summary>
        [Option("namespace")]
        public string Namespace { get; set; }
        
        public string Name { get; }

        public Documentation Documentation { get; private set; }

        public bool SubPacket => MemberList.Count != 0;
        
        public IEnumerable<IStatement> Statements { get; }
        private readonly IList<IStatement> _statements = new List<IStatement>();
        
        public Packet(string name, IMemberContainer parent) : base(parent)
        {
            Name = name;
            Statements = new ReadOnlyCollection<IStatement>(_statements);
        }

        public void AddStatement(IStatement statement)
        {
            _statements.Add(statement);
        }
        
        public void SetDocumentation(Documentation documentation)
        {
            Documentation = documentation;
        }
    }
}
