using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RiceCakeSoftware.CattleBreedersNotes.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace RiceCakeSoftware.CattleBreedersNotes.Api.Controllers;

[AutoValidateAntiforgeryToken]
[Route("api/sessions")]
[ApiController]
public class SessionsController : ControllerBase
{
    private readonly AppSettings _appSettings;

    public SessionsController(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    [HttpGet]
    public ActionResult Get()
    {
        if (Request.Headers.ContainsKey("access_token") &&
            Request.Headers["access_token"].First() == _appSettings.AccessToken)
        {
            return Ok();
        }
        else
        {
            return Forbid();
        }
    }

    [HttpPost]
    public ActionResult Post([FromBody] PostRequest request)
    {
        if (request.Email == "xxxxxxxx@xxxxxxxx.xxx" && request.Password == string.Join(string.Empty, SHA256.HashData(Encoding.UTF8.GetBytes("xxxxxxxx")).Select(x => $"{x:x2}")))
        {
            return Ok(new Dictionary<string, string>() { { "token", BuildToken() }, });
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpDelete]
    public ActionResult Delete()
    {
        return Ok();
    }

    private string BuildToken()
    {
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_appSettings.SigningKey));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
        JwtSecurityToken token = new(_appSettings.Issuer, _appSettings.Audience, null, null, DateTime.Now.AddDays(1), credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public class PostRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
