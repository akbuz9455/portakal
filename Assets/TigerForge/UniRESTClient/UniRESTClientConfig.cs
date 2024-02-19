/*
* =================================
*  TIGERFORGE UniREST Client v.3.5
* ---------------------------------
*     Configuration settings
* =================================
*/

namespace TigerForge
{
    public class UniRESTClientConfig
    {
        public static string Key1 = "qD3PrE6boUB71puJk0K884mOuwwfgTnl";
        public static string Key2 = "aJ2FjLqz9G6aPAj9";
        public static string AppID = "jLqz";
        public static string ServerUrl = "https://dostext.web.tr/UNIREST/";
    }
    public static class API
    {
        public static string userLogin_firstLogin = "userLogin/firstLogin/";
    }
    [System.Serializable]
    public static class DB
    {
        [System.Serializable]
        public class Kullanicilar
        {
            public int id = 0;
            public string kullaniciAdi = "";
            public string Sifre = "";
        }

        [System.Serializable]
        public class Users
        {
            public int id = 0;
            public string username = "";
            public string password = "";
            public string tokenl = "";
            public string tokenr = "";
            public string tokenw = "";
            public string regdate = "";
            public string logdate = "";
        }

    }
}
