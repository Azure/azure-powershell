﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
// TODO: Remove IfDef
#if NETSTANDARD
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
#endif
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Properties;
using System;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public static class AzureRMProfileExtensions
    {
        /// <summary>
        /// Set the context for the current profile, preserving token cache information.
        /// After MSAL, token cache is no longer stored in contexts. So this method roughly equals to TrySetDefaultContext().
        /// </summary>
        /// <param name="profile">The profile to change the context for</param>
        /// <param name="newContext">The new context, with no token cache information.</param>
        public static void SetContextWithCache(this IAzureContextContainer profile, IAzureContext newContext, string name = null)
        {
            if (profile == null)
            {
                throw new ArgumentNullException("profile", Resources.ProfileCannotBeNull);
            }

            if (newContext == null)
            {
                throw new ArgumentNullException("newContext", Resources.ContextCannotBeNull);
            }

            var rmProfile = profile as AzureRmProfile;
            if (rmProfile != null)
            {
                rmProfile.TrySetDefaultContext(name, newContext);
            }
            else
            {
                profile.DefaultContext = newContext;
            }
        }
    }
}