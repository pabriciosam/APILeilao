using Bogus;
using FluentAssertions;
using Leilao.API.Comunication.Requests;
using Leilao.API.Contracts;
using Leilao.API.Entities;
using Leilao.API.Services;
using Leilao.API.UseCases.Offers.CreateOffer;
using Moq;
using Xunit;

namespace UseCases.Test.Offer.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        //ARRANGE
        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(o => o.Price, f => f.Random.Decimal(1, 700)).Generate();

        var offerRepository = new Mock<IOfferRepository>();
        var loggerUser = new Mock<ILoggerUser>();
        loggerUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggerUser.Object, offerRepository.Object);

        //ACT
        var act = () => useCase.Execute(itemId, request);

        //ASSERT
        act.Should().NotThrow();
    }
}
