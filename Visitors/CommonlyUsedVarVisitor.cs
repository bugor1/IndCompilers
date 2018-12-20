using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgramTree;

namespace SimpleLang.Visitors
{
    public class CommonlyUsedVarVisitor : AutoVisitor
    {
        Dictionary<string, int> used = new Dictionary<string, int>();

        public string mostCommonlyUsedVar()
        {
            int max = 0;
            string result = "";
            //throw new NotImplementedException();
            foreach (var el in used)
            {
                if (el.Value > max)
                {
                    max = el.Value;
                    result = el.Key;
                }
            }

            return result;
        }

        public override void VisitAssignNode(AssignNode a)
        {
            a.Id.Visit(this);
            a.Expr.Visit(this);
        }

        public override void VisitWriteNode(WriteNode w)
        {
            w.Expr.Visit(this);
        }

        public override void VisitVarDefNode(VarDefNode w)
        {
            foreach (var v in w.vars)
                v.Visit(this);
        }

        public override void VisitIdNode(IdNode id)
        {
            if (used.Keys.Contains(id.Name))
            {
                used[id.Name]++;
            }
            else
            {
                used.Add(id.Name, 1);
            }

        }

        

    }
}
