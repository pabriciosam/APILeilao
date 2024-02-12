using Leilao.API.Entities;

namespace Leilao.API.Contracts;

public interface IOfferRepository
{
    public void Add(Offer offer);
}
