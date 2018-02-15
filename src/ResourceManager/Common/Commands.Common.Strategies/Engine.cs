using System;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    sealed class Engine : IEngine
    {
        string _SubscriptionId { get; }

        public Engine(string subscriptionId)
        {
            _SubscriptionId = subscriptionId;
        }

        public string GetId<TModel>(IEntityConfig<TModel> config) where TModel : class
            => config.GetId(_SubscriptionId).IdToString();
    }
}
