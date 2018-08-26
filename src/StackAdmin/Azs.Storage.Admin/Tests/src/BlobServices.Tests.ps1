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
    Run AzureStack BlobServices admin tests

.DESCRIPTION
    Run AzureStack BlobServices admin tests using either mock client or our client.
	The mock client allows for recording and playback.  This allows for offline tests.

.PARAMETER RunRaw
    Run using our client creation path.

.EXAMPLE
    PS C:\> .\src\BlobServices.Tests.ps1
    Describing BlobServices
  [+] TestGetBlobService 2.16s
  [+] TestListBlobServiceMetricDefinitions 1.58s
  [+] TestListBlobServiceMetrics 2.02s

.NOTES
    Author: Deepa Thomas
	Copyright: Microsoft
    Date:   February 20, 2018
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

    Describe "BlobServices" -Tags @('BlobService', 'Azs.Storage.Admin') {

        . $PSScriptRoot\Common.ps1

        BeforeEach {

            function ValidateBlobService {
                param(
                    [Parameter(Mandatory = $true)]
                    $BlobService
                )
                # Resource
                $BlobService					| Should Not Be $null

                # Validate BlobService properties
                $BlobService.BlobSvcContainerGcInterval										| Should Not Be $null
                $BlobService.BlobSvcShallowGcInterval										| Should Not Be $null
                $BlobService.BlobSvcStreamMapMinContainerOccupancyPercent					| Should Not Be $null
                $BlobService.FrontEndCallbackThreadsCount									| Should Not Be $null
                $BlobService.FrontEndCpuBasedKeepAliveThrottlingCpuMonitorIntervalInSeconds	| Should Not Be $null
                $BlobService.FrontEndCpuBasedKeepAliveThrottlingEnabled						| Should Not Be $null
                $BlobService.FrontEndCpuBasedKeepAliveThrottlingPercentCpuThreshold			| Should Not Be $null
                $BlobService.FrontEndCpuBasedKeepAliveThrottlingPercentRequestsToThrottle	| Should Not Be $null
                $BlobService.FrontEndHttpListenPort											| Should Not Be $null
                $BlobService.FrontEndHttpsListenPort										| Should Not Be $null
                $BlobService.FrontEndMaxMillisecondsBetweenMemorySamples					| Should Not Be $null
                $BlobService.FrontEndMemoryThrottleThresholdSettings						| Should Not Be $null
                $BlobService.FrontEndMemoryThrottlingEnabled								| Should Not Be $null
                $BlobService.FrontEndMinThreadPoolThreads									| Should Not Be $null
                $BlobService.FrontEndThreadPoolBasedKeepAliveIOCompletionThreshold			| Should Not Be $null
                $BlobService.FrontEndThreadPoolBasedKeepAliveMonitorIntervalInSeconds		| Should Not Be $null
                $BlobService.FrontEndThreadPoolBasedKeepAlivePercentage						| Should Not Be $null
                $BlobService.FrontEndThreadPoolBasedKeepAliveWorkerThreadThreshold			| Should Not Be $null
                $BlobService.FrontEndUseSlaTimeInAvailability								| Should Not Be $null
                $BlobService.Location														| Should Not Be $null
                $BlobService.Version														| Should Not Be $null
                $BlobService.Id																| Should Not Be $null
                $BlobService.Name															| Should Not Be $null
                $BlobService.Type															| Should Not Be $null
            }
        }

        it "TestGetBlobService" -Skip:$('TestGetBlobService' -in $global:SkippedTests) {
            $global:TestName = 'TestGetBlobService'

            $farms = Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroupName
            foreach ($farm in $farms) {
                $blobService = Get-AzsBlobService -ResourceGroupName $global:ResourceGroupName -FarmName (Select-Name $farm.Name)
                $blobService  | Should Not Be $null
                ValidateBlobService -BlobService $blobService
            }
        }

        it "TestListBlobServiceMetricDefinitions" -Skip:$('TestListBlobServiceMetricDefinitions' -in $global:SkippedTests) {
            $global:TestName = 'TestListBlobServiceMetricDefinitions'

            $farms = Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroupName
            foreach ($farm in $farms) {
                $blobService = Get-AzsBlobService -ResourceGroupName $global:ResourceGroupName -FarmName (Select-Name $farm.Name)
                $blobService  | Should Not Be $null
                ValidateBlobService -BlobService $blobService
                Get-AzsBlobServiceMetricDefinition -ResourceGroupName $global:ResourceGroupName -FarmName (Select-Name $farm.Name)
            }
        }

        it "TestListBlobServiceMetrics" -Skip:$('TestListBlobServiceMetrics' -in $global:SkippedTests) {
            $global:TestName = 'TestListBlobServiceMetrics'

            $farms = Get-AzsStorageFarm -ResourceGroupName $global:ResourceGroupName
            foreach ($farm in $farms) {
                $blobService = Get-AzsBlobService -ResourceGroupName $global:ResourceGroupName -FarmName (Select-Name $farm.Name)
                $blobService  | Should Not Be $null
                ValidateBlobService -BlobService $blobService
                Get-AzsBlobServiceMetric -ResourceGroupName $global:ResourceGroupName -FarmName (Select-Name $farm.Name)
            }
        }
    }
}
