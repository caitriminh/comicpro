using ComicPro2019.Properties;


namespace ComicPro2019
{
    public class ConfigDatabase
    {
        public static string IP_SERVER_NAME = Settings.Default.server;
        public static string USER_NAME_DB = Settings.Default.user;
        public static string PASSWORD_DB = Settings.Default.matkhau;
        public static string DATABASE = Settings.Default.database;
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
