using Microsoft.Azure.Commands.Common.Strategies;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Strategies
{
    internal sealed class ShouldProcess : IShouldProcess
    {
        readonly Cmdlet _Cmdlet;

        readonly MessageLoop _MessageLoop;

        public ShouldProcess(Cmdlet cmdlet, MessageLoop messageLoop)
        {
            _Cmdlet = cmdlet;
            _MessageLoop = messageLoop;
        }

        public async Task<bool> ShouldCreate<TModel>(ResourceConfig<TModel> config, TModel model)
            where TModel : class
            => await _MessageLoop.Invoke(
                () => _Cmdlet.ShouldProcess(
                    config.Name, VerbsCommon.New + " " + config.Strategy.Type));
    }
}
