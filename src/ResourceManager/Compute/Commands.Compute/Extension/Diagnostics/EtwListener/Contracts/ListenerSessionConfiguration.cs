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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.VisualStudio.EtwListener.Common.Contracts
{
    [DataContract]
    internal class ListenerSessionConfiguration
    {
        public ListenerSessionConfiguration()
        {
            this.ProviderConfigurations = new List<ProviderConfiguration>();
        }

        [DataMember]
        public IList<ProviderConfiguration> ProviderConfigurations { get; private set; }

        public static ListenerSessionConfiguration Create(string[] texts)
        {
            if (texts == null || texts.Length == 0)
            {
                return new ListenerSessionConfiguration();
            }

            var lines = texts
                // StringSplitOptions.RemoveEmptyEntries removes empty strings, but not whitespace strings.
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Trim())
                .ToArray();

            var config = new ListenerSessionConfiguration();
            foreach (var line in lines)
            {
                var pConfig = ProviderConfiguration.Create(line);
                config.ProviderConfigurations.Add(pConfig);
            }

            return config;
        }
    }
}
