namespace DelTaX
{
    public static class DBSetUp
    {
        public static void IntializeConfig(WebApplicationBuilder builder)
        {
            var DelTexDBString = builder.Configuration.GetValue<String>("ConnectionStrings:DelTaXDB");
            DelTaX.Manager.Helper.DBSetUpManager(DelTexDBString);
        }
    }
}
