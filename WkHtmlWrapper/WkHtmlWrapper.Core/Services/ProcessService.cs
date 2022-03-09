using System.Diagnostics;
using System.Threading.Tasks;
using WkHtmlWrapper.Core.Services.Interfaces;

namespace WkHtmlWrapper.Core.Services
{
    internal class ProcessService : IProcessService
    {
        public async Task StartAsync(string filename, string arguments)
        {
            await Task.Run(() =>
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo(filename, arguments)
                    {
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    }
                };

                process.Start();
                process.WaitForExit();
                var logs = process.StandardOutput.ReadToEnd();
                var errors = process.StandardError.ReadToEnd();
                if(!string.IsNullOrEmpty(errors))
                    throw new System.Exception($"Process failed with: {errors} \n\n Logs:{logs}");
            });
        }
    }
}