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

$global:SkippedTests = @(
    'TestCreateUpdateThenDeletePlan',
    'TestTestMoveSubscription'
)

# Multiple tests
$global:Location = "local"
$global:ResourceGroupName = "System.local"

# Acquired plan tests
$global:TargetSubscriptionId = "8158498d-27b1-4ccf-9aa1-de0f925731e6"
$global:SubscriptionId = "ca831431-dac2-4466-a538-59fa3f882f68"
$global:AcquisitionId = "718c7f7c-4868-479a-98ce-5caaa8f158c8"

# Offer Tests
$global:OfferResourceGroupName = "testrg"
$global:OfferName = "testOffer1"

# Plan tests
$global:PlanResourceGroupName = "testrg"
$global:PlanName = "testplans"
$global:PlanDescription = "description of the plan"

# Subscriptions Tests
$global:Owner = 'user@microsoft.com'

# Test Availability
$global:TestAvailability = "Test Sub"
$global:ResourceType = "Microsoft.Subscriptions.Admin/plans"

$global:Client = $null

if (-not $global:RunRaw) {
    # Load the script block
    $scriptBlock = {
        if ($null -eq $global:Client) {
            $global:Client = Get-MockClient -ClassName 'SubscriptionsAdminClient' -TestName $global:TestName
        }
        $global:Client
    }
    Mock New-ServiceClient $scriptBlock -ModuleName $global:ModuleName
}

if (Test-Path "$PSScriptRoot\Override.ps1") {
    . $PSScriptRoot\Override.ps1
}
