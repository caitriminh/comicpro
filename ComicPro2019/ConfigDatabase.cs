using DAT;

namespace ComicPro2019
{
    public class ConfigDatabase : DbConnect
    {
        public static string IP_SERVER_NAME = "125.212.221.113";
        public static string USER_NAME_DB = "caitriminh";
        public static string PASSWORD_DB = "Diemthuong@2809";
        public static string DATABASE = "comicpro";
        public static int TIME_OUT = 3; // default 3s
        public static bool IS_CONNECTED = true;
        public static string IP_SERVER_LOCAL = ".";

        public static string CONNECTION_STRINGS = $"server={IP_SERVER_NAME};uid={USER_NAME_DB}; database={DATABASE}; password={PASSWORD_DB};";
        public static string CONNECTION()
        {
            string strConnection = $"Server={IP_SERVER_NAME};Database={DATABASE};User Id={USER_NAME_DB};Password = {PASSWORD_DB}; ;Connection Timeout={TIME_OUT}";
            if (IP_SERVER_NAME != ".")
            {
                strConnection = $"Server={IP_SERVER_NAME};Database={DATABASE};Trusted_Connection=True;";
            }

            return strConnection;
        }

    }
}
