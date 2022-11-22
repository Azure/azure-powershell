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

using Microsoft.Azure.PowerShell.Cmdlets.Ssh.AzureClients;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Ssh.Helpers.Compute;
using Microsoft.Azure.PowerShell.Ssh.Helpers.HybridCompute;
using Microsoft.Azure.PowerShell.Ssh.Helpers.HybridCompute.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.PowerShell.Cmdlets.Ssh.Common
{
    /// <summary>
    /// Utils class to determine the Azure Resource Type of Target Machines.
    /// </summary>
    internal class ResourceTypeUtils
    {
        #region fields
        private IAzureContext _context;
        private ComputeClient _computeClient;
        private HybridComputeClient _hybridComputeClient;
        #endregion

        #region Properties
   
        private ComputeClient ComputeClient
        {
            get
            {
                if (_computeClient == null)
                {
                    _computeClient = new ComputeClient(_context);
                }
                return _computeClient;
            }
        }

        private HybridComputeClient HybridComputeClient
        {
            get
            {
                if (_hybridComputeClient == null)
                {
                    _hybridComputeClient = new HybridComputeClient(_context);
                }
                return _hybridComputeClient;
            }
        }

        private IVirtualMachinesOperations VirtualMachineClient
        {
            get
            {
                return ComputeClient.ComputeManagementClient.VirtualMachines;
            }
        }

        private IMachinesOperations ArcMachineClient
        {
            get
            {
                return HybridComputeClient.HybridComputeManagementClient.Machines;
            }
        }
        #endregion

        public ResourceTypeUtils(IAzureContext context)
        {
            _context = context;
        }

        #region Internal Methods
        internal string GetResourceType(
           string vmName,
           string rgName,
           string resourceType,
           out string exceptionMessage)
        {

            if (resourceType != null)
            {
                return ConfirmResourceType(vmName, rgName, resourceType, out exceptionMessage);
            }

            exceptionMessage = "";

            System.Net.HttpStatusCode _computeExceptionCode;
            System.Net.HttpStatusCode _hybridExceptionCode;

            bool _isArc = TryArcServer(vmName, rgName, out _hybridExceptionCode);
            bool _isAzVM = TryAzureVM(vmName, rgName, out _computeExceptionCode);

            if (_isArc && _isAzVM)
            {
                exceptionMessage = $"There exists an Azure VM and an Arc Server with the same name {vmName} under the resource group {rgName}. " +
                    $"Please specify the target Resource Type using -ResourceType";
                return null;
            }

            if (!_isArc && !_isAzVM)
            {
                exceptionMessage = $"{GetNotFoundOrForbbiddenExceptionMessage(_computeExceptionCode, "Microsoft.Compute/virtualMachines", rgName, vmName)} " +
                    $"And {GetNotFoundOrForbbiddenExceptionMessage(_hybridExceptionCode, "Microsoft.HybridCompute/machines", rgName, vmName)}";
                return null;
            }
            
            if (_isArc)
            {
                return "Microsoft.HybridCompute/machines";
            }

            return "Microsoft.Compute/virtualMachines";

        }
        #endregion

        #region Private Methods
               
        /// <summary>
        /// This method confirms if the Resource Type passed in by the user is a valid resource.
        /// </summary>
        /// <param name="vmName"></param>
        /// <param name="rgName"></param>
        /// <param name="resourceType"></param>
        /// <param name="exceptionMessage"></param>
        /// <returns></returns>
        private string ConfirmResourceType(
            string vmName,
            string rgName,
            string resourceType,
            out string exceptionMessage)
        {
            exceptionMessage = "";
            System.Net.HttpStatusCode exceptionCode;

            if (resourceType.Equals("Microsoft.HybridCompute/machines"))
            {
                if (TryArcServer(vmName, rgName, out exceptionCode))
                {
                    return "Microsoft.HybridCompute/machines";
                }
            }
            else
            {
                if (TryAzureVM(vmName, rgName, out exceptionCode))
                {
                    return "Microsoft.Compute/virtualMachines";
                }
            }

            exceptionMessage = GetNotFoundOrForbbiddenExceptionMessage(exceptionCode, resourceType, rgName, vmName);
            
            return null;
        }

        private string GetNotFoundOrForbbiddenExceptionMessage(System.Net.HttpStatusCode code, string resourceType, string rgName, string vmName)
        {
            string exceptionMessage = "";

            if (code == System.Net.HttpStatusCode.NotFound)
            {
                exceptionMessage = $"The Resource {resourceType}/{vmName} under resource group '{rgName}' was not found.";
            }
            else if (code == System.Net.HttpStatusCode.Forbidden)
            {
                //double check if this is the message
                exceptionMessage = $"Access to resource {resourceType}/{vmName} under resource group '{rgName}' is Forbidden.";
            }

            return exceptionMessage;
        }

        private bool TryArcServer(
            string vmName,
            string rgName,
            out System.Net.HttpStatusCode azexception)
        {
            azexception = System.Net.HttpStatusCode.OK;
            
            try
            {
                var result = this.ArcMachineClient.GetWithHttpMessagesAsync(
                    rgName, vmName).GetAwaiter().GetResult();
            }
            catch (ErrorResponseException exception)
            {
                // Either the Resource doesn't exist, or the user doesn't have permission
                // to access the arc servers on that resource group.
                // In that case, the user is probably trying to connect to an Azure VM.
                if (exception.Response.StatusCode == System.Net.HttpStatusCode.NotFound ||
                    exception.Response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    azexception = exception.Response.StatusCode;
                    return false;
                }

                // Unexpected exception we can't handle.
                throw;
            }

            return true;
        }

        private bool TryAzureVM(
            string vmName,
            string rgName,
            out System.Net.HttpStatusCode azexception)
        {
            azexception = System.Net.HttpStatusCode.OK;

            try
            {
                var result = this.VirtualMachineClient.GetWithHttpMessagesAsync(
                    rgName, vmName).GetAwaiter().GetResult();
            }
            catch (CloudException exception)
            {
                // Either the Resource doesn't exist, or the user doesn't have permission
                // to access the Azure VMs on that resource group.
                // In that case, the user is probably trying to connect to an Arc Server.
                if (exception.Response.StatusCode == System.Net.HttpStatusCode.NotFound ||
                    exception.Response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    azexception = exception.Response.StatusCode;
                    return false;
                }

                // Unexpected exception we can't handle.
                throw;
            }

            return true;
        }
        #endregion

    }
}
