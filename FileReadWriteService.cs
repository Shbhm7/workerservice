
public class FileReadWriteService : BackgroundService
{
    private readonly ILogger<FileReadWriteService> logger;
    private readonly FileService fileService;

    public FileReadWriteService(ILogger<FileReadWriteService> logger, FileService fileService)
    {
        this.logger = logger;
        this.fileService = fileService;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
        logger.LogInformation("Background service has started.");
        while (!stoppingToken.IsCancellationRequested)
        {
            string content = fileService.ReadFromFile();
            logger.LogInformation("Read content from file: {Content}", content);
            string newContent = $"{content} - Modified: {DateTime.UtcNow}";
            fileService.WriteToFile(newContent);
            logger.LogInformation("Wrote content to file: {Content}", newContent);
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
        }
        catch (Exception ex)
            {  
                logger.LogError("An error occurred: {Error}", ex.Message);
            }
        logger.LogInformation("Background service has stopped.");
        }
    }

