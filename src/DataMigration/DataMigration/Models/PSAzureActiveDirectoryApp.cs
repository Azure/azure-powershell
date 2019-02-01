// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSAzureActiveDirectoryApp.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Security;

namespace Microsoft.Azure.Commands.DataMigration.Models
{
    public class PSAzureActiveDirectoryApp
    {
        public PSAzureActiveDirectoryApp(string tenantId)
        {
            if (string.IsNullOrEmpty(tenantId))
            {
                throw new ArgumentNullException("TenantId");
            }

            this.TenantId = tenantId;
        }

        public string ApplicationId { get; set; }
        
        public SecureString AppKey { get; set; }

        public string TenantId { get; private set; }

    }
}