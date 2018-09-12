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
    Run AzureStack QueueServices admin tests

.DESCRIPTION
    Run AzureStack QueueServices admin tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\QueueServices.Tests.ps1
    Describing QueueServices
	[+] TestGetQueueService 3.18s
	[+] TestListAllQueueServiceMetricDefinitions 1.31s
	[+] TestListAllQueueServiceMetrics 1.35s

.NOTES
    Author: Deepa Thomas
	Copyright: Microsoft
    Date:   February 28, 2018
#>
param(
    [bool]$RunRaw = $false,
    [bool]$UseInstalled = $false
)

$Global:UseInstalled = $UseInstalled
$global:RunRaw = $RunRaw
$global:TestName = ""

. $PSScriptRoot\CommonModules.ps1

InModuleScope Azs.Storage.Admin {

    Describe "QueueServices" -Tags @('QueueServices', 'Azs.Storage.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateQueueService {
                param(
                    [Parameter(Mandatory = $true)]
                    $queueService
                )
                # Resource
                $queueService								| Should Not Be $null

                # Validate QueueService properties
                $queueService.FrontEndCallbackThreadsCount					| Should Not Be $null
                $queueService.FrontEndCpuBasedKeepAliveThrottlingCpuMonitorIntervalInSeconds					| Should Not Be $null
                $queueService.FrontEndCpuBasedKeepAliveThrottlingEnabled							| Should Not Be $null
                $queueService.FrontEndCpuBasedKeepAliveThrottlingPercentCpuThreshold						| Should Not Be $null
                $queueService.FrontEndCpuBasedKeepAliveThrottlingPercentRequestsToThrottle							| Should Not Be $null
                $queueService.FrontEndHttpListenPort					| Should Not Be $null
                $queueService.FrontEndHttpsListenPort				| Should Not Be $null
                $queueService.FrontEndMaxMillisecondsBetweenMemorySamples							| Should Not Be $null
                $queueService.FrontEndMemoryThrottleThresholdSettings						| Should Not Be $null
                $queueService.FrontEndMemoryThrottlingEnabled					| Should Not Be $null
                $queueService.FrontEndMinThreadPoolThreads					| Should Not Be $null
                $queueService.FrontEndThreadPoolBasedKeepAliveIOCompletionThreshold					| Should Not Be $null
                $queueService.FrontEndThreadPoolBasedKeepAliveMonitorIntervalInSeconds							| Should Not Be $null
                $queueService.FrontEndThreadPoolBasedKeepAlivePercentage						| Should Not Be $null
                $queueService.FrontEndThreadPoolBasedKeepAliveWorkerThreadThreshold							| Should Not Be $null
                $queueService.FrontEndUseSlaTimeInAvailability					| Should Not Be $null
                $queueService.Id				| Should Not Be $null
                $queueService.Location							| Should Not Be $null
                $queueService.Type				| Should Not Be $null
                $queueService.Version							| Should Not Be $null
                $queueService.Name						| Should Not Be $null
            }
        }

        AfterEach {
            $global:Client = $null
        }

        it "TestGetQueueService" -Skip:$('TestGetQueueService' -in $global:SkippedTests) {
            $global:TestName = 'TestGetQueueService'

            $farms = Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroupName
            foreach ($farm in $farms) {
                $queueService = Get-AzsQueueService -ResourceGroupName $global:ResourceGroupName -FarmName $farm.Name
                ValidateQueueService -queueService $queueService
            }
        }

        it "TestListAllQueueServiceMetricDefinitions" -Skip:$('TestListAllQueueServiceMetricDefinitions' -in $global:SkippedTests) {
            $global:TestName = 'TestListAllQueueServiceMetricDefinitions'

            $farms = Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroupName
            foreach ($farm in $farms) {
                Get-AzsQueueServiceMetricDefinition -ResourceGroupName $global:ResourceGroupName -FarmName $farm.Name | Out-Null
            }
        }

        it "TestListAllQueueServiceMetrics" -Skip:$('TestListAllQueueServiceMetrics' -in $global:SkippedTests) {
            $global:TestName = 'TestListAllQueueServiceMetrics'

            $farms = Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroupName
            foreach ($farm in $farms) {
                Get-AzsQueueServiceMetric -ResourceGroupName $global:ResourceGroupName -FarmName $farm.Name | Out-Null
            }
        }
    }
}
