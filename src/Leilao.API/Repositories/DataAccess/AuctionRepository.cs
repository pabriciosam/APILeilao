using Leilao.API.Contracts;
using Leilao.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Leilao.API.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
    private readonly LeilaoDbContext _dbContext;
    public AuctionRepository(LeilaoDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent()
    {
        var data = Convert.ToDateTime("01/21/2024 00:00:00");

        return _dbContext
            .Auctions
            .Include(le => le.Items)
            .FirstOrDefault(le => data >= le.Starts && data <= le.Ends);
    }
}