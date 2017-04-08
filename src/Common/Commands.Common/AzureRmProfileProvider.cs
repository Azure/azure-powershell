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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System.Threading;

namespace Microsoft.WindowsAzure.Commands.Common
{
    public class AzureRmProfileProvider : IProfileProvider
    {
        private static int _initialized = 0;
        public static AzureRmProfileProvider Instance { get; private set; }
        public virtual IAzureContextContainer Profile { get; set; }

        public virtual void SetTokenCacheForProfile(IAzureContextContainer profile)
        {

        }

        public virtual void ResetDefaultProfile()
        {
            Profile.Clear();
        }

        /// <summary>
        /// Set the instance of the profile provider for AzureRM
        /// </summary>
        /// <param name="provider">The provider to initialize with</param>
        /// <param name="overwrite">if true, overwrite the existing provider, if it was previously initialized</param>
        public static void SetInstance(AzureRmProfileProvider provider, bool overwrite)
        {
            if (Interlocked.Exchange(ref _initialized, 1) == 0 || overwrite)
            {
                Instance = provider;
            }
        }

        /// <summary>
        /// Set the instance of the profile provider for AzureRM, if it is not already initialized
        /// </summary>
        /// <param name="provider">The provider</param>
        public static void SetInstance(AzureRmProfileProvider provider)
        {
            SetInstance(provider, false);
        }
    }
}
