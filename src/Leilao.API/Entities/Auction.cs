namespace Leilao.API.Entities;

//A entidade precisa ter o mesmo nome da tabela no banco
public class Auction
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Starts { get; set; }
    public DateTime Ends { get; set; }
    public List<ItemEntity> Items { get; set; } = [];
}