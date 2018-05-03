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
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Microsoft.Azure.Management.DataMigration.Models;

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
