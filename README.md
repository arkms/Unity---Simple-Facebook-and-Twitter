A simple social manager for Facebook and Twitter for Unity, Cross platform

Works in PC, MAC, Linux, Android, iOS, Windows Phone and BlackBerry

- Share Score
  - Facebook:Social.FacebookManager.Share("My new recod is: " + Score, "This is my new record", "This is a good game");
  - Twitter: Social.TwitterManager.Share("My new recod is: " + Score + " in RingFever");
  
- Like Facebook Page:
  - Social.FacebookManager.LikeGame(true);
  
- Follow in Twitter
  - Social.TwitterManager.FollowTwitter();
  
CONFIGURATION
--------
  
In TwitterManager.cs and FacebookManager.cs,, you need change some variables, there are in top for easy and fast access
Like you APPID of Facebook, URL of you image icon, and other ones.

NOTE of normal version:
----
In Androids with Twitter can use the Twitter APP and for follow you can call Facebook APP
In iOS can use Native Facebook and Twitter APP

NOTE of lite version
----
This force use always web method, so you can ignore the param "WebOnly",, in normal version you only need define WEBONLY in top of both scripts.


Any problem can ask in Issues
