using ProgramTree;


namespace SimpleLang.Visitors
{
    public class MaxIfCycleNestVisitor : AutoVisitor
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

        public override void VisitIfNode(IfNode w)
        {
            currentDeep++;
            if (currentDeep > MaxNest)
                MaxNest = currentDeep;
            w.Stat1.Visit(this);
            if (w.Stat2 != null)
                w.Stat2.Visit(this);
            currentDeep--;
        }
    }
}