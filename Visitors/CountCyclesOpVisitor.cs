using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgramTree;

namespace SimpleLang.Visitors
{
    public class CountCyclesOpVisitor : AutoVisitor
    {
        int Count = 0;
        int Cycles = 0;
        bool isCycle = false;
        public int MidCount()
        {
            if (Cycles == 0)
                return 0;
            return Count / Cycles;
            
        }

        public override void VisitCycleNode(CycleNode c)
        {
            isCycle = true;
            Cycles += 1;
            c.Stat.Visit(this);
            isCycle = false;

        }

        public override void VisitAssignNode(AssignNode a)
        {
            if (isCycle)
                Count += 1;
        }
    }
}
