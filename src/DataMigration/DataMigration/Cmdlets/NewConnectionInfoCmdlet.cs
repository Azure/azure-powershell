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

using System.Management.Automation;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    /// <summary>
    /// Class that creates a new instance of the Sql Server Connection Info.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataMigrationConnectionInfo"), OutputType(typeof(ConnectionInfo))]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DmsConnInfo")]
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
                    case ServerTypeEnum.MongoDb:
                        this.connCmdlet = new MongoDbConnectionInfoCmdlet(this.MyInvocation);
                        break;
                    case ServerTypeEnum.SQLMI:
                        this.connCmdlet = new MiSqlConnectionInfoCmdlet(this.MyInvocation);
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
