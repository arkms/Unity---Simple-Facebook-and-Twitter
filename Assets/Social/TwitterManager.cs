using UnityEngine;
using System.Collections;

namespace Social
{
    public static class TwitterManager
    {
        //Name of game
        const string GameName = "RingFever";
        //URL of Game
        const string URLGame = "www.google.com";
        //ID in Twitter -- for use in FollowTwitter()
        const string IDTwitter = "ARKMs0";

        /// <summary>
        /// Post in Wtitter
        /// </summary>
        /// <param name="_text">Text to post //limit 140 characters</param>
        /// <param name="_addInfo">Add name and link of the game</param>
        /// <param name="_HashGame">HashTag of Game if have one</param>
        /// <param name="_forceWeb">Use native Twiiter or force use web</param>
        /// <param name="lang">lenguage in twitter,, //Only for web version</param>
        public static void Share(string _text, bool _addInfo= false, string _HashGame="", bool _forceWeb = false, string lang = "en")
        {
            if (_addInfo)
            {
                _text += " in " + GameName + "- " + URLGame;
            }
            //------------------------------------------------------------
            if (_text.Length > 140)
            {
                Debug.LogWarning("Text have more of 140 characters");
                return;
            }

#if UNITY_ANDROID && !UNITY_EDITOR
            if (!_forceWeb && CheckTwitterAppIsPresent())
            {
                SocialPost.twitter(_text);
            }
            else
            {
                Application.OpenURL("https://twitter.com/intent/tweet" + "?text=" + WWW.EscapeURL(_text) + 
                ((_HashGame != "") ? ("&amp;via=" + WWW.EscapeURL(_HashGame)) : "") +
                "&amp;lang=" + WWW.EscapeURL(lang));
            }
#elif UNITY_IPHONE && !UNITY_EDITOR
            if (!_forceWeb)
            {
                SocialPost.twitter(_text);
            }
            else
            {
                Application.OpenURL("https://twitter.com/intent/tweet" + "?text=" + WWW.EscapeURL(_text) + 
                ((_HashGame != "") ? ("&amp;via=" + WWW.EscapeURL(_HashGame)) : "") +
                "&amp;lang=" + WWW.EscapeURL(lang));
            }
#endif
            Application.OpenURL("https://twitter.com/intent/tweet" + "?text=" + WWW.EscapeURL(_text) + 
            ((_HashGame != "") ? ("&amp;via=" + WWW.EscapeURL(_HashGame)) : "") +
            "&amp;lang=" + WWW.EscapeURL(lang));
        }

        /// <summary>
        /// Open the twitter page of you game to follow
        /// </summary>
        public static void FollowTwitter()
        {
            Application.OpenURL("https://twitter.com/" + IDTwitter);
        }


        private static bool CheckTwitterAppIsPresent()
        {
            AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");

            //take the list of all packages on the device
            AndroidJavaObject appList = packageManager.Call<AndroidJavaObject>("getInstalledPackages", 0);
            int num = appList.Call<int>("size");
            for (int i = 0; i < num; i++)
            {
                AndroidJavaObject appInfo = appList.Call<AndroidJavaObject>("get", i);
                string packageNew = appInfo.Get<string>("packageName");
                if (packageNew.CompareTo("com.twitter.android") == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
