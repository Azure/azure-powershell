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

<<<<<<< HEAD
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
#if NETSTANDARD
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
using Microsoft.Azure.Commands.Common.Authentication.Core;
#endif
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.IO;
=======
using System.IO;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public class ProtectedProfileProvider : AzureRmProfileProvider
    {
<<<<<<< HEAD
        AzureRmProfile _profile = new AzureRmProfile { DefaultContext = new AzureContext { TokenCache = AzureSession.Instance.TokenCache } };
=======
        AzureRmProfile _profile = new AzureRmProfile { DefaultContext = new AzureContext() };
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

        public ProtectedProfileProvider()
        {
            using (var fileProvider = ProtectedFileProvider.CreateFileProvider(Path.Combine(AzureSession.Instance.ARMProfileDirectory, AzureSession.Instance.ARMProfileFile)))
            {
                _profile = new AzureRmProfile(fileProvider);
            }
        }

<<<<<<< HEAD
        public override void ResetDefaultProfile()
        {
            foreach (var context in _profile.Contexts.Values)
            {
                context.TokenCache.Clear();
            }

            base.ResetDefaultProfile();
        }

=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public override T GetProfile<T>()
        {
            return Profile as T;
        }

<<<<<<< HEAD
        public override void SetTokenCacheForProfile(IAzureContextContainer profile)
        {
            base.SetTokenCacheForProfile(profile);
            var session = AzureSession.Instance;
            var cache = new ProtectedFileTokenCache(Path.Combine(session.TokenCacheDirectory, session.TokenCacheFile), session.DataStore);
            session.TokenCache = cache;
            if (profile.HasTokenCache())
            {
                cache.Deserialize(profile.GetTokenCache().CacheData);
            }

            profile.SetTokenCache(cache);
        }

=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public override IAzureContextContainer Profile
        {
            get
            {
                return _profile;
            }

            set
            {
                _profile = value as AzureRmProfile;
            }
        }

        /// <summary>
        /// Initialize the resource manager profile
        /// </summary>
        public static void InitializeResourceManagerProfile(bool overwrite = false)
        {
            SetInstance(() => new ProtectedProfileProvider(), overwrite);
        }

    }
}
