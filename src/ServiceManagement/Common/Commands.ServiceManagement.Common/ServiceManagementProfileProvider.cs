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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.IO;
using System;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Common.Properties;

namespace Microsoft.WindowsAzure.Commands.Common
{
    public class ServiceManagementProfileProvider : AzureSMProfileProvider
    {
        private AzureSMProfile _profile;
        private AzureSMProfile _defaultProfile;

        public override IAzureContextContainer Profile
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

        public override T GetProfile<T>() 
        {
           if (!typeof(T).IsAssignableFrom(typeof(AzureSMProfile)))
            {
                throw new ArgumentOutOfRangeException(nameof(T), Resources.BadProfileTypeArgument);
            }

            return _profile as T;
        }

        /// <summary>
        /// Create the default profile, based on the default profile path
        /// </summary>
        /// <returns>The default profile, serialized from the default location on disk</returns>
        private AzureSMProfile InitializeDefaultProfile()
        {
            if (!string.IsNullOrEmpty(AzureSession.Instance.ProfileDirectory) && !string.IsNullOrEmpty(AzureSession.Instance.ProfileFile))
            {
                try
                {
                    GeneralUtilities.EnsureDefaultProfileDirectoryExists();
                    return new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory,
                        AzureSession.Instance.ProfileFile));
                }
                catch
                {
                    // swallow exceptions in creating the profile from disk
                }
            }

            return new AzureSMProfile();
        }

        private void SetProfileValue(IAzureContextContainer container)
        {
            AzureSMProfile profile = container as AzureSMProfile;
            _profile = profile;
        }

        public override void ResetDefaultProfile()
        {
            SetProfileValue(null);
        }

        public override void SetTokenCacheForProfile(IAzureContextContainer container)
        {
        }

        /// <summary>
        /// Initialize the profile provider for service management cmdlets
        /// </summary>
        public static void InitializeServiceManagementProfile()
        {
            SetInstance(() => new ServiceManagementProfileProvider());
        }
    }
}
