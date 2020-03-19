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
Restore a existing mariadb server from a backup with a timestamp.
.Description
Restore a existing mariadb server from a backup with a timestamp.
.Example
To view examples, please use the -Online parameter with Get-Help or navigate to: https://docs.microsoft.com/en-us/powershell/module/az.mariadb/restore-azmariadbserverwithgeo
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
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/restore-azmariadbserverwithgeo
#>
function Restore-AzMariaDBServerWithGeo {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer])]
    [CmdletBinding(DefaultParameterSetName='SourceServerId', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Profile('latest-2019-04-30')]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # MariaDb member name.
        ${Name},

        [Parameter(ParameterSetName='SourceServerId', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # The source server id to restore from.
        ${SourceServerId},

        [Parameter(ParameterSetName='ServerObject', Mandatory, ValueFromPipeline)]
=======
function Restore-AzMariaDbServerWithGeo
{
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer])]
    [CmdletBinding(DefaultParameterSetName='ServerName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Profile('latest-2019-04-30')]
    param(
        [Parameter(ParameterSetName='ServerName', Mandatory, HelpMessage='MariaDb server name.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # MariaDb server name.
        ${Name},

        [Parameter(ParameterSetName='ServerObject', Mandatory, ValueFromPipeline, HelpMessage='The source server object to restore from.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer]
        # The source server object to restore from.
        ${InputObject},
    
<<<<<<< HEAD
        [Parameter(Mandatory)]
=======
        [Parameter(ParameterSetName='ServerName', Mandatory, HelpMessage='You can obtain this value from the Azure Resource Manager API or the portal.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # The name of the resource group that contains the resource.
        # You can obtain this value from the Azure Resource Manager API or the portal.
        ${ResourceGroupName},
    
<<<<<<< HEAD
        [Parameter()]
=======
        [Parameter(HelpMessage='The subscription ID is part of the URI for every service call.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets the subscription Id which uniquely identifies the Microsoft Azure subscription.
        # The subscription ID is part of the URI for every service call.
        ${SubscriptionId},
    
        #region ServerForCreate
<<<<<<< HEAD
        [Parameter()]
=======
        [Parameter(HelpMessage='The location the resource resides in.')]
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
        [Parameter(HelpMessage='The name of the sku, typically, tier + family + cores, e.g. B_Gen4_1, GP_Gen5_8.')]
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
=======
        [Parameter(HelpMessage='Application-specific metadata in the form of key-value pairs.')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerUpdateParametersTags]))]
        [System.Collections.Hashtable]
        # Application-specific metadata in the form of key-value pairs.
        ${Tag},
>>>>>>> upstream/wyunchi/generate-mariadb
        #endregion ServerForCreate

        #region GeoRestore
        #endregion

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
            $Parameter.Property = [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerPropertiesForGeoRestore]::new()

            #region ServerForCreate
<<<<<<< HEAD
            if ($PSBoundParameters.ContaineKey('Location')) {
=======
            if ($PSBoundParameters.ContainsKey('Location')) {
>>>>>>> upstream/wyunchi/generate-mariadb
                $Parameter.Location = $PSBoundParameters['Location']
                $Null = $PSBoundParameters.Remove('Location')
            } else {
                if ($PSBoundParameters.ContainsKey('SourceServerId')) {
                    $Parameter.Property.SourceServerId = $PSBoundParameters['SourceServerId']
                    
                    $FieldList = $PSBoundParameters['SourceServerId'].Split('/')
                    $InputObject = Get-AzMariadbServer -ResourceGroupName $FieldList[4] -ServerName $FieldList[8]
                    $Null = $PSBoundParameters.Remove('SourceServerId')
                }
                if ($PSBoundParameters.ContainsKey('InputObject')) {
                    $Parameter.Property.SourceServerId = $InputObject.Id
                    $Null = $PSBoundParameters.Remove('InputObject')
                }
                $Parameter.Location = $InputObject.Location
            }

<<<<<<< HEAD
            if ($PSBoundParameters.ContainsKey('SkuCapacity')) {
                $Parameter.SkuCapacity = $PSBoundParameters['SkuCapacity']
                $PSBoundParameters.Remove('SkuCapacity')
            }

            if ($PSBoundParameters.ContainsKey('SkuFamily')) {
                $Parameter.SkuFamily = $PSBoundParameters['SkuFamily']
                $PSBoundParameters.Remove('SkuFamily')
            }

            if ($PSBoundParameters.ContainsKey('SkuTier')) {
                $Parameter.SkuTier = $PSBoundParameters['SkuTier']
                $PSBoundParameters.Remove('SkuTier')
            }

=======
>>>>>>> upstream/wyunchi/generate-mariadb
            if ($PSBoundParameters.ContainsKey('SkuName')) {
                $Parameter.SkuName = $PSBoundParameters['SkuName']
                $PSBoundParameters.Remove('SkuName')
            }
<<<<<<< HEAD

            if ($PSBoundParameters.ContainsKey('SkuSize')) {
                $Parameter.SkuSize = $PSBoundParameters['SkuSize']
                $PSBoundParameters.Remove('SkuSize')
            }
=======
>>>>>>> upstream/wyunchi/generate-mariadb
            #endregion ServerForCreate

            $PSBoundParameters.Add('Parameter', $Parameter)
    
            Az.MariaDb.internal\New-AzMariaDbServer @PSBoundParameters
          } catch {
              throw
          }
    }
}
