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
.SYNOPSIS
Validate Fabric capacity
#>
function Validate_Capacity{
	Param ([Object]$Capacity,
        [string]$CapacityName,
        [string]$CapacityId,
		[string]$Location,
		[string]$State,
		[string]$ProvisioningState,
        [string]$SkuName)
	$Capacity.Name | Should -Be $CapacityName
    $Capacity.Id | Should -Be $CapacityId
	$Capacity.Location | Should -Be $Location
	$Capacity.State | Should -Be $State
	$Capacity.ProvisioningState | Should -Be  $ProvisioningState
	$Capacity.Type | Should -Be "Microsoft.Fabric/capacities"
    $Capacity.SkuName | Should -Be $SkuName
    $Capacity.SkuTier | Should -Be $env.SkuTier
}

function Validate_Capacity_Exists_In_Array{
    Param ([Object]$CapacitiesList)
    $found = $false
    foreach ($capacity in $CapacitiesList) {
        if ($capacity.Name -eq $env.CapacityName) {
            $found = $true
            Validate_Capacity $capacity $env.CapacityName $env.CapacityId $env.Location "Active" "Succeeded" $env.SkuName
            break
        }
    }
    $found | Should -Be $true
}

function Validate_Capacity_Skus{
	Param ([Object]$CapacitySkus)
    foreach ($capacitySku in $CapacitiySkus) {
        $capacitySku.ResourceType | Should -Be "Microsoft.Fabric/capacities"
        $capacitySku.SkuTier | Should -Be $env.SkuTier
        @("F2", "F4", "F8", "F16", "F32", "F64", "F128", "F256", "F512", "F1024", "F2048") | Should -Contain $capacitySku.SkuName
    }
}

function Validate_Skus{
    Param ([Object]$Skus)
    foreach ($sku in $Skus) {
        $sku.ResourceType | Should -Be "Capacities"
        @("F2", "F4", "F8", "F16", "F32", "F64", "F128", "F256", "F512", "F1024", "F2048") | Should -Contain $sku.Name
    }
}

function RandomString( [int32]$len) {
    if ($len -lt 3) {
        throw "Length must be at least 3."
    }

    # Generate the random string
    return -join ((97..122)  | Get-Random -Count $len | ForEach-Object {[char]$_})
}