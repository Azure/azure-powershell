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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
using Microsoft.WindowsAzure.Commands.Common.Utilities;
using System;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System.Collections.Concurrent;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Common.Authentication.ResourceManager.Common
{
    /// <summary>
    /// Contains helper methods shared between common lib and Az.Accounts.
    /// Named to be different from <see cref="SharedUtilities" />.
    /// </summary>
    public class AzureRmSharedUtilities : ISharedUtilities
    {
        public IAzureContextContainer CopyForContextOverriding(IAzureContextContainer contextContainer)
        {
            var profile = contextContainer as AzureRmProfile;
            return new AzureRmProfile()
            {
                DefaultContextKey = profile.DefaultContextKey,
                EnvironmentTable = profile.EnvironmentTable,
                // Contexts need a new instance else any change to DefaultContext will affect the original profile
                Contexts = new ConcurrentDictionary<string, IAzureContext>(profile.Contexts, StringComparer.CurrentCultureIgnoreCase),
                ShouldRefreshContextsFromCache = profile.ShouldRefreshContextsFromCache,
                // ProfilePath is not copied because
                // 1. it's protected setter
                // 2. copy won't be written back to disk, so it's not useful
                ExtendedProperties = profile.ExtendedProperties
            };
        }
    }
}
