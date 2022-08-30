namespace Sales
{
    public class SalesAgent : SalesUnit
    {
        public int Credit { get; private set; }

        public SalesAgent(string name) : base(name)
        {
        }

        public override void PayCommission(int amount)
        {
            this.Credit += amount;
        }
    }
}