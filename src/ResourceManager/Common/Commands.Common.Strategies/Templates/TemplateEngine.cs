using System;
using System.Collections.Concurrent;

namespace Microsoft.Azure.Commands.Common.Strategies.Templates
{
    class TemplateEngine : IEngine
    {
        IClient _client { get; }

        public TemplateEngine(IClient client)
        {
            _client = client;
        }

        public string GetId(IEntityConfig config)
            => "[concat(resourceGroup().id, '" + config.GetProvidersId().IdToString() + "')]";

        public string GetParameterValue<T>(Parameter<T> parameter)
        {
            Parameters.TryAdd(parameter.Name, parameter.Value);
            return "[parameters('" + parameter.Name + "')]";
        }

        public ConcurrentDictionary<string, object> Parameters { get; }
            = new ConcurrentDictionary<string, object>();
    }
}
