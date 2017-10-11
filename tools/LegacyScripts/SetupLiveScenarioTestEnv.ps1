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

[CmdletBinding()]
Param( [switch] $Record )

$scriptFolder = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
. ($scriptFolder + '.\SetupTestEnv.ps1')

$resourceManagerVariables = Test-Path env:TEST_CSM_ORGID_AUTHENTICATION
$serviceManagementVariables = Test-Path env:TEST_ORGID_AUTHENTICATION
# Using storage account is not recommended because of the complexity, but we will still support it
$oldRdfeTestVariables = $(Test-Path env:AZURE_STORAGE_ACCESS_KEY) -and $(Test-Path env:AZURE_STORAGE_ACCOUNT)
if (!$serviceManagementVariables -AND !$resourceManagerVariables -AND !$oldRdfeTestVariables) {
  Write-Host "You environment has NOT been set up for sceanrio testing. We will help you configure..." -ForegroundColor "Yellow"
  $subscription = Read-Host 'Please input the Azure subscription guid you tests will use:'
  $env:TEST_ORGID_AUTHENTICATION = "SubscriptionId=$subscription;BaseUri=https://management.core.windows.net/;AADAuthEndpoint=https://login.windows.net/;GraphUri=https://graph.windows.net/"
  $env:TEST_CSM_ORGID_AUTHENTICATION = "SubscriptionId=$subscription;BaseUri=https://management.azure.com/;AADAuthEndpoint=https://login.windows.net/"
  Write-Host "To avoid getting prompt again, you can preset one of following environment variables with the value beside" -ForegroundColor "Yellow"
  Write-Host "TEST_ORGID_AUTHENTICATION : $env:TEST_ORGID_AUTHENTICATION"
  Write-Host "TEST_CSM_ORGID_AUTHENTICATION : $env:TEST_CSM_ORGID_AUTHENTICATION"
}

$env:AZURE_TEST_ENVIRONMENT="production"

if ($Record) {
  Write-Host "Setting up 'Record' mode"
  $env:AZURE_TEST_MODE="Record"
  $env:TEST_HTTPMOCK_OUTPUT="$env:AzurePSRoot\src\Common\Commands.ScenarioTest\Resources\SessionRecords\"
  Write-Host "The HTTP traffic will be captured under $env:TEST_HTTPMOCK_OUTPUT." -ForegroundColor "Green"
} else {
  Remove-Item env:\AZURE_TEST_MODE
}

Write-Host "Environment has been set up. You can launch Visual Studio to run tests by typing devenv.exe here; or, through msbuild.exe" -ForegroundColor "Green"
