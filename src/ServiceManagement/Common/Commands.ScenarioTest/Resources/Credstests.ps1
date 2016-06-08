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

Import-Module azure
.".\Credentials.ps1"
$global:totalCount = 0;
$global:passedCount = 0;

function Run-TestProtected
{
   param([ScriptBlock]$script, [string] $testName)
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
   }
   catch
   {
     Out-String -InputObject $_.Exception | Write-Host -ForegroundColor Red
	 Write-Host
     Write-Host  -ForegroundColor Red =====================================
	 Write-Host -ForegroundColor Red "Test Failed"
     Write-Host  -ForegroundColor Red =====================================
	 Write-Host
   }
   finally
   {
      $global:totalCount = $global:totalCount + 1
   }
}

Run-TestProtected {Run-Test {Test-ImportPublishSettingsFile '.\tipsf001.publishsettings'} } "Multiple Test-ImportPublishSettingsFile"
Run-TestProtected {Run-Test {Test-ImportPublishSettingsFile '.\tipsf002.publishsettings'} } "Single Test-ImportPublishSettingsFile"
Run-TestProtected {Run-Test {Test-ImportPublishSettingsFile '.\tipsf003.publishsettings'} } "Alternate address Test-ImportPublishSettingsFile"
Run-TestProtected {Run-Test {Test-ImportInvalidPublishSettingsFile '.\tipsf004.publishsettings'}} "Import invalid publish settings"
Run-TestProtected {Run-Test {Test-ImportNonExistentPublishSettingsFile}} "Import non-existent publish settings"
Run-TestProtected {Run-Test {Test-RemoveInvalidSubscription}} "Remove invalid subscription"
Run-TestProtected {Run-Test {Test-RemoveEmptySubscription}} "Remove Empty Subscription"
Run-TestProtected {Run-Test {Test-GetInvalidSubscription}} "Get Invalid Subscription"
Run-TestProtected {Run-Test {Test-GetEmptySubscription}} "Get Empty Subscription"
Run-TestProtected {Run-Test {Test-GetEmptyCurrentSubscription}} "Get Current subscription (empty)"
Run-TestProtected {Run-Test {Test-GetEmptyDefaultSubscription}} "Get Default Subscription (empty)"
# Run-TestProtected {Run-Test {Test-SelectValidSubscriptions '.\tipsf001.publishsettings'}} "Select Valid Subscriptions"
Run-TestProtected {Run-Test {Test-SelectSubscriptionAfterClear '.\tipsf001.publishsettings'}} "Select subscription after clear"
Run-TestProtected {Run-Test {Test-SelectInvalidSubscription}} "Select invalid subscription"
Run-TestProtected {Run-Test {Test-SelectEmptySubscription}} "Select empty subscription"
Write-Host
Write-Host -ForegroundColor Green "$global:passedCount / $global:totalCount Credentials Tests Pass"
Write-Host

