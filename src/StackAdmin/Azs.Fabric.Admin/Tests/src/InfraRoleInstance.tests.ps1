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
	Run AzureStack fabric admin InfrastructureRole instance tests.

.DESCRIPTION
    Run AzureStack fabric admin InfrastructureRole instance tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\InfrastructureRoleInstance.Tests.ps1
	Describing InfrastructureRoleInstances
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
    [bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)

$Global:UseInstalled = $UseInstalled
$global:RunRaw = $RunRaw
$global:TestName = ""

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Fabric.Admin {

    Describe "InfrastructureRoleInstances" -Tags @('InfrastructureRoleInstance', 'Azs.Fabric.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateInfrastructureRoleInstance {
                param(
                    [Parameter(Mandatory = $true)]
                    $InfrastructureRoleInstance
                )

                $InfrastructureRoleInstance          | Should Not Be $null

                # Resource
                $InfrastructureRoleInstance.Id       | Should Not Be $null
                $InfrastructureRoleInstance.Location | Should Not Be $null
                $InfrastructureRoleInstance.Name     | Should Not Be $null
                $InfrastructureRoleInstance.Type     | Should Not Be $null

                # Infra Role Instance
                $InfrastructureRoleInstance.ScaleUnit       | Should Not Be $null
                $InfrastructureRoleInstance.ScaleUnitNode  | Should Not Be $null
                $InfrastructureRoleInstance.Size            | Should Not Be $null
                $InfrastructureRoleInstance.State           | Should Not Be $null

            }

            function AssertInfrastructureRoleInstancesAreSame {
                param(
                    [Parameter(Mandatory = $true)]
                    $Expected,

                    [Parameter(Mandatory = $true)]
                    $Found
                )
                if ($Expected -eq $null) {
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

        It "TestListInfraRoleInstances" -Skip:$('TestListInfraRoleInstances' -in $global:SkippedTests) {
            $global:TestName = 'TestListInfraRoleInstances'
            $InfrastructureRoleInstances = Get-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            $InfrastructureRoleInstances | Should Not Be $null
            foreach ($InfrastructureRoleInstance in $InfrastructureRoleInstances) {
                ValidateInfrastructureRoleInstance -InfrastructureRoleInstance $InfrastructureRoleInstance
            }
        }

        It "TestGetInfraRoleInstance" -Skip:$('TestGetInfraRoleInstance' -in $global:SkippedTests) {
            $global:TestName = 'TestGetInfraRoleInstance'

            $InfrastructureRoleInstances = Get-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            foreach ($InfrastructureRoleInstance in $InfrastructureRoleInstances) {
                $retrieved = Get-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $InfrastructureRoleInstance.Name
                AssertInfrastructureRoleInstancesAreSame -Expected $InfrastructureRoleInstance -Found $retrieved
                break
            }
        }

        It "TestGetAllInfraRoleInstances" -Skip:$('TestGetAllInfraRoleInstances' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllInfraRoleInstances'

            $InfrastructureRoleInstances = Get-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            foreach ($InfrastructureRoleInstance in $InfrastructureRoleInstances) {
                $retrieved = Get-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $InfrastructureRoleInstance.Name
                AssertInfrastructureRoleInstancesAreSame -Expected $InfrastructureRoleInstance -Found $retrieved
            }
        }

        # Need to record new tests
        It "TestInfraRoleInstancePowerOn" -Skip:$('TestInfraRoleInstancePowerOn' -in $global:SkippedTests) {
            $global:TestName = 'TestInfraRoleInstancePowerOn'

            $InfrastructureRoleInstances = Get-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            foreach ($InfrastructureRoleInstance in $InfrastructureRoleInstances) {
                Start-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $InfrastructureRoleInstance.Name -Force
                break
            }
        }

        # Need to record new tests
        It "TestInfraRoleInstancePowerOnAll" -Skip:$('TestInfraRoleInstancePowerOnAll' -in $global:SkippedTests) {
            $global:TestName = 'TestInfraRoleInstancePowerOnAll'

            $InfrastructureRoleInstances = Get-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            foreach ($InfrastructureRoleInstance in $InfrastructureRoleInstances) {
                Start-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $InfrastructureRoleInstance.Name -Force
            }
        }

        # Tenant VMs
        It "TestGetInfrastructureRoleInstanceOnTenantVM" -Skip:$('TestGetInfrastructureRoleInstanceOnTenantVM' -in $global:SkippedTests) {
            $global:TestName = 'TestGetInfrastructureRoleInstanceOnTenantVM'

            { Get-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $global:TenantVMName } | Should Throw
        }

        It "TestInfrastructureRoleInstanceShutdownOnTenantVM" -Skip:$('TestInfrastructureRoleInstanceShutdownOnTenantVM' -in $global:SkippedTests) {
            $global:TestName = 'TestInfrastructureRoleInstanceShutdownOnTenantVM'
            {
                Disable-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $global:TenantVMName -Force
            } | Should Throw
        }

        It "TestInfrastructureRoleInstanceRebootOnTenantVM" -Skip:$('TestInfrastructureRoleInstanceRebootOnTenantVM' -in $global:SkippedTests) {
            $global:TestName = 'TestInfrastructureRoleInstanceRebootOnTenantVM'
            {
                Restart-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $global:TenantVMName -Force
            } | Should Throw
        }

        It "TestInfrastructureRoleInstancePowerOffOnTenantVM" -Skip:$('TestInfrastructureRoleInstancePowerOffOnTenantVM' -in $global:SkippedTests) {
            $global:TestName = 'TestInfrastructureRoleInstancePowerOffOnTenantVM'
            {
                Stop-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $global:TenantVMName -Force
            } | Should Throw
        }


        # Disabled

        It "TestInfrastructureRoleInstanceShutdown" -Skip:$('TestInfrastructureRoleInstanceShutdown' -in $global:SkippedTests) {
            $global:TestName = 'TestInfrastructureRoleInstanceShutdown'

            $InfrastructureRoleInstances = Get-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            foreach ($InfrastructureRoleInstance in $InfrastructureRoleInstances) {
                Disable-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $InfrastructureRoleInstance.Name -Force
                break
            }
        }

        It "TestInfrastructureRoleInstancePowerOff" -Skip:$('TestInfrastructureRoleInstancePowerOff' -in $global:SkippedTests) {
            $global:TestName = 'TestInfrastructureRoleInstancePowerOff'

            $InfrastructureRoleInstances = Get-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            foreach ($InfrastructureRoleInstance in $InfrastructureRoleInstances) {
                Stop-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $InfrastructureRoleInstance.Name -Force
                break
            }
        }

        It "TestInfrastructureRoleInstanceReboot" -Skip:$('TestInfrastructureRoleInstanceReboot' -in $global:SkippedTests) {
            $global:TestName = 'TestInfrastructureRoleInstanceReboot'

            $InfrastructureRoleInstances = Get-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            foreach ($InfrastructureRoleInstance in $InfrastructureRoleInstances) {
                Restart-AzsInfrastructureRoleInstance -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $InfrastructureRoleInstance.Name -Force
                break
            }
        }
    }
}
