using System;
using System.Windows;
using Prism.Unity;
using Prism.Ioc;

namespace ImageComparer
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            var dialog = new SettingsWindow();
            bool? dialogResult = dialog.ShowDialog();
            base.OnStartup(e);
            /* Handle results */
            /*if (true || dialogResult.HasValue && dialogResult.Value)
            {
                base.OnStartup(e);
            }
            else
            {
                this.Shutdown();
            }*/
        }
    }
}
