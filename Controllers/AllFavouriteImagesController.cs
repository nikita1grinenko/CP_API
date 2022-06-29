using Microsoft.AspNetCore.Mvc;
using MyLovelyDogsApi.Clients;
using MyLovelyDogsApi.Models;

namespace MyLovelyDogsApi.Controllers;


[ApiController]
[Route("[controller]")]
public class AllFavouriteImagesController : ControllerBase
{
    [HttpGet(Name = "AllFavImages")]
    public List<FavouriteImageModel> Name()
    {
        MyDogsClient Client_5 = new MyDogsClient();
        return Client_5.GETAllFavImages().Result;
    }
}