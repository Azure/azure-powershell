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
Full Account CRUD cycle
#>
function Test-ProviderShareSubscriptionGrantAndRevoke
{
    $resourceGroup = getAssetName
    $AccountName = getAssetName
    $ShareName = getAssetName
    $ShareSubId = getAssetName
	$resourceId = getAssetName

	$revoked = Revoke-AzDataShareSubscriptionAccess -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareName $ShareName -ShareSubscriptionId $ShareSubId
	Assert-NotNull $revoked

	$revoked = Revoke-AzDataShareSubscriptionAccess -ResourceId $resourceId -ShareSubscriptionId $ShareSubId
	Assert-NotNull $revoked

	$reinstated = Grant-AzDataShareSubscriptionAccess -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareName $ShareName -ShareSubscriptionId $ShareSubId
	Assert-NotNull $reinstated
	
	$reinstated = Grant-AzDataShareSubscriptionAccess -ResourceId $resourceId -ShareSubscriptionId $ShareSubId
	Assert-NotNull $reinstated
}

function Test-ProviderShareSubscriptionGet
{
    $resourceGroup = getAssetName
    $AccountName = getAssetName
    $ShareName = getAssetName
    $ShareSubscriptionId = getAssetName

    $retrievedProviderShareSubscription = Get-AzDataShareProviderShareSubscription -AccountName $AccountName -ResourceGroupName $resourceGroup -ShareName $ShareName -ShareSubscriptionId $ShareSubscriptionId
 	$shareSubscriptionName = "sdktestingprovidersharesubscription20"

    Assert-NotNull $retrievedProviderShareSubscription
    Assert-AreEqual $shareSubscriptionName $retrievedProviderShareSubscription.Name
    Assert-AreEqual $ShareSubscriptionId $retrievedProviderShareSubscription.ShareSubscriptionObjectId
    Assert-AreEqual "Active" $retrievedProviderShareSubscription.ShareSubscriptionStatus
}