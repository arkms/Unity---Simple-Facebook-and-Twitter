using UnityEngine;

namespace Social
{
    public static class FacebookManager
    {
        //APP ID
        private const string APIKEY = "1533588730187847";
        // URL of ICON. At least 200px by 200px
        private const string Picture = "http://www.alsain.mx/games/IconoRingFever.png";

        //ID of Page of Game --// This is optional
        private const string FacebookPageID = "1631488683744980";

        // Link to game
#if UNITY_ANDROID
        private const string Link = "https://play.google.com/store";
#elif UNITY_IPHONE
        private const string Link = "https://itunes.apple.com/mx/genre/ios/id36?mt=8";
#else
        private const string Link = "http://www.alsain.mx/games/IconoRingFever.png";
#endif
    


        /// <summary>
        /// Post in Facebook,, example Share("My New Score!! is over 9000!!", "Yeah!, I got new record :D", "Enjoy this game");
        /// </summary>
        /// <param name="_name">Name of link</param>
        /// <param name="_caption">Caption</param>
        /// <param name="_description">The description of the link</param>
        public static void Share(string _text, string _caption, string _description)
        {
            Application.OpenURL("https://www.facebook.com/dialog/feed?" +
            "app_id=" + APIKEY +
            "&link=" + Link +
            "&picture=" + Picture +
            "&name=" + ChangeSpace(_text) +
            "&caption=" + ChangeSpace(_caption) +
            "&description=" + ChangeSpace(_description) +
            "&redirect_uri=https://facebook.com/");
        }

        /// <summary>
        /// Post in Facebook, with different image
        /// </summary>
        /// <param name="_name">Name of link</param>
        /// <param name="_caption">Caption</param>
        /// <param name="_description">The description of the link</param>
        /// <param name="_iconUrl">Url of image,, can be like a trophy icon</param>
        public static void Share(string _text, string _caption, string _description, string _imageUrl)
        {
            Application.OpenURL("https://www.facebook.com/dialog/feed?" +
            "app_id=" + APIKEY +
            "&link=" + Link +
            "&picture=" + _imageUrl +
            "&name=" + ChangeSpace(_text) +
            "&caption=" + ChangeSpace(_caption) +
            "&description=" + ChangeSpace(_description) +
            "&redirect_uri=https://facebook.com/");
        }

        /// <summary>
        /// Show facebook page game
        /// </summary>
        /// <param name="_ForceWeb">Force use web //Only in Android</param>
        public static void LikeGame(bool _ForceWeb= false)
        {
#if UNITY_ANDROID
            if (!_ForceWeb && CheckFacebookAppIsPresent())
            {
                Application.OpenURL("fb://profile/"+ FacebookPageID); //use facebook app
            }
            else//is not facebook app
            {
                Application.OpenURL("https://www.facebook.com/" + FacebookPageID);
            }
#else
            Application.OpenURL("https://www.facebook.com/" + FacebookPageID);
#endif
        }

        private static bool CheckFacebookAppIsPresent()
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
                if (packageNew.CompareTo("com.facebook.katana") == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private static string ChangeSpace(string val)
        {
            return val.Replace(" ", "%20");
        }
    }
}
