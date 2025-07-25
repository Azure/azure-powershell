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

namespace Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Providers
{
    internal static class UnsettableMemoryConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddUnsettableInMemoryCollection(this IConfigurationBuilder builder, string id, IEnumerable<KeyValuePair<string, string>> initialData = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Add(id, new UnsettableMemoryConfigurationSource() { InitialData = initialData });
            return builder;
        }
    }
}
