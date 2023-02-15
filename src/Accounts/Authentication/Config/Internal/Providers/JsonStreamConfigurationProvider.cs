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

using System.IO;

namespace Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Providers
{
    /// <summary>
    /// Loads configuration key/values from a json stream into a provider.
    /// </summary>
    internal class JsonStreamConfigurationProvider : StreamConfigurationProvider
    {
        public JsonStreamConfigurationProvider(JsonStreamConfigurationSource source, string id) : base(source, id)
        {
        }

        /// <summary>
        /// Loads json configuration key/values from a stream into a provider.
        /// </summary>
        /// <param name="stream">The json <see cref="Stream"/> to load configuration data from.</param>
        public override void Load(Stream stream)
        {
            Data = JsonConfigurationFileParser.Parse(stream);
        }
    }
}
