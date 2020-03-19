
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
Updates a configuration of a server.
.Description
Updates a configuration of a server.
.Example
To view examples, please use the -Online parameter with Get-Help or navigate to: https://docs.microsoft.com/en-us/powershell/module/az.mariadb/update-azmariadbconfiguration
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfiguration
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfiguration
.Notes
COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

CONFIGURATION <IConfiguration>: Represents a Configuration.
  [Source <String>]: Source of the configuration.
  [Value <String>]: Value of the configuration.

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
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/update-azmariadbconfiguration
#>
function Update-AzMariaDbConfiguration {
=======
function Update-AzMariaDbConfiguration
{
>>>>>>> upstream/wyunchi/generate-mariadb
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfiguration])]
    [CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Profile('latest-2019-04-30')]
    param(
<<<<<<< HEAD
        [Parameter(ParameterSetName='ServerName', Mandatory)]
=======
        [Parameter(ParameterSetName='ServerName', Mandatory, HelpMessage='You can obtain this value from the Azure Resource Manager API or the portal.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # The name of the resource group that contains the resource.
        # You can obtain this value from the Azure Resource Manager API or the portal.
        ${ResourceGroupName},
    
<<<<<<< HEAD
        [Parameter(ParameterSetName='ServerName', Mandatory)]
=======
        [Parameter(ParameterSetName='ServerName', Mandatory, HelpMessage='The name of the server.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # The name of the server.
        ${ServerName},
<<<<<<< HEAD

        [Parameter(ParameterSetName='ServerId', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # The Id of the server.
        ${ServerId},
    
        [Parameter(ParameterSetName='ServerName', Mandatory)]
=======
    
        [Parameter(ParameterSetName='ServerName', Mandatory, HelpMessage='The subscription ID that identifies an Azure subscription.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The subscription ID that identifies an Azure subscription.
        ${SubscriptionId},
    
<<<<<<< HEAD
        [Parameter(ParameterSetName='ServerObject', Mandatory, ValueFromPipeline)]
=======
        [Parameter(ParameterSetName='ServerObject', Mandatory, ValueFromPipeline, HelpMessage='Identity Parameter')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${ServerObject},
    
<<<<<<< HEAD
        [Parameter()]
=======
        [Parameter(HelpMessage='Configurations to be updated.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.Collections.Hashtable]
        ${Configuration},

<<<<<<< HEAD
        [Parameter()]
=======
        [Parameter(HelpMessage='The name of the server configuration.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Alias('ConfigurationName')]
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
        [System.String]
        # The name of the server configuration.
        ${Name},
    
<<<<<<< HEAD
        [Parameter()]
=======
        [Parameter(HelpMessage='Value of the configuration.')]
>>>>>>> upstream/wyunchi/generate-mariadb
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
        [System.String]
        # Value of the configuration.
        ${Value},
    
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
<<<<<<< HEAD
            Import-Module (Join-Path $PSScriptRoot MariaDbUtils.psm1)
=======
>>>>>>> upstream/wyunchi/generate-mariadb
            if ($PSBoundParameters.ContainsKey('ServerId')) {
                $ServerId = $PSBoundParameters['ServerId']
                $PSBoundParameters['ServerName'] = Get-ServerNameFromMariaDbId $ServerId
                $PSBoundParameters['ResourceGroupName'] = Get-ResourceGroupNameFromMariaDbId $ServerId
                $Null = $PSBoundParameters.Remove('ServerId')
            } elseif ($PSBoundParameters.ContainsKey('ServerObject')) {
                $ServerId = $PSBoundParameters['ServerObject'].Id
                $PSBoundParameters['ServerName'] = Get-ServerNameFromMariaDbId $ServerId
                $PSBoundParameters['ResourceGroupName'] = Get-ResourceGroupNameFromMariaDbId $ServerId
                $Null = $PSBoundParameters.Remove('ServerObject')
            }

            if ($PSBoundParameters.ContainsKey('Name')) {
                $Configuration = [System.Collections.Hashtable]::new()
                $Configuration.Add($Name, $Value)
            }
            if ($PSBoundParameters.ContainsKey('Configuration')) {
                $PSBoundParameters.Remove('PSBoundParameters')
            }
            foreach ($ConfigName in $Configuration.Keys) {
                $PSBoundParameters['Name'] = $Configuration[$ConfigName]
                Az.MariaDb.internal\Update-AzMariaDbConfiguration @PSBoundParameters
            }
        } catch {
            throw
        }
    }
}
