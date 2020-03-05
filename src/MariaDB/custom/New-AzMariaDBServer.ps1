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
function New-AzMariaDbServer {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory, HelpMessage='MariaDb server name.')]
        [Alias('ServerName')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # MariaDb server name.
        ${Name},
    
        [Parameter(Mandatory, HelpMessage='The name of the resource group that contains the resource.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # The name of the resource group that contains the resource.
        # You can obtain this value from the Azure Resource Manager API or the portal.
        ${ResourceGroupName},

        [Parameter(HelpMessage='The subscription ID is part of the URI for every service call')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets the subscription Id which uniquely identifies the Microsoft Azure subscription.
        # The subscription ID is part of the URI for every service call.
        ${SubscriptionId},

        #region ServerForCreate
        [Parameter(Mandatory, HelpMessage='The location the resource resides in.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.String]
        # The location the resource resides in.
        ${Location},

        [Parameter(Mandatory, HelpMessage='The name of the sku, typically, tier + family + cores, e.g. B_Gen4_1, GP_Gen5_8.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.String]
        # The name of the sku, typically, tier + family + cores, e.g. B_Gen4_1, GP_Gen5_8.
        ${Sku},

        [Parameter(HelpMessage='Enable ssl enforcement or not when connect to server.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum]
        # Enable ssl enforcement or not when connect to server.
        ${SslEnforcement},

        [Parameter(HelpMessage='Backup retention days for the server.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [int]
        # Backup retention days for the server
        ${StorageProfileBackupRetentionDay},

        [Parameter(HelpMessage='Enable Geo-redundant or not for server backup.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup]
        # Enable Geo-redundant or not for server backup.
        ${StorageProfileGeoRedundantBackup},

        [Parameter(HelpMessage='Enable Storage Auto Grow.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow]
        # Enable Storage Auto Grow.
        ${StorageProfileStorageAutogrow},

        [Parameter(HelpMessage='Max storage allowed for a server.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [int]
        # Max storage allowed for a server.
        ${StorageProfileStorageMb},

        [Parameter(HelpMessage='Application-specific metadata in the form of key-value pairs.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerUpdateParametersTags]))]
        [System.Collections.Hashtable]
        # Application-specific metadata in the form of key-value pairs.
        ${Tag},

        [Parameter(HelpMessage='Server version.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion]
        # Server version
        ${Version},
        #endregion ServerForCreate

        #region ServerPropertiesForDefaultCreate
        [Parameter(Mandatory, HelpMessage='Username of administrator.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.String]
        # Username of administrator.
        ${AdministratorUsername},
    
        [Parameter(Mandatory, HelpMessage='Password of administrator, should be SecureString.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.Security.SecureString]
        # Password of administrator, should be SecureString.
        ${AdministratorLoginPassword},
        #endregion ServerPropertiesForDefaultCreate
        
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
            $Parameter = [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerForCreate]::new()
            $Parameter.Property = [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerPropertiesForDefaultCreate]::new()

            #region ServerForCreate
            if ($PSBoundParameters.ContainsKey('Location')) {
                $Parameter.Location = $PSBoundParameters['Location']
                $null = $PSBoundParameters.Remove('Location')
            }

            if ($PSBoundParameters.ContainsKey('Sku')) {
                $Parameter.Sku = $PSBoundParameters['Sku']
                $null = $PSBoundParameters.Remove('Sku')
            }

            if ($PSBoundParameters.ContainsKey('SslEnforcement')) {
                $Parameter.SslEnforcement = $PSBoundParameters['SslEnforcement']
                $null = $PSBoundParameters.Remove('SslEnforcement')
            }
            else
            {
                $Parameter.SslEnforcement = [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum]::Enable
            }

            if ($PSBoundParameters.ContainsKey('StorageProfileBackupRetentionDay')) {
                $Parameter.StorageProfileBackupRetentionDay = $PSBoundParameters['StorageProfileBackupRetentionDay']
                $null = $PSBoundParameters.Remove('StorageProfileBackupRetentionDay')
            }

            if ($PSBoundParameters.ContainsKey('StorageProfileGeoRedundantBackup')) {
                $Parameter.StorageProfileGeoRedundantBackup = $PSBoundParameters['StorageProfileGeoRedundantBackup']
                $null = $PSBoundParameters.Remove('StorageProfileGeoRedundantBackup')
            }

            if ($PSBoundParameters.ContainsKey('StorageProfileStorageAutogrow')) {
                $Parameter.StorageProfileStorageAutogrow = $PSBoundParameters['StorageProfileStorageAutogrow']
                $null = $PSBoundParameters.Remove('StorageProfileStorageAutogrow')
            }

            if ($PSBoundParameters.ContainsKey('StorageProfileStorageMb')) {
                $Parameter.StorageProfileStorageMb = $PSBoundParameters['StorageProfileStorageMb']
                $null = $PSBoundParameters.Remove('StorageProfileStorageMb')
            }

            if ($PSBoundParameters.ContainsKey('Tag')) {
                $Parameter.Tag = $PSBoundParameters['Tag']
                $null = $PSBoundParameters.Remove('Tag')
            }

            if ($PSBoundParameters.ContainsKey('Version')) {
                $Parameter.Version = $PSBoundParameters['Version']
                $null = $PSBoundParameters.Remove('Version')
            }
            #endregion ServerForCreate

            $Parameter.CreateMode = [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.CreateMode]::Default
            $Parameter.Property.AdministratorLogin = $PSBoundParameters['AdministratorUsername']
            $null = $PSBoundParameters.Remove('AdministratorUsername')

            $BSTR = [System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($PSBoundParameters['AdministratorLoginPassword'])
            $Parameter.Property.AdministratorLoginPassword = [System.Runtime.InteropServices.Marshal]::PtrToStringAuto($BSTR)
            $null = $PSBoundParameters.Remove('AdministratorLoginPassword')

            $null = $PSBoundParameters.Add('Parameter', $Parameter)
    
            Az.MariaDb.internal\New-AzMariaDbServer @PSBoundParameters
          } catch {
              throw
          }
    }
}
    