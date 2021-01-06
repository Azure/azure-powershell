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
Get the available SKU information for the location
.Description
Get the available SKU information for the location
#>

function Get-AzMySqlFlexibleServerLocationBasedCapability {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.ICapabilityProperties])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Path')]
    [System.String]
    # The name of the location.
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MySql.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

process {
    try {
        $PSBoundParameters.LocationName = $PSBoundParameters['Location']
        $null = $PSBoundParameters.Remove('Location')

        $Result = Az.MySql.internal\Get-AzMySqlFlexibleServerLocationBasedCapability @PSBoundParameters
        Write-Host "Please refer to https://aka.ms/mysql-pricing for pricing details"
        $SkusTiers = $Result[0].SupportedFlexibleServerEdition
        $TableResult = @()

        foreach ($Skus in $SkusTiers) {
            $TierName = $Skus.Name
            try {
                $Keys = $Skus.SupportedServerVersion[0].SupportedVcore
                
                foreach ($Key in $Keys) {
                    $NewEntry = New-Object -TypeName PSCustomObject -Property @{SKU=$Key.Name; Tier=$TierName; vCore=$Key.Vcore; Memory=$Key.SupportedMemoryPerVcoreMb}
                    $TableResult += $NewEntry
                }
            }
            catch {
                throw "No SKU info for this location"
            }
        }
        
        return $TableResult

        
    } catch {
        throw
    }
}
}