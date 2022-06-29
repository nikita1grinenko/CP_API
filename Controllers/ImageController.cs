using Microsoft.AspNetCore.Mvc;
using MyLovelyDogsApi.Clients;
using MyLovelyDogsApi.Models;

namespace MyLovelyDogsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : ControllerBase
{
    [HttpGet(Name = "ImageByName")]
    public ImageModel Name(string Name)
    {
        MyDogsClient Client_2 = new MyDogsClient();
        return Client_2.GETImageByName(Name).Result;
    }
}