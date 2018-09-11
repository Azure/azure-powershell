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

namespace Microsoft.Azure.Commands.DeploymentManager.Client
{
    using System.Collections.Generic;
    using System;
    using System.Net;

    using Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.DeploymentManager.Models;
    using Microsoft.Azure.Management.DeploymentManager;
    using Microsoft.Azure.Management.DeploymentManager.Models;
    using Microsoft.Azure.Management.Internal.Resources;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The client that handles all the requests from the commands.
    /// </summary>
    internal class DeploymentManagerClient
    {
        /// <summary>
        /// The deployment manager client.
        /// </summary>
        private AzureDeploymentManagerClient _client;

        /// <summary>
        /// THe resource management client.
        /// </summary>
        private ResourceManagementClient _resourceManagementClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeploymentManagerClient"/> class.
        /// </summary>
        /// <param name="context">The current Azure session context.</param>
        internal DeploymentManagerClient(IAzureContext context)
        {
            this._client = AzureSession.Instance.ClientFactory.CreateArmClient<AzureDeploymentManagerClient>(context, AzureEnvironment.Endpoint.ResourceManager);
            this._resourceManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeploymentManagerClient"/> class.
        /// </summary>
        internal DeploymentManagerClient() { }

        /// <summary>
        /// Gets or sets the logger used for vebose logging.
        /// </summary>
        internal Action<string> VerboseLogger { get; set; }

        /// <summary>
        /// Gets or sets the logger used to log errors.
        /// </summary>
        internal Action<string> ErrorLogger { get; set; }

        internal PSRollout GetRollout(string resourceGroupName, string rolloutName, int? retryAttempt = null)
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            var rollout = _client.Rollouts.Get(resourceGroupName, rolloutName, retryAttempt);
            return new PSRollout(resourceGroupName, rollout);
        }

        internal PSRollout RestartRollout(PSRollout psRollout, bool? skipSucceeded = true)
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            var rollout = _client.Rollouts.Restart(psRollout.ResourceGroupName, psRollout.Name, skipSucceeded);
            return new PSRollout(psRollout.ResourceGroupName, rollout);
        }

        internal PSRollout CancelRollout(PSRollout psRollout)
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            var rollout = _client.Rollouts.Cancel(psRollout.ResourceGroupName, psRollout.Name);
            return new PSRollout(psRollout.ResourceGroupName, rollout);
        }

        internal bool DeleteRollout(PSRollout psRollout)
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            var result = _client.Rollouts.DeleteWithHttpMessagesAsync(psRollout.ResourceGroupName, psRollout.Name).GetAwaiter().GetResult();
            return (result.Response.StatusCode == HttpStatusCode.OK || result.Response.StatusCode == HttpStatusCode.NoContent);
        }

        internal PSArtifactSource PutArtifactSource(PSArtifactSource psArtifactSource)
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            var artifactSource =_client.ArtifactSources.Create(
                psArtifactSource.ResourceGroupName, 
                psArtifactSource.Name, 
                psArtifactSource.ToSdkType());

            return new PSArtifactSource(psArtifactSource.ResourceGroupName, artifactSource);
        }

        internal bool ArtifactSourceExists(PSArtifactSource psArtifactSource)
        {
            return DeploymentManagerClient.ResourceExists(psArtifactSource, this.GetArtifactSource);
        }

        internal PSArtifactSource GetArtifactSource(PSArtifactSource psArtifactSource)
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            var artifactSource = _client.ArtifactSources.Get(psArtifactSource.ResourceGroupName, psArtifactSource.Name);
            return new PSArtifactSource(psArtifactSource.ResourceGroupName, artifactSource);
        }

        internal bool DeleteArtifactSource(PSArtifactSource psArtifactSource)
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            var result = _client.ArtifactSources.DeleteWithHttpMessagesAsync(psArtifactSource.ResourceGroupName, psArtifactSource.Name).GetAwaiter().GetResult();
            return (result.Response.StatusCode == HttpStatusCode.OK || result.Response.StatusCode == HttpStatusCode.NoContent);
        }

        internal PSServiceTopologyResource PutServiceTopology(PSServiceTopologyResource psTopologyResource)
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            var serviceTopologyResource = _client.ServiceTopologies.Create(
                psTopologyResource.ToSdkType(),
                psTopologyResource.ResourceGroupName,
                psTopologyResource.Name);

            return new PSServiceTopologyResource(psTopologyResource.ResourceGroupName, serviceTopologyResource);
        }

        internal bool ServiceTopologyExists(PSServiceTopologyResource psServiceTopologyResource)
        {
            return DeploymentManagerClient.ResourceExists(psServiceTopologyResource, this.GetServiceTopology);
        }

        internal PSServiceResource PutService(PSServiceResource psServiceResource)
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            var serviceResource = _client.Services.Create(
                psServiceResource.ResourceGroupName, 
                psServiceResource.ServiceTopologyName, 
                psServiceResource.Name, 
                psServiceResource.ToSdkType());

            return new PSServiceResource(psServiceResource.ResourceGroupName, psServiceResource.ServiceTopologyName, serviceResource);
        }

        internal bool ServiceExists(PSServiceResource psServiceResource)
        {
            return DeploymentManagerClient.ResourceExists(psServiceResource, this.GetService);
        }

        internal PSStepResource PutStep(PSStepResource psStepResource)
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            var stepResource = _client.Steps.Create(
                psStepResource.ResourceGroupName,
                psStepResource.Name,
                psStepResource.ToSdkType());

            return new PSStepResource(psStepResource.ResourceGroupName, stepResource);
        }

        internal PSServiceUnitResource PutServiceUnit(
            PSServiceUnitResource psServiceUnitResource)
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            var serviceUnitResource = _client.ServiceUnits.Create(
                psServiceUnitResource.ResourceGroupName, 
                psServiceUnitResource.ServiceTopologyName, 
                psServiceUnitResource.ServiceName, 
                psServiceUnitResource.Name, 
                psServiceUnitResource.ToSdkType());

            return new PSServiceUnitResource(
                psServiceUnitResource.ResourceGroupName,
                psServiceUnitResource.ServiceTopologyName,
                psServiceUnitResource.ServiceName,
                serviceUnitResource);
        }

        internal bool ServiceUnitExists(PSServiceUnitResource psServiceUnitResource)
        {
            return DeploymentManagerClient.ResourceExists(psServiceUnitResource, this.GetServiceUnit);
        }

        internal PSServiceTopologyResource GetServiceTopology(PSServiceTopologyResource pSServiceTopologyResource)
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            var serviceTopologyResource = _client.ServiceTopologies.Get(pSServiceTopologyResource.ResourceGroupName, pSServiceTopologyResource.Name);
            return new PSServiceTopologyResource(pSServiceTopologyResource.ResourceGroupName, serviceTopologyResource);
        }

        internal PSServiceResource GetService(PSServiceResource pSServiceResource)
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            var serviceResource = _client.Services.Get(pSServiceResource.ResourceGroupName, pSServiceResource.ServiceTopologyName, pSServiceResource.Name);

            return new PSServiceResource(
                pSServiceResource.ResourceGroupName,
                pSServiceResource.ServiceTopologyName,
                serviceResource);
        }

        internal PSServiceUnitResource GetServiceUnit(PSServiceUnitResource psServiceUnit)
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            var serviceUnit = _client.ServiceUnits.Get(psServiceUnit.ResourceGroupName, psServiceUnit.ServiceTopologyName, psServiceUnit.ServiceName, psServiceUnit.Name);

            return new PSServiceUnitResource(
                psServiceUnit.ResourceGroupName,
                psServiceUnit.ServiceTopologyName,
                psServiceUnit.ServiceName,
                serviceUnit);
        }

        internal bool DeleteServiceTopology(PSServiceTopologyResource psServiceTopologyResource)
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            var result = _client.ServiceTopologies.DeleteWithHttpMessagesAsync(psServiceTopologyResource.ResourceGroupName, psServiceTopologyResource.Name).GetAwaiter().GetResult();
            return (result.Response.StatusCode == HttpStatusCode.OK || result.Response.StatusCode == HttpStatusCode.NoContent);
        }

        internal bool DeleteService(PSServiceResource psServiceResource)
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            var result = _client.Services.DeleteWithHttpMessagesAsync(psServiceResource.ResourceGroupName, psServiceResource.ServiceTopologyName, psServiceResource.Name).GetAwaiter().GetResult();
            return (result.Response.StatusCode == HttpStatusCode.OK || result.Response.StatusCode == HttpStatusCode.NoContent);
        }

        internal bool DeleteServiceUnit(PSServiceUnitResource psServiceUnitResource)
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            var result = _client.ServiceUnits.DeleteWithHttpMessagesAsync(
                psServiceUnitResource.ResourceGroupName, 
                psServiceUnitResource.ServiceTopologyName, 
                psServiceUnitResource.ServiceName, 
                psServiceUnitResource.Name).GetAwaiter().GetResult();
            return (result.Response.StatusCode == HttpStatusCode.OK || result.Response.StatusCode == HttpStatusCode.NoContent);
        }

        internal IList<Operation> GetOperations()
        {
            _resourceManagementClient.Providers.Register("Microsoft.DeploymentManager");

            return _client.Operations.Get();
        }

        private static bool ResourceExists<T>(T resourceObject, Func<T, T> getFunc) where T : PSResource
        {
            T retrievedServiceResource = null;
            try
            {
                retrievedServiceResource = getFunc(resourceObject);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }
            }

            return retrievedServiceResource != null;
        }
    }
}
