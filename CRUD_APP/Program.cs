using System;
using System.Windows.Forms;
using framework.View.Forms;
using framework.View.Modal;
using framework.core_app;

namespace framework
{

    static class Program
    {
        [STAThread]
        static void Main()
        {
            var app = App.instance();
            DbConfig config = new DbConfig();
            config.DatabaseType = "SQL";
            config.DatabaseName = "TODO";
            config.Server = "DESKTOP-8DIPVFE\\SQLEXPRESS";
            app.setConfig(config);
            app.readDbConfig();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            app.setTarget<tasks>();

            Application.Run(app.initAuthForm<users>());
        }
    }
}
