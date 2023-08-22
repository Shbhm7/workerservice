
class Program
{
    static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                string filePathRead = "C:\\Users\\Shubham.Pathania\\Documents\\SampleText.txt";
                string filePathWrite = "C:\\Users\\Shubham.Pathania\\Documents\\SampleTextNew.txt";
                services.AddSingleton(new FileService(filePathRead,filePathWrite));
                services.AddHostedService<FileReadWriteService>();
            });
}