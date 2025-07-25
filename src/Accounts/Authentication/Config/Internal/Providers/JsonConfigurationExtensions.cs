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

using Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Interfaces;
using System;
using System.IO;

namespace Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Providers
{
    /// <summary>
    /// Extension methods for adding the <see cref="JsonStreamConfigurationProvider"/>.
    /// </summary>
    internal static class JsonConfigurationExtensions
    {
        /// <summary>
        /// Adds a JSON configuration source to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="id"></param>
        /// <param name="stream">The <see cref="Stream"/> to read the json configuration data from.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddJsonStream(this IConfigurationBuilder builder, string id, Stream stream)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.Add<JsonStreamConfigurationSource>(id, s => s.Stream = stream);
        }
    }
}
