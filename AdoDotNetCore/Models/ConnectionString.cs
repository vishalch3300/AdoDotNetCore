namespace AdoDotNetCore.Models
{
    public class ConnectionString
    {
        ////Windows Authentication
        //private static string cs = "Server=DESKTOP-9371I5C\\SQL2019EXPRESS; Database=AdoDotNetDB_Core; Trusted_Connection=True;";

        //Sql Server Authentication
        private static string cs = "Server=DESKTOP-9371I5C\\SQL2019EXPRESS; Database=AdoDotNetDB_Core; User Id=sa; Password=SqlAdmin%123;";

        public static string dbcs { get => cs; }
    }
}
