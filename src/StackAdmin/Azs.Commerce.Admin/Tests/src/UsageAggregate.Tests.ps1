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
    Run AzureStack Commerce admin edge gateway tests.

.DESCRIPTION
    Run AzureStack Commerce admin edge gateway tests using either mock client or our client.
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
    [bool]$RunRaw = $false
)

$global:RunRaw = $RunRaw

. $PSScriptRoot\CommonModules.ps1

$global:TestName = ""

InModuleScope Azs.Commerce.Admin {

    Describe "SubscriberUsageAggregates" -Tags @('SubscriberUsageAggregate', 'Azs.Commerce.Admin') {

        BeforeEach {

            . $PSScriptRoot\Common.ps1

            function ValidateSubscriberUsageAggregate {
                param(
                    [Parameter(Mandatory = $true)]
                    $SubscriberUsageAggregate
                )

                $SubscriberUsageAggregate          | Should Not Be $null

                # Resource
                $SubscriberUsageAggregate.Id       | Should Not Be $null
                $SubscriberUsageAggregate.Name     | Should Not Be $null
                $SubscriberUsageAggregate.Type     | Should Not Be $null

                # Subscriber Usage Aggregate
                $SubscriberUsageAggregate.InstanceData    | Should Not Be $null
                $SubscriberUsageAggregate.MeterId         | Should Not Be $null
                $SubscriberUsageAggregate.Quantity        | Should Not Be $null
                $SubscriberUsageAggregate.SubscriptionId  | Should Not Be $null
                $SubscriberUsageAggregate.UsageEndTime    | Should Not Be $null
                $SubscriberUsageAggregate.UsageStartTime  | Should Not Be $null

            }
        }


        It "TestListSubscriberUsageAggregatesFromLastTwoDays" {
            $global:TestName = 'TestListSubscriberUsageAggregatesFromLastTwoDays'

            [DateTime]$start = "2017-09-06T00:00:00Z"
            [DateTime]$end = "2017-09-07T00:00:00Z"

            $usageAggregates = Get-AzsSubscriberUsage -ReportedStartTime $start -ReportedEndTime $end -AggregationGranularity Hourly
            foreach ($usageAggregate in $usageAggregates) {
                ValidateSubscriberUsageAggregate -SubscriberUsageAggregate $usageAggregate
            }
        }


    }
}
