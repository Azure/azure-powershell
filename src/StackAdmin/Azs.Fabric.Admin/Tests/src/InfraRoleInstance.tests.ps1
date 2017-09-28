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
    Run AzureStack fabric admin infrarole instance tests.

.DESCRIPTION
    Run AzureStack fabric admin infrarole instance tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    C:\PS> .\src\InfraRoleInstance.Tests.ps1
	Describing InfraRoleInstances
	 [+] TestListInfraRoleInstances 238ms
	 [+] TestGetInfraRoleInstance 119ms
	 [+] TestGetAllInfraRoleInstances 290ms
	 [+] TestInfraRoleInstancePowerOn 104ms
	 [+] TestInfraRoleInstancePowerOnAll 156ms
	 [+] TestGetInfraRoleInstanceOnTenantVM 111ms
	 [+] TestInfraRoleInstanceShutdownOnTenantVM 69ms
	 [+] TestInfraRoleInstanceRebootOnTenantVM 59ms
	 [+] TestInfraRoleInstancePowerOffOnTenantVM 59ms
	 [!] TestInfraRoleInstanceShutdown 5ms
	 [!] TestInfraRoleInstancePowerOff 5ms
	 [!] TestInfraRoleInstanceReboot 2ms

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

	Describe "InfraRoleInstances" -Tags @('InfraRoleInstance', 'Azs.Fabric.Admin') {

		BeforeEach  {
			
			. $PSScriptRoot\Common.ps1

			function ValidateInfraRoleInstance {
				param(
					[Parameter(Mandatory=$true)]
					$InfraRoleInstance
				)
			
				$InfraRoleInstance          | Should Not Be $null

				# Resource
				$InfraRoleInstance.Id       | Should Not Be $null
				$InfraRoleInstance.Location | Should Not Be $null
				$InfraRoleInstance.Name     | Should Not Be $null
				$InfraRoleInstance.Type     | Should Not Be $null

				# Infra Role Instance
				$InfraRoleInstance.ScaleUnit       | Should Not Be $null
				$InfraRoleInstance.ScaleUnitNode  | Should Not Be $null
				$InfraRoleInstance.Size            | Should Not Be $null
				$InfraRoleInstance.State           | Should Not Be $null

			}

			function AssertInfraRoleInstancesAreSame {
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

					# Infra Role Instance
					$Found.ScaleUnit      | Should Be $Expected.ScaleUnit
					$Found.ScaleUnitNode  | Should Be $Expected.ScaleUnitNode
					$Found.Size.Cores     | Should Be $Expected.Size.Cores
					$Found.Size.MemoryGb  | Should Be $Expected.Size.MemoryGb
					$Found.State          | Should Be $Expected.State

				}
			}
		}
		
		It "TestListInfraRoleInstances" {
			$global:TestName = 'TestListInfraRoleInstances'
			$InfraRoleInstances = Get-AzsInfraRoleInstance -Location $Location
			$InfraRoleInstances | Should Not Be $null
			foreach($InfraRoleInstance in $InfraRoleInstances) {
				ValidateInfraRoleInstance -InfraRoleInstance $InfraRoleInstance
			}
	    }
	
		It "TestGetInfraRoleInstance" {
            $global:TestName = 'TestGetInfraRoleInstance'

			$InfraRoleInstances = Get-AzsInfraRoleInstance -Location $Location
			foreach($InfraRoleInstance in $InfraRoleInstances) {
				$retrieved = Get-AzsInfraRoleInstance -Location $Location -InfraRoleInstance $InfraRoleInstance.Name
				AssertInfraRoleInstancesAreSame -Expected $InfraRoleInstance -Found $retrieved
				break
			}
		}

		It "TestGetAllInfraRoleInstances" {
			$global:TestName = 'TestGetAllInfraRoleInstances'

			$InfraRoleInstances = Get-AzsInfraRoleInstance -Location $Location
			foreach($InfraRoleInstance in $InfraRoleInstances) {
				$retrieved = Get-AzsInfraRoleInstance -Location $Location -InfraRoleInstance $InfraRoleInstance.Name
				AssertInfraRoleInstancesAreSame -Expected $InfraRoleInstance -Found $retrieved
			}
		}

		It "TestInfraRoleInstancePowerOn" {
			$global:TestName = 'TestInfraRoleInstancePowerOn'

			$InfraRoleInstances = Get-AzsInfraRoleInstance -Location $Location
			foreach($InfraRoleInstance in $InfraRoleInstances) {
				Invoke-AzsInfraRoleInstancePowerOn -Location $Location -InfraRoleInstance $InfraRoleInstance.Name
				break
			}
		}

		It "TestInfraRoleInstancePowerOnAll" {
			$global:TestName = 'TestInfraRoleInstancePowerOnAll'

			$InfraRoleInstances = Get-AzsInfraRoleInstance -Location $Location
			foreach($InfraRoleInstance in $InfraRoleInstances) {
				Invoke-AzsInfraRoleInstancePowerOn -Location $Location -InfraRoleInstance $InfraRoleInstance.Name
			}
		}

		# Tenant VMs
		
		

		It "TestGetInfraRoleInstanceOnTenantVM" {
			$global:TestName = 'TestGetInfraRoleInstanceOnTenantVM'

			{ Get-AzsInfraRoleInstance -Location $Location -InfraRoleInstance $TenantVMName } | Should Throw
		}
		
		It "TestInfraRoleInstanceShutdownOnTenantVM" {
			$global:TestName = 'TestInfraRoleInstanceShutdownOnTenantVM'
			{
				Invoke-AzsInfraRoleInstanceShutdown -Location $Location -InfraRoleInstance $TenantVMName
			} | Should Throw
		}
		
		It "TestInfraRoleInstanceRebootOnTenantVM" {
			$global:TestName = 'TestInfraRoleInstanceRebootOnTenantVM'
			{
				Invoke-AzsInfraRoleInstanceReboot -Location $Location -InfraRoleInstance $TenantVMName
		} | Should Throw
		}
		
		It "TestInfraRoleInstancePowerOffOnTenantVM" {
			$global:TestName = 'TestInfraRoleInstancePowerOffOnTenantVM'
			{
				Invoke-AzsInfraRoleInstancePowerOff -Location $Location -InfraRoleInstance $TenantVMName
			} | Should Throw
		}


		# Disabled

		It "TestInfraRoleInstanceShutdown" -Skip {
			$global:TestName = 'TestInfraRoleInstanceShutdown'

			$InfraRoleInstances = Get-AzsInfraRoleInstance -Location $Location
			foreach($InfraRoleInstance in $InfraRoleInstances) {
				Invoke-AzsInfraRoleInstanceShutdown -Location $Location -InfraRoleInstance $InfraRoleInstance.Name
				break
			}
		}

		It "TestInfraRoleInstancePowerOff" -Skip {
			$global:TestName = 'TestInfraRoleInstancePowerOff'

			$InfraRoleInstances = Get-AzsInfraRoleInstance -Location $Location
			foreach($InfraRoleInstance in $InfraRoleInstances) {
				Invoke-AzsInfraRoleInstancePoweroff -Location $Location -InfraRoleInstance $InfraRoleInstance.Instance
				break
			}
		}

		It "TestInfraRoleInstanceReboot" -Skip {
			$global:TestName = 'TestInfraRoleInstanceReboot'

			$InfraRoleInstances = Get-AzsInfraRoleInstance -Location $Location
			foreach($InfraRoleInstance in $InfraRoleInstances) {
				Invoke-AzsInfraRoleInstanceReboot -Location $Location -InfraRoleInstance $InfraRoleInstance.Instance
				break
			}
		}
    }
}