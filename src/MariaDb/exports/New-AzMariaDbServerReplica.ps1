
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

.Description

.Example
PS C:\> New-AzMariaDbServerReplica -ServerName mariadb-test-9pebvn -Name mariadb-test-9pebvn-rep01 -ResourceGroupName mariadb-test-qu5ov0

Name                      Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuSize SkuTier        SslEnforcement
----                      -------- ------------------ ------- ----------------------- -------   ------- -------        --------------
mariadb-test-9pebvn-rep01 eastus   xpwjyfdgui         10.2    7168                    GP_Gen5_4         GeneralPurpose Enabled
.Example
PS C:\> Get-AzMariaDbServer -Name mariadb-test-9pebvn -ResourceGroupName mariadb-test-qu5ov0 | New-AzMariaDbServerReplica -Name mariadb-test-9pebvn-rep02

Name                      Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuSize SkuTier        SslEnforcement
----                      -------- ------------------ ------- ----------------------- -------   ------- -------        --------------
mariadb-test-9pebvn-rep02 eastus   xpwjyfdgui         10.2    7168                    GP_Gen5_4         GeneralPurpose Enabled

.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/new-azmariadbserverreplica
#>
function New-AzMariaDbServerReplica {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer])]
[CmdletBinding(DefaultParameterSetName='ServerName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('ReplicaServerName')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # Replica name.
    ${Name},

    [Parameter(ParameterSetName='ServerName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # MariaDb server name.
    ${ServerName},

    [Parameter(ParameterSetName='ServerName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID is part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ServerObject', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer]
    # The source server object to restore from.
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The location the resource resides in.
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The name of the sku, typically, tier + family + cores, e.g.
    # B_Gen4_1, GP_Gen5_8.
    ${Sku},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerUpdateParametersTags]))]
    [System.Collections.Hashtable]
    # Application-specific metadata in the form of key-value pairs.
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            ServerName = 'Az.MariaDb.custom\New-AzMariaDbServerReplica';
            ServerObject = 'Az.MariaDb.custom\New-AzMariaDbServerReplica';
        }
        if (('ServerName', 'ServerObject') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
