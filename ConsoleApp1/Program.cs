using log4net;
using log4net.Config;

XmlConfigurator.Configure(new FileInfo("log4net.config"));

long i = 0;

var log = LogManager.GetLogger(typeof(Program));

while (true)
{
    log.Info($"[{i++}]: Logging... Waiting 1 second...\n");
    Thread.Sleep(1_000);
}
