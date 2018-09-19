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
using System.ServiceModel.Channels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.CloudService
{
    /// <summary>
    /// Simple implementation of the IServiceManagement interface that can be
    /// used for mocking basic interactions without involving Azure directly.
    /// </summary>
    public class SimpleServiceManagement : IServiceManagement
    {
        /// <summary>
        /// Gets or sets a value indicating whether the thunk wrappers will
        /// throw an exception if the thunk is not implemented.  This is useful
        /// when debugging a test.
        /// </summary>
        public bool ThrowsIfNotImplemented { get; set; }

        /// <summary>
        /// Initializes a new instance of the SimpleServiceManagement class.
        /// </summary>
        public SimpleServiceManagement()
        {
            ThrowsIfNotImplemented = true;
        }

        #region AddCertificates
        public Action<SimpleServiceManagementAsyncResult> AddCertificatesThunk { get; set; }
        public IAsyncResult BeginAddCertificates(string subscriptionId, string serviceName, CertificateFile input, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["input"] = input;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndAddCertificates(IAsyncResult asyncResult)
        {
            if (AddCertificatesThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                AddCertificatesThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("AddCertificatesThunk is not implemented!");
            }
        }

        #endregion

        #region DeleteCertificate

        public Action<SimpleServiceManagementAsyncResult> DeleteCertificateThunk { get; set; }

        public IAsyncResult BeginDeleteCertificate(string subscriptionId, string serviceName, string thumbprintAlgorithm, string thumbprintInHex, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["thumbprintalgorithm"] = thumbprintAlgorithm;
            result.Values["thumbprintInHex"] = thumbprintInHex;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndDeleteCertificate(IAsyncResult asyncResult)
        {
            if (DeleteCertificateThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                DeleteCertificateThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("DeleteCertificateThunk is not implemented!");
            }
        }

        #endregion

        #region GetCertificate

        public Func<SimpleServiceManagementAsyncResult, Certificate> GetCertificateThunk { get; set; }
        
        public IAsyncResult BeginGetCertificate(string subscriptionId, string serviceName, string thumbprintAlgorithm, string thumbprintInHex, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["thumbprintAlgorithm"] = thumbprintAlgorithm;
            result.Values["thumbprintInHex"] = thumbprintInHex;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public Certificate EndGetCertificate(IAsyncResult asyncResult)
        {
            if (GetCertificateThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                return GetCertificateThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetCertificateThunk is not implemented!");
            }

            return default(Certificate);
        }

        #endregion

        #region ListCertificates

        public Func<SimpleServiceManagementAsyncResult, CertificateList> ListCertificatesThunk { get; set; }

        public void EndDeleteDiskEx(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginListCertificates(string subscriptionId, string serviceName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public CertificateList EndListCertificates(IAsyncResult asyncResult)
        {
            CertificateList certificates = default(CertificateList);
            if (ListCertificatesThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                return ListCertificatesThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("ListCertificatesThunk is not implemented!");
            }

            return certificates;
        }
        #endregion

        #region Autogenerated Thunks

        #region ChangeConfiguration

        public Action<SimpleServiceManagementAsyncResult> ChangeConfigurationThunk { get; set; }

        public IAsyncResult BeginChangeConfiguration(string subscriptionId, string serviceName, string deploymentName, ChangeConfigurationInput input, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["deploymentName"] = deploymentName;
            result.Values["input"] = input;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndChangeConfiguration(IAsyncResult asyncResult)
        {
            if (ChangeConfigurationThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                ChangeConfigurationThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("ChangeConfigurationThunk is not implemented!");
            }
        }
        #endregion ChangeConfiguration

        #region ChangeConfigurationBySlot
        public Action<SimpleServiceManagementAsyncResult> ChangeConfigurationBySlotThunk { get; set; }

        public IAsyncResult BeginChangeConfigurationBySlot(string subscriptionId, string serviceName, string deploymentSlot, ChangeConfigurationInput input, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["deploymentSlot"] = deploymentSlot;
            result.Values["input"] = input;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndChangeConfigurationBySlot(IAsyncResult asyncResult)
        {
            if (ChangeConfigurationBySlotThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                ChangeConfigurationBySlotThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("ChangeConfigurationBySlotThunk is not implemented!");
            }
        }
        #endregion ChangeConfigurationBySlot

        #region UpdateDeploymentStatus
        public Action<SimpleServiceManagementAsyncResult> UpdateDeploymentStatusThunk { get; set; }

        public IAsyncResult BeginUpdateDeploymentStatus(string subscriptionId, string serviceName, string deploymentName, UpdateDeploymentStatusInput input, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["deploymentName"] = deploymentName;
            result.Values["input"] = input;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndUpdateDeploymentStatus(IAsyncResult asyncResult)
        {
            if (UpdateDeploymentStatusThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                UpdateDeploymentStatusThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("UpdateDeploymentStatusThunk is not implemented!");
            }
        }
        #endregion UpdateDeploymentStatus

        #region UpdateDeploymentStatusBySlot
        public Action<SimpleServiceManagementAsyncResult> UpdateDeploymentStatusBySlotThunk { get; set; }

        public IAsyncResult BeginUpdateDeploymentStatusBySlot(string subscriptionId, string serviceName, string deploymentSlot, UpdateDeploymentStatusInput input, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["deploymentSlot"] = deploymentSlot;
            result.Values["input"] = input;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndUpdateDeploymentStatusBySlot(IAsyncResult asyncResult)
        {
            if (UpdateDeploymentStatusBySlotThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                UpdateDeploymentStatusBySlotThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("UpdateDeploymentStatusBySlotThunk is not implemented!");
            }
        }
        #endregion UpdateDeploymentStatusBySlot

        #region UpgradeDeployment
        public Action<SimpleServiceManagementAsyncResult> UpgradeDeploymentThunk { get; set; }

        public IAsyncResult BeginUpgradeDeployment(string subscriptionId, string serviceName, string deploymentName, UpgradeDeploymentInput input, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["deploymentName"] = deploymentName;
            result.Values["input"] = input;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndUpgradeDeployment(IAsyncResult asyncResult)
        {
            if (UpgradeDeploymentThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                UpgradeDeploymentThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("UpgradeDeploymentThunk is not implemented!");
            }
        }
        #endregion UpgradeDeployment

        #region UpgradeDeploymentBySlot
        public Action<SimpleServiceManagementAsyncResult> UpgradeDeploymentBySlotThunk { get; set; }

        public IAsyncResult BeginUpgradeDeploymentBySlot(string subscriptionId, string serviceName, string deploymentSlot, UpgradeDeploymentInput input, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["deploymentSlot"] = deploymentSlot;
            result.Values["input"] = input;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndUpgradeDeploymentBySlot(IAsyncResult asyncResult)
        {
            if (UpgradeDeploymentBySlotThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                UpgradeDeploymentBySlotThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("UpgradeDeploymentBySlotThunk is not implemented!");
            }
        }
        #endregion UpgradeDeploymentBySlot

        #region WalkUpgradeDomain
        public Action<SimpleServiceManagementAsyncResult> WalkUpgradeDomainThunk { get; set; }

        public IAsyncResult BeginWalkUpgradeDomain(string subscriptionId, string serviceName, string deploymentName, WalkUpgradeDomainInput input, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["deploymentName"] = deploymentName;
            result.Values["input"] = input;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndWalkUpgradeDomain(IAsyncResult asyncResult)
        {
            if (WalkUpgradeDomainThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                WalkUpgradeDomainThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("WalkUpgradeDomainThunk is not implemented!");
            }
        }
        #endregion WalkUpgradeDomain

        #region WalkUpgradeDomainBySlot
        public Action<SimpleServiceManagementAsyncResult> WalkUpgradeDomainBySlotThunk { get; set; }

        public IAsyncResult BeginWalkUpgradeDomainBySlot(string subscriptionId, string serviceName, string deploymentSlot, WalkUpgradeDomainInput input, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["deploymentSlot"] = deploymentSlot;
            result.Values["input"] = input;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndWalkUpgradeDomainBySlot(IAsyncResult asyncResult)
        {
            if (WalkUpgradeDomainBySlotThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                WalkUpgradeDomainBySlotThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("WalkUpgradeDomainBySlotThunk is not implemented!");
            }
        }
        #endregion WalkUpgradeDomainBySlot

        #region RebootDeploymentRoleInstance
        public Action<SimpleServiceManagementAsyncResult> RebootDeploymentRoleInstanceThunk { get; set; }

        public IAsyncResult BeginRebootDeploymentRoleInstance(string subscriptionId, string serviceName, string deploymentName, string roleInstanceName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["deploymentName"] = deploymentName;
            result.Values["roleInstanceName"] = roleInstanceName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndRebootDeploymentRoleInstance(IAsyncResult asyncResult)
        {
            if (RebootDeploymentRoleInstanceThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                RebootDeploymentRoleInstanceThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("RebootDeploymentRoleInstanceThunk is not implemented!");
            }
        }
        #endregion RebootDeploymentRoleInstance

        #region ReimageDeploymentRoleInstance
        public Action<SimpleServiceManagementAsyncResult> ReimageDeploymentRoleInstanceThunk { get; set; }

        public IAsyncResult BeginReimageDeploymentRoleInstance(string subscriptionId, string serviceName, string deploymentName, string roleInstanceName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["deploymentName"] = deploymentName;
            result.Values["roleInstanceName"] = roleInstanceName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndReimageDeploymentRoleInstance(IAsyncResult asyncResult)
        {
            if (ReimageDeploymentRoleInstanceThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                ReimageDeploymentRoleInstanceThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("ReimageDeploymentRoleInstanceThunk is not implemented!");
            }
        }
        #endregion ReimageDeploymentRoleInstance

        #region RebootDeploymentRoleInstanceBySlot
        public Action<SimpleServiceManagementAsyncResult> RebootDeploymentRoleInstanceBySlotThunk { get; set; }

        public IAsyncResult BeginRebootDeploymentRoleInstanceBySlot(string subscriptionId, string serviceName, string deploymentSlot, string roleInstanceName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["deploymentSlot"] = deploymentSlot;
            result.Values["roleInstanceName"] = roleInstanceName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndRebootDeploymentRoleInstanceBySlot(IAsyncResult asyncResult)
        {
            if (RebootDeploymentRoleInstanceBySlotThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                RebootDeploymentRoleInstanceBySlotThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("RebootDeploymentRoleInstanceBySlotThunk is not implemented!");
            }
        }
        #endregion RebootDeploymentRoleInstanceBySlot

        #region ReimageDeploymentRoleInstanceBySlot
        public Action<SimpleServiceManagementAsyncResult> ReimageDeploymentRoleInstanceBySlotThunk { get; set; }

        public IAsyncResult BeginReimageDeploymentRoleInstanceBySlot(string subscriptionId, string serviceName, string deploymentSlot, string roleInstanceName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["deploymentSlot"] = deploymentSlot;
            result.Values["roleInstanceName"] = roleInstanceName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndReimageDeploymentRoleInstanceBySlot(IAsyncResult asyncResult)
        {
            if (ReimageDeploymentRoleInstanceBySlotThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                ReimageDeploymentRoleInstanceBySlotThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("ReimageDeploymentRoleInstanceBySlotThunk is not implemented!");
            }
        }
        #endregion ReimageDeploymentRoleInstanceBySlot

        #region UpdateHostedService
        public Action<SimpleServiceManagementAsyncResult> UpdateHostedServiceThunk { get; set; }

        public IAsyncResult BeginUpdateHostedService(string subscriptionId, string serviceName, UpdateHostedServiceInput input, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["input"] = input;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndUpdateHostedService(IAsyncResult asyncResult)
        {
            if (UpdateHostedServiceThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                UpdateHostedServiceThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("UpdateHostedServiceThunk is not implemented!");
            }
        }
        #endregion UpdateHostedService

        #region DeleteHostedService
        public Action<SimpleServiceManagementAsyncResult> DeleteHostedServiceThunk { get; set; }

        public IAsyncResult BeginDeleteHostedService(string subscriptionId, string serviceName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndDeleteHostedService(IAsyncResult asyncResult)
        {
            if (DeleteHostedServiceThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                DeleteHostedServiceThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("DeleteHostedServiceThunk is not implemented!");
            }
        }
        #endregion DeleteHostedService

        #region ListHostedServices
        public Func<SimpleServiceManagementAsyncResult, HostedServiceList> ListHostedServicesThunk { get; set; }

        public IAsyncResult BeginListHostedServices(string subscriptionId, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public HostedServiceList EndListHostedServices(IAsyncResult asyncResult)
        {
            HostedServiceList value = default(HostedServiceList);
            if (ListHostedServicesThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                value = ListHostedServicesThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("ListHostedServicesThunk is not implemented!");
            }

            return value;
        }
        #endregion ListHostedServices

        #region GetHostedService
        public Func<SimpleServiceManagementAsyncResult, HostedService> GetHostedServiceThunk { get; set; }

        public IAsyncResult BeginGetHostedService(string subscriptionId, string serviceName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public HostedService EndGetHostedService(IAsyncResult asyncResult)
        {
            HostedService value = default(HostedService);
            if (GetHostedServiceThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                value = GetHostedServiceThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetHostedServiceThunk is not implemented!");
            }

            return value;
        }
        #endregion GetHostedService

        #region GetHostedServiceWithDetails
        public Func<SimpleServiceManagementAsyncResult, HostedService> GetHostedServiceWithDetailsThunk { get; set; }

        public IAsyncResult BeginGetHostedServiceWithDetails(string subscriptionId, string serviceName, Boolean embedDetail, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["embedDetail"] = embedDetail;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public HostedService EndGetHostedServiceWithDetails(IAsyncResult asyncResult)
        {
            HostedService value = default(HostedService);
            if (GetHostedServiceWithDetailsThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                value = GetHostedServiceWithDetailsThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetHostedServiceWithDetailsThunk is not implemented!");
            }

            return value;
        }
        #endregion GetHostedServiceWithDetails

        #region ListLocations
        public Func<SimpleServiceManagementAsyncResult, LocationList> ListLocationsThunk { get; set; }

        public IAsyncResult BeginListLocations(string subscriptionId, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public LocationList EndListLocations(IAsyncResult asyncResult)
        {
            LocationList value = default(LocationList);
            if (ListLocationsThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                value = ListLocationsThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("ListLocationsThunk is not implemented!");
            }

            return value;
        }
        #endregion ListLocations

        #region SwapDeployment
        public Action<SimpleServiceManagementAsyncResult> SwapDeploymentThunk { get; set; }

        public IAsyncResult BeginSwapDeployment(string subscriptionId, string serviceName, SwapDeploymentInput input, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["input"] = input;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndSwapDeployment(IAsyncResult asyncResult)
        {
            if (SwapDeploymentThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                SwapDeploymentThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("SwapDeploymentThunk is not implemented!");
            }
        }
        #endregion SwapDeployment

        #region CreateOrUpdateDeployment
        public Action<SimpleServiceManagementAsyncResult> CreateOrUpdateDeploymentThunk { get; set; }

        public IAsyncResult BeginCreateOrUpdateDeployment(string subscriptionId, string serviceName, string deploymentSlot, CreateDeploymentInput input, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["deploymentSlot"] = deploymentSlot;
            result.Values["input"] = input;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndCreateOrUpdateDeployment(IAsyncResult asyncResult)
        {
            if (CreateOrUpdateDeploymentThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                CreateOrUpdateDeploymentThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("CreateOrUpdateDeploymentThunk is not implemented!");
            }
        }
        #endregion CreateOrUpdateDeployment

        #region DeleteDeployment
        public Action<SimpleServiceManagementAsyncResult> DeleteDeploymentThunk { get; set; }

        public IAsyncResult BeginDeleteDeployment(string subscriptionId, string serviceName, string deploymentName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["deploymentName"] = deploymentName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndDeleteDeployment(IAsyncResult asyncResult)
        {
            if (DeleteDeploymentThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                DeleteDeploymentThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("DeleteDeploymentThunk is not implemented!");
            }
        }
        #endregion DeleteDeployment

        #region DeleteDeploymentBySlot
        public Action<SimpleServiceManagementAsyncResult> DeleteDeploymentBySlotThunk { get; set; }

        public IAsyncResult BeginDeleteDeploymentBySlot(string subscriptionId, string serviceName, string deploymentSlot, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["deploymentSlot"] = deploymentSlot;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndDeleteDeploymentBySlot(IAsyncResult asyncResult)
        {
            if (DeleteDeploymentBySlotThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                DeleteDeploymentBySlotThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("DeleteDeploymentBySlotThunk is not implemented!");
            }
        }
        #endregion DeleteDeploymentBySlot

        #region GetDeployment
        public Func<SimpleServiceManagementAsyncResult, Deployment> GetDeploymentThunk { get; set; }

        public IAsyncResult BeginGetDeployment(string subscriptionId, string serviceName, string deploymentName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["deploymentName"] = deploymentName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public Deployment EndGetDeployment(IAsyncResult asyncResult)
        {
            Deployment value = default(Deployment);
            if (GetDeploymentThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                value = GetDeploymentThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetDeploymentThunk is not implemented!");
            }

            return value;
        }
        #endregion GetDeployment

        #region GetDeploymentBySlot
        public Func<SimpleServiceManagementAsyncResult, Deployment> GetDeploymentBySlotThunk { get; set; }

        public IAsyncResult BeginGetDeploymentBySlot(string subscriptionId, string serviceName, string deploymentSlot, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["deploymentSlot"] = deploymentSlot;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public Deployment EndGetDeploymentBySlot(IAsyncResult asyncResult)
        {
            Deployment value = default(Deployment);
            if (GetDeploymentBySlotThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                value = GetDeploymentBySlotThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetDeploymentBySlotThunk is not implemented!");
            }

            return value;
        }
        #endregion GetDeploymentBySlot

        #region ListOperatingSystems
        public Func<SimpleServiceManagementAsyncResult, OperatingSystemList> ListOperatingSystemsThunk { get; set; }

        public IAsyncResult BeginListOperatingSystems(string subscriptionId, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public OperatingSystemList EndListOperatingSystems(IAsyncResult asyncResult)
        {
            OperatingSystemList value = default(OperatingSystemList);
            if (ListOperatingSystemsThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                value = ListOperatingSystemsThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("ListOperatingSystemsThunk is not implemented!");
            }

            return value;
        }
        #endregion ListOperatingSystems

        #region ListOperatingSystemFamilies
        public Func<SimpleServiceManagementAsyncResult, OperatingSystemFamilyList> ListOperatingSystemFamiliesThunk { get; set; }

        public IAsyncResult BeginListOperatingSystemFamilies(string subscriptionId, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public OperatingSystemFamilyList EndListOperatingSystemFamilies(IAsyncResult asyncResult)
        {
            OperatingSystemFamilyList value = default(OperatingSystemFamilyList);
            if (ListOperatingSystemFamiliesThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                value = ListOperatingSystemFamiliesThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("ListOperatingSystemFamiliesThunk is not implemented!");
            }

            return value;
        }
        #endregion ListOperatingSystemFamilies

        #region GetOperationStatus
        public Func<SimpleServiceManagementAsyncResult, Operation> GetOperationStatusThunk { get; set; }

        public OSImageDetails EndGetOSImageWithDetails(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginGetOperationStatus(string subscriptionId, string operationTrackingId, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["operationTrackingId"] = operationTrackingId;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public Operation EndGetOperationStatus(IAsyncResult asyncResult)
        {
            Operation value = default(Operation);
            if (GetOperationStatusThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                value = GetOperationStatusThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetOperationStatusThunk is not implemented!");
            }

            return value;
        }
        #endregion GetOperationStatus

        #region ListStorageServices
        public Func<SimpleServiceManagementAsyncResult, StorageServiceList> ListStorageServicesThunk { get; set; }

        public IAsyncResult BeginListStorageServices(string subscriptionId, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public StorageServiceList EndListStorageServices(IAsyncResult asyncResult)
        {
            StorageServiceList value = default(StorageServiceList);
            if (ListStorageServicesThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                value = ListStorageServicesThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("ListStorageServicesThunk is not implemented!");
            }

            return value;
        }
        #endregion ListStorageServices

        #region GetStorageService
        public Func<SimpleServiceManagementAsyncResult, StorageService> GetStorageServiceThunk { get; set; }

        public IAsyncResult BeginGetStorageService(string subscriptionId, string serviceName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public StorageService EndGetStorageService(IAsyncResult asyncResult)
        {
            StorageService value = default(StorageService);
            if (GetStorageServiceThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                value = GetStorageServiceThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetStorageServiceThunk is not implemented!");
            }

            return value;
        }
        #endregion GetStorageService

        #region GetStorageKeys
        public Func<SimpleServiceManagementAsyncResult, StorageService> GetStorageKeysThunk { get; set; }

        public IAsyncResult BeginGetStorageKeys(string subscriptionId, string serviceName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public StorageService EndGetStorageKeys(IAsyncResult asyncResult)
        {
            StorageService value = default(StorageService);
            if (GetStorageKeysThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                value = GetStorageKeysThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetStorageKeysThunk is not implemented!");
            }

            return value;
        }
        #endregion GetStorageKeys

        #region RegenerateStorageServiceKeys
        public Func<SimpleServiceManagementAsyncResult, StorageService> RegenerateStorageServiceKeysThunk { get; set; }

        public IAsyncResult BeginRegenerateStorageServiceKeys(string subscriptionId, string serviceName, RegenerateKeys regenerateKeys, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["regenerateKeys"] = regenerateKeys;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public StorageService EndRegenerateStorageServiceKeys(IAsyncResult asyncResult)
        {
            StorageService value = default(StorageService);
            if (RegenerateStorageServiceKeysThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                value = RegenerateStorageServiceKeysThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("RegenerateStorageServiceKeysThunk is not implemented!");
            }

            return value;
        }
        #endregion RegenerateStorageServiceKeys

        #region CreateStorageService
        public Action<SimpleServiceManagementAsyncResult> CreateStorageServiceThunk { get; set; }

        public IAsyncResult BeginCreateStorageService(string subscriptionId, CreateStorageServiceInput createStorageServiceInput, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["createStorageServiceInput"] = createStorageServiceInput;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndCreateStorageService(IAsyncResult asyncResult)
        {
            if (CreateStorageServiceThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                CreateStorageServiceThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("CreateStorageServiceThunk is not implemented!");
            }
        }
        #endregion CreateStorageService

        #region DeleteStorageService
        public Action<SimpleServiceManagementAsyncResult> DeleteStorageServiceThunk { get; set; }

        public IAsyncResult BeginDeleteStorageService(string subscriptionId, string StorageServiceName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["StorageServiceName"] = StorageServiceName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndDeleteStorageService(IAsyncResult asyncResult)
        {
            if (DeleteStorageServiceThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                DeleteStorageServiceThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("DeleteStorageServiceThunk is not implemented!");
            }
        }
        #endregion DeleteStorageService

        #region UpdateStorageService
        public Action<SimpleServiceManagementAsyncResult> UpdateStorageServiceThunk { get; set; }

        public IAsyncResult BeginUpdateStorageService(string subscriptionId, string StorageServiceName, UpdateStorageServiceInput updateStorageServiceInput, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["StorageServiceName"] = StorageServiceName;
            result.Values["updateStorageServiceInput"] = updateStorageServiceInput;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndUpdateStorageService(IAsyncResult asyncResult)
        {
            if (UpdateStorageServiceThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                UpdateStorageServiceThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("UpdateStorageServiceThunk is not implemented!");
            }
        }
        #endregion UpdateStorageService

        #region CreateAffinityGroup

        public Action<SimpleServiceManagementAsyncResult> CreateAffinityGroupThunk { get; set; }

        public IAsyncResult BeginCreateAffinityGroup(string subscriptionId, CreateAffinityGroupInput input, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["input"] = input;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndCreateAffinityGroup(IAsyncResult asyncResult)
        {
            if (CreateAffinityGroupThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                CreateAffinityGroupThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("CreateAffinityGroupThunk is not implemented!");
            }
        }

        #endregion

        #region DeleteAffinityGroup

        public Action<SimpleServiceManagementAsyncResult> DeleteAffinityGroupThunk { get; set; }

        public IAsyncResult BeginDeleteAffinityGroup(string subscriptionId, string affinityGroupName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["affinityGroupName"] = affinityGroupName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndDeleteAffinityGroup(IAsyncResult asyncResult)
        {
            if (DeleteAffinityGroupThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                DeleteAffinityGroupThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("DeleteAffinityGroupThunk is not implemented!");
            }
        }

        #endregion

        #region UpdateAffinityGroup

        public Action<SimpleServiceManagementAsyncResult> UpdateAffinityGroupThunk { get; set; }

        public IAsyncResult BeginUpdateAffinityGroup(string subscriptionId, string affinityGroupName, UpdateAffinityGroupInput input, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["affinityGroupName"] = affinityGroupName;
            result.Values["input"] = input;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndUpdateAffinityGroup(IAsyncResult asyncResult)
        {
            if (UpdateAffinityGroupThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                UpdateAffinityGroupThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("UpdateAffinityGroupThunk is not implemented!");
            }
        }

        #endregion

        #region ListAffinityGroups

        public Func<SimpleServiceManagementAsyncResult, AffinityGroupList> ListAffinityGroupsThunk { get; set; }

        public IAsyncResult BeginListAffinityGroups(string subscriptionId, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public AffinityGroupList EndListAffinityGroups(IAsyncResult asyncResult)
        {
            AffinityGroupList value = default(AffinityGroupList);
            if (ListAffinityGroupsThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                value = ListAffinityGroupsThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("ListAffinityGroupsThunk is not implemented!");
            }

            return value;
        }

        #endregion ListAffinityGroups

        #region GetAffinityGroup
        public Func<SimpleServiceManagementAsyncResult, AffinityGroup> GetAffinityGroupThunk { get; set; }

        public IAsyncResult BeginGetAffinityGroup(string subscriptionId, string affinityGroupName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["affinityGroupName"] = affinityGroupName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public AffinityGroup EndGetAffinityGroup(IAsyncResult asyncResult)
        {
            AffinityGroup value = default(AffinityGroup);
            if (GetAffinityGroupThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                value = GetAffinityGroupThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetAffinityGroupThunk is not implemented!");
            }

            return value;
        }
        #endregion GetAffinityGroup

        #region CreateHostedService
        public Action<SimpleServiceManagementAsyncResult> CreateHostedServiceThunk { get; set; }

        public IAsyncResult BeginCreateHostedService(string subscriptionId, CreateHostedServiceInput input, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["input"] = input;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndCreateHostedService(IAsyncResult asyncResult)
        {
            if (CreateHostedServiceThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                CreateHostedServiceThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("CreateHostedServiceThunk is not implemented!");
            }
        }
        #endregion CreateHostedService

        #endregion Autogenerated Thunks

        public IAsyncResult BeginCreateDeployment(string subscriptionId, string serviceName, Deployment deployment, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndCreateDeployment(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginResumeDeploymentUpdateOrUpgrade(string subscriptionId, string serviceName, string deploymentName, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndResumeDeploymentUpdateOrUpgrade(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginResumeDeploymentUpdateOrUpgradeBySlot(string subscriptionId, string serviceName, string deploymentSlot, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndResumeDeploymentUpdateOrUpgradeBySlot(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginSuspendDeploymentUpdateOrUpgrade(string subscriptionId, string serviceName, string deploymentName, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndSuspendDeploymentUpdateOrUpgrade(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginSuspendDeploymentUpdateOrUpgradeBySlot(string subscriptionId, string serviceName, string deploymentSlot, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndSuspendDeploymentUpdateOrUpgradeBySlot(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginRollbackDeploymentUpdateOrUpgrade(string subscriptionId, string serviceName, string deploymentName, RollbackUpdateOrUpgradeInput input, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndRollbackDeploymentUpdateOrUpgrade(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginRollbackDeploymentUpdateOrUpgradeBySlot(string subscriptionId, string serviceName, string deploymentSlot, RollbackUpdateOrUpgradeInput input, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndRollbackDeploymentUpdateOrUpgradeBySlot(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginGetPackage(string subscriptionId, string serviceName, string deploymentName, string containerUri, bool overwriteExisting, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndGetPackage(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginGetPackageBySlot(string subscriptionId, string serviceName, string deploymentSlot, string containerUri, bool overwriteExisting, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndGetPackageBySlot(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginListDisks(string subscriptionID, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public DiskList EndListDisks(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginCreateDisk(string subscriptionID, Disk disk, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public Disk EndCreateDisk(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginGetDisk(string subscriptionID, string diskName, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public Disk EndGetDisk(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUpdateDisk(string subscriptionID, string diskName, Disk disk, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public Disk EndUpdateDisk(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginDeleteDisk(string subscriptionID, string diskName, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndDeleteDisk(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginDeleteDiskEx(string subscriptionID, string diskName, string comp, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginAddRole(string subscriptionID, string serviceName, string deploymentName, Role role, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndAddRole(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginGetRole(string subscriptionID, string serviceName, string deploymentName, string roleName, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public Role EndGetRole(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUpdateRole(string subscriptionID, string serviceName, string deploymentName, string roleName, Role role, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndUpdateRole(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginDeleteRole(string subscriptionID, string serviceName, string deploymentName, string roleName, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndDeleteRole(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginAddDataDisk(string subscriptionID, string serviceName, string deploymentName, string roleName, DataVirtualHardDisk dataDisk, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndAddDataDisk(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUpdateDataDisk(string subscriptionID, string serviceName, string deploymentName, string roleName, string lun, DataVirtualHardDisk dataDisk, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndUpdateDataDisk(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginGetDataDisk(string subscriptionID, string serviceName, string deploymentName, string roleName, string lun, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public DataVirtualHardDisk EndGetDataDisk(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginDeleteDataDisk(string subscriptionID, string serviceName, string deploymentName, string roleName, string lun, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndDeleteDataDisk(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginExecuteRoleOperation(string subscriptionID, string serviceName, string deploymentName, string roleInstanceName, RoleOperation roleOperation, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndExecuteRoleOperation(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginDownloadRDPFile(string subscriptionID, string serviceName, string deploymentName, string instanceName, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public System.IO.Stream EndDownloadRDPFile(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public Func<SimpleServiceManagementAsyncResult, AvailabilityResponse> IsDNSAvailableThunk { get; set; }
        public IAsyncResult BeginIsDNSAvailable(string subscriptionId, string serviceName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;

            return result;
        }

        public AvailabilityResponse EndIsDNSAvailable(IAsyncResult asyncResult)
        {
            AvailabilityResponse availabilityResponse = new AvailabilityResponse();

            if (IsDNSAvailableThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                availabilityResponse = IsDNSAvailableThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("IsDNSAvailableThunk is not implemented!");
            }

            return availabilityResponse;
        }

        public IAsyncResult BeginSetNetworkConfiguration(string subscriptionId, System.IO.Stream networkConfiguration, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndSetNetworkConfiguration(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginGetNetworkConfiguration(string subscriptionId, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public System.IO.Stream EndGetNetworkConfiguration(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginListVirtualNetworkSites(string subscriptionId, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public VirtualNetworkSiteList EndListVirtualNetworkSites(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public void EndSetVirtualNetworkGatewayConfiguration(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginListOSImages(string subscriptionID, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public OSImageList EndListOSImages(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginCreateOSImage(string subscriptionID, OSImage image, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public OSImage EndCreateOSImage(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginGetOSImage(string subscriptionID, string imageName, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public OSImage EndGetOSImage(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUpdateOSImage(string subscriptionID, string imageName, OSImage image, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public OSImage EndUpdateOSImage(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginDeleteOSImage(string subscriptionID, string imageName, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndDeleteOSImage(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginDeleteOSImageEx(string subscriptionID, string imageName, string comp, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndDeleteOSImageEx(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginReplicateOSImage(string subscriptionID, string imageName, ReplicationInput replicationInput, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public string EndReplicateOSImage(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginShareOSImage(string subscriptionID, string imageName, string permission, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public bool EndShareOSImage(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUnReplicateOSImage(string subscriptionID, string imageName, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndUnReplicateOSImage(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginQueryOSImages(string subscriptionID, string location, string publisher, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public OSImageList EndQueryOSImages(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginGetOSImageWithDetails(string subscriptionID, string imageName, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public Func<SimpleServiceManagementAsyncResult, AvailabilityResponse> IsStorageServiceAvailableThunk { get; set; }
        public IAsyncResult BeginIsStorageServiceAvailable(string subscriptionId, string serviceName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionId"] = subscriptionId;
            result.Values["serviceName"] = serviceName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;

            return result;
        }

        public AvailabilityResponse EndIsStorageServiceAvailable(IAsyncResult asyncResult)
        {
            AvailabilityResponse availabilityResponse = new AvailabilityResponse();

            if (IsStorageServiceAvailableThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                availabilityResponse = IsStorageServiceAvailableThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("IsStorageServiceAvailableThunk is not implemented!");
            }

            return availabilityResponse;
        }

        public IAsyncResult BeginGetAzureWebsites(string subscriptionId, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndGetAzureWebsites(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginGetSubscription(string subscriptionID, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public Subscription EndGetSubscription(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginListSubscriptionOperations(string subscriptionID, string startTime, string endTime, string objectIdFilter, string operationResultFilter, string continuationToken, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public SubscriptionOperationCollection EndListSubscriptionOperations(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginProcessMessage(Message request, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public System.ServiceModel.Channels.Message EndProcessMessage(IAsyncResult result)
        {
            throw new NotImplementedException();
        }


        public IAsyncResult BeginAddHostedServiceExtension(string subscriptionId, string serviceName, HostedServiceExtensionInput extension, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginDeleteDeploymentVirtualIPs(string subscriptionId, string serviceName, string deploymentName, string vipGroupName, VirtualIPList vips, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginDeleteDeploymentVirtualIPsBySlot(string subscriptionId, string serviceName, string deploymentSlot, string vipGroupName, VirtualIPList vips, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginDeleteHostedServiceExtension(string subscriptionId, string serviceName, string extensionId, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginGetHostedServiceExtension(string subscriptionId, string serviceName, string extensionId, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginListHostedServiceExtensions(string subscriptionId, string serviceName, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginListLatestExtensions(string subscriptionId, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndAddHostedServiceExtension(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public void EndDeleteDeploymentVirtualIPs(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public void EndDeleteDeploymentVirtualIPsBySlot(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public void EndDeleteHostedServiceExtension(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public HostedServiceExtension EndGetHostedServiceExtension(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public HostedServiceExtensionList EndListHostedServiceExtensions(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public ExtensionImageList EndListLatestExtensions(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }


        public IAsyncResult BeginAddSubscriptionCertificate(string subscriptionId, SubscriptionCertificate Certificate, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginExecuteRoleSetOperation(string subscriptionID, string serviceName, string deploymentName, RoleSetOperation roleSetOperation, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginGetSubscriptionCertificate(string subscriptionID, string thumbprint, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginListSubscriptionCertificates(string subscriptionID, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginRemoveSubscriptionCertificate(string subscriptionID, string thumbprint, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUpdateLoadBalancedEndpointSet(string subscriptionID, string serviceName, string deploymentName, LoadBalancedEndpointList loadBalancedEndpointList, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndAddSubscriptionCertificate(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public void EndExecuteRoleSetOperation(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public SubscriptionCertificate EndGetSubscriptionCertificate(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public SubscriptionCertificateList EndListSubscriptionCertificates(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public void EndRemoveSubscriptionCertificate(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public void EndUpdateLoadBalancedEndpointSet(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }


        public IAsyncResult BeginRebuildDeploymentRoleInstance(string subscriptionId, string serviceName, string deploymentName, string roleInstanceName, string resources, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginRebuildDeploymentRoleInstanceBySlot(string subscriptionId, string serviceName, string deploymentSlot, string roleInstanceName, string resources, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndRebuildDeploymentRoleInstance(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public void EndRebuildDeploymentRoleInstanceBySlot(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }
    }
}