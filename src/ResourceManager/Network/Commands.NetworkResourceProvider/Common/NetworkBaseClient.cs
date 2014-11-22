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

using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    public abstract class NetworkBaseClient : AzurePSCmdlet
    {

        //;protected static string NetworkCmdletPrefix
        public NetworkClient networkClient;

        public NetworkClient NetworkClient
        {
            get
            {
                if (networkClient == null)
                {
                    networkClient = new NetworkClient(CurrentContext)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                }
                return networkClient;
            }

            set { networkClient = value; }
        }
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            NetworkResourceManagerProfile.Initialize();
        }
    }
}
