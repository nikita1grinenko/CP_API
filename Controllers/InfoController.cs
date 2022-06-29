using Microsoft.AspNetCore.Mvc;
using MyLovelyDogsApi.Clients;
using MyLovelyDogsApi.Models;

namespace MyLovelyDogsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class InfoController : ControllerBase
{
    [HttpGet(Name = "InfoByName")]
    public BreedModel Name(string Name)
    {
        MyDogsClient Client_1 = new MyDogsClient();
        return Client_1.GETInfoByName(Name).Result;
    }
}