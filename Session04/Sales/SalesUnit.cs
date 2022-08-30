using System;

namespace Sales
{
    public abstract class SalesUnit
    {
        public string Name { get; set; }
        public SalesUnit(string name)
        {
            Name = name;
        }
        public abstract void PayCommission(int amount);
    }
}
