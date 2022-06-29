using MongoDB.Driver;
using MyLovelyDogsApi.Constants;
using MyLovelyDogsApi.Models;
using Newtonsoft.Json;

namespace MyLovelyDogsApi.Clients;

public class MyDogsClient
{
    private HttpClient _httpClient;
    private static string _address;
    private static string _apiKey;

    public MyDogsClient()
    {
        _address = Const.address;
        _apiKey = Const.apiKey;
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(_address);
    }


    public async Task<BreedModel> GETInfoByName(string Name)
    {
        try
        {
            var responce = await _httpClient.GetAsync($"/v1/breeds/search?q={Name}");
            var content = responce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<BreedModel>>(content);
            return result[0];
        }
        catch (Exception e)
        {
            return new BreedModel() {name = "Not found"};
            throw;
        }

    }

    public async Task<ImageModel> GETImageByName(string Name)
    {
        var image_id = GETInfoByName(Name).Result.reference_image_id;
        var responce = await _httpClient.GetAsync($"/v1/images/{image_id}");
        var content = responce.Content.ReadAsStringAsync().Result;
        var result = JsonConvert.DeserializeObject<ImageModel>(content);
        return result;
    }

    public async Task POSTFavTheImage(string Image_Id)
    {
        string connectionString = "mongodb://localhost:27017";
        string databaseName = "mylovelydogs_db";
        string collectionName = "favourites";
        var fav_1 = new FavouriteImageModel {Image = Image_Id};
        var client_db = new MongoClient(connectionString);
        var db = client_db.GetDatabase(databaseName);
        var collection_db = db.GetCollection<FavouriteImageModel>(collectionName);
        await collection_db.InsertOneAsync(fav_1);
    }

    public async Task DELETFavTheImage(string Image_Id)
    {
        string connectionString = "mongodb://localhost:27017";
        string databaseName = "mylovelydogs_db";
        string collectionName = "favourites";
        var fav_1 = new FavouriteImageModel {Image = Image_Id};
        var client_db = new MongoClient(connectionString);
        var db = client_db.GetDatabase(databaseName);
        var collection_db = db.GetCollection<FavouriteImageModel>(collectionName);
        var filter = Builders<FavouriteImageModel>.Filter.Eq("Image", Image_Id);
        await collection_db.DeleteOneAsync(filter);
    }

    public async Task<List<FavouriteImageModel>> GETAllFavImages()
    {
        string connectionString = "mongodb://localhost:27017";
        string databaseName = "mylovelydogs_db";
        string collectionName = "favourites";
        var client_db = new MongoClient(connectionString);
        var db = client_db.GetDatabase(databaseName);
        var collection_db = db.GetCollection<FavouriteImageModel>(collectionName);
        var result = await collection_db.FindAsync(_ => true);


        return result.ToList();
    }

    public async Task<ImageModel> GETUrlByImageId(string image_id)
    {
        var responce = await _httpClient.GetAsync($"/v1/images/{image_id}");
        var content = responce.Content.ReadAsStringAsync().Result;
        var result = JsonConvert.DeserializeObject<ImageModel>(content);
        return result;
    }
}