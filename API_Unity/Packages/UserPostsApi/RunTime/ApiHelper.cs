using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;
using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json;

public static class ApiHelper
{
    public static async Task<Users> GetUserDataByIdAsync(int id)
    {
        string url = $"https://localhost:7053/api/users/{id}";

        UnityWebRequest request = UnityWebRequest.Get(url);
        await request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;

            Users response = JsonUtility.FromJson<Users>(json);
            return response;
        }
        else
        {
            Debug.LogError("Request failed: " + request.error);
            return null;
        }
    }

    public static async Task<List<UserPosts>> GetUserPostsAsync(int userId)
    {
        UnityWebRequest request = UnityWebRequest.Get($"https://localhost:7053/api/users/{userId}/posts");
        await request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            return JsonConvert.DeserializeObject<List<UserPosts>>(request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Error: " + request.error);
            return null;
        }
    }
}

