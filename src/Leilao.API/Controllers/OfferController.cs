using Leilao.API.Comunication.Requests;
using Leilao.API.Filters;
using Leilao.API.UseCases.Offers.CreateOffer;
using Microsoft.AspNetCore.Mvc;

namespace Leilao.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : RocktseatLeilaoBaseController
{

    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer(
        [FromRoute] int itemId,
        [FromBody] RequestCreateOfferJson request,
        [FromServices] CreateOfferUseCase useCare)
    {
        var id = useCare.Execute(itemId, request);

        return Created(string.Empty, id);
    }
}