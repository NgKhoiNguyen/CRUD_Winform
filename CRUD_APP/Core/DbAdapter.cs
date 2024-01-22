using System;

namespace framework.core_app
{
    public class DbConfigAdapter : IReadConfig
    {
        private readonly IDbConfig originalConfig;

        public DbConfigAdapter(IDbConfig originalConfig)
        {
            this.originalConfig = originalConfig ?? throw new ArgumentNullException(nameof(originalConfig));
        }

        public string getString()
        {
            return "Server="+ originalConfig.Server + ";" +"Database="+ originalConfig.DatabaseName + ";" +"TrustServerCertificate = true;"+ "Integrated Security = True;";
        }
    }
}
