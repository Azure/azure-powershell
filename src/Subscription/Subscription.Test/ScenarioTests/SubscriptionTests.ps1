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
    $accounts = @(@{ ObjectId = "cdf813b6-bdc2-4df5-b150-00ccfd7580e2" })
    
    # Verify the caller has at least one enrollment account.
    Assert-True { $accounts.Count -gt 0 }

    $myNewSubName = GetAssetName

    $newSub = New-AzSubscription -EnrollmentAccountObjectId $accounts[0].ObjectId -Name $myNewSubName -OfferType MS-AZR-0017P

    Assert-AreEqual $myNewSubName $newSub.Name
	Assert-NotNull $newSub.SubscriptionId
}

function Test-UpdateSubscription
{
    $subId = "8f99ecea-4536-468e-9cce-ac18497a353d"

    $updateSub = Update-AzSubscription -SubscriptionId $subId

	Assert-NotNull updateSub.SubscriptionId
}

function Test-NewModernSubscription
{
    # $accounts = Get-AzEnrollmentAccount
    $billingAccountId = "d6fd151e-2f30-50d5-34b2-fe40b1d64b7f:31670802-3752-4741-b5cc-683c71eca69b_2019-05-31" 
	$billingProfileId = "4S2P-T44P-BG7-TGB" 
	$InvoiceSectionId = "74EQ-I4QH-PJA-TGB" 

    $myNewSubName = "subscriptionName"
	$skuId ="0001"

    $newSub = New-AzModernSubscription -BillingAccountId $billingAccountId -BillingProfileId $billingProfileId -InvoiceSectionId $InvoiceSectionId -Name $myNewSubName -SkuId $skuId

    Assert-AreEqual $myNewSubName $newSub.Name
	Assert-NotNull $newSub.SubscriptionId
}

function Test-NewCspSubscription
{
    # $accounts = Get-AzEnrollmentAccount
    $billingAccountId = "d6fd151e-2f30-50d5-34b2-fe40b1d64b7f:34756dd9-25b9-40c6-bc85-c25f68bff94f_2018-09-30" 
	$customerId = "JIMI-YGZA-BG7-TGB" 

    $myNewSubName = "subscriptionName"
	$skuId ="0001"

    $newSub = New-AzModernSubscription -BillingAccountId $billingAccountId -CustomerId $customerId -Name $myNewSubName -SkuId $skuId

    Assert-AreEqual $myNewSubName $newSub.Name
	Assert-NotNull $newSub.SubscriptionId
}
