using System;
using System.Collections.Concurrent;
using System.Security;

namespace Microsoft.Azure.Commands.Common.Strategies.Templates
{
    public class TemplateEngine : IEngine
    {
        IClient _client { get; }

        public TemplateEngine(IClient client)
        {
            _client = client;
        }

        public string GetId(IEntityConfig config)
            => "[concat(resourceGroup().id, '" + config.GetProvidersId().IdToString() + "')]";

        public string GetSecureString(string name, SecureString secret)
        {
            SecureStrings.AddOrUpdate(
                name,
                secret,
                (n, s) => 
                {
                    throw new Exception("The template parameter '" + name + "' already exists.");
                });
            return "[parameters('" + name + "')]";
        }

        public ConcurrentDictionary<string, SecureString> SecureStrings { get; }
            = new ConcurrentDictionary<string, SecureString>();
    }
}
