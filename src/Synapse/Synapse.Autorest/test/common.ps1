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
Validate if kusto pool is valid
#>
function Validate_Cluster{
	Param ([Object]$KustoPool,
		[string]$workspaceName,
		[string]$KustoPoolName,
		[string]$Location,
		[string]$State,
		[string]$ProvisioningState,
		[string]$ResourceType,
        [string]$SkuName,
        [string]$SkuSize,
		[int]$Capacity)
	$KustoPool.Name | Should -Be ($workspaceName + "/" + $KustoPoolName)
	$KustoPool.Location | Should -Be $Location
	$KustoPool.State | Should -Be $State
	$KustoPool.ProvisioningState | Should -Be  $ProvisioningState
	$KustoPool.Type | Should -Be $ResourceType
    $KustoPool.SkuName | Should -Be $SkuName
    $KustoPool.SkuSize | Should -Be $SkuSize
	$KustoPool.SkuCapacity | Should -Be $Capacity
}