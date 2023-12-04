
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
Creates an object to update NIC properties of a test migrating server.
.Description
The New-AzMigrateTestNicMapping cmdlet creates a mapping of the source NIC attached to the server to be test migrated. This object is provided as an input to the Start-AzMigrateTestMigration cmdlet to update the NIC and its properties for a test migrating server.
.Link
https://learn.microsoft.com/powershell/module/az.migrate/new-azmigratetestnicmapping
#>
function New-AzMigrateTestNicMapping {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202301.IVMwareCbtNicInput])]
    [CmdletBinding(DefaultParameterSetName = 'VMwareCbt', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the ID of the NIC to be updated.
        ${NicID},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Subnet name for the NIC in the destination Virtual Network to which the server needs to be test migrated.
        ${TestNicSubnet}
    )
    
    process {
        $NicObject = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202301.VMwareCbtNicInput]::new()
        $NicObject.NicId = $NicID

        if ($PSBoundParameters.ContainsKey('TestNicSubnet')) {
            $NicObject.TestSubnetName = $TestNicSubnet
        }
        return $NicObject
    }

}   