using FluentAssertions;
using System.Linq;
using Xunit;

namespace Sales.Test
{
    public class GroupBuilderTests
    {
        [Fact]
        public void Create_group_with_agents()
        {
            //arrange & act
            var group = new SalesGroupBuilder()
                .Create("Design pattern in domain model")
                    .WithAgent(a => a.Create("A"))
                    .WithAgent(a => a.Create("B"))
                    .WithAgent(a => a.Create("c"))
                .Build();

            //assert
            group.Should().NotBeNull();
            group.Units.Should().HaveCount(3);
        }

        [Fact]
        public void Create_group_with_nested_group_and_agents()
        {
            //arrange & act
            var group = new SalesGroupBuilder()
               .Create("Design pattern in domain model")
                   .WithAgent(a => a.Create("A"))
                   .WithAgent(a => a.Create("B"))
                   .WithAgent(a => a.Create("c"))
                   .WithGroup(g => g.Create("Active Guys")
                       .WithAgent(a => a.Create("G-A"))
                       .WithAgent(a => a.Create("G-B")))
               .Build();

            //assert
            group.Should().NotBeNull();
            group.Units.Should().HaveCount(4);
            group.Units.Last().As<SalesGroup>().Units.Should().HaveCount(2);
        }

        [Fact]
        public void Group_commission_should_be_equal()
        {
            //arrange
            var group = new SalesGroupBuilder()
              .Create("Design pattern in domain model")
                  .WithAgent(a => a.Create("A"))
                  .WithAgent(a => a.Create("B"))
              .Build();

            // act
            group.PayCommission(100);

            //assert
            group.Units.First().As<SalesAgent>().Credit.Should().Be(50);
        }

        [Fact]
        public void Complex_group_commission_should_be_equal()
        {
            //arrange
            var group = new SalesGroupBuilder()
               .Create("Design pattern in domain model")
                   .WithAgent(a => a.Create("A"))
                   .WithGroup(g => g.Create("Active Guys")
                       .WithAgent(a => a.Create("G-A"))
                       .WithAgent(a => a.Create("G-B")))
               .Build();

            // act
            group.PayCommission(100);

            //assert
            group.Should().NotBeNull();
            group.Units.First().As<SalesAgent>().Credit.Should().Be(50);
            group.Units.Last().As<SalesGroup>().Units.Last().As<SalesAgent>().Credit.Should().Be(25);
        }
    }
}