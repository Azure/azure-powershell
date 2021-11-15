using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class AcrTokenCache : IAzureSessionListener
    {
        private IDictionary<string, AcrToken> _cache;

        public AcrTokenCache()
        {
            _cache = new Dictionary<string, AcrToken>();
        }

        public void OnEvent(object sender, AzureSessionEventArgs e)
        {
            _cache.Clear();
        }

        public bool TryGetToken(string key, out AcrToken value)
        {
            return _cache.TryGetValue(key, out value);
        }

        public void Set(string key, AcrToken token)
        {
            _cache[key] = token;
        }
    }
}
