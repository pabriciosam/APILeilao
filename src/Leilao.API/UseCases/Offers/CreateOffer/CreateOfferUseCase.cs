using Leilao.API.Comunication.Requests;
using Leilao.API.Contracts;
using Leilao.API.Entities;
using Leilao.API.Services;

namespace Leilao.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly ILoggerUser _loggerUser;
    private readonly IOfferRepository _repository;

    public CreateOfferUseCase(ILoggerUser loggerUser, IOfferRepository repository)
    {
         _loggerUser = loggerUser;
        _repository = repository;
    }
    
    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        var user = _loggerUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id
        };

        _repository.Add(offer);

        return offer.Id;
    }
}
