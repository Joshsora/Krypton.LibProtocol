﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using Krypton.LibProtocol.Extensions;
using Krypton.LibProtocol.Member.Common;
using Krypton.LibProtocol.Member.Statement;
using Krypton.LibProtocol.Member.Type;

namespace Krypton.LibProtocol.Member.Declared.Type
{
    /// <summary>
    /// DeclaredTypeBase is an abstract class implemented by types declared inside a Library
    /// </summary>
    public abstract class TypeDeclarationBase : IMember, IStatementContainer, INameable, IDocumentable
    {   
        /// <summary>
        /// The name of the decalred type
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// The Parent of the declared type
        /// </summary>
        public IMemberContainer Parent { get; }
        
        /// <summary>
        /// The statements that compose the type
        /// </summary>
        public IEnumerable<IStatement> Statements { get; }

        public Documentation Documentation { get; private set; }
        
        private readonly IList<IStatement> _statements = new List<IStatement>();

        protected TypeDeclarationBase(string name, IMemberContainer parent)
        {
            Name = name;
            Parent = parent;
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
