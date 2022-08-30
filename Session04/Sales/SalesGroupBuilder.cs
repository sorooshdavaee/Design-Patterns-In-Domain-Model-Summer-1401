using System;
using System.Collections.Generic;

namespace Sales
{
    public class SalesGroupBuilder
    {
        private string _name;
        private SalesGroup _group;
        private SalesAgentBuilder _agentBuilder;
        private List<SalesUnit> _subs;

        public SalesGroupBuilder Create(string name)
        {
            _name = name;
            _agentBuilder = new SalesAgentBuilder();
            _subs = new List<SalesUnit>();

            //_group = new SalesGroup(name);
            return this;
        }

        public SalesGroupBuilder WithAgent(Action<SalesAgentBuilder> configuration)
        {
            configuration.Invoke(_agentBuilder);
            _subs.Add(_agentBuilder.Build());
            return this;
        }
        //public SalesGroupBuilder WithAgent2(Action<SalesAgentBuilder> configuration)
        //{
        //    configuration.Invoke(_agentBuilder);
        //    _group.Units.Add(_agentBuilder.Build());
        //    return this;
        //}
        public SalesGroupBuilder WithAgent(SalesAgent item)
        {
            _group.Units.Add(item);
            return this;
        }


        public SalesGroup Build()
        {
            _group = new SalesGroup(_name, _subs);
            return _group;
        }


    }
}