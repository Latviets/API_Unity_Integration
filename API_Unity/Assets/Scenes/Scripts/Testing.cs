//using System.Collections;
//using UnityEngine;
//using UnityEngine.Networking;
//using UnityEngine.UI;
//public class GetApiData : MonoBehaviour
//{
//    public string URL;
//    public InputField id;
//    public GameObject playerStatusPanel;
//    public async void GetData()
//    {
//        if (string.IsNullOrWhiteSpace(id.text))
//        {
//            Debug.LogWarning("User ID cannot be empty!");
//            return;
//        }

//        ApiResponse user = await ApiHelper.GetUserDataByIdAsync(int.Parse(id.text));
//        if (user != null)
//        {
//            playerStatusPanel.transform.GetChild(0).GetComponent<Text>().text = "Name: " + user.name;
//            playerStatusPanel.transform.GetChild(1).GetComponent<Text>().text = "Email: " + user.email;
//            playerStatusPanel.transform.GetChild(2).GetComponent<Text>().text = "Address: " + user.address;
//        }
//        else
//        {
//            Debug.LogError("Failed to fetch user data.");
//        }
//    }

//    public IEnumerator FetchData()
//    {
//        using (UnityWebRequest request = UnityWebRequest.Get(URL + id.text))
//        {
//            yield return request.SendWebRequest();

//            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
//            {
//                Debug.LogError(request.error);
//            }
//            else
//            {
//                // Deserialize the JSON response to the ApiResponse class
//                ApiResponse user = JsonUtility.FromJson<ApiResponse>(request.downloadHandler.text);

//                // Update the panel with user data
//                playerStatusPanel.transform.GetChild(0).GetComponent<Text>().text = "Name: " + user.name;
//                playerStatusPanel.transform.GetChild(1).GetComponent<Text>().text = "Email: " + user.email;
//                playerStatusPanel.transform.GetChild(2).GetComponent<Text>().text = "Address: " + user.address;
//            }
//        }
//    }
//}