using System.Collections.Generic;
using System.Linq;

namespace Sales
{
    public class SalesGroup : SalesUnit
    {
        public List<SalesUnit> Units { get; private set; }
        public SalesGroup(string name, List<SalesUnit> units)
            : base(name)
        {
            Units = units;
        }
        public SalesGroup(string name, params SalesUnit[] units) : this(name,units?.ToList()) { }
        public override void PayCommission(int amount)
        {
            var eachShare = amount / Units.Count;
            foreach (var salesUnit in Units)
                salesUnit.PayCommission(eachShare);
        }
    }
}