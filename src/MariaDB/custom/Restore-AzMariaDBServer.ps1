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
To view examples, please use the -Online parameter with Get-Help or navigate to: https://docs.microsoft.com/en-us/powershell/module/az.mariadb/restore-azmariadbserver
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
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/restore-azmariadbserver
#>
function Restore-AzMariaDBServer {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer])]
    [CmdletBinding(DefaultParameterSetName='SourceServerId', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Profile('latest-2019-04-30')]
    param(
        [Parameter(Mandatory)]
=======
function Restore-AzMariaDbServer
{
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer])]
    [CmdletBinding(DefaultParameterSetName='ServerName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Profile('latest-2019-04-30')]
    param(
        [Parameter(ParameterSetName='ServerName', Mandatory)]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # MariaDb member name.
        ${Name},

<<<<<<< HEAD
        [Parameter(ParameterSetName='SourceServerId', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # The source server id to restore from.
        ${SourceServerId},

=======
>>>>>>> upstream/wyunchi/generate-mariadb
        [Parameter(ParameterSetName='ServerObject', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer]
        # The source server object to restore from.
        ${InputObject},
    
<<<<<<< HEAD
        [Parameter(Mandatory)]
=======
        [Parameter(ParameterSetName='ServerName', Mandatory)]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # The name of the resource group that contains the resource.
        # You can obtain this value from the Azure Resource Manager API or the portal.
        ${ResourceGroupName},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets the subscription Id which uniquely identifies the Microsoft Azure subscription.
        # The subscription ID is part of the URI for every service call.
        ${SubscriptionId},

<<<<<<< HEAD
=======
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerUpdateParametersTags]))]
        [System.Collections.Hashtable]
        # Application-specific metadata in the form of key-value pairs.
        ${Tag},

>>>>>>> upstream/wyunchi/generate-mariadb
        #region PointInTimeRestore
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.DateTime]
        # The location the resource resides in.
        ${RestorePointInTime},
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
            $Parameter.Property = [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ServerPropertiesForRestore]::new()

            if ($PSBoundParameters.ContainsKey('SourceServerId')) {
                $Parameter.Property.SourceServerId = $PSBoundParameters['SourceServerId']
                
                $FieldList = $PSBoundParameters['SourceServerId'].Split('/')
                $InputObject = Get-AzMariadbServer -ResourceGroupName $FieldList[4] -ServerName $FieldList[8]
                $PSBoundParameters.Remove('SourceServerId')
            }
            if ($PSBoundParameters.ContainsKey('InputObject')) {
                $Parameter.Property.SourceServerId = $InputObject.Id
                $PSBoundParameters.Remove('InputObject')
            }
            $Parameter.Location = $InputObject.Location
    
            if ($PSBoundParameters.ContainsKey('RestorePointInTime')) {
                $Parameter.Property.RestorePointInTime = $RestorePointInTime
                $PSBoundParameters.Remove('RestorePointInTime')
            }

            $PSBoundParameters.Add('Parameter', $Parameter)

            Az.MariaDb.internal\New-AzMariaDbServer @PSBoundParameters
          } catch {
              throw
          }
    }
}
