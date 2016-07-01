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

using System;
<<<<<<< HEAD
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Network.Common;
=======
>>>>>>> 944fbbb5a3ad6f02a8f01b03133504a7f09a91c8

namespace Microsoft.Azure.Commands.Network
{
    public abstract class NetworkBaseCmdlet : AzureRMCmdlet
    {

        private NetworkClient _networkClient;

        public NetworkClient NetworkClient
        {
            get
            {
                if (_networkClient == null)
                {
                    _networkClient = new NetworkClient(DefaultProfile.Context)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                }
                return _networkClient;
            }

            set { _networkClient = value; }
        }
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            NetworkResourceManagerProfile.Initialize();
            try
            {
                Execute();
            }
            catch (Rest.Azure.CloudException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public virtual void Execute()
        {
        }

        public static string GetResourceGroup(string resourceId)
        {
            const string resourceGroup = "resourceGroups";

            var startIndex = resourceId.IndexOf(resourceGroup, StringComparison.OrdinalIgnoreCase) + resourceGroup.Length + 1;
            var endIndex = resourceId.IndexOf("/", startIndex, StringComparison.OrdinalIgnoreCase);

            return resourceId.Substring(startIndex, endIndex - startIndex);
        }
    }
}
