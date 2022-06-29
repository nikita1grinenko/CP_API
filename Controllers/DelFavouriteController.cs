using Microsoft.AspNetCore.Mvc;
using MyLovelyDogsApi.Clients;

namespace MyLovelyDogsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DelFavouriteController : ControllerBase
{
    [HttpDelete(Name = "DelFavTheDog")]
    public string Name(string Image_Id)
    {
        MyDogsClient Client_4 = new MyDogsClient();
        Client_4.DELETFavTheImage(Image_Id);
        return $"{Image_Id} is deleted from favourite";
    }
}