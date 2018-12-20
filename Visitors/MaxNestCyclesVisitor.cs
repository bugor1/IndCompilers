using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgramTree;

namespace SimpleLang.Visitors
{
    public class MaxNestCyclesVisitor : AutoVisitor
    {
        public int MaxNest = 0;
        int currentDeep = 0;

        public override void VisitCycleNode(CycleNode c)
        {
            currentDeep++;
            if (currentDeep > MaxNest)
                MaxNest = currentDeep;
            c.Stat.Visit(this);
            currentDeep--;
        }
    }
}
