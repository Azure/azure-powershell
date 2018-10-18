using Microsoft.Azure.Commands.Common.Strategies;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Strategies
{
    static class StrategyCmdlet
    {
        public static async Task<TModel> RunAsync<TModel>(
            Client client,
            IParameters<TModel> parameters,
            IAsyncCmdlet asyncCmdlet,
            CancellationToken cancellationToken)
            where TModel : class
        {
            // create a DAG of configs.
            var config = await parameters.CreateConfigAsync();

            // reade current Azure state.
            var current = await config.GetStateAsync(client, cancellationToken);

            // update location.
            parameters.Location = current.UpdateLocation(parameters.Location, config);

            // update a DAG of configs.
            config = await parameters.CreateConfigAsync();

            var engine = new SdkEngine(client.SubscriptionId);
            var target = config.GetTargetState(current, engine, parameters.Location);

            // apply target state
            var newState = await config.UpdateStateAsync(
                client,
                target,
                cancellationToken,
                new ShouldProcess(asyncCmdlet),
                asyncCmdlet.ReportTaskProgress);

            return newState.Get(config) ?? current.Get(config);
        }
    }
}
