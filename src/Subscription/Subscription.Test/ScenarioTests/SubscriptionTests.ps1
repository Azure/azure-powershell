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
    $subscriptionId = "d17ad3ae-320e-42ff-b5a1-705389c6063a"

    $updateSub = Update-AzSubscription -SubscriptionId $subscriptionId -Action "Rename" -Name "RenameFromPowershell"

	Assert-NotNull updateSub.SubscriptionId
}

function Test-UpdateCancelSubscription
{
    $subscriptionId = "687a7385-011e-4538-8d8d-ab484f19ba00"

    $updateSub = Update-AzSubscription -SubscriptionId $subscriptionId -Action "Cancel"

	Assert-NotNull updateSub.SubscriptionId
}

function Test-NewSubscriptionAlias
{
    $aliasName = "test-alias"
	$workload = "Production"
	$subscriptionId = "d17ad3ae-320e-42ff-b5a1-705389c6063a"

    $newsub = New-AzSubscriptionAlias -AliasName $aliasName -Workload $workload -SubscriptionId $subscriptionId

	Assert-NotNull newsub
}

function Test-GetSubscriptionAlias
{
    $aliasName = "test-alias"

    $newsub = Get-AzSubscriptionAlias -AliasName $aliasName

	Assert-NotNull newsub
}

function Test-RemoveSubscriptionAlias
{
    $aliasName = "test-alias"

    $newsub = Remove-AzSubscriptionAlias -AliasName $aliasName

	Assert-NotNull newsub
}
