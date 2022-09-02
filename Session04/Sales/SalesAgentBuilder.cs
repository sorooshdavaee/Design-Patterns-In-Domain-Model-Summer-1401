using System;

namespace Sales
{
    public class SalesAgentBuilder
    {
        private SalesAgent _salesAgent;
        public SalesAgent Build()
        {
            return _salesAgent;
        }

        public SalesAgentBuilder Create(string name)
        {
            _salesAgent = new SalesAgent(name);
            return this;
        }

        ///more action 
        // public SalesAgentBuilder DoSomething(type param)
        //{
        //    _salesAgent.Param=param;
        //    return this;
        //}

        public SalesAgent Instansiate(string name)
        {
            return new SalesAgent(name);
        }
    }
}