namespace Vault
{
    public class Worker(ILogger<Worker> logger) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                int i = 0;
                if (logger.IsEnabled(LogLevel.Information))
                {
                    string token = GenerateAccessToken.GenerateJwtToken($"user{i}", "61855471618554716185547161855471", "SynapseVault", "SynapseVaultConsumers", "admin");
                    logger.LogInformation($"New token is: {token}", DateTimeOffset.Now);
                    //logger.LogInformation($"Is new token valid: {}");
                }
                i++;
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
