// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Management.DataMigration;
using Microsoft.Azure.Management.DataMigration.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public abstract class TaskCmdlet : DynamicCmdlet
    {
        protected readonly string SourceConnection = "SourceConnection";
        protected readonly string SourceCred = "SourceCred";
        protected readonly string TargetConnection = "TargetConnection";
        protected readonly string TargetCred = "TargetCred";

        public TaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public abstract ProjectTaskProperties ProcessTaskCmdlet();

        protected void SourceConnectionInfoParam(bool mandatory = false)
        {
            this.SimpleParam(SourceConnection, typeof(ConnectionInfo), "Connection Info Detail", mandatory);
            this.SimpleParam(SourceCred, typeof(PSCredential), "Credential Detail", mandatory);
        }

        protected void TargetConnectionInfoParam(bool mandatory = false)
        {
            this.SimpleParam(TargetConnection, typeof(ConnectionInfo), "Connection Info Detail", mandatory);
            this.SimpleParam(TargetCred, typeof(PSCredential), "Credential Detail", mandatory);
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        internal static string Decrypt(SecureString secureString)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
