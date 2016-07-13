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

using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.ScenarioTest.Mocks
{
    public class MockDeploymentClientFactory
    {
        public static ResourceManagementClient GetResourceClient(ResourceManagementClient wrapped)
        {
            var deployment = new Mock<IDeploymentOperations>();
            deployment.Setup(d => d.ValidateAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<Deployment>(), It.IsAny<CancellationToken>())).Returns(
                    (string resourceGroupName, string deploymentName, Deployment props, CancellationToken token) =>
                        Task.FromResult(new DeploymentValidateResponse
                        {
                            Error = null,
                            IsValid = true,
                            Properties = new DeploymentPropertiesExtended
                            {
                                CorrelationId = Guid.NewGuid().ToString(),
                                DebugSetting = props.Properties.DebugSetting,
                                DebugSettingResponse = props.Properties.DebugSetting,
                                Dependencies = new List<Dependency>(),
                                Duration = TimeSpan.FromSeconds(1),
                                Mode = props.Properties.Mode,
                                Outputs = string.Empty,
                                Parameters = props.Properties.Parameters,
                                ParametersLink = props.Properties.ParametersLink,
                                Providers = new List<Provider>
                                    {
                                        new Provider
                                        {
                                            Id = Guid.NewGuid().ToString(),
                                            Namespace = "Microsoft.Compute",
                                            RegistrationState = "Registered",
                                            RequestId = Guid.NewGuid().ToString(),
                                            ResourceTypes = null,
                                            StatusCode = HttpStatusCode.OK
                                        }
                                    }

                            },
                            RequestId = Guid.NewGuid().ToString(),
                            StatusCode = HttpStatusCode.OK
                        }));
            deployment.Setup(
                d => d.BeginDeletingAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(
                    (string resourceGroupName, string deploymentName, CancellationToken token) =>
                        wrapped.Deployments.BeginDeletingAsync(resourceGroupName, deploymentName, token));
            deployment.Setup(
                d => d.CancelAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(
                    (string resourceGroupName, string deploymentName, CancellationToken token) =>
                        wrapped.Deployments.CancelAsync(resourceGroupName, deploymentName, token));
            deployment.Setup(
                d => d.CheckExistenceAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(
                    (string resourceGroupName, string deploymentName, CancellationToken token) =>
                        wrapped.Deployments.CheckExistenceAsync(resourceGroupName, deploymentName, token));
            deployment.Setup(
                d =>
                    d.CreateOrUpdateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Deployment>(),
                        It.IsAny<CancellationToken>()))
                .Returns(
                    (string resourceGroupName, string deploymentName, Deployment depl, CancellationToken token) =>
                        wrapped.Deployments.CreateOrUpdateAsync(resourceGroupName, deploymentName, depl, token));
            deployment.Setup(
                d => d.DeleteAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(
                    (string resourceGroupName, string deploymentName, CancellationToken token) =>
                        wrapped.Deployments.DeleteAsync(resourceGroupName, deploymentName, token));
            deployment.Setup(
                d => d.GetAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(
                    (string resourceGroupName, string deploymentName, CancellationToken token) =>
                        wrapped.Deployments.GetAsync(resourceGroupName, deploymentName, token));
            deployment.Setup(
                d =>
                    d.ListAsync(It.IsAny<string>(), It.IsAny<DeploymentListParameters>(),
                        It.IsAny<CancellationToken>()))
                .Returns(
                    (string resourceGroupName, DeploymentListParameters list, CancellationToken token) =>
                        wrapped.Deployments.ListAsync(resourceGroupName, list, token));
            deployment.Setup(
                d => d.ListNextAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(
                    (string nextLink, CancellationToken token) =>
                        wrapped.Deployments.ListNextAsync(nextLink, token));
            var mockResource = new Mock<ResourceManagementClient>();
            mockResource.SetupGet(r => r.Deployments).Returns(deployment.Object);
            mockResource.SetupGet(r => r.Resources).Returns(wrapped.Resources);
            mockResource.SetupGet(r => r.DeploymentOperations).Returns(wrapped.DeploymentOperations);
            mockResource.SetupGet(r => r.ProviderOperationsMetadata).Returns(wrapped.ProviderOperationsMetadata);
            mockResource.SetupGet(r => r.Providers).Returns(wrapped.Providers);
            mockResource.SetupGet(r => r.ResourceGroups).Returns(wrapped.ResourceGroups);
            mockResource.SetupGet(r => r.ResourceProviderOperationDetails)
                .Returns(wrapped.ResourceProviderOperationDetails);
            mockResource.SetupGet(r => r.Tags).Returns(wrapped.Tags);

            return mockResource.Object;
        }
    }
}
