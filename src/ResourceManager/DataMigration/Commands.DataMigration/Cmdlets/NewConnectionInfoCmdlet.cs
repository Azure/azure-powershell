// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewConnectionInfoCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Management.DataMigration.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    /// <summary>
    /// Class that creates a new instance of the Sql Server Connection Info.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmDataMigrationConnectionInfo", SupportsShouldProcess = true), OutputType(typeof(ConnectionInfo))]
    [Alias("New-AzureRmDmsConnInfo")]
    public class NewConnectionInfoCmdlet : DataMigrationCmdlet, IDynamicParameters
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        public ServerTypeEnum ServerType
        {
            get
            {
                return serverType;
            }
            set
            {
                serverType = value;
                serverTypeSet = true;
            }
        }

        private ServerTypeEnum serverType;

        private bool serverTypeSet;

        private ConnectionInfoCmdlet connCmdlet = null;

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.ServerType.ToString(), Resources.createDbInfo))
            {
                base.ExecuteCmdlet();

                if (connCmdlet != null)
                {
                    WriteObject(connCmdlet.ProcessConnectionInfoCmdlet());
                }
                else
                {
                    throw new PSArgumentException("Invalid Argument List");
                }
            }
        }

        public object GetDynamicParameters()
        {
            RuntimeDefinedParameterDictionary dynamicParams = null;

            if (serverTypeSet)
            {
                ServerTypeEnum type = ServerType;
                switch (type)
                {
                    case ServerTypeEnum.SQL:
                        this.connCmdlet = new SqlConnectionInfoCmdlet(this.MyInvocation);
                        break;
                    default:
                        throw new PSArgumentException();
                }

                dynamicParams = connCmdlet.RuntimeDefinedParams;
            }

            return dynamicParams;
        }
    }
}
