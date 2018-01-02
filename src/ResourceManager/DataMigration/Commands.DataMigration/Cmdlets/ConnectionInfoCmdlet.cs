// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectionInfoCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Management.DataMigration.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public abstract class ConnectionInfoCmdlet : DynamicCmdlet
    {
        public ConnectionInfoCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public abstract ConnectionInfo ProcessConnectionInfoCmdlet();

    }
}
