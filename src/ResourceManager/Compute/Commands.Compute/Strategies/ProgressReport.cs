using Microsoft.Azure.Commands.Common.Strategies;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Strategies
{
    sealed class ProgressReport : IProgressReport
    {
        readonly Cmdlet _Cmdlet;

        readonly MessageLoop _MessageLoop;

        public ProgressReport(Cmdlet cmdlet, MessageLoop messageLoop)
        {
            _Cmdlet = cmdlet;
            _MessageLoop = messageLoop;
        }

        public void Report<TModel>(ResourceConfig<TModel> config, double progress)
            where TModel : class
            => _MessageLoop.BeginInvoke(() => _Cmdlet.WriteVerbose(progress == 0 
                ? "Creating " + config.Name + " " + config.Strategy.Type + "..."
                : config.Name + " " + config.Strategy.Type + " is created."));
    }
}
