
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
Creates an object to update NIC properties of a replicating server.
.Description
The New-AzMigrateNicMapping cmdlet creates a mapping of the source NIC attached to the server to be migrated. This object is provided as an input to the Set-AzMigrateServerReplication cmdlet to update the NIC and its properties for a replicating server.
.Link
https://learn.microsoft.com/powershell/module/az.migrate/new-azmigratenicmapping
#>
function New-AzMigrateNicMapping {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202301.IVMwareCbtNicInput])]
    [CmdletBinding(DefaultParameterSetName = 'VMwareCbt', PositionalBinding = $false)]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the ID of the NIC to be updated.
        ${NicID},

        [Parameter()]
        [ValidateSet("primary" , "secondary", "donotcreate")]
        [ArgumentCompleter({"primary" , "secondary", "donotcreate"})]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies whether the NIC to be updated will be the primary, secondary or not migrated.
        ${TargetNicSelectionType},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Subnet name for the NIC in the destination Virtual Network to which the server needs to be migrated.
        ${TargetNicSubnet},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the name of the NIC to be created.
        ${TargetNicName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the IP within the destination subnet to be used for the NIC.
        ${TargetNicIP},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the Subnet name for the NIC in the destination Virtual Network to which the server needs to be test migrated.
        ${TestNicSubnet},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
        [System.String]
        # Specifies the IP within the destination test subnet to be used for the NIC.
        ${TestNicIP}
    )
    
    process {
        $NicObject = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202301.VMwareCbtNicInput]::new()
        $NicObject.NicId = $NicID
        if ($PSBoundParameters.ContainsKey('TargetNicSelectionType')) {
            if ($TargetNicSelectionType -eq 'primary') {
                $NicObject.IsPrimaryNic = "true"
                $NicObject.IsSelectedForMigration = "true"
            }
            elseif ($TargetNicSelectionType -eq 'secondary') {
                $NicObject.IsPrimaryNic = "false"
                $NicObject.IsSelectedForMigration = "true"
            }
            elseif ($TargetNicSelectionType -eq 'donotcreate') {
                $NicObject.IsPrimaryNic = "false"
                $NicObject.IsSelectedForMigration = "false"
            }
        }
        if ($PSBoundParameters.ContainsKey('TargetNicSubnet')) {
            $NicObject.TargetSubnetName = $TargetNicSubnet
        }
       
        if ($PSBoundParameters.ContainsKey('TargetNicIP')) {
            $isValidIpAddress = [ipaddress]::TryParse($TargetNicIP,[ref][ipaddress]::Loopback)
            if(!$isValidIpAddress) {
                throw "(InvalidPrivateIPAddressFormat) Static IP address value '$($TargetNicIP)' is invalid."
            }
            $NicObject.TargetStaticIPAddress = $TargetNicIP
        }

        if ($PSBoundParameters.ContainsKey('TargetNicName')) {
            if ($TargetNicName.length -gt 80 -or $TargetNicName.length -eq 0) {
                throw "The NIC name must be between 1 and 80 characters long."
            }

            if ($TargetNicName -notmatch "^[^_\W][a-zA-Z0-9_\-\.]{0,79}(?<![-.])$") {
                throw "The NIC name must begin with a letter or number, end with a letter, number or underscore, and may contain only letters, numbers, underscores, periods, or hyphens."
            }
            $NicObject.TargetNicName = $TargetNicName
        }

        
        if ($PSBoundParameters.ContainsKey('TestNicSubnet')) {
            $NicObject.TestSubnetName = $TestNicSubnet
        }
       
        if ($PSBoundParameters.ContainsKey('TestNicIP')) {
            $isValidIpAddress = [ipaddress]::TryParse($TestNicIP,[ref][ipaddress]::Loopback)
            if(!$isValidIpAddress) {
                throw "(InvalidPrivateIPAddressFormat) Static IP address value '$($TestNicIP)' is invalid."
            }
            $NicObject.TestStaticIPAddress = $TestNicIP
        }

        return $NicObject
    }

}   