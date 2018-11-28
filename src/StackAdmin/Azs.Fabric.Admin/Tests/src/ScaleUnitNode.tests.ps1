﻿# ----------------------------------------------------------------------------------
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
    [bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)

$Global:UseInstalled = $UseInstalled
$global:RunRaw = $RunRaw
$global:TestName = ""

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Fabric.Admin {

    Describe "ScaleUnitNodes" -Tags @('ScaleUnitNode', 'Azs.Fabric.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateScaleUnitNode {
                param(
                    [Parameter(Mandatory = $true)]
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
                    [Parameter(Mandatory = $true)]
                    $Expected,

                    [Parameter(Mandatory = $true)]
                    $Found
                )
                if ($Expected -eq $null) {
                    $Found | Should Be $null
                }
                else {
                    $Found                  | Should Not Be $null

                    # Resource
                    $Found.Id               | Should Be $Expected.Id
                    $Found.Location         | Should Be $Expected.Location
                    $Found.Name             | Should Be $Expected.Name
                    $Found.Type             | Should Be $Expected.Type

                    # Scale Unit Node
                    $Found.CanPowerOff          | Should Be $Expected.CanPowerOff

                    if ($Expected.Capacity -eq $null) {
                        $Found.Capacity  | Should Be $null
                    }
                    else {
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

        AfterEach {
            $global:Client = $null
        }


        It "TestListScaleUnitNodes" -Skip:$('TestListScaleUnitNodes' -in $global:SkippedTests) {
            $global:TestName = 'TestListScaleUnitNodes'

            $ScaleUnitNodes = Get-AzsScaleUnitNode -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            $ScaleUnitNodes | Should Not Be $null
            foreach ($ScaleUnitNode in $ScaleUnitNodes) {
                ValidateScaleUnitNode -ScaleUnitNode $ScaleUnitNode
            }
        }


        It "TestGetScaleUnitNode" -Skip:$('TestGetScaleUnitNode' -in $global:SkippedTests) {
            $global:TestName = 'TestGetScaleUnitNode'

            $ScaleUnitNodes = Get-AzsScaleUnitNode -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            foreach ($ScaleUnitNode in $ScaleUnitNodes) {
                $retrieved = Get-AzsScaleUnitNode -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $ScaleUnitNode.Name
                AssertScaleUnitNodesAreSame -Expected $ScaleUnitNode -Found $retrieved
                break
            }
        }

        It "TestGetAllScaleUnitNodes" -Skip:$('TestGetAllScaleUnitNodes' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllScaleUnitNodes'

            $ScaleUnitNodes = Get-AzsScaleUnitNode -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            foreach ($ScaleUnitNode in $ScaleUnitNodes) {
                $retrieved = Get-AzsScaleUnitNode -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $ScaleUnitNode.Name
                AssertScaleUnitNodesAreSame -Expected $ScaleUnitNode -Found $retrieved
            }
        }

        It "TestStartStopMaintenanceModeUnitNode" -Skip:$('TestStartStopMaintenanceModeUnitNode' -in $global:SkippedTests) {
            $global:TestName = 'TestStartStopMaintenanceModeUnitNode'

            $ScaleUnitNodes = Get-AzsScaleUnitNode -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            foreach ($ScaleUnitNode in $ScaleUnitNodes) {
                {
                    Disable-AzsScaleUnitNode -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $ScaleUnitNode.Name -Force -ErrorAction Stop
                    Enable-AzsScaleUnitNode -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $ScaleUnitNode.Name -Force -ErrorAction Stop
                } | Should Throw
                break
            }
        }

        # Tenant VM

        It "TestGetScaleUnitNodeOnTenantVM" -Skip:$('TestGetScaleUnitNodeOnTenantVM' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllScaleUnitNodes'

            { Get-AzsScaleUnitNode -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $global:TenantVMName -ErrorAction Stop } | Should Throw
        }

        It "TestPowerOnOnTenantVM" -Skip:$('TestPowerOnOnTenantVM' -in $global:SkippedTests) {
            $global:TestName = 'TestPowerOnOnTenantVM'
            {
                $operationStatus = Start-AzsScaleUnitNode -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $global:TenantVMName -Force -ErrorAction Stop
                $operationStatus.ProvisioningState | Should not be ""
                $operationStatus.ProvisioningState | Should be "Failure"
            } | Should Throw
        }

        It "TestPowerOffOnTenantVM" -Skip:$('TestPowerOffOnTenantVM' -in $global:SkippedTests) {
            $global:TestName = 'TestPowerOffOnTenantVM'

            {
                $operationStatus = Stop-AzsScaleUnitNode -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $global:TenantVMName -Force -ErrorAction Stop
                $operationStatus.ProvisioningState | Should not be ""
                $operationStatus.ProvisioningState | Should be "Failure"
            } | Should Throw
        }

        It "TestStartMaintenanceModeOnTenantVM" -Skip:$('TestStartMaintenanceModeOnTenantVM' -in $global:SkippedTests) {
            $global:TestName = 'TestStartMaintenanceModeOnTenantVM'
            {
                $operationStatus = Disable-AzsScaleUnitNode -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $TenantVMName -Force -ErrorAction Stop
                $operationStatus.ProvisioningState | Should not be ""
                $operationStatus.ProvisioningState | Should be "Failure"
            } | Should Throw
        }


        # Disabled

        It "TestPowerOnScaleUnitNode" -Skip:$('TestPowerOnScaleUnitNode' -in $global:SkippedTests) {
            $global:TestName = 'TestPowerOnScaleUnitNode'

            $ScaleUnitNodes = Get-AzsScaleUnitNode -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            foreach ($ScaleUnitNode in $ScaleUnitNodes) {
                Start-AzsScaleUnitNode -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $ScaleUnitNode.Name -Force
                $retrieved | Should Be $null
                break
            }
        }

        It "TestPowerOffScaleUnitNode" -Skip:$('TestPowerOffScaleUnitNode' -in $global:SkippedTests) {
            $global:TestName = 'TestPowerOffScaleUnitNode'

            $ScaleUnitNodes = Get-AzsScaleUnitNode -ResourceGroupName $global:ResourceGroupName -Location $global:Location
            foreach ($ScaleUnitNode in $ScaleUnitNodes) {
                $retrieved = Stop-AzsScaleUnitNode -ResourceGroupName $global:ResourceGroupName -Location $global:Location -Name $ScaleUnitNode.Name -Force
                $retrieved | Should Be $null
                break
            }
        }

        It "TestAddScaleUnitNode" -Skip:$('TestAddScaleUnitNode' -in $global:SkippedTests) {
            $global:TestName = "TestAddScaleUnitNode"

            $NewNode = New-AzsScaleUnitNodeObject -ComputerName "ASRR1N22R19U29" -BMCIPv4Address "100.83.64.17"
            {
            Add-AzsScaleUnitNode -NodeList $NewNode -ScaleUnit "s-cluster" -Location 'east'
            } | Should not throw

        }
    }
}
