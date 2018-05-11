using System;
using System.Collections.Concurrent;
using System.Security;

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
            var isSecureString = typeof(T) == typeof(SecureString);
            Parameters.TryAdd(
                parameter.Name,
                new Parameter
                {
                    type = isSecureString ? "secureString" : "string",
                    defaultValue = isSecureString ? null : parameter.Value as object
                });
            return "[parameters('" + parameter.Name + "')]";
        }

        public ConcurrentDictionary<string, Parameter> Parameters { get; }
            = new ConcurrentDictionary<string, Parameter>();
    }
}
