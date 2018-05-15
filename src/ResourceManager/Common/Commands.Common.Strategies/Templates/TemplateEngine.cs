// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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
