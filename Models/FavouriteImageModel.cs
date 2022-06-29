using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyLovelyDogsApi.Models;


public class FavouriteImageModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    public string Id { get; set; }
    public string Image { get; set; }

}