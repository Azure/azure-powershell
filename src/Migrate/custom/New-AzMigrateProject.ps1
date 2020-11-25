
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
Creates a new Migrate project.
.Description
Creates a new Migrate project. 
.Link
https://docs.microsoft.com/en-us/powershell/module/az.migrate/get-azmigrateserver
#>

function New-AzMigrateProject {
    [CmdletBinding(DefaultParameterSetName='PutExpandedCustom', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param (
        [Parameter(ParameterSetName='PutExpandedCustom', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the migrate project name.
        ${Name},

        [Parameter(ParameterSetName='PutExpandedCustom', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the resource group name.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='PutExpandedCustom', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the VMware machine name.
        ${Location},

        [Parameter(ParameterSetName='PutExpandedCustom')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the VMware machine name.
        ${ETag},

        [Parameter(ParameterSetName='PutExpandedCustom')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProjectProperties]
        # Specifies the project properties.
        ${Property},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Specifies the subscription id.
        ${SubscriptionId}
    )
    
    process{
        if ($null -eq $Property) {
            $Property = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrateProjectProperties]::new()
            $Property.RegisteredTool = {}
        }

        return Set-AzMigrateProject -Name $Name -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionId -Location $Location -ETag $ETag -Property $Property
    }
}