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


# Test Variables
$global:SkippedTests = @(
    "TestDownloadAzsAzureBridgeProductPipeline",
    "TestRemoveAzsAzureBridgeDownloadedProduct",
    "TestRemoveAzsAzureBridgeDownloadedProductPipeline"
)

$global:Provider = "Microsoft.AzureBridge.Admin"

$global:ActivationName = "default"
$global:ResourceGroupName = "azurestack-activation"
$global:ProductName1 = "Canonical.UbuntuServer1710-ARM.1.0.6"
$global:ProductName2 = "microsoft.docker-arm.1.1.0"

$global:Client = $null

# Run using mocked client
if (-not $global:RunRaw) {
    $scriptBlock = {
        if ($null -eq $global:Client) {
            $global:Client = Get-MockClient -ClassName 'AzureBridgeAdminClient' -TestName $global:TestName -Verbose
        }
        return $global:Client
    }
    Mock New-ServiceClient $scriptBlock -ModuleName $global:ModuleName
}

if (Test-Path "$PSScriptRoot\Override.ps1") {
    . $PSScriptRoot\Override.ps1
}

