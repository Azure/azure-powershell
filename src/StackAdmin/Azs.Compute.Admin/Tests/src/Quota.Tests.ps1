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

InModuleScope Azs.Compute.Admin {

    Describe "Quota" -Tags @('Quota', 'Azs.Compute.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateComputeQuota {
                param(
                    [Parameter(Mandatory = $true)]
                    $Quota
                )

                $Quota          | Should Not Be $null

                # Resource
                $Quota.Id       | Should Not Be $null
                $Quota.Name     | Should Not Be $null
                $Quota.Type     | Should Not Be $null

                # Subscriber Usage Aggregate
                $Quota.AvailabilitySetCount                 | Should Not Be $null
                $Quota.CoresLimit                           | Should Not Be $null
                $Quota.VirtualMachineCount                  | Should Not Be $null
                $Quota.VmScaleSetCount                      | Should Not Be $null
                $Quota.StandardManagedDiskAndSnapshotSize   | Should Not Be $null
                $Quota.PremiumManagedDiskAndSnapshotSize    | Should Not Be $null
            }

            function AssertSame {
                param(
                    $Expected,
                    $Found
                )
            }
        }
        
        It "TestListQuotas" -Skip:$('TestListQuotas' -in $global:SkippedTests) {
            $global:TestName = 'TestListQuotas'
            $quotas = Get-AzsComputeQuota -Location $global:Location

            $quotas | Should Not Be $null
            foreach ($quota in $quotas) {
                ValidateComputeQuota -Quota $quota
            }
        }
                
        It "TestGetQuota" -Skip:$('TestGetQuota' -in $global:SkippedTests) {
            $global:TestName = 'TestGetQuota'

            $quotas = Get-AzsComputeQuota -Location $global:Location
            $quotas | Should Not Be $null
            foreach ($quota in $quotas) {
                $result = Get-AzsComputeQuota -Location $global:Location -Name $quota.Name

                AssertSame -Expected $quota -Found $result
                break
            }
        }

        It "TestGetAllQuotas" -Skip:$('TestGetAllQuotas' -in $global:SkippedTests) {
            $global:TestName = 'TestGetAllQuotas'
            $quotas = Get-AzsComputeQuota -Location $global:Location
            $quotas | Should Not Be $null
            foreach ($quota in $quotas) {
                $result = Get-AzsComputeQuota -Location $global:Location -Name $quota.Name
                AssertSame -Expected $quota -Found $result
            }
        }

        It "TestCreateQuota" -Skip:$('TestCreateQuota' -in $global:SkippedTests) {
            $global:TestName = 'TestCreateQuota'

            $quotaNamePrefix = "testQuota"
            $data = @(
                @(0, 0, 0, 0, 0, 0, 0),
                @(1, 0, 0, 0, 0, 0, 1),
                @(0, 1, 0, 0, 0, 0, 2),
                @(0, 0, 1, 0, 0, 0, 3),
                @(0, 0, 0, 1, 0, 0, 4),
                @(0, 0, 0, 0, 1, 0, 5),
                @(0, 0, 0, 0, 0, 1, 6),
                @(100, 100, 100, 100 ,100, 100, 7),
                @(1000, 1000, 1000, 1000, 1000, 1000, 8)
            )

            $data | ForEach-Object {
                $name = $quotaNamePrefix + $_[6]
                $quota = New-AzsComputeQuota -Location $global:Location -Name $name -AvailabilitySetCount $_[0] -CoresLimit $_[1] -VmScaleSetCount $_[2] -VirtualMachineCount $_[3] -StandardManagedDiskAndSnapshotSize $_[4] -PremiumManagedDiskAndSnapshotSize $_[5]
                $quota.AvailabilitySetCount                 | Should be $_[0]
                $quota.CoresLimit                           | Should be $_[1]
                $quota.VmScaleSetCount                      | Should be $_[2]
                $quota.VirtualMachineCount                  | Should be $_[3]
                $quota.StandardManagedDiskAndSnapshotSize   | Should be $_[4]
                $quota.PremiumManagedDiskAndSnapshotSize    | Should be $_[5]
            }

            $data | ForEach-Object {
                $name = $quotaNamePrefix + $_[6]
                Remove-AzsComputeQuota -Location $global:Location -Name $name -Force
            }

        }
        
        # Tests wth Invalid data
        It "TestCreateInvalidQuota" -Skip:$('TestCreateInvalidQuota' -in $global:SkippedTests) {
            $global:TestName = 'TestCreateInvalidQuota'

            $data = @(
                @(-1, 1, 1, 1, 1, 1),
                @(1, -1, 1, 1, 1, 1),
                @(1, 1, -1, 1, 1, 1),
                @(1, 1, 1, -1, 1, 1),
                @(1, 1, 1, 1, -1, 1),
                @(1, 1, 1, 1, 1, -1),
                @(-1, 0, 0, 0, 0, 0),
                @( 0, -1, 0, 0, 0, 0),
                @( 0, 0, -1, 0, 0, 0),
                @( 0, 0, 0, -1, 0, 0),
                @( 0, 0, 0, 0, -1, 0),
                @( 0, 0, 0, 0, 0, -1),
                @(-1, -1, -1, -1, -1, -1)
            )

            $name = "myQuota"
            $data | ForEach-Object {
                {
                    New-AzsComputeQuota -Location $global:Location -Name $name -AvailabilitySetCount $_[0] -CoresLimit $_[1] -VmScaleSetCount $_[2] -VirtualMachineCount $_[3] -StandardManagedDiskAndSnapshotSize $_[4] -PremiumManagedDiskAndSnapshotSize $_[5]
                } | Should Throw
            }
        }

        # Apparently CRP will default to a place even if it does not exist
        It "TestListInvalidLocation" -Skip:$('TestListInvalidLocation' -in $global:SkippedTests) {
            $global:TestName = 'TestListInvalidLocation'
            $quotas = Get-AzsComputeQuota -Location "thisisnotarealplace"
            $quotas | Should Be $null
        }

        It "TestDeleteNonExistingQuota" -Skip:$('TestDeleteNonExistingQuota' -in $global:SkippedTests) {
            $global:TestName = 'TestDeleteNonExistingQuota'

            {Remove-AzsComputeQuota -Location $global:Location -Name "thisdoesnotexistandifitdoesoops" -Force} | Should Throw "Operation returned an invalid status code 'NotFound'"
        }

        It "TestCreateQuotaOnInvalidLocation" -Skip:$('TestCreateQuotaOnInvalidLocation' -in $global:SkippedTests) {
            $global:TestName = 'TestCreateQuotaOnInvalidLocation'

            $quotaNamePrefix = "testQuota"
            $invalidLocation = "thislocationdoesnotexist"

            $data = @(
                @( 0, 0, 0, 0, 0, 0, 0 ),
                @( 1, 0, 0, 0, 0, 0, 1 ),
                @( 0, 1, 0, 0, 0, 0, 2 ),
                @( 0, 0, 1, 0, 0, 0, 3 ),
                @( 0, 0, 0, 1, 0, 0, 4 ),
                @( 0, 0, 0, 0, 1, 0, 5 ),
                @( 0, 0, 0, 0, 0, 1, 6 ),
                @( 100, 100, 100, 100 ,100, 100,  7 ),
                @( 1000, 1000, 1000, 1000, 1000, 1000, 8 )
            )
            $data | ForEach-Object {
                $name = $quotaNamePrefix + $_[6]
                New-AzsComputeQuota -Location $invalidLocation -Name $name -AvailabilitySetCount $_[0] -CoresLimit $_[1] -VmScaleSetCount $_[2] -VirtualMachineCount $_[3] -StandardManagedDiskAndSnapshotSize $_[4] -PremiumManagedDiskAndSnapshotSize $_[5] | Should be $null
                Get-AzsComputeQuota -Location $invalidLocation -Name $quota.Name | Should be $null

            }

            $data | ForEach-Object {
                $name = $quotaNamePrefix + $_[4]
                Get-AzsComputeQuota -Location | Where-Object { $_.Name -eq $name} | Should be $null
            }
        }
        
        # Session recording for this needs a manual update.
        # Set command would try to do a get before to ensure the quota exists.
        It "TestQuotaCreateUpdateDelete" -Skip:$('TestQuotaCreateUpdateDelete' -in $global:SkippedTests) {
            $global:TestName = 'TestQuotaCreateUpdateDelete'

            #
            #	if running against the actual environment enable the following to create first.
            #	New-AzsComputeQuota -Location $global:Location -Name "testQuotaCreateUpdateDelete" -AvailabilitySetCount 1 -CoresLimit 1 -VmScaleSetCount 1 -VirtualMachineCount 1 -StandardManagedDiskAndSnapshotSize 1 -PremiumManagedDiskAndSnapshotSize 1
            # Powershell replay playback session grabs the first matching response in the recorded sessions file. 
            # So it always picks the first response. If the test checks for not exist (404), then create and checks for exists, that test would always fail in recoreded sessions.
            #
            Set-AzsComputeQuota -Location $global:Location -Name "testQuotaCreateUpdateDelete" -AvailabilitySetCount 1 -CoresLimit 1 -VmScaleSetCount 1 -VirtualMachineCount 1 -StandardManagedDiskAndSnapshotSize 1 -PremiumManagedDiskAndSnapshotSize 1
            Set-AzsComputeQuota -Location $global:Location -Name "testQuotaCreateUpdateDelete" -AvailabilitySetCount 1 -CoresLimit 1 -VmScaleSetCount 1 -VirtualMachineCount 2 -StandardManagedDiskAndSnapshotSize 1 -PremiumManagedDiskAndSnapshotSize 1
            Set-AzsComputeQuota -Location $global:Location -Name "testQuotaCreateUpdateDelete" -AvailabilitySetCount 2 -CoresLimit 1 -VmScaleSetCount 1 -VirtualMachineCount 2 -StandardManagedDiskAndSnapshotSize 1 -PremiumManagedDiskAndSnapshotSize 1
            Set-AzsComputeQuota -Location $global:Location -Name "testQuotaCreateUpdateDelete" -AvailabilitySetCount 2 -CoresLimit 1 -VmScaleSetCount 2 -VirtualMachineCount 2 -StandardManagedDiskAndSnapshotSize 1 -PremiumManagedDiskAndSnapshotSize 1
            Set-AzsComputeQuota -Location $global:Location -Name "testQuotaCreateUpdateDelete" -AvailabilitySetCount 2 -CoresLimit 2 -VmScaleSetCount 2 -VirtualMachineCount 2 -StandardManagedDiskAndSnapshotSize 1 -PremiumManagedDiskAndSnapshotSize 1
            Set-AzsComputeQuota -Location $global:Location -Name "testQuotaCreateUpdateDelete" -AvailabilitySetCount 2 -CoresLimit 2 -VmScaleSetCount 2 -VirtualMachineCount 2 -StandardManagedDiskAndSnapshotSize 2 -PremiumManagedDiskAndSnapshotSize 1
            Set-AzsComputeQuota -Location $global:Location -Name "testQuotaCreateUpdateDelete" -AvailabilitySetCount 2 -CoresLimit 2 -VmScaleSetCount 2 -VirtualMachineCount 2 -StandardManagedDiskAndSnapshotSize 2 -PremiumManagedDiskAndSnapshotSize 2
        }

    }
}
