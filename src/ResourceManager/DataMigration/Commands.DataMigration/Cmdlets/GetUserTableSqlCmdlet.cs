// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetUserTableSqlCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Management.DataMigration;
using Microsoft.Azure.Management.DataMigration.Models;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class GetUserTableSqlCmdlet : TaskCmdlet
    {
        private readonly string SelectedDatabase = "SelectedDatabase";

        public GetUserTableSqlCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.SourceConnectionInfoParam(true);
            this.SimpleParam(SelectedDatabase, typeof(string[]), "List of database names to collect tables for", true);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            GetUserTablesSqlTaskProperties properties = new GetUserTablesSqlTaskProperties();

            if (MyInvocation.BoundParameters.ContainsKey(SourceConnection))
            {
                properties.Input = new GetUserTablesSqlTaskInput();
                properties.Input.ConnectionInfo = (SqlConnectionInfo)MyInvocation.BoundParameters[SourceConnection];
                PSCredential cred = (PSCredential)MyInvocation.BoundParameters[SourceCred];
                properties.Input.ConnectionInfo.UserName = cred.UserName;
                properties.Input.ConnectionInfo.Password = Decrypt(cred.Password);
                properties.Input.SelectedDatabases = ((string[])MyInvocation.BoundParameters[SelectedDatabase]).ToList();
            }
            else
            {
                throw new PSArgumentException("Invalid Argument List");
            }

            return properties;
        }
    }
}
