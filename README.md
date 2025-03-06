# Unity Project: API Integration Example

This Unity project demonstrates how to integrate an external Web API into a Unity application using an SDK library. It fetches and displays user data and user posts dynamically on the game screen.
Project developed using Unity's Universal 2D pipeline.
Backend API developed with ASP.NET Web API.

## Features
- Integration with a RESTful Web API.
- Fetches user data (name, email, and address).
- Fetches user posts associated with a specific user.
- Displays all fetched information directly on the game screen using Unity's text elements.
- Error handling for invalid input or server failures.

## Requirements
- Unity 2021.3 or newer (supporting Universal 2D projects).
- TextMeshPro package included in the project.
- ASP.NET Web API to provide the backend data for user details and posts.

## How to Run the Project
1. Clone the repository:
   
2. Open the project in Unity Editor (ensure you're using the compatible version mentioned above).

3. Play the scene:

- Make sure the backend API service is running locally or accessible via the configured API URL in the SDK.
- Enter a valid user ID in the Unity Inspector (or use the hardcoded ID in the script).

## SDK Integration
- This project uses the ApiHelper SDK library to manage all Web API calls. The SDK is included as part of the Packages/ directory in the project.

## SDK Features:
- GetUserDataByIdAsync: Fetches user details by user ID.
- GetUserPostsAsync: Fetches posts for a specific user by user ID.
## Error Handling
- Invalid or Missing Input: Displays an error message on the game screen and logs it in the console.
- Server Errors or Invalid Responses: Displays an error message and handles null or invalid API responses gracefully.

