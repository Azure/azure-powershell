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
function Test-UpdateRenameSubscription
{
    $subId = "bc085fce-1a23-4734-b588-7c36b622317e"

    $updateSub = Update-AzSubscription -SubscriptionId $subId -Action "Rename" -Name "RenameFromPowershell"

	Assert-NotNull updateSub.SubscriptionId
}

function Test-UpdateCancelSubscription
{
    $subId = "bc085fce-1a23-4734-b588-7c36b622317e"

    $updateSub = Update-AzSubscription -SubscriptionId $subId -Action "Cancel"

	Assert-NotNull updateSub.SubscriptionId
}

function Test-NewSubscriptionAlias
{
    $aliasName = "navyprod1"
	$displayName = "testSub1"
	$billingScope ="billingScope"
	$workload = "Production"

    $newsub = New-AzSubscriptionAlias -AliasName $aliasName -SubscriptionName $displayName -BillingScope $billingScope -Workload $workload

	Assert-NotNull newsub
}

function Test-GetSubscriptionAlias
{
    $aliasName = "navyprod1"

    $newsub = Get-AzSubscriptionAlias -AliasName $aliasName

	Assert-NotNull newsub
}

function Test-RemoveSubscriptionAlias
{
    $aliasName = "navyprod1"

    $newsub = Remove-AzSubscriptionAlias -AliasName $aliasName

	Assert-NotNull newsub
}
