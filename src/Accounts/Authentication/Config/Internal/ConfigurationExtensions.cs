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
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Authentication.Config.Internal
{
    /// <summary>
    /// Extension methods for configuration classes./>.
    /// </summary>
    internal static class ConfigurationExtensions
    {
        /// <summary>
        /// Adds a new configuration source.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="id"></param>
        /// <param name="configureSource">Configures the source secrets.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder Add<TSource>(this IConfigurationBuilder builder, string id, Action<TSource> configureSource) where TSource : IConfigurationSource, new()
        {
            var source = new TSource();
            configureSource?.Invoke(source);
            return builder.Add(id, source);
        }

        /// <summary>
        /// Shorthand for GetSection("ConnectionStrings")[name].
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="name">The connection string key.</param>
        /// <returns>The connection string.</returns>
        public static string GetConnectionString(this IConfiguration configuration, string name)
        {
            return configuration?.GetSection("ConnectionStrings")?[name].value;
        }

        /// <summary>
        /// Get the enumeration of key value pairs within the <see cref="IConfiguration" />
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/> to enumerate.</param>
        /// <returns>An enumeration of key value pairs.</returns>
        public static IEnumerable<KeyValuePair<string, string>> AsEnumerable(this IConfiguration configuration) => configuration.AsEnumerable(makePathsRelative: false);

        /// <summary>
        /// Get the enumeration of key value pairs within the <see cref="IConfiguration" />
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/> to enumerate.</param>
        /// <param name="makePathsRelative">If true, the child keys returned will have the current configuration's Path trimmed from the front.</param>
        /// <returns>An enumeration of key value pairs.</returns>
        public static IEnumerable<KeyValuePair<string, string>> AsEnumerable(this IConfiguration configuration, bool makePathsRelative)
        {
            var stack = new Stack<IConfiguration>();
            stack.Push(configuration);
            var rootSection = configuration as IConfigurationSection;
            int prefixLength = (makePathsRelative && rootSection != null) ? rootSection.Path.Length + 1 : 0;
            while (stack.Count > 0)
            {
                IConfiguration config = stack.Pop();
                // Don't include the sections value if we are removing paths, since it will be an empty key
                if (config is IConfigurationSection section && (!makePathsRelative || config != configuration))
                {
                    yield return new KeyValuePair<string, string>(section.Path.Substring(prefixLength), section.Value.Item1);
                }
                foreach (IConfigurationSection child in config.GetChildren())
                {
                    stack.Push(child);
                }
            }
        }

        /// <summary>
        /// Determines whether the section has a <see cref="IConfigurationSection.Value"/> or has children
        /// </summary>
        public static bool Exists(this IConfigurationSection section)
        {
            if (section == null)
            {
                return false;
            }
            return section.Value.Item1 != null || section.GetChildren().Any();
        }
    }
}
