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

using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class MsalCacheHelperProvider
    {
        private static MsalCacheHelper MsalCacheHelper;
        private static object ObjectLock = new object();
        protected const string PowerShellClientId = Constants.PowerShellClientId;

        public static MsalCacheHelper GetCacheHelper()
        {
            if(MsalCacheHelper == null)
            {
                lock(ObjectLock)
                {
                    if(MsalCacheHelper == null)
                    {
                        var cacheDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ".IdentityService");
                        try
                        {
                            StorageCreationProperties storageProperties = new StorageCreationPropertiesBuilder("msal.cache", cacheDirectory)
                                .WithMacKeyChain("Microsoft.Developer.IdentityService", "MSALCache")
                                .WithLinuxKeyring("msal.cache", "default", "MSALCache",
                                new KeyValuePair<string, string>("MsalClientID", "Microsoft.Developer.IdentityService"),
                                new KeyValuePair<string, string>("Microsoft.Developer.IdentityService", "1.0.0.0"))
                                .Build();

                            var cacheHelper = MsalCacheHelper.CreateAsync(storageProperties).ConfigureAwait(false).GetAwaiter().GetResult();
                            cacheHelper.VerifyPersistence();
                            MsalCacheHelper = cacheHelper;
                        }
                        catch(MsalCachePersistenceException)
                        {
                            StorageCreationProperties storageProperties = new StorageCreationPropertiesBuilder("msal.cache", cacheDirectory)
                                .WithMacKeyChain("Microsoft.Developer.IdentityService", "MSALCache")
                                .WithLinuxUnprotectedFile()
                                .Build();

                            MsalCacheHelper = MsalCacheHelper.CreateAsync(storageProperties).ConfigureAwait(false).GetAwaiter().GetResult();
                        }
                    }
                }
            }

            return MsalCacheHelper;
        }
    }
}
