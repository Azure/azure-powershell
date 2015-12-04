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
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Moq;
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.Common
{
    /// <summary>
    /// This class simulates querying and updating hosted services.
    /// </summary>
    public class MockServicesHost
    {
        public class ServiceData
        {
            public string Name { get; set; }
            public DeploymentData ProductionDeployment { get; set; }
            public DeploymentData StagingDeployment { get; set; }

            public ServiceData AddDeployment(Action<DeploymentData> setter)
            {
                var data = new DeploymentData();
                setter(data);

                switch (data.Slot)
                {
                    case DeploymentSlot.Production:
                        ProductionDeployment = data;
                        break;
                    case DeploymentSlot.Staging:
                        StagingDeployment = data;
                        break;
                }
                return this;
            }
        }

        public class DeploymentData
        {
            public string Name { get; set; }
            public DeploymentSlot Slot { get; set; }
        }

        public IList<ServiceData> Services { get; private set; }

        public UpdatedDeploymentStatus? LastDeploymentStatusUpdate { get; set; }

        public MockServicesHost()
        {
            Services = new List<ServiceData>();
        }

        public MockServicesHost Add(Action<ServiceData> setter)
        {
            var service = new ServiceData();
            setter(service);
            Services.Add(service);
            return this;
        }

        public MockServicesHost Clear()
        {
            Services.Clear();
            return this;
        }

        public void InitializeMocks(Mock<ComputeManagementClient> mock)
        {
            mock.Setup(c => c.HostedServices.GetDetailedAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns((string s, CancellationToken cancellationToken) => CreateGetDetailedResponse(s));

            mock.Setup(c => c.Deployments.GetBySlotAsync(It.IsAny<string>(), It.IsAny<DeploymentSlot>(), It.IsAny<CancellationToken>()))
                .Returns((string serviceName, DeploymentSlot slot, CancellationToken cancellationToken) => CreateDeploymentGetResponse(serviceName, slot));

            mock.Setup(
                c =>
                c.Deployments.CreateAsync(
                    It.IsAny<string>(),
                    It.IsAny<DeploymentSlot>(),
                    It.IsAny<DeploymentCreateParameters>(),
                    It.IsAny<CancellationToken>()))
                .Callback(
                    (string name, DeploymentSlot slot, DeploymentCreateParameters createParameters, CancellationToken cancellationToken) =>
                    CreateDeployment(name, slot, createParameters))
                .Returns(CreateDeploymentCreateResponse);

            mock.Setup(c => c.ServiceCertificates.ListAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Tasks.FromResult<ServiceCertificateListResponse>(null));

            mock.Setup(c => c.Deployments.UpdateStatusByDeploymentSlotAsync(
                It.IsAny<string>(), It.IsAny<DeploymentSlot>(), It.IsAny<DeploymentUpdateStatusParameters>(), It.IsAny<CancellationToken>()))
                .Callback((string name, DeploymentSlot slot, DeploymentUpdateStatusParameters p, CancellationToken cancellationToken) =>
                {
                    LastDeploymentStatusUpdate = p.Status;
                })
                .Returns(CreateUpdateStatusResponse);
        }

        private Task<HostedServiceGetDetailedResponse> CreateGetDetailedResponse(string serviceName)
        {
            var service = Services.FirstOrDefault(s => s.Name == serviceName);
            Task<HostedServiceGetDetailedResponse> resultTask;

            if (service != null)
            {
                var response = new HostedServiceGetDetailedResponse
                {
                    ServiceName = service.Name,
                    StatusCode = HttpStatusCode.OK,
                };
                if (service.ProductionDeployment != null)
                {
                    response.Deployments.Add(CreateDeploymentResponse(service.ProductionDeployment));
                }

                if (service.StagingDeployment != null)
                {
                    response.Deployments.Add(CreateDeploymentResponse(service.StagingDeployment));
                }
                resultTask = Tasks.FromResult(response);
            }
            else
            {
                resultTask = Tasks.FromException<HostedServiceGetDetailedResponse>(ClientMocks.Make404Exception());
            }
            return resultTask;
        }

        private HostedServiceGetDetailedResponse.Deployment CreateDeploymentResponse(DeploymentData d)
        {
            if (d != null)
            {
                return new HostedServiceGetDetailedResponse.Deployment
                {
                    DeploymentSlot = d.Slot,
                    Name = d.Name,
                    Roles =
                    {
                        new Role
                        {
                            RoleName = "Role1"
                        }
                    }
                };
            }
            return null;
        }

        private Task<DeploymentGetResponse> CreateDeploymentGetResponse(string serviceName, DeploymentSlot slot)
        {
            var service = Services.FirstOrDefault(s => s.Name == serviceName);
            var failedResponse = Tasks.FromException<DeploymentGetResponse>(ClientMocks.Make404Exception());
            if (service == null)
            {
                return failedResponse;
            }

            if (slot == DeploymentSlot.Production && service.ProductionDeployment == null ||
                slot == DeploymentSlot.Staging && service.StagingDeployment == null)
            {
                return failedResponse;
            }

            var response = new DeploymentGetResponse
            {
                Name = serviceName,
                Configuration = "config",
                DeploymentSlot = slot,
                Status = DeploymentStatus.Starting,
                PersistentVMDowntime = new PersistentVMDowntime
                {
                    EndTime = DateTime.Now,
                    StartTime = DateTime.Now,
                    Status = "",
                },
                LastModifiedTime = DateTime.Now
            };

            return Tasks.FromResult(response);
        }

        private void CreateDeployment(string serviceName, DeploymentSlot slot,
                                      DeploymentCreateParameters createParameters)
        {
            var service = Services.First(s => s.Name == serviceName);
            service.AddDeployment(d =>
            {
                d.Name = createParameters.Name;
                d.Slot = slot;
            });
        }

        private Task<OperationStatusResponse> CreateDeploymentCreateResponse()
        {
            return Tasks.FromResult(new OperationStatusResponse
            {
                RequestId = "someid",
                StatusCode = HttpStatusCode.OK
            });
        }

        private Task<OperationStatusResponse> CreateUpdateStatusResponse()
        {
            return Tasks.FromResult(new OperationStatusResponse
            {
                Status = OperationStatus.InProgress
            });
        }
    }
}
