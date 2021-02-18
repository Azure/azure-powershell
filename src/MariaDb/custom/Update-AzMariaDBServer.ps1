
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Updates an existing server. The request body can contain one to many of the properties present in the normal server definition. Use Update-AzMariaDbConfiguration instead if you want update server parameters such as wait_timeout or net_retry_count.
.Description
Updates an existing server. The request body can contain one to many of the properties present in the normal server definition. Use Update-AzMariaDbConfiguration instead if you want update server parameters such as wait_timeout or net_retry_count.
#>
function Update-AzMariaDbServer
{
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer])]
    [CmdletBinding(DefaultParameterSetName='ServerName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='ServerName', Mandatory, HelpMessage='MariaDB server name')]
        [Alias('ServerName')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # MariaDB server name.
        ${Name},
    
        [Parameter(ParameterSetName='ServerName', Mandatory, HelpMessage='The name of the resource group that contains the resource.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # The name of the resource group that contains the resource.
        # You can obtain this value from the Azure Resource Manager API or the portal.
        ${ResourceGroupName},
    
        [Parameter(ParameterSetName='ServerName', HelpMessage='The subscription ID is part of the URI for every service call')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets the subscription Id which uniquely identifies the Microsoft Azure subscription.
        # The subscription ID is part of the URI for every service call.
        ${SubscriptionId},
    
        [Parameter(ParameterSetName='ServerObject', Mandatory, ValueFromPipeline, HelpMessage='Identity Parameter')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},

        #region ServerUpdateParameters
        [Parameter(HelpMessage='The replication role of the server.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.String]
        # The replication role of the server.
        ${ReplicationRole},
    
        [Parameter(HelpMessage='The password of the administrator login.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.Security.SecureString]
        # The password of the administrator login which should be SecureString.
        ${AdministratorLoginPassword},

        [Parameter(HelpMessage='Enable ssl enforcement or not when connect to server.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum]
        # Enable ssl enforcement or not when connect to server.
        ${SslEnforcement},

        [Parameter(HelpMessage='Backup retention days for the server.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [int]
        # Backup retention days for the server.
        ${BackupRetentionDay},

        [Parameter(HelpMessage='Enable Geo-redundant or not for server backup.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup]
        # Enable Geo-redundant or not for server backup.
        ${GeoRedundantBackup},

        [Parameter(HelpMessage='Enable Storage Auto Grow.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow])]
        [Validateset('Enabled', 'Disabled')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow]
        # Enable Storage Auto Grow.
        ${StorageAutogrow},

        [Parameter(HelpMessage='Max storage allowed for a server.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [int]
        # Max storage allowed for a server.
        ${StorageInMb},

        [Parameter(HelpMessage='The name of the sku, typically, tier + family + cores, e.g. B_Gen4_1, GP_Gen5_8.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.String]
        # The name of the sku, typically, tier + family + cores, e.g. B_Gen4_1, GP_Gen5_8.
        ${Sku},

        [Parameter(HelpMessage='Application-specific metadata in the form of key-value pairs.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerUpdateParametersTags]))]
        [System.Collections.Hashtable]
        # Application-specific metadata in the form of key-value pairs.
        ${Tag},
        #endregion ServerUpdateParameters
    
        #region DefaultParameters
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
        #endregion DefaultParameters
    )
    
    process {
        try {
            if ($PSBoundParameters.ContainsKey('AdministratorLoginPassword')) {
                $PSBoundParameters['AdministratorLoginPassword'] = . "$PSScriptRoot/../utils/Unprotect-SecureString.ps1" $PSBoundParameters['AdministratorLoginPassword']
                $Null = $PSBoundParameters.Remove('AdministratorLoginPassword')
            }

            if ($PSBoundParameters.ContainsKey('Sku')) {
                $PSBoundParameters.Add('SkuName', $PSBoundParameters['Sku'])
                $null = $PSBoundParameters.Remove('Sku')
            }

            if ($PSBoundParameters.ContainsKey('BackupRetentionDay')) {
                $PSBoundParameters.Add('StorageProfileBackupRetentionDay', $PSBoundParameters['BackupRetentionDay'])
                $null = $PSBoundParameters.Remove('BackupRetentionDay')
            }

            if ($PSBoundParameters.ContainsKey('GeoRedundantBackup')) {
                $PSBoundParameters.Add('StorageProfileGeoRedundantBackup', $PSBoundParameters['GeoRedundantBackup'])
                $null = $PSBoundParameters.Remove('GeoRedundantBackup')
            }

            if ($PSBoundParameters.ContainsKey('StorageAutogrow')) {
                $PSBoundParameters.Add('StorageProfileStorageAutogrow', $PSBoundParameters['StorageAutogrow'])
                $null = $PSBoundParameters.Remove('StorageAutogrow')
            }

            if ($PSBoundParameters.ContainsKey('StorageInMb')) {
                $PSBoundParameters.Add('StorageProfileStorageMb', $PSBoundParameters['StorageInMb'])
                $null = $PSBoundParameters.Remove('StorageInMb')
            }
    
            Az.MariaDb.internal\Update-AzMariaDbServer @PSBoundParameters
          } catch {
              throw
          }
    }
}
