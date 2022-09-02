using FluentAssertions;
using System.Linq;
using Xunit;

namespace Sales.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            var group = new SalesGroupBuilder()
                .Create("Design pattern in domain model")
                    .WithAgent(a => a.Create("A"))
                    .WithAgent(a => a.Create("B"))
                    .WithAgent(a => a.Create("c"))
                .Build();


            group.Should().NotBeNull();
            group.Units.Should().HaveCount(3);
        }

        [Fact]
        public void Test2()
        {
             var group = new SalesGroupBuilder()
                .Create("Design pattern in domain model")
                    .WithAgent(a => a.Create("A"))
                    .WithAgent(a => a.Create("B"))
                    .WithAgent(a => a.Create("c"))
                    .WithGroup(g=>g.Create("Active Guys")
                        .WithAgent(a=>a.Create("G-A"))
                        .WithAgent(a=>a.Create("G-B")))
                .Build();


            group.Should().NotBeNull();
            group.Units.Should().HaveCount(4);
            group.Units.Last().As<SalesGroup>().Units.Should().HaveCount(2);
        }

        [Fact]
        public void Test3()
        {
            var group = new SalesGroupBuilder()
              .Create("Design pattern in domain model")
                  .WithAgent(a => a.Create("A"))
                  .WithAgent(a => a.Create("B"))
              .Build();

            group.PayCommission(100);


            group.Units.First().As<SalesAgent>().Credit.Should().Be(50);
        }

         [Fact]
        public void Test4()
        {
             var group = new SalesGroupBuilder()
                .Create("Design pattern in domain model")
                    .WithAgent(a => a.Create("A"))
                    .WithGroup(g=>g.Create("Active Guys")
                        .WithAgent(a=>a.Create("G-A"))
                        .WithAgent(a=>a.Create("G-B")))
                .Build();

              group.PayCommission(100);

            group.Should().NotBeNull();
            group.Units.First().As<SalesAgent>().Credit.Should().Be(50);
            group.Units.Last().As<SalesGroup>().Units.Last().As<SalesAgent>().Credit.Should().Be(25);
        }
    }
}