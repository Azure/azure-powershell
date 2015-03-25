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

.".\\..\\Common.ps1"
.".\\..\\Assert.ps1"
.".\\Websites\\Common.ps1"
.".\\Websites\\WebsitesTests.ps1"
$global:totalCount = 0;
$global:passedCount = 0;
$global:passedTests = @()
$global:failedTests = @()
$global:times = @{}
Add-Type -Path "..\\Microsoft.Azure.Test.HttpRecorder.dll"
Add-Type -Path "..\\Microsoft.Azure.Test.Framework.dll"
[Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Initialize("foo", "bar")
function Run-TestProtected
{
   param([ScriptBlock]$script, [string] $testName)
   $testStart = Get-Date
   try 
   {
     Write-Host  -ForegroundColor Green =====================================
	 Write-Host  -ForegroundColor Green "Running test $testName"
     Write-Host  -ForegroundColor Green =====================================
	 Write-Host
     &$script
	 $global:passedCount = $global:passedCount + 1
	 Write-Host
     Write-Host  -ForegroundColor Green =====================================
	 Write-Host -ForegroundColor Green "Test Passed"
     Write-Host  -ForegroundColor Green =====================================
	 Write-Host
	 $global:passedTests += $testName
   }
   catch
   {
     Out-String -InputObject $_.Exception | Write-Host -ForegroundColor Red
	 Write-Host
     Write-Host  -ForegroundColor Red =====================================
	 Write-Host -ForegroundColor Red "Test Failed"
     Write-Host  -ForegroundColor Red =====================================
	 Write-Host
	 $global:failedTests += $testName
   }
   finally
   {
      $testEnd = Get-Date
	  $testElapsed = $testEnd - $testStart
	  $global:times[$testName] = $testElapsed
      $global:totalCount = $global:totalCount + 1
   }
}

Write-Host Initializing websites tests
Initialize-WebsiteTest
Write-Host Initialization Completed
$global:startTime = Get-Date
Run-TestProtected { Run-WebsiteTest {Test-GettingJobHistory} "Test-GettingJobHistory" } "Test-GettingJobHistory"
Run-TestProtected { Run-WebsiteTest {Test-GettingWebsiteJobs} "Test-GettingWebsiteJobs"} "Test-GettingWebsiteJobs"
Run-TestProtected { Run-WebsiteTest {Test-StartAndStopAzureWebsiteContinuousJob}  "Test-StartAndStopAzureWebsiteContinuousJob"} "Test-StartAndStopAzureWebsiteContinuousJob"
Run-TestProtected { Run-WebsiteTest {Test-StartAzureWebsiteTriggeredJob} "Test-StartAzureWebsiteTriggeredJob"} "Test-StartAzureWebsiteTriggeredJob"
Run-TestProtected { Run-WebsiteTest {Test-RemoveNonExistingAzureWebsiteJob} "Test-RemoveNonExistingAzureWebsiteJob"} "Test-RemoveNonExistingAzureWebsiteJob"
Run-TestProtected { Run-WebsiteTest {Test-RemoveAzureWebsiteContinuousJob} "Test-RemoveAzureWebsiteContinuousJob"} "Test-RemoveAzureWebsiteContinuousJob"
Run-TestProtected { Run-WebsiteTest {Test-RemoveAzureWebsiteTriggeredJob} "Test-RemoveAzureWebsiteTriggeredJob"} "Test-RemoveAzureWebsiteTriggeredJob"
Run-TestProtected { Run-WebsiteTest {Test-SetAzureWebsite} "Test-SetAzureWebsite"} "Test-SetAzureWebsite"
Run-TestProtected { Run-WebsiteTest {Test-NewAzureWebSiteUpdateGit}  "Test-NewAzureWebSiteUpdateGit"} "Test-NewAzureWebSiteUpdateGit"
#Run-TestProtected { Run-WebsiteTest {Test-NewAzureWebSiteGitHubAllParms} "Test-NewAzureWebSiteGitHubAllParms"} "Test-NewAzureWebSiteGitHubAllParms"
Run-TestProtected { Run-WebsiteTest {Test-NewAzureWebSiteMultipleCreds} "Test-NewAzureWebSiteMultipleCreds"} "Test-NewAzureWebSiteMultipleCreds"
Run-TestProtected { Run-WebsiteTest {Test-AzureWebSiteShowSingleSite} "Test-AzureWebSiteShowSingleSite"} "Test-AzureWebSiteShowSingleSite"
Run-TestProtected { Run-WebsiteTest {Test-AzureWebSiteListAll} "Test-AzureWebSiteListAll"} "Test-AzureWebSiteListAll"
Run-TestProtected { Run-WebsiteTest {Test-GetAzureWebSiteListNone} "Test-GetAzureWebSiteListNone"} "Test-GetAzureWebSiteListNone"
Run-TestProtected { Run-WebsiteTest {Test-KuduAppsExpressApp} "Test-KuduAppsExpressApp"} "Test-KuduAppsExpressApp"
Run-TestProtected { Run-WebsiteTest {Test-GetAzureWebsiteLocation} "Test-GetAzureWebsiteLocation"} "Test-GetAzureWebsiteLocation"
Run-TestProtected { Run-WebsiteTest {Test-DisablesBothByDefault} "Test-DisablesBothByDefault"} "Test-DisablesBothByDefault"
Run-TestProtected { Run-WebsiteTest {Test-DisablesStorageOnly} "Test-DisablesStorageOnly"} "Test-DisablesStorageOnly"
Run-TestProtected { Run-WebsiteTest {Test-DisablesFileOnly} "Test-DisablesFileOnly"} "Test-DisablesFileOnly"
Run-TestProtected { Run-WebsiteTest {Test-DisableApplicationDiagnosticOnTableStorageAndFile} "Test-DisableApplicationDiagnosticOnTableStorageAndFile"} "Test-DisableApplicationDiagnosticOnTableStorageAndFile"
Run-TestProtected { Run-WebsiteTest {Test-DisableApplicationDiagnosticOnFileSystem} "Test-DisableApplicationDiagnosticOnFileSystem"} "Test-DisableApplicationDiagnosticOnFileSystem"
Run-TestProtected { Run-WebsiteTest {Test-DisableApplicationDiagnosticOnTableStorage} "Test-DisableApplicationDiagnosticOnTableStorage"} "Test-DisableApplicationDiagnosticOnTableStorage"
Run-TestProtected { Run-WebsiteTest {Test-ThrowsForInvalidStorageAccountName} "Test-ThrowsForInvalidStorageAccountName"} "Test-ThrowsForInvalidStorageAccountName"
Run-TestProtected { Run-WebsiteTest {Test-ReconfigureStorageAppDiagnostics} "Test-ReconfigureStorageAppDiagnostics"} "Test-ReconfigureStorageAppDiagnostics"
Run-TestProtected { Run-WebsiteTest {Test-UpdateTheDiagnositicLogLevel} "Test-UpdateTheDiagnositicLogLevel"} "Test-UpdateTheDiagnositicLogLevel"
Run-TestProtected { Run-WebsiteTest {Test-EnableApplicationDiagnosticOnFileSystem} "Test-EnableApplicationDiagnosticOnFileSystem"} "Test-EnableApplicationDiagnosticOnFileSystem"
Run-TestProtected { Run-WebsiteTest {Test-EnableApplicationDiagnosticOnTableStorage} "Test-EnableApplicationDiagnosticOnTableStorage"} "Test-EnableApplicationDiagnosticOnTableStorage"
Run-TestProtected { Run-WebsiteTest {Test-EnableApplicationDiagnosticOnBlobStorage} "Test-EnableApplicationDiagnosticOnBlobStorage"} "Test-EnableApplicationDiagnosticOnBlobStorage"
Run-TestProtected { Run-WebsiteTest {Test-RestartAzureWebsite} "Test-RestartAzureWebsite"} "Test-RestartAzureWebsite"
Run-TestProtected { Run-WebsiteTest {Test-StopAzureWebsite} "Test-StopAzureWebsite"} "Test-StopAzureWebsite"
Run-TestProtected { Run-WebsiteTest {Test-StartAzureWebsite} "Test-StartAzureWebsite"} "Test-StartAzureWebsite"
Run-TestProtected { Run-WebsiteTest {Test-GetAzureWebsiteWithStoppedSite} "Test-GetAzureWebsiteWithStoppedSite"} "Test-GetAzureWebsiteWithStoppedSite"
Run-TestProtected { Run-WebsiteTest {Test-GetAzureWebsite} "Test-GetAzureWebsite"} "Test-GetAzureWebsite"
#Run-TestProtected { Run-WebsiteTest {Test-GetAzureWebsiteLogListPath} "Test-GetAzureWebsiteLogListPath"} "Test-GetAzureWebsiteLogListPath"
#Run-TestProtected { Run-WebsiteTest {Test-GetAzureWebsiteLogTailUriEncoding} "Test-GetAzureWebsiteLogTailUriEncoding"} "Test-GetAzureWebsiteLogTailUriEncoding"
#Run-TestProtected { Run-WebsiteTest {Test-GetAzureWebsiteLogTailPath} "Test-GetAzureWebsiteLogTailPath"} "Test-GetAzureWebsiteLogTailPath"
#Run-TestProtected { Run-WebsiteTest {Test-GetAzureWebsiteLogTail} "Test-GetAzureWebsiteLogTail"} "Test-GetAzureWebsiteLogTail"
Run-TestProtected { Run-WebsiteTest {Test-RemoveAzureServiceWithWhatIf} "Test-RemoveAzureServiceWithWhatIf"} "Test-RemoveAzureServiceWithWhatIf"
Run-TestProtected { Run-WebsiteTest {Test-RemoveAzureServiceWithNonExistingName} "Test-RemoveAzureServiceWithNonExistingName"} "Test-RemoveAzureServiceWithNonExistingName"
Run-TestProtected { Run-WebsiteTest {Test-RemoveAzureServiceWithValidName} "Test-RemoveAzureServiceWithValidName"} "Test-RemoveAzureServiceWithValidName"
Run-TestProtected { Run-WebsiteTest {Test-WithInvalidCredentials { Get-AzureWebsiteLog -Tail -Name foo }} "TestGetAzureWebsiteLogWithInvalidCredentials"} "TestGetAzureWebsiteLogWithInvalidCredentials"
Run-TestProtected { Run-WebsiteTest {Test-WithInvalidCredentials {Remove-AzureWebsite foo -Force }} "TestRemoveAzureWebsiteWithInvalidCredentials"} "TestRemoveAzureWebsiteWithInvalidCredentials"
Write-Host
Write-Host -ForegroundColor Green "$global:passedCount / $global:totalCount Website Tests Pass"
Write-Host -ForegroundColor Green "============"
Write-Host -ForegroundColor Green "PASSED TESTS"
Write-Host -ForegroundColor Green "============"
$global:passedTests | % { Write-Host -ForegroundColor Green "PASSED "$_": "($global:times[$_]).ToString()}
Write-Host -ForegroundColor Green "============"
Write-Host
Write-Host -ForegroundColor Red "============"
Write-Host -ForegroundColor Red "FAILED TESTS"
Write-Host -ForegroundColor Red "============"
$global:failedTests | % { Write-Host -ForegroundColor Red "FAILED "$_": "($global:times[$_]).ToString()}
Write-Host -ForegroundColor Red "============"
Write-Host
$global:endTime = Get-Date
Write-Host -ForegroundColor Green "======="
Write-Host -ForegroundColor Green "TIMES"
Write-Host -ForegroundColor Green "======="
Write-Host
Write-Host -ForegroundColor Green "Start Time: $global:startTime"
Write-Host -ForegroundColor Green "End Time: $global:endTime"
Write-Host -ForegroundColor Green "Elapsed: "($global:endTime - $global:startTime).ToString()


