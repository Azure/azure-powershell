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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.IO;

namespace Microsoft.WindowsAzure.Commands.Common
{
    public class AzureSMProfileProvider : IProfileProvider<AzureSMProfile>
    {
        private AzureSMProfile _profile;
        private AzureSMProfile _defaultProfile;
        private TokenCache _defaultDiskTokenCache;
        static AzureSMProfileProvider()
        {
            Instance = new AzureSMProfileProvider();
        }
        private AzureSMProfileProvider()
        {
            _defaultDiskTokenCache = TokenCache.DefaultShared;
        }

        public static AzureSMProfileProvider Instance { get; private set; }
        public AzureSMProfile Profile
        {
            get
            {
                var returnValue = _profile;
                if (_profile == null)
                {
                    if (_defaultProfile == null)
                    {
                        _defaultProfile = InitializeDefaultProfile();
                        SetProfileValue(null);
                    }

                    returnValue = _defaultProfile;
                }

                return returnValue;
            }
            set { SetProfileValue(value); }
        }

        /// <summary>
        /// Create the default profile, based on the default profile path
        /// </summary>
        /// <returns>The default profile, serialized from the default location on disk</returns>
        private AzureSMProfile InitializeDefaultProfile()
        {
            if (!string.IsNullOrEmpty(AzureSession.ProfileDirectory) && !string.IsNullOrEmpty(AzureSession.ProfileFile))
            {
                try
                {
                    GeneralUtilities.EnsureDefaultProfileDirectoryExists();
                    _defaultDiskTokenCache = new ProtectedFileTokenCache(
                        Path.Combine(AzureSession.ProfileDirectory,
                        AzureSession.TokenCacheFile));
                    return new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory,
                        AzureSession.ProfileFile));
                }
                catch
                {
                    // swallow exceptions in creating the profile from disk
                }
            }

            _defaultDiskTokenCache = TokenCache.DefaultShared;
            return new AzureSMProfile();
        }

        private void SetProfileValue(AzureSMProfile profile)
        {
            _profile = profile;
            SetTokenCacheForProfile(profile);
        }

        public void ResetDefaultProfile()
        {
            SetProfileValue(null);
        }

        public void SetTokenCacheForProfile(AzureSMProfile profile)
        {
            var defaultProfilePath = Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile);
            if (_profile == null || string.Equals(profile.ProfilePath, defaultProfilePath, StringComparison.OrdinalIgnoreCase))
            {
                AzureSession.TokenCache = _defaultDiskTokenCache;
            }
            else
            {
                AzureSession.TokenCache = TokenCache.DefaultShared;
            }
        }
    }
}
