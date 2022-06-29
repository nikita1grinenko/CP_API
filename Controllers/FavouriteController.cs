using Microsoft.AspNetCore.Mvc;
using MyLovelyDogsApi.Clients;

namespace MyLovelyDogsApi.Controllers;

[ApiController]
[Route("[controller]")]

public class FavouriteController : ControllerBase
{
    [HttpPost(Name = "FavTheDog")]
    public string Name(string Image_Id)
    {
        MyDogsClient Client_3 = new MyDogsClient();
        Client_3.POSTFavTheImage(Image_Id);
        return $"{Image_Id} is added to favourite";
    }
}