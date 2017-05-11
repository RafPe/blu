using Topshelf;
using Topshelf.Logging;

namespace Blu.service
{


    public class TownCrier
    {
        private readonly LogWriter logWriter;

        readonly string _timer;
        public TownCrier()
        {
            logWriter = HostLogger.Get<TownCrier>();

            logWriter.Debug("Tick:"); // Needs to add NlogConfig to the application
        }
        public void Start() {  }
        public void Stop() {  }
    }

    public class Program
    {
        public static void Main()
        {
            

            HostFactory.Run(x =>                                 //1
            {
                x.UseNLog();
                x.BeforeInstall(() => { });
                x.AfterInstall(() => { });
                x.EnableServiceRecovery(rc =>
                {
                    rc.RestartService(1); // restart the service after 1 minute
                });
                x.Service<TownCrier>(s =>                        //2
                {
                    s.ConstructUsing(name => new TownCrier());     //3
                    s.WhenStarted(tc => tc.Start());              //4
                    s.WhenStopped(tc => tc.Stop());               //5
                });
                x.RunAsLocalSystem();                            //6

                x.SetDescription("Sample Topshelf Host");        //7
                x.SetDisplayName("Stuff");                       //8
                x.SetServiceName("Stuff");                       //9
                
            });                                                  //10
        }
    }
}
