namespace Sample.WorkerApplication;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IHostEnvironment _environment;

    public Worker(ILogger<Worker> logger, IHostEnvironment environment)
    {
        _logger = logger;
        _environment = environment;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Access the server name
            var serverName = Environment.MachineName;
            var applicationName = _environment.ApplicationName;
            var environment = _environment.EnvironmentName;

            // Print or use the server name as needed
            Console.WriteLine($"Server Name: {serverName}");
            Console.WriteLine($"Application Name: {applicationName}");
            Console.WriteLine($"Environment Name: {environment}");

            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            await Task.Delay(1000, stoppingToken);
        }
    }
}
