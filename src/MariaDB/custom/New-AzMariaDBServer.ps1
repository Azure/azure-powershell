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
<<<<<<< HEAD
<#
.Synopsis
Creates a new database.
.Description
Creates a new database.
.Example
To view examples, please use the -Online parameter with Get-Help or navigate to: https://docs.microsoft.com/en-us/powershell/module/az.mariadb/new-azmariadbserver
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IDatabase
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IDatabase
.Notes
COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IMariaDbIdentity>: Identity Parameter
  [ConfigurationName <String>]: The name of the server configuration.
  [DatabaseName <String>]: The name of the database.
  [FirewallRuleName <String>]: The name of the server firewall rule.
  [Id <String>]: Resource identity path
  [LocationName <String>]: The name of the location.
  [ResourceGroupName <String>]: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  [SecurityAlertPolicyName <SecurityAlertPolicyName?>]: The name of the security alert policy.
  [ServerName <String>]: The name of the server.
  [SubscriptionId <String>]: The subscription ID that identifies an Azure subscription.
  [VirtualNetworkRuleName <String>]: The name of the virtual network rule.

PARAMETER <IDatabase>: Represents a Database.
  [Charset <String>]: The charset of the database.
  [Collation <String>]: The collation of the database.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/new-azmariadbserver
#>
function New-AzMariaDBServer {
=======
function New-AzMariaDbServer {
>>>>>>> upstream/wyunchi/generate-mariadb
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Profile('latest-2019-04-30')]
    param(
<<<<<<< HEAD
        [Parameter(Mandatory)]
=======
        [Parameter(Mandatory, HelpMessage='MariaDb server name.')]
        [Alias('ServerName')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # MariaDb server name.
        ${Name},
    
<<<<<<< HEAD
        [Parameter(Mandatory)]
=======
        [Parameter(Mandatory, HelpMessage='The name of the resource group that contains the resource.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # The name of the resource group that contains the resource.
        # You can obtain this value from the Azure Resource Manager API or the portal.
        ${ResourceGroupName},
<<<<<<< HEAD
    
        [Parameter()]
=======

        [Parameter(HelpMessage='The subscription ID is part of the URI for every service call')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets the subscription Id which uniquely identifies the Microsoft Azure subscription.
        # The subscription ID is part of the URI for every service call.
        ${SubscriptionId},

        #region ServerForCreate
<<<<<<< HEAD
        [Parameter(Mandatory)]
=======
        [Parameter(Mandatory, HelpMessage='The location the resource resides in.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.String]
        # The location the resource resides in.
        ${Location},

<<<<<<< HEAD
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [int]
        # The scale up/out capacity, representing server's compute units.
        ${SkuCapacity},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.String]
        # The family of hardware.
        ${SkuFamily},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SkuTier]
        # The tier of the particular SKU, e.g. Basic.
        ${SkuTier},

        [Parameter()]
=======
        [Parameter(Mandatory, HelpMessage='The name of the sku, typically, tier + family + cores, e.g. B_Gen4_1, GP_Gen5_8.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.String]
        # The name of the sku, typically, tier + family + cores, e.g. B_Gen4_1, GP_Gen5_8.
        ${SkuName},

<<<<<<< HEAD
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.String]
        # The size code, to be interpreted by resource as appropriate.
        ${SkuSize},

        [Parameter()]
=======
        [Parameter(HelpMessage='Enable ssl enforcement or not when connect to server.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum]
        # Enable ssl enforcement or not when connect to server.
        ${SslEnforcement},

<<<<<<< HEAD
        [Parameter()]
=======
        [Parameter(HelpMessage='Backup retention days for the server.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [int]
        # Backup retention days for the server
        ${StorageProfileBackupRetentionDay},

<<<<<<< HEAD
        [Parameter()]
=======
        [Parameter(HelpMessage='Enable Geo-redundant or not for server backup.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup]
        # Enable Geo-redundant or not for server backup.
        ${StorageProfileGeoRedundantBackup},

<<<<<<< HEAD
        [Parameter()]
=======
        [Parameter(HelpMessage='Enable Storage Auto Grow.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow]
        # Enable Storage Auto Grow.
        ${StorageProfileStorageAutogrow},

<<<<<<< HEAD
        [Parameter()]
=======
        [Parameter(HelpMessage='Max storage allowed for a server.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [int]
        # Max storage allowed for a server.
        ${StorageProfileStorageMb},

<<<<<<< HEAD
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion]
        # Application-specific metadata in the form of key-value pairs.
        ${Tag},

        [Parameter()]
=======
        [Parameter(HelpMessage='Application-specific metadata in the form of key-value pairs.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerUpdateParametersTags]))]
        [System.Collections.Hashtable]
        # Application-specific metadata in the form of key-value pairs.
        ${Tag},

        [Parameter(HelpMessage='Server version.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion]
        # Server version
        ${Version},
        #endregion ServerForCreate

        #region ServerPropertiesForDefaultCreate
<<<<<<< HEAD
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.String]
        # The mode to create a new server.
        ${AdministratorLogin},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.Security.SecureString]
        # The mode to create a new server.
        ${AdministratorLoginPassword},
    
=======
        [Parameter(Mandatory, HelpMessage='Username of administrator.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.String]
        # Username of administrator.
        ${AdministratorLogin},
    
        [Parameter(Mandatory, HelpMessage='Password of administrator, should be SecureString.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.Security.SecureString]
        # Password of administrator, should be SecureString.
        ${AdministratorLoginPassword},
>>>>>>> upstream/wyunchi/generate-mariadb
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

<<<<<<< HEAD
            if ($PSBoundParameters.ContainsKey('SkuCapacity')) {
                $Parameter.SkuCapacity = $PSBoundParameters['SkuCapacity']
                $null = $PSBoundParameters.Remove('SkuCapacity')
            }

            if ($PSBoundParameters.ContainsKey('SkuFamily')) {
                $Parameter.SkuFamily = $PSBoundParameters['SkuFamily']
                $null = $PSBoundParameters.Remove('SkuFamily')
            }

            if ($PSBoundParameters.ContainsKey('SkuTier')) {
                $Parameter.SkuTier = $PSBoundParameters['SkuTier']
                $null = $PSBoundParameters.Remove('SkuTier')
            }

=======
>>>>>>> upstream/wyunchi/generate-mariadb
            if ($PSBoundParameters.ContainsKey('SkuName')) {
                $Parameter.SkuName = $PSBoundParameters['SkuName']
                $null = $PSBoundParameters.Remove('SkuName')
            }

<<<<<<< HEAD
            if ($PSBoundParameters.ContainsKey('SkuSize')) {
                $Parameter.SkuSize = $PSBoundParameters['SkuSize']
                $null = $PSBoundParameters.Remove('SkuSize')
            }

=======
>>>>>>> upstream/wyunchi/generate-mariadb
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
            $Parameter.Property.AdministratorLogin = $PSBoundParameters['AdministratorLogin']
            $null = $PSBoundParameters.Remove('AdministratorLogin')

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
    