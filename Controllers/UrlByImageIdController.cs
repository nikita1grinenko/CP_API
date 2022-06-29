using Microsoft.AspNetCore.Mvc;
using MyLovelyDogsApi.Clients;
using MyLovelyDogsApi.Models;

namespace MyLovelyDogsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UrlByImageIdController : ControllerBase
{
    [HttpGet(Name = "UrlByName")]
    public ImageModel  Name(string image_id)
    {
        MyDogsClient Client_1 = new MyDogsClient();
        return Client_1.GETUrlByImageId(image_id).Result;
    }
}