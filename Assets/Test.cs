using UnityEngine;

public class Test : MonoBehaviour
{
    public int Score = 100;


    void OnGUI()
    {
        if (GUI.Button(new Rect(0f, 0f, Screen.width / 2f, Screen.height / 2f), "Post Facebook"))
        {
            Social.FacebookManager.Share("My new recod is: " + Score, "This is my new record", "This is a good game");
        }
        if (GUI.Button(new Rect(Screen.width / 2f, 0f, Screen.width / 2f, Screen.height / 2f), "Post Twitter"))
        {
            Social.TwitterManager.Share("My new recod is: " + Score + " in RingFever", _forceWeb: true);
        }
        if (GUI.Button(new Rect(0f, Screen.height / 2f, Screen.width/2, Screen.height / 2f), "Like Game"))
        {
            Social.FacebookManager.LikeGame(true);
        }
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2f, Screen.width / 2, Screen.height / 2f), "Follow Game"))
        {
            Social.TwitterManager.FollowTwitter();
        }
    }
}