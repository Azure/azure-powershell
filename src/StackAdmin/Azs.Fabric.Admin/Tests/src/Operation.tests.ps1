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
    Run AzureStack fabric admin operation tests.

.DESCRIPTION
    Run AzureStack fabric admin operation tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    C:\PS> .\src\Operation.Tests.ps1
	Describing Operations
	 [!] TestGetComputeFabricOperations 22ms
	 [!] TestGetNetworkFabricOperations 2ms

.NOTES
    Author: Jeffrey Robinson
	Copyright: Microsoft
    Date:   August 24, 2017
#>
param(
	[bool]$RunRaw = $false
)

$Global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

$global:TestName = ""
	
InModuleScope Azs.Fabric.Admin {

	Describe "Operations" -Tags @('Operation', 'Azs.Fabric.Admin') {

		BeforeEach  {
			
			. $PSScriptRoot\Common.ps1

		}
		
		It "TestGetComputeFabricOperations" -Skip {
			$global:TestName = 'TestGetComputeFabricOperations'

			Get-AzsComputeFabricOperation -ComputeOperationResult "storageFabricOperation" -Location $Location -Provider "Microsoft.Storage"
	    }
	
		It "TestGetNetworkFabricOperations" -Skip {
            $global:TestName = 'TestGetNetworkFabricOperations'

			Get-AzsComputeFabricOperation -NetworkOperationResult "storageFabricOperation" -Location $Location -Provider "Microsoft.Compute"
		}

    }
}