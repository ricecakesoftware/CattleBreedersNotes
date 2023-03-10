using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiceCakeSoftware.CattleBreedersNotes.Commons;

namespace RiceCakeSoftware.CattleBreedersNotes.Api.Controllers;

[AutoValidateAntiforgeryToken]
[Route("api/cows")]
[ApiController]
public class CowsController : ControllerBase
{
    private static readonly Cow[] _cows = new Cow[]
    {
        new() { Id = "1234557890", Name = "いち", BirthDate = new(2022, 1, 1), },
        new() { Id = "2345678901", Name = "に", BirthDate = new(2022, 2, 2), },
    };

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet]
    public ActionResult Get()
    {
        return Ok(_cows);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("stats")]
    public ActionResult GetStats()
    {
        return Ok(new Dictionary<string, string>() { { "counts", $"{_cows.Count()}" }, });
    }
}
