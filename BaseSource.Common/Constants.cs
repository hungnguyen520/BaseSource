namespace BaseSource.Common
{
    public static class Constants
    {
        public const string CONNECTION_STRING = "BaseSourceConnection";

        public const string EMAIL_CONTACT = "nphihung@tma.com.vn";

        public const int PASSWORD_MIN_LENGHT = 6;

        public const double ACCOUNT_LOCKOUT_TIMESPAN_MINUTES = 60;

        public const int MAX_FAILED_ACCESS_ATTEMPTS_BEFORE_LOCKOUT = 5;

        public const double TOKEN_LIFESPAN_MINUTES = 60;

        public const string CONFIGURATION_EMAIL_SERVICE_ACCOUNT = "nphihung";

        public const string CONFIGURATION_EMAIL_SERVICE_EMAIL_ADDRESS = "nguyenphihung520@gmail.com";

        public const string CONFIGURATION_EMAIL_SERVICE_DISPLAY_NAME = "Nguyen Phi Hung";

        public const string CONFIGURATION_EMAIL_SERVICE_PASSWORD = "12345678x@X";

        public const string ALLOWED_ORIGIN = "*";

        public const string ACCESS_CONTROL_ALLOW_ORGIN = "Access-Control-Allow-Origin";

        public const string ERR_INVALID_GRANT = "invalid_grant";

        public const string ERR_USERNAME_PASS_INCORRECT = "User name or password is incorrect!";
    }
}