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

using Microsoft.Azure.Commands.MachineLearning.Utilities;

namespace Microsoft.Azure.Commands.MachineLearning
{
    public abstract class WebServicesCmdletBase : MachineLearningCmdletBase
    {
        public const string CommandletSuffix = "AzureRmMlWebService";

        private WebServicesClient webServicesClient;

        public WebServicesClient WebServicesClient
        {
            get
            {
                if (this.webServicesClient == null)
                {
                    this.webServicesClient = new WebServicesClient(DefaultProfile.DefaultContext);
                }

                this.webServicesClient.VerboseLogger = WriteVerboseWithTimestamp;
                this.webServicesClient.ErrorLogger = WriteErrorWithTimestamp;
                this.webServicesClient.WarningLogger = WriteWarningWithTimestamp;
                return this.webServicesClient;
            }
            set { this.webServicesClient = value; }
        }
    }
}
