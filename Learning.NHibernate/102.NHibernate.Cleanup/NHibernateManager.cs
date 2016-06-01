namespace _102.NHibernate.Cleanup
{
    using global::NHibernate;
    using global::NHibernate.Cfg;
    using global::NHibernate.Dialect;
    using global::NHibernate.Driver;
    using System.Reflection;

    public static class NHibernateManager
    {
        private static Configuration configuration;
        static NHibernateManager()
        {
            configuration = new Configuration();
            configuration.DataBaseIntegration(x => {
                x.ConnectionString = "Server=localhost;Database=NHibernageDemo;Integrated Security=SSPI;";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
                //x.LogSqlInConsole = true;
            });

            // Add all the models
            configuration.AddAssembly(Assembly.GetExecutingAssembly());
        }

        public static ISessionFactory GetSessionFactory()
        {
            return configuration.BuildSessionFactory();
        }        
    }
}
