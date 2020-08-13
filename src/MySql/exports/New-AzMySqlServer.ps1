
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
Creates a new server.
.Description
Creates a new server.
.Example
PS C:\> New-AzMySqlServer -Name mysql-test -ResourceGroupName PowershellMySqlTest -Location eastus -AdministratorUser mysql_test -AdministratorLoginPassword $password -Sku GP_Gen5_4

Name          Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuTier        SslEnforcement
----          -------- ------------------ ------- ----------------------- -------   -------        ------------
mysql-test    eastus   mysql_test         5.7     5120                    GP_Gen5_4 GeneralPurpose Enabled

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServer
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mysql/new-azmysqlserver
#>
function New-AzMySqlServer {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServer])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('ServerName')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Path')]
    [System.String]
    # The name of the server.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource, You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Body')]
    [System.String]
    # The location the resource resides in.
    ${Location},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Body')]
    [System.String]
    # The location the resource resides in.
    ${AdministratorUserName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Body')]
    [System.Security.SecureString]
    # The location the resource resides in.
    ${AdministratorLoginPassword},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Body')]
    [System.String]
    # The name of the sku, typically, tier + family + cores, e.g.
    # B_Gen4_1, GP_Gen5_8.
    ${Sku},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum])]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum]
    # Enable ssl enforcement or not when connect to server.
    ${SslEnforcement},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Body')]
    [System.Int32]
    # Backup retention days for the server.
    # Day count is between 7 and 35.
    ${BackupRetentionDay},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup])]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup]
    # Enable Geo-redundant or not for server backup.
    ${GeoRedundantBackup},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow])]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow]
    # Enable Storage Auto Grow.
    ${StorageAutogrow},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Body')]
    [System.Int32]
    # Max storage allowed for a server.
    ${StorageInMb},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerForCreateTags]))]
    [System.Collections.Hashtable]
    # Application-specific metadata in the form of key-value pairs.
    ${Tag},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion])]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion]
    # Server version.
    ${Version},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job.
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach.
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously.
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
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
            CreateExpanded = 'Az.MySql.custom\New-AzMySqlServer';
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
