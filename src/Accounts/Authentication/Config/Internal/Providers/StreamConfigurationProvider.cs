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
using System.IO;

namespace Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Providers
{
    /// <summary>
    /// Stream based configuration provider
    /// </summary>
    internal abstract class StreamConfigurationProvider : ConfigurationProvider
    {
        /// <summary>
        /// The source settings for this provider.
        /// </summary>
        public StreamConfigurationSource Source { get; }

        private bool _loaded;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="id"></param>
        public StreamConfigurationProvider(StreamConfigurationSource source, string id) : base(id)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
        }

        /// <summary>
        /// Load the configuration data from the stream.
        /// </summary>
        /// <param name="stream">The data stream.</param>
        public abstract void Load(Stream stream);

        /// <summary>
        /// Load the configuration data from the stream. Will throw after the first call.
        /// </summary>
        public override void Load()
        {
            if (_loaded)
            {
                throw new InvalidOperationException("StreamConfigurationProviders cannot be loaded more than once.");
            }
            Load(Source.Stream);
            _loaded = true;
        }
    }
}
