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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    public partial class DataFactoryClient
    {
        public virtual async Task<IntegrationRuntimeResource> CreateOrUpdateIntegrationRuntimeAsync(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName,
            IntegrationRuntimeResource resource)
        {
            return await this.DataFactoryManagementClient.IntegrationRuntimes.CreateOrUpdateAsync(
                    resourceGroupName,
                    dataFactoryName,
                    integrationRuntimeName,
                    resource);
        }

        public virtual PSIntegrationRuntime CreateOrUpdateIntegrationRuntime(CreatePSIntegrationRuntimeParameters parameters)
        {
            PSIntegrationRuntime psIntegrationRuntime = null;

            Action createOrUpdateIntegrationRuntime = () =>
            {
                var integrationRuntime = this.CreateOrUpdateIntegrationRuntimeAsync(
                    parameters.ResourceGroupName,
                    parameters.DataFactoryName,
                    parameters.Name,
                    parameters.IntegrationRuntimeResource).ConfigureAwait(true).GetAwaiter().GetResult();

                var managed = integrationRuntime.Properties as ManagedIntegrationRuntime;
                if (managed != null)
                {
                    psIntegrationRuntime = new PSManagedIntegrationRuntime(integrationRuntime,
                            parameters.ResourceGroupName,
                            parameters.DataFactoryName);
                }
                else
                {
                    var selfHosted = integrationRuntime.Properties as SelfHostedIntegrationRuntime;
                    if (selfHosted != null)
                    {
                        psIntegrationRuntime = new PSSelfHostedIntegrationRuntime(integrationRuntime,
                                parameters.ResourceGroupName,
                                parameters.DataFactoryName);
                    }
                }
            };

            parameters.ConfirmAction(
                    parameters.Force,  // prompt only if the integration runtime exists
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.IntegrationRuntimeExists,
                        parameters.Name,
                        parameters.DataFactoryName),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.IntegrationRuntimeUpdating,
                        parameters.Name,
                        parameters.DataFactoryName),
                    parameters.Name,
                    createOrUpdateIntegrationRuntime,
                    () => parameters.IsUpdate);

            return psIntegrationRuntime;
        }

        public virtual async Task<List<PSIntegrationRuntime>> ListIntegrationRuntimesAsync(AdfEntityFilterOptions filterOptions)
        {
            var integrationRuntimes = new List<PSIntegrationRuntime>();

            IPage<IntegrationRuntimeResource> response;
            if (filterOptions.NextLink.IsNextPageLink())
            {
                response = await this.DataFactoryManagementClient.IntegrationRuntimes.ListByFactoryNextAsync(filterOptions.NextLink);
            }
            else
            {
                response = await this.DataFactoryManagementClient.IntegrationRuntimes.ListByFactoryAsync(
                    filterOptions.ResourceGroupName,
                    filterOptions.DataFactoryName);
            }

            filterOptions.NextLink = response?.NextPageLink;
            if (response == null)
            {
                return integrationRuntimes;
            }

            foreach (var integrationRuntime in response.ToList())
            {
                var managed = integrationRuntime.Properties as ManagedIntegrationRuntime;
                if (managed != null)
                {
                    integrationRuntimes.Add(new PSManagedIntegrationRuntime(
                        integrationRuntime,
                        filterOptions.ResourceGroupName,
                        filterOptions.DataFactoryName));
                }
                else
                {
                    var selfHosted = integrationRuntime.Properties as SelfHostedIntegrationRuntime;
                    if (selfHosted != null)
                    {
                        integrationRuntimes.Add(new PSSelfHostedIntegrationRuntime(
                            integrationRuntime,
                            filterOptions.ResourceGroupName,
                            filterOptions.DataFactoryName));
                    }
                    else
                    {
                        integrationRuntimes.Add(new PSIntegrationRuntime(
                            integrationRuntime,
                            filterOptions.ResourceGroupName,
                            filterOptions.DataFactoryName));
                    }
                }
            }

            return integrationRuntimes;
        }

        public virtual async Task<PSIntegrationRuntime> GetIntegrationRuntimeAsync(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName)
        {
            var response = await this.DataFactoryManagementClient.IntegrationRuntimes.GetAsync(
                resourceGroupName,
                dataFactoryName,
                integrationRuntimeName);

            return GenerateIntegraionRuntimeObject(response, null, resourceGroupName, dataFactoryName);
        }

        public virtual async Task<PSIntegrationRuntime> GetIntegrationRuntimeStatusAsync(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName)
        {
            var taskGetIntegrationRuntime = Task.Run(
                async () => await this.DataFactoryManagementClient.IntegrationRuntimes.GetAsync(
                    resourceGroupName,
                    dataFactoryName,
                    integrationRuntimeName));
            var taskGetStatus = Task.Run(
                async () => await this.DataFactoryManagementClient.IntegrationRuntimes.GetStatusAsync(
                    resourceGroupName,
                    dataFactoryName,
                    integrationRuntimeName));
            await Task.WhenAll(taskGetIntegrationRuntime, taskGetStatus);

            return GenerateIntegraionRuntimeObject(
                taskGetIntegrationRuntime.Result,
                taskGetStatus.Result,
                resourceGroupName,
                dataFactoryName);
        }

        public virtual async Task<HttpStatusCode> DeleteIntegrationRuntimeAsync(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName)
        {
            var response = await this.DataFactoryManagementClient.IntegrationRuntimes.DeleteWithHttpMessagesAsync(
                resourceGroupName,
                dataFactoryName,
                integrationRuntimeName);

            return response.Response.StatusCode;
        }

        public virtual async Task<PSIntegrationRuntimeKeys> RegenerateIntegrationRuntimeAuthKeyAsync(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName,
            string keyName)
        {
            var response =
                await this.DataFactoryManagementClient.IntegrationRuntimes.RegenerateAuthKeyAsync(
                    resourceGroupName,
                    dataFactoryName,
                    integrationRuntimeName,
                    new IntegrationRuntimeRegenerateKeyParameters(keyName));

            return new PSIntegrationRuntimeKeys(response.AuthKey1, response.AuthKey2);
        }

        public virtual async Task<PSIntegrationRuntimeKeys> GetIntegrationRuntimeKeyAsync(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName)
        {
            var response = await this.DataFactoryManagementClient.IntegrationRuntimes.ListAuthKeysAsync(
                resourceGroupName,
                dataFactoryName,
                integrationRuntimeName);

            return new PSIntegrationRuntimeKeys(response.AuthKey1, response.AuthKey2);
        }

        public virtual async Task<PSManagedIntegrationRuntimeStatus> StartIntegrationRuntimeAsync(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName,
            IntegrationRuntimeResource integrationRuntime)
        {
            var response = await this.DataFactoryManagementClient.IntegrationRuntimes.BeginStartWithHttpMessagesAsync(
                resourceGroupName,
                dataFactoryName,
                integrationRuntimeName);

            try
            {
                var result = await this.DataFactoryManagementClient.GetLongRunningOperationResultAsync(response, null, default(CancellationToken));
                return (PSManagedIntegrationRuntimeStatus)GenerateIntegraionRuntimeObject(integrationRuntime,
                    result.Body,
                    resourceGroupName,
                    dataFactoryName);
            }
            catch (Exception e)
            {
                throw RethrowLongingRunningException(e);
            }
        }

        public virtual async Task StopIntegrationRuntimeAsync(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName)
        {
            var response = await this.DataFactoryManagementClient.IntegrationRuntimes.BeginStopWithHttpMessagesAsync(
                resourceGroupName,
                dataFactoryName,
                integrationRuntimeName);

            try
            {
                await this.DataFactoryManagementClient.GetLongRunningOperationResultAsync(response, null, default(CancellationToken));
            }
            catch (Exception e)
            {
                throw RethrowLongingRunningException(e);
            }
        }

        public virtual async Task<PSIntegrationRuntimeMetrics> GetIntegrationRuntimeMetricAsync(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName)
        {
            var data = await this.DataFactoryManagementClient.IntegrationRuntimes.GetMonitoringDataAsync(
                resourceGroupName,
                dataFactoryName,
                integrationRuntimeName);

            return new PSIntegrationRuntimeMetrics(data, resourceGroupName, dataFactoryName);
        }

        public virtual async Task<HttpStatusCode> RemoveIntegrationRuntimeNodeAsync(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName,
            string nodeName)
        {
            var response = await this.DataFactoryManagementClient.IntegrationRuntimeNodes.DeleteWithHttpMessagesAsync(
                resourceGroupName,
                dataFactoryName,
                integrationRuntimeName,
                nodeName);

            return response.Response.StatusCode;
        }

        public virtual async Task SyncIntegrationRuntimeCredentialInNodesAsync(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName)
        {
            await this.DataFactoryManagementClient.IntegrationRuntimes.SyncCredentialsAsync(
                resourceGroupName,
                dataFactoryName,
                integrationRuntimeName);
        }

        public virtual async Task<SelfHostedIntegrationRuntimeNode> UpdateIntegrationRuntimeNodesAsync(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName,
            string nodeName,
            UpdateIntegrationRuntimeNodeRequest request)
        {
            return await this.DataFactoryManagementClient.IntegrationRuntimeNodes.UpdateAsync(
                resourceGroupName,
                dataFactoryName,
                integrationRuntimeName,
                nodeName,
                request);
        }

        public virtual async Task<IntegrationRuntimeNodeIpAddress> GetIntegrationRuntimeNodeIpAsync(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName,
            string nodeName)
        {
            return await this.DataFactoryManagementClient.IntegrationRuntimeNodes.GetIpAddressAsync(
                resourceGroupName,
                dataFactoryName,
                integrationRuntimeName,
                nodeName);
        }

        public virtual async Task UpgradeIntegrationRuntimeAsync(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName)
        {
            await this.DataFactoryManagementClient.IntegrationRuntimes.UpgradeAsync(
                resourceGroupName,
                dataFactoryName,
                integrationRuntimeName);
        }

        public virtual async Task<PSSelfHostedIntegrationRuntimeStatus> UpdateIntegrationRuntimeAsync(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName,
            IntegrationRuntimeResource resource,
            UpdateIntegrationRuntimeRequest request)
        {
            var response = await this.DataFactoryManagementClient.IntegrationRuntimes.UpdateAsync(
                resourceGroupName,
                dataFactoryName,
                integrationRuntimeName,
                request);
            var selfHostedStatus = response.Properties as SelfHostedIntegrationRuntimeStatus;

            return new PSSelfHostedIntegrationRuntimeStatus(
                resource,
                selfHostedStatus,
                resourceGroupName,
                dataFactoryName,
                DataFactoryManagementClient.DeserializationSettings);
        }

        internal async Task<bool> CheckIntegrationRuntimeExistsAsync(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName)
        {
            try
            {
                PSIntegrationRuntime integrationRuntime = await this.GetIntegrationRuntimeAsync(
                    resourceGroupName,
                    dataFactoryName,
                    integrationRuntimeName);

                return integrationRuntime != null;
            }
            catch (ErrorResponseException e)
            {
                //Get throws Exception message with NotFound Status
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }

        private PSIntegrationRuntime GenerateIntegraionRuntimeObject(
            IntegrationRuntimeResource integrationRuntime,
            IntegrationRuntimeStatusResponse status,
            string resourceGroupName,
            string dataFactoryName)
        {
            var managed = integrationRuntime.Properties as ManagedIntegrationRuntime;
            if (status == null)
            {
                if (managed != null)
                {
                    return new PSManagedIntegrationRuntime(integrationRuntime, resourceGroupName, dataFactoryName);
                }

                var selfHosted = integrationRuntime.Properties as SelfHostedIntegrationRuntime;
                if (selfHosted != null)
                {
                    return new PSSelfHostedIntegrationRuntime(integrationRuntime, resourceGroupName, dataFactoryName);
                }

                // For the legacy integration runtime, we only return the most common part.
                return new PSIntegrationRuntime(integrationRuntime, resourceGroupName, dataFactoryName);
            }

            if (managed != null)
            {
                return new PSManagedIntegrationRuntimeStatus(
                    integrationRuntime,
                    (ManagedIntegrationRuntimeStatus)status.Properties,
                    resourceGroupName,
                    dataFactoryName);
            }
            else
            {
                var selfHosted = integrationRuntime.Properties as SelfHostedIntegrationRuntime;
                if (selfHosted != null)
                {
                    return new PSSelfHostedIntegrationRuntimeStatus(
                        integrationRuntime,
                        (SelfHostedIntegrationRuntimeStatus)status.Properties,
                        resourceGroupName,
                        dataFactoryName,
                        DataFactoryManagementClient.DeserializationSettings);
                }
            }

            // Don't support get status for legacy integraiton runtime.
            throw new PSInvalidOperationException("This type of integration runtime is not supported by this version powershell cmdlets.");
        }

        private Exception RethrowLongingRunningException(Exception e)
        {
            var ce = e as CloudException;
            if (ce?.Body != null)
            {
                return new CloudException()
                {
                    Body = new CloudError()
                    {
                        Code = ce.Body.Code,
                        Message = Resources.LongRunningStatusError + "\n" + ce.Body.Message,
                        Target = ce.Body.Target
                    },
                    Request = ce.Request,
                    Response = ce.Response,
                    RequestId = ce.RequestId
                };
            }

            return new Exception(Resources.LongRunningStatusError, e);
        }
    }
}