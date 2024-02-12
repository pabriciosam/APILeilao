using Bogus;
using FluentAssertions;
using Leilao.API.Contracts;
using Leilao.API.Entities;
using Leilao.API.Enums;
using Leilao.API.UseCases.Leiloes.GetCurrent;
using Moq;
using Xunit;

namespace UseCases.Test.Leliloes.GetCurrent;
public class GetCurrenteLeilaoUseCaseTest
{
    [Fact]
    public void Success()
    {
        //ARRANGE
        //Comentário teste
        //Mais uma vez
        var auctionEntity = new Faker<Auction>()
            .RuleFor(a => a.Id, f => f.Random.Number(1, 10))
            .RuleFor(a => a.Name, f => f.Lorem.Word())
            .RuleFor(a => a.Starts, f => f.Date.Past())
            .RuleFor(a => a.Ends, f => f.Date.Future())
            .RuleFor(a => a.Items, (f, auction) => new List<ItemEntity>
            { 
                new ItemEntity
                {
                    Id = f.Random.Number(1, 700),
                    Name = f.Commerce.ProductName(),
                    Brand = f.Commerce.Department(),
                    Condition = f.PickRandom<Conditions>(),
                    AuctionId = auction.Id
                }
            }).Generate();

        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(auctionEntity);

        var useCase = new GetCurrenteLeilaoUseCase(mock.Object);
        
        //ACT
        var auction = useCase.Execute();

        //ASSERT
        auction.Should().NotBeNull();
        auction.Id.Should().Be(auctionEntity.Id);
        auction.Name.Should().Be(auctionEntity.Name);
    }
}
