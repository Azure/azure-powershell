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
Create subscription
#>
function Test-NewSubscription
{
    # $accounts = Get-AzEnrollmentAccount
    $accounts = @(@{ ObjectId = "455fd0a7-b04e-4a92-9e1b-d0650c8ba276" })
    
    # Verify the caller has at least one enrollment account.
    Assert-True { $accounts.Count -gt 0 }

    $myNewSubName = GetAssetName

    $newSub = New-AzSubscription -EnrollmentAccountObjectId $accounts[0].ObjectId -Name $myNewSubName -OfferType MS-AZR-0017P

    Assert-AreEqual $myNewSubName $newSub.Name
	Assert-NotNull $newSub.SubscriptionId
}

function Test-UpdateRenameSubscription
{
    $subId = "21cba39d-cbbc-487f-9749-43c5c960f269"

    $updateSub = Update-AzSubscription -SubscriptionId $subId -Action "Rename" -Name "RenameFromPowershell"

	Assert-NotNull updateSub.SubscriptionId
}

function Test-UpdateCancelSubscription
{
    $subId = "21cba39d-cbbc-487f-9749-43c5c960f269"

    $updateSub = Update-AzSubscription -SubscriptionId $subId -Action "Cancel"

	Assert-NotNull updateSub.SubscriptionId
}
