using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgramTree;

namespace SimpleLang.Visitors
{
    public class ExprComplexityVisitor : AutoVisitor
    {
        public int comlexity = 0;
        List<int> comlexityList = new List<int>();

        // список должен содержать сложность каждого выражения, встреченного при обычном порядке обхода AST
        public List<int> getComplexityList()
        {
            return comlexityList;
        }

        public override void VisitAssignNode(AssignNode a)
        {
            comlexity = 0;
            a.Expr.Visit(this);
            comlexityList.Add(comlexity);
        }

        public override void VisitWriteNode(WriteNode w)
        {
            comlexity = 0;
            w.Expr.Visit(this);
            comlexityList.Add(comlexity);
        }

        public override void VisitCycleNode(CycleNode c)
        {
            comlexity = 0;
            c.Expr.Visit(this);
            comlexityList.Add(comlexity);

            c.Stat.Visit(this);
        }

        public override void VisitBinOpNode(BinOpNode binop)
        {

            binop.Left.Visit(this);
            binop.Right.Visit(this);
            switch (binop.Op)
            {
                case '+':
                    comlexity++;
                    break;
                case '-':
                    comlexity++;
                    break;
                case '*':
                    comlexity += 3;
                    break;
                case '/':
                    comlexity += 3;
                    break;

            }

        }

    }
}
