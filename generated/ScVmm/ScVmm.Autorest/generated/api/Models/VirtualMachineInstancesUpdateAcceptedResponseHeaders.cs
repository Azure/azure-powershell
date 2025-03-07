// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Extensions;

    public partial class VirtualMachineInstancesUpdateAcceptedResponseHeaders :
        Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IVirtualMachineInstancesUpdateAcceptedResponseHeaders,
        Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IVirtualMachineInstancesUpdateAcceptedResponseHeadersInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.IHeaderSerializable
    {

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Backing field for <see cref="RetryAfter" /> property.</summary>
        private int? _retryAfter;

        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public int? RetryAfter { get => this._retryAfter; set => this._retryAfter = value; }

        /// <param name="headers"></param>
        void Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.IHeaderSerializable.ReadHeaders(global::System.Net.Http.Headers.HttpResponseHeaders headers)
        {
            if (headers.TryGetValues("Location", out var __locationHeader0))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IVirtualMachineInstancesUpdateAcceptedResponseHeadersInternal)this).Location = System.Linq.Enumerable.FirstOrDefault(__locationHeader0) is string __headerLocationHeader0 ? __headerLocationHeader0 : (string)null;
            }
            if (headers.TryGetValues("Retry-After", out var __retryAfterHeader1))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IVirtualMachineInstancesUpdateAcceptedResponseHeadersInternal)this).RetryAfter = System.Linq.Enumerable.FirstOrDefault(__retryAfterHeader1) is string __headerRetryAfterHeader1 ? int.TryParse( __headerRetryAfterHeader1, out int __headerRetryAfterHeader1Value ) ? __headerRetryAfterHeader1Value : default(int?) : default(int?);
            }
        }

        /// <summary>
        /// Creates an new <see cref="VirtualMachineInstancesUpdateAcceptedResponseHeaders" /> instance.
        /// </summary>
        public VirtualMachineInstancesUpdateAcceptedResponseHeaders()
        {

        }
    }
    public partial interface IVirtualMachineInstancesUpdateAcceptedResponseHeaders

    {
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"Location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"Retry-After",
        PossibleTypes = new [] { typeof(int) })]
        int? RetryAfter { get; set; }

    }
    internal partial interface IVirtualMachineInstancesUpdateAcceptedResponseHeadersInternal

    {
        string Location { get; set; }

        int? RetryAfter { get; set; }

    }
}