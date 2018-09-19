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
    public abstract class CommitmentPlansCmdletBase : MachineLearningCmdletBase
    {
        public const string CommitmentPlanCommandletSuffix = "AzureRmMlCommitmentPlan";

        public const string CommitmentAssociationCommandletSuffix = "AzureRmMlCommitmentAssociation";

        public const string CommitmentPlanUsageHistorySuffix = "AzureRmMlCommitmentPlanUsageHistory";

        private CommitmentPlansClient commitmentPlansClient;

        public CommitmentPlansClient CommitmentPlansClient
        {
            get
            {
                if (this.commitmentPlansClient == null)
                {
                    this.commitmentPlansClient = new CommitmentPlansClient(DefaultProfile.DefaultContext);
                }

                this.commitmentPlansClient.VerboseLogger = WriteVerboseWithTimestamp;
                this.commitmentPlansClient.ErrorLogger = WriteErrorWithTimestamp;
                this.commitmentPlansClient.WarningLogger = WriteWarningWithTimestamp;
                return this.commitmentPlansClient;
            }
            set { this.commitmentPlansClient = value; }
        }
    }
}
