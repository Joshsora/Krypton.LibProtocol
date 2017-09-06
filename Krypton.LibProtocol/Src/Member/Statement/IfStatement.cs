﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using Krypton.LibProtocol.Member.Expression;
using Krypton.LibProtocol.Target;

namespace Krypton.LibProtocol.Member.Statement
{
    public class IfStatement : IExpressiveStatementContainer, IStatement, ITemplateType
    {
        public string TemplateName => "if_statement";
        
        public IStatementContainer Parent { get; }
        
        public IEnumerable<IStatement> Statements { get; }
        
        private IList<IStatement> _statements = new List<IStatement>();

        public IList<IExpression> Expressions { get; }

        private IList<IExpression> _expressions = new List<IExpression>();
        
        public IfStatement(IStatementContainer parent)
        {
            Parent = parent;
            
            Statements = new ReadOnlyCollection<IStatement>(_statements);
            Expression = new ReadOnlyCollection<IExpression>(_expressions);
        }

        public void AddStatement(IStatement statement)
        {
            _statements.Add(statement);
        }

        
        public void AddExpresion(IExpression expression)
        {
            _expressions.Add(expression);
        }
    }
}
