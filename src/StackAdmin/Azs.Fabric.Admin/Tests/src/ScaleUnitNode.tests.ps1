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
    Run AzureStack fabric admin scale unit node tests.

.DESCRIPTION
    Run AzureStack fabric admin scale unit node tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\ScaleUnitNode.Tests.ps1
	Describing ScaleUnitNodes
	 [+] TestListScaleUnitNodes 168ms
	 [+] TestGetScaleUnitNode 110ms
	 [+] TestGetAllScaleUnitNodes 83ms
	 [+] TestPowerOnScaleUnitNode 248ms
	 [+] TestStartStopMaintenanceModeUnitNode 94ms
	 [+] TestGetScaleUnitNodeOnTenantVM 66ms
	 [+] TestPowerOnOnTenantVM 137ms
	 [+] TestPowerOffOnTenantVM 149ms
	 [+] TestStartMaintenanceModeOnTenantVM 141ms
	 [!] TestPowerOnScaleUnitNode 3ms
	 [!] TestPowerOffScaleUnitNode 2ms

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

	Describe "ScaleUnitNodes" -Tags @('ScaleUnitNode', 'Azs.Fabric.Admin') {

		BeforeEach  {

			. $PSScriptRoot\Common.ps1

			function ValidateScaleUnitNode {
				param(
					[Parameter(Mandatory=$true)]
					$ScaleUnitNode
				)

				$ScaleUnitNode          | Should Not Be $null

				# Resource
				$ScaleUnitNode.Id       | Should Not Be $null
				$ScaleUnitNode.Location | Should Not Be $null
				$ScaleUnitNode.Name     | Should Not Be $null
				$ScaleUnitNode.Type     | Should Not Be $null

				# Scale Unit Node
				$ScaleUnitNode.CanPowerOff          | Should Not Be $null
				$ScaleUnitNode.Capacity             | Should Not Be $null
				$ScaleUnitNode.PowerState           | Should Not Be $null
				$ScaleUnitNode.ScaleUnitName        | Should Not Be $null
				$ScaleUnitNode.ScaleUnitNodeStatus  | Should Not Be $null
				$ScaleUnitNode.ScaleUnitUri         | Should Not Be $null
			}

			function AssertScaleUnitNodesAreSame {
				param(
					[Parameter(Mandatory=$true)]
					$Expected,

					[Parameter(Mandatory=$true)]
					$Found
				)
				if($Expected -eq $null) {
					$Found | Should Be $null
				} else {
					$Found                  | Should Not Be $null

					# Resource
					$Found.Id               | Should Be $Expected.Id
					$Found.Location         | Should Be $Expected.Location
					$Found.Name             | Should Be $Expected.Name
					$Found.Type             | Should Be $Expected.Type

					# Scale Unit Node
					$Found.CanPowerOff          | Should Be $Expected.CanPowerOff

					if($Expected.Capacity -eq $null) {
						$Found.Capacity  | Should Be $null
					} else {
						$Found.Capacity           | Should not Be $null
						$Found.Capacity.Cores     | Should Be $Expected.Capacity.Cores
						$Found.Capacity.MemoryGB  | Should Be $Expected.Capacity.MemoryGB
					}

					$Found.PowerState           | Should Be $Expected.PowerState
					$Found.ScaleUnitName        | Should Be $Expected.ScaleUnitName
					$Found.ScaleUnitNodeStatus  | Should Be $Expected.ScaleUnitNodeStatus
					$Found.ScaleUnitUri         | Should Be $Expected.ScaleUnitUri
				}
			}
		}


		It "TestListScaleUnitNodes" {
			$global:TestName = 'TestListScaleUnitNodes'
			$ScaleUnitNodes = Get-AzsScaleUnitNode -ResourceGroupName $ResourceGroup -Location $Location
			$ScaleUnitNodes | Should Not Be $null
			foreach($ScaleUnitNode in $ScaleUnitNodes) {
				ValidateScaleUnitNode -ScaleUnitNode $ScaleUnitNode
			}
	    }


		It "TestGetScaleUnitNode" {
            $global:TestName = 'TestGetScaleUnitNode'

			$ScaleUnitNodes = Get-AzsScaleUnitNode -ResourceGroupName $ResourceGroup -Location $Location
			foreach($ScaleUnitNode in $ScaleUnitNodes) {
				$retrieved = Get-AzsScaleUnitNode -ResourceGroupName $ResourceGroup -Location $Location -Name $ScaleUnitNode.Name
				AssertScaleUnitNodesAreSame -Expected $ScaleUnitNode -Found $retrieved
				break
			}
		}

		It "TestGetAllScaleUnitNodes" {
			$global:TestName = 'TestGetAllScaleUnitNodes'

			$ScaleUnitNodes = Get-AzsScaleUnitNode -ResourceGroupName $ResourceGroup -Location $Location
			foreach($ScaleUnitNode in $ScaleUnitNodes) {
				$retrieved = Get-AzsScaleUnitNode -ResourceGroupName $ResourceGroup -Location $Location -Name $ScaleUnitNode.Name
				AssertScaleUnitNodesAreSame -Expected $ScaleUnitNode -Found $retrieved
			}
		}

		It "TestStartStopMaintenanceModeUnitNode" {
			$global:TestName = 'TestStartStopMaintenanceModeUnitNode'

			$ScaleUnitNodes = Get-AzsScaleUnitNode -ResourceGroupName $ResourceGroup -Location $Location
            foreach($ScaleUnitNode in $ScaleUnitNodes) {
				{
					Disable-AzsScaleUnitNode -ResourceGroupName $ResourceGroup -Location $Location -Name $ScaleUnitNode.Name -Force
					Enable-AzsScaleUnitNode -ResourceGroupName $ResourceGroup -Location $Location -Name $ScaleUnitNode.Name -Force
				} | Should Throw
				break
            }
		}

		# Tenant VM

		It "TestGetScaleUnitNodeOnTenantVM" {
			$global:TestName = 'TestGetAllScaleUnitNodes'

			{ Get-AzsScaleUnitNode -ResourceGroupName $ResourceGroup -Location $Location -Name $TenantVMName } | Should Throw
		}

		It "TestPowerOnOnTenantVM" {
			$global:TestName = 'TestPowerOnOnTenantVM'
			{
				$operationStatus = Start-AzsScaleUnitNode -ResourceGroupName $ResourceGroup -Location $Location -Name $TenantVMName -Force
				$operationStatus.ProvisioningState | Should not be ""
				$operationStatus.ProvisioningState | Should be "Failure"
			} | Should Throw
		}

		It "TestPowerOffOnTenantVM" {
			$global:TestName = 'TestPowerOffOnTenantVM'

			{
				$operationStatus = Stop-AzsScaleUnitNode -ResourceGroupName $ResourceGroup -Location $Location -Name $TenantVMName -Force
				$operationStatus.ProvisioningState | Should not be ""
				$operationStatus.ProvisioningState | Should be "Failure"
			} | Should Throw
		}

		It "TestStartMaintenanceModeOnTenantVM" {
			$global:TestName = 'TestStartMaintenanceModeOnTenantVM'
			{
				$operationStatus = Disable-AzsScaleUnitNode -ResourceGroupName $ResourceGroup -Location $Location -Name $TenantVMName -Force
				$operationStatus.ProvisioningState | Should not be ""
				$operationStatus.ProvisioningState | Should be "Failure"
			} | Should Throw
		}


		# Disabled

		It "TestPowerOnScaleUnitNode" -Skip {
			$global:TestName = 'TestPowerOnScaleUnitNode'

			$ScaleUnitNodes = Get-AzsScaleUnitNode -ResourceGroupName $ResourceGroup -Location $Location
            foreach($ScaleUnitNode in $ScaleUnitNodes) {
                Start-AzsScaleUnitNode -ResourceGroupName $ResourceGroup -Location $Location -Name $ScaleUnitNode.Name -Force
				$retrieved | Should Be $null
				break
            }
		}

		It "TestPowerOffScaleUnitNode" -Skip {
			$global:TestName = 'TestPowerOffScaleUnitNode'

			$ScaleUnitNodes = Get-AzsScaleUnitNode -ResourceGroupName $ResourceGroup -Location $Location
            foreach($ScaleUnitNode in $ScaleUnitNodes) {
                $retrieved = Stop-AzsScaleUnitNode -ResourceGroupName $ResourceGroup -Location $Location -Name $ScaleUnitNode.Name -Force
				$retrieved | Should Be $null
				break
            }
		}
    }
}
