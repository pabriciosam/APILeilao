using Leilao.API.Contracts;
using Leilao.API.Entities;

namespace Leilao.API.UseCases.Leiloes.GetCurrent;

public class GetCurrenteLeilaoUseCase
{
    private readonly IAuctionRepository _repository;

    public GetCurrenteLeilaoUseCase(IAuctionRepository repository) => _repository = repository;

    public Auction? Execute()
    {
        return _repository.GetCurrent();
    }
}