using FluentAssertions;
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
      
        //[Fact]
        //public void Test2()
        //{
        //    var group = new SalesGroupBuilder()
        //        .Create("Design pattern in domain model")
        //            .WithAgent2(a => a.Create("A"))
        //            .WithAgent2(a => a.Create("B"))
        //        .Build();

        //    group.Should().NotBeNull();
        //    group.Units.Should().HaveCount(2);
        //}

        [Fact]
        public void Test3()
        {
            var group = new SalesGroupBuilder()
              .Create("Design pattern in domain model")
                  .WithAgent(a => a.Create("A"))
                  .WithAgent(a => a.Create("B"))
              .Build();

            group.PayCommission(100);


            (group.Units.First() as SalesAgent).Credit.Should().Equals(50);
        }
    }
}