using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

public class UserData : MonoBehaviour
{
    public TextMeshProUGUI ApiResponseDisplay;
    public TMPro.TMP_InputField UserIdInput;

    public void GetUserData()
    {
        if (string.IsNullOrWhiteSpace(UserIdInput.text))
        {
            string errorMessage = "User ID cannot be empty!";
            Debug.LogWarning(errorMessage);
            ApiResponseDisplay.text = errorMessage;
            return;
        }

        int userId;
        if (!int.TryParse(UserIdInput.text, out userId))
        {
            string errorMessage = "Invalid User ID! Please enter a valid number.";
            Debug.LogWarning(errorMessage);
            ApiResponseDisplay.text = errorMessage;
            return;
        }

        StartCoroutine(GetUserDataCoroutine(userId));
    }


    public void GetUserPosts()
    {
        if (string.IsNullOrWhiteSpace(UserIdInput.text))
        {
            string errorMessage = "User ID cannot be empty!";
            Debug.LogWarning(errorMessage);
            ApiResponseDisplay.text = errorMessage;
            return;
        }

        int userId;
        if (!int.TryParse(UserIdInput.text, out userId))
        {
            string errorMessage = "Invalid User ID! Please enter a valid number.";
            Debug.LogWarning(errorMessage);
            ApiResponseDisplay.text = errorMessage;
            return;
        }

        StartCoroutine(GetUserPostsCoroutine(userId));
    }


    private IEnumerator GetUserDataCoroutine(int userId)
    {
        Task<Users> task = ApiHelper.GetUserDataByIdAsync(userId);
        yield return new WaitUntil(() => task.IsCompleted);

        if (task.Exception != null)
        {
            string errorMessage = "Error retrieving user data: " + task.Exception.Message;
            Debug.LogError(errorMessage);
            ApiResponseDisplay.text = errorMessage;
        }
        else if (task.Result == null)
        {
            string errorMessage = "Error: No user data returned from the server.";
            Debug.LogError(errorMessage);
            ApiResponseDisplay.text = errorMessage;
        }
        else
        {
            Users user = task.Result;
            ApiResponseDisplay.text = $"Name: {user.name}\nEmail: {user.email}\nAddress: {user.address}";
        }
    }

    private IEnumerator GetUserPostsCoroutine(int userId)
    {
        Task<List<UserPosts>> postsTask = ApiHelper.GetUserPostsAsync(userId);
        yield return new WaitUntil(() => postsTask.IsCompleted);

        if (postsTask.Exception != null)
        {
            string errorMessage = $"Error retrieving posts: {postsTask.Exception.Message}";
            Debug.LogError(errorMessage);
            ApiResponseDisplay.text = errorMessage;
        }
        else if (postsTask.Result == null || postsTask.Result.Count == 0)
        {
            string errorMessage = "No posts found for this user.";
            Debug.LogWarning(errorMessage);
            ApiResponseDisplay.text = errorMessage;
        }
        else
        {
            List<UserPosts> userPosts = postsTask.Result;
            ApiResponseDisplay.text = "User Posts:\n";
            foreach (var post in userPosts)
            {
                ApiResponseDisplay.text += $"Post ID: {post.id}\nContent: {post.postContent}\n\n";
            }
        }
    }
}
