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

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.MachineLearning.CommitmentPlans;
using Microsoft.Azure.Management.MachineLearning.CommitmentPlans.Models;
using APIClient = Microsoft.Azure.Management.MachineLearning.CommitmentPlans.AzureMLCommitmentPlansManagementClient;

namespace Microsoft.Azure.Commands.MachineLearning.Utilities
{
    using Rest.Azure;

    public class CommitmentPlansClient : MachineLearningClientBase
    {
        private readonly APIClient apiClient;

        public CommitmentPlansClient(AzureContext context)
        {
            this.apiClient = AzureSession.ClientFactory.CreateArmClient<APIClient>(
                context,
                AzureEnvironment.Endpoint.ResourceManager);
        }

        public CommitmentPlan CreateOrUpdateAzureMlCommitmentPlan(
            string resourceGroupName,
            string location,
            string commitmentPlanName,
            ResourceSku commitmentPlanSku)
        {
            CommitmentPlan commitmentPlan = new CommitmentPlan
            {
                Location = location,
                Sku = commitmentPlanSku
            };

            return this.apiClient.CommitmentPlans.CreateOrUpdate(
                commitmentPlan,
                resourceGroupName,
                commitmentPlanName);
        }

        public CommitmentPlan PatchAzureMlCommitmentPlan(
            string resourceGroupName,
            string commitmentPlanName,
            CommitmentPlanPatchPayload patchPayload)
        {
            return this.apiClient.CommitmentPlans.Patch(
                patchPayload,
                resourceGroupName,
                commitmentPlanName);
        }

        public void RemoveAzureMlCommitmentPlan(
            string resourceGroupName,
            string commitmentPlanName)
        {
            this.apiClient.CommitmentPlans.Remove(
                resourceGroupName,
                commitmentPlanName);
        }

        public CommitmentPlan GetAzureMlCommitmentPlan(
            string resourceGroupName,
            string commitmentPlanName)
        {
            return this.apiClient.CommitmentPlans.Get(
                resourceGroupName,
                commitmentPlanName);
        }

        public async Task<IPage<CommitmentPlan>> ListAzureMlCommitmentPlansInResourceGroupAsync(
            string resourceGroupName,
            string nextLink,
            CancellationToken? cancellationToken)
        {
            string skipToken = CommitmentPlansClient.GetSkipTokenFromLink(nextLink);
            var cancellationTokenParam = cancellationToken ?? CancellationToken.None;

            var paginatedResponse =
                await
                    this.apiClient.CommitmentPlans.ListInResourceGroupWithHttpMessagesAsync(
                        resourceGroupName,
                        skipToken,
                        cancellationToken: cancellationTokenParam).ConfigureAwait(false);

            return paginatedResponse.Body;
        }

        public async Task<IPage<CommitmentPlan>> ListAzureMlCommitmentPlansAsync(
            string nextLink,
            CancellationToken? cancellationToken)
        {
            string skipToken = CommitmentPlansClient.GetSkipTokenFromLink(nextLink);
            var cancellationTokenParam = cancellationToken ?? CancellationToken.None;

            var paginatedResponse =
                await this.apiClient.CommitmentPlans.ListWithHttpMessagesAsync(
                    skipToken,
                    cancellationToken: cancellationTokenParam).ConfigureAwait(false);

            return paginatedResponse.Body;
        }

        public CommitmentAssociation GetAzureMlCommitmentAssociation(
            string resourceGroupName,
            string commitmentPlanName,
            string commitmentAssociationName)
        {
            return this.apiClient.CommitmentAssociations.Get(resourceGroupName, commitmentPlanName, commitmentAssociationName);
        }

        public async Task<IPage<CommitmentAssociation>> ListAzureMlCommitmentAssociationsAsync(
            string resourceGroupName,
            string commitmentPlanName,
            string nextLink,
            CancellationToken? cancellationToken)
        {
            string skipToken = CommitmentPlansClient.GetSkipTokenFromLink(nextLink);
            var cancellationTokenParam = cancellationToken ?? CancellationToken.None;

            var paginatedResponse =
                await
                    this.apiClient.CommitmentAssociations.ListWithHttpMessagesAsync(
                        resourceGroupName,
                        commitmentPlanName,
                        skipToken,
                        cancellationToken: cancellationTokenParam).ConfigureAwait(false);

            return paginatedResponse.Body;
        }

        public async Task<IPage<PlanUsageHistory>> GetAzureMlCommitmentPlanUsageHistoryAsync(
            string resourceGroupName,
            string commitmentPlanName,
            string nextLink,
            CancellationToken? cancellationToken)
        {
            string skipToken = CommitmentPlansClient.GetSkipTokenFromLink(nextLink);
            var cancellationTokenParam = cancellationToken ?? CancellationToken.None;

            var paginatedResponse =
                await
                    this.apiClient.UsageHistory.ListWithHttpMessagesAsync(
                        resourceGroupName,
                        commitmentPlanName,
                        skipToken,
                        cancellationToken: cancellationTokenParam).ConfigureAwait(false);

            return paginatedResponse.Body;
        }

        public async Task<CommitmentAssociation> MoveCommitmentAssociationAsync(
            string resourceGroupName,
            string commitmentPlanName,
            string commitmentAssociationName,
            string destinationPlanId,
            CancellationToken? cancellationToken)
        {
            var cancellationTokenParam = cancellationToken ?? CancellationToken.None;
            var moveRequest = new MoveCommitmentAssociationRequest(destinationPlanId);

            var resposne =
                await
                    this.apiClient.CommitmentAssociations.MoveWithHttpMessagesAsync(
                        resourceGroupName,
                        commitmentPlanName, commitmentAssociationName, moveRequest,
                        cancellationToken: cancellationTokenParam).ConfigureAwait(false);

            return resposne.Body;
        }
    }
}