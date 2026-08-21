// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    public partial class ServersMigrateNetworkModeAcceptedResponseHeaders :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServersMigrateNetworkModeAcceptedResponseHeaders,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServersMigrateNetworkModeAcceptedResponseHeadersInternal,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IHeaderSerializable
    {

        /// <summary>Backing field for <see cref="XmsRequestId" /> property.</summary>
        private string _xmsRequestId;

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string XmsRequestId { get => this._xmsRequestId; set => this._xmsRequestId = value; }

        /// <param name="headers"></param>
        void Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IHeaderSerializable.ReadHeaders(global::System.Net.Http.Headers.HttpResponseHeaders headers)
        {
            if (headers.TryGetValues("x-ms-request-id", out var __xMSRequestIdHeader0))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServersMigrateNetworkModeAcceptedResponseHeadersInternal)this).XmsRequestId = System.Linq.Enumerable.FirstOrDefault(__xMSRequestIdHeader0) is string __headerXMSRequestIdHeader0 ? __headerXMSRequestIdHeader0 : (string)null;
            }
        }

        /// <summary>
        /// Creates an new <see cref="ServersMigrateNetworkModeAcceptedResponseHeaders" /> instance.
        /// </summary>
        public ServersMigrateNetworkModeAcceptedResponseHeaders()
        {

        }
    }
    public partial interface IServersMigrateNetworkModeAcceptedResponseHeaders

    {
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"x-ms-request-id",
        PossibleTypes = new [] { typeof(string) })]
        string XmsRequestId { get; set; }

    }
    internal partial interface IServersMigrateNetworkModeAcceptedResponseHeadersInternal

    {
        string XmsRequestId { get; set; }

    }
}