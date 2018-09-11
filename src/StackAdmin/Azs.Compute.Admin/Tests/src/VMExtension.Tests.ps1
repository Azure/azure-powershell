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
    Run AzureStack Compute admin edge gateway tests.

.DESCRIPTION
    Run AzureStack Compute admin edge gateway tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\SubscriberUsageAggregate.Tests.ps1
    Describing SubscriberUsageAggregates
	 [+] TestListSubscriberUsageAggregates 81ms
	 [+] TestGetSubscriberUsageAggregate 73ms
	 [+] TestGetAllSubscriberUsageAggregates 66ms

.NOTES
    Author: Microsoft
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

InModuleScope Azs.Compute.Admin {

    Describe "VMExtensions" -Tags @('VMExtensions', 'Azs.Compute.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateVMExtension {
                param(
                    [Parameter(Mandatory = $true)]
                    $VMExtension
                )

                $VMExtension          | Should Not Be $null

                # Resource
                $VMExtension.Id       | Should Not Be $null
                $VMExtension.Type     | Should Not Be $null
            }

            function ValidateSameVMExtension {
                param(
                    $VMExt1,
                    $VMExt2
                )
                Get-Member -InputObject $VMExt1 -MemberType Properties {
                    $variable = $_.Name
                    $VMExt1."$variable" | Should be $VMExt2."$variable"
                }
            }
        }

		AfterEach {
			$global:Client = $null
		}


        It "TestListVMExtensions" -Skip:$('TestListVMExtensions' -in $global:SkippedTests) {
            $global:TestName = 'TestListVMExtensions'

            $VMExtensions = Get-AzsVMExtension -Location $global:Location
            $VMExtensions | Should Not Be $null
            foreach ($VMExtension in $VMExtensions) {
                ValidateVMExtension -VMExtension $VMExtension
            }
        }


        It "TestGetVMExtension" -Skip:$('TestGetVMExtension' -in $global:SkippedTests) {
            $global:TestName = 'TestGetVMExtension'

            $VMExtensions = Get-AzsVMExtension -Location $global:Location
            $VMExtensions | Should Not Be $null
            foreach ($VMExtension in $VMExtensions) {
                ValidateVMExtension -VMExtension $VMExtension
            }
        }


        It "TestGetAllVMExtensions" -Skip:$('TestGetAllVMExtensions' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllVMExtensions'

            $VMExtensions = Get-AzsVMExtension -Location $global:Location
            $VMExtensions | Should Not Be $null
            foreach ($VMExtension in $VMExtensions) {
                $vmExt = Get-AzsVMExtension `
                    -Location $vmextension.Location `
                    -Publisher $vmExtension.Publisher `
                    -Type $vmExtension.ExtensionType `
                    -Version $vmExtension.TypeHandlerVersion `

                $vmExt | Should not be $null
                ValidateSameVMExtension $VMExtension $vmExt
            }
        }


        It "TestCreateVMExtension" -Skip:$('TestCreateVMExtension' -in $global:SkippedTests) {
            $global:TestName = 'TestCreateVMExtension'
            $result = Add-AzsVMExtension `
                -Location $global:Location `
                -Publisher "Microsoft" `
                -Type "MicroExtension" `
                -Version "0.1.0" `
                -ComputeRole "IaaS" `
                -SourceBlob "https://github.com/Microsoft/PowerShell-DSC-for-Linux/archive/v1.1.1-294.zip" `
                -SupportMultipleExtensions `
                -VmOsType "Linux" `
                -Force
            $result | Should not be $null
        }


        It "TestDeleteVMExtension" -Skip:$('TestDeleteVMExtension' -in $global:SkippedTests) {
            $global:TestName = 'TestDeleteVMExtension'
            Remove-AzsVMExtension -Location $global:Location -Publisher "Microsoft" -Type "MicroExtension" -Version "0.1.0" -Force
        }
    }
}
