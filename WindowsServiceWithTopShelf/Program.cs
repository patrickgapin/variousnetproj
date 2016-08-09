using Topshelf;

namespace FileConverterService
{
    public class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(serviceConfig =>
            {
                serviceConfig.Service<ConverterService>(serviceInstance =>
                {
                    serviceInstance.ConstructUsing(
                        () => new ConverterService());

                    serviceInstance.WhenStarted(execute => execute.Start());

                    serviceInstance.WhenStopped(execute => execute.Stop());
                });

                serviceConfig.SetServiceName("AwesomeFileConverter");  // No spaces allowed.
                serviceConfig.SetDisplayName("Awesome File Converter");
                serviceConfig.SetDescription("Playing with a Topshelf Windows Service Demo.");

                serviceConfig.StartAutomatically();
            });
        }
    }
}
