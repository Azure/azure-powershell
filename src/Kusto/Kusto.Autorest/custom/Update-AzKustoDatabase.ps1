
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
Updates a database.
.Description
Updates a database.
.Example
$2ds = New-TimeSpan -Days 2
$4ds = New-TimeSpan -Days 4
Update-AzKustoDatabase -ResourceGroupName testrg -ClusterName testnewkustocluster -Name mykustodatabase -Kind ReadWrite -SoftDeletePeriod $4ds -HotCachePeriod $2ds -Location 'East US' -CallerRole Admin

Kind      Location Name                                Type
----      -------- ----                                ----
ReadWrite East US  testnewkustocluster/mykustodatabase Microsoft.Kusto/Clusters/Databases

.Link
https://learn.microsoft.com/powershell/module/az.kusto/update-azkustodatabase
#>
function Update-AzKustoDatabase {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20221229.IDatabase])]
    [CmdletBinding(DefaultParameterSetName = 'UpdateExpanded', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(ParameterSetName = 'UpdateExpanded', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Path')]
        [System.String]
        # The name of the Kusto cluster.
        ${ClusterName},

        [Parameter(ParameterSetName = 'UpdateExpanded', Mandatory)]
        [Alias('DatabaseName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Path')]
        [System.String]
        # The name of the database in the Kusto cluster.
        ${Name},

        [Parameter(ParameterSetName = 'UpdateExpanded', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Path')]
        [System.String]
        # The name of the resource group containing the Kusto cluster.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'UpdateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},

        [Parameter(ParameterSetName = 'UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},

        [Parameter(Mandatory)]
        [ArgumentCompleter( { param ( $CommandName, $ParameterName, $WordToComplete, $CommandAst, $FakeBoundParameters ) return @('ReadWrite', 'ReadOnlyFollowing') })]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Kind]
        # Kind of the database
        ${Kind},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.TimeSpan]
        # The time the data should be kept in cache for fast queries in TimeSpan.
        ${HotCachePeriod},

        [Parameter(ParameterSetName = 'UpdateExpanded')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.TimeSpan]
        # The time the data should be kept before it stops being accessible to queries in TimeSpan.
        ${SoftDeletePeriod},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Query')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.CallerRole]
        # By default, any user who run operation on a database become an Admin on it.
        # This property allows the caller to exclude the caller from Admins list.
        ${CallerRole},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
        [System.String]
        # Resource location.
        ${Location},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        try {
            if ($PSBoundParameters['Kind'] -eq 'ReadWrite') {
                $Parameter = [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20221229.ReadWriteDatabase]::new()
            }
            else {
                $Parameter = [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20221229.ReadOnlyFollowingDatabase]::new()
            }

            $Parameter.Kind = $PSBoundParameters['Kind']
            $null = $PSBoundParameters.Remove('Kind')

            if ($PSBoundParameters.ContainsKey('SoftDeletePeriod')) {
                $Parameter.SoftDeletePeriod = $PSBoundParameters['SoftDeletePeriod']
                $null = $PSBoundParameters.Remove('SoftDeletePeriod')
            } 
            
            if ($PSBoundParameters.ContainsKey('HotCachePeriod')) {
                $Parameter.HotCachePeriod = $PSBoundParameters['HotCachePeriod']
                $null = $PSBoundParameters.Remove('HotCachePeriod')
            }   

            $Parameter.Location = $PSBoundParameters['Location']
            $null = $PSBoundParameters.Remove('Location')

            $null = $PSBoundParameters.Add('Parameter', $Parameter)

            Az.Kusto.internal\Update-AzKustoDatabase @PSBoundParameters
        }
        catch {
            throw
        }
    }
}
