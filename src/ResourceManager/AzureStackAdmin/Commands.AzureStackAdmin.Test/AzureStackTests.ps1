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
.Synopsis
   Test the flow of Admin user creates a plan, offer and a tenant subscription for the specified user and deletes the created resources
   The plan and offer contains the Subscriptions and Sql services by default.
.EXAMPLE
    This example creates the subscription  with a new plan and offer. It deletes the created resources as well
    Test-TenantSubscription -SubscriptionUser "azurestackmachine\tenantuser1"

.EXAMPLE
    This example creates the subscription  with a new plan and offer. It does not delete the created resources
    Test-TenantSubscription -SubscriptionUser "azurestackmachine\tenantuser1" -DoNotDelete
.EXAMPLE
    This example creates the reseller subscription  with a new plan and offer. It deletes the created resources as well
    Test-TenantSubscription -Services @("Microsoft.Subscriptions") -SubscriptionUser "azurestackmachine\tenantuser1"
.NOTES
     The function is called only after Ignore-SelfSignedCert and Set-AzureStackEnvironment with the correct parameters
#>
function Test-TenantSubscription
{
    param
    (
        # Specifies the user name for the subscription
        [String] $SubscriptionUser ="user@contoso.com",

        [String] $OfferName ="TestTenantSubscriptionOffer",

        [String] $BasePlanName ="TestTenantSubscriptionPlan",

        [String] $ResourceGroupName ="TestTenantSubscriptionRG",

        [ValidateSet("Public", "Private", "Decommissioned")]
        [String] $State = "Public",

        # Specifies the services included in the plan, offer and subscription
        [String[]] $Services=@("Microsoft.Subscriptions","Microsoft.Sql"),

        # Specifies whether to delete the created resources
        [Switch] $DoNotDelete
    )


    New-ResourceGroup -ResourceGroupName $ResourceGroupName

    New-Plan -PlanName $BasePlanName -ResourceGroupName $ResourceGroupName -Services $Services
    $plan = Get-Plan -PlanName $BasePlanName -ResourceGroupName $ResourceGroupName

    Assert-NotNull $plan
    Assert-True { $plan.Properties.DisplayName -eq  $BasePlanName}

    Set-Plan -Plan $plan -ResourceGroup $ResourceGroupName -State $State

    New-Offer -OfferName $offerName -BasePlan $plan -ResourceGroupName $ResourceGroupName

    $offer = Get-Offer -OfferName $offerName -ResourceGroupName $ResourceGroupName

    Assert-NotNull $offer
    Assert-True { $offer.Properties.DisplayName -eq  $offerName}

    Set-Offer -Offer $offer -ResourceGroup $ResourceGroupName -State "Public"

    $publicOffer = Get-Offer -OfferName $offerName

	[Microsoft.AzureStack.Commands.NewManagedSubscription]::SubscriptionIds.Enqueue("8E7DD69E-9AB2-44A1-94D8-F7BC8E12645E")
    $subscription = New-Subscription -SubscriptionUser $SubscriptionUser -OfferId $publicOffer.Id -Managed

    Set-Offer -Offer $offer -ResourceGroup $ResourceGroupName -State $State

    if (!$DoNotDelete)
    {
        Remove-Subscription -TargetSubscriptionId $subscription.SubscriptionId
        Remove-Offer -OfferName $offerName -ResourceGroupName $ResourceGroupName
        Remove-Plan -PlanName $BasePlanName -ResourceGroupName $ResourceGroupName
        Remove-ResourceGroup -ResourceGroupName $ResourceGroupName
    }
}

<#
.Synopsis
   Acquire token as Tenant user and then subscribe to offer and deletes the created plan, offer, subscription resources
   The plan and offer contains the Subscriptions and Sql services by default.
.EXAMPLE
    This example creates the subscription  with a new plan and offer. It deletes the created resources as well
    Test-TenantSubscribeToOffer -SubscriptionUser "azurestackmachine\tenantuser1"  -UserPassword $password

.EXAMPLE
    This example creates the subscription  with a new plan and offer. It does not delete the created resources
    Test-TenantSubscribeToOffer -SubscriptionUser "azurestackmachine\tenantuser1" -UserPassword $password -DoNotDelete
.EXAMPLE
    This example creates the reseller subscription  with a new plan and offer. It deletes the created resources as well
    Test-TenantSubscribeToOffer -Services @("Microsoft.Subscriptions") -SubscriptionUser "azurestackmachine\tenantuser1" -UserPassword $password
.NOTES
     The function is called only after Ignore-SelfSignedCert and Set-AzureStackEnvironment with the correct parameters
#>
function Test-TenantSubscribeToOffer
{
    param
    (
        [String] $SubscriptionUser="user@contoso.com",

        [Parameter(Mandatory=$true)]
        [String] $UserPassword,

        [String[]] $Services=@("Microsoft.Subscriptions","Microsoft.Sql"),

        [Switch] $DoNotDelete
    )

    $offerName = "TestOffer-"  + [Guid]::NewGuid().ToString()
    $planName = "TestPlan-"  + [Guid]::NewGuid().ToString()
    $rgName = "TestRG-" + [Guid]::NewGuid().ToString()
    $subDisplayName = "$SubscriptionUser Test Subscription"

    New-ResourceGroup -ResourceGroupName $rgName

    New-Plan -PlanName $planName -ResourceGroupName $rgName -Services $Services
    $plan = Get-Plan -PlanName $planName -ResourceGroupName $rgName

    Assert-NotNull $plan
    Assert-True {$plan.Properties.DisplayName -eq  $planName}

    Set-Plan -Plan $plan -ResourceGroup $rgName -State "Public"

    New-Offer -OfferName $offerName -BasePlan $plan -ResourceGroupName $rgName
    $offer = Get-Offer -OfferName $offerName -ResourceGroupName $rgName

    Assert-NotNull $offer
    Assert-True { $offer.Properties.DisplayName -eq  $offerName}

    Set-Offer -Offer $offer -ResourceGroup $rgName -State "Public"

    $password = ConvertTo-SecureString $UserPassword -AsPlainText -Force
    $credential = New-Object System.Management.Automation.PSCredential($SubscriptionUser, $password)

    $token =  Get-EnvironmentSpecificToken -Credential $credential

    # Check whether the plan created is visible for the tenant
    $tenantOffer = Get-Offer -OfferName $offerName -Token $token

    # Creating a subscription with Tenant Token
    $subscription = New-Subscription -SubscriptionUser $SubscriptionUser -OfferId $tenantOffer.Id -Token $token

    if (!$DoNotDelete)
    {
        Remove-Subscription -TargetSubscriptionId $subscription.SubscriptionId
        Remove-Offer -OfferName $offerName -ResourceGroupName $rgName
        Remove-Plan -PlanName $planName -ResourceGroupName $rgName
        Remove-ResourceGroup -ResourceGroupName $rgName
    }
 }

 <#
.Synopsis
    Creates and Deletes a new plan. The plan contains the Subscriptions and Sql services by default.
.EXAMPLE
    This example creates and deletes a new plan
    Test-Plan
.EXAMPLE
    This example creates a plan named DefaultPlan and does not delete it
    Test-Plan -Services @("Microsoft.Subscriptions") -PlanName DefaultPlan -DoNotDelete
.NOTES
     The function is called only after Ignore-SelfSignedCert and Set-AzureStackEnvironment with the correct parameters
#>
function Test-Plan
{
    param
    (
        [Alias("Name")]
        [String] $PlanName ="TestPlanPlan",

        [String[]] $Services=@("Microsoft.Subscriptions"),

        [ValidateSet("Public", "Private", "Decommissioned")]
        [String] $State = "Public",

        [Switch] $DoNotDelete
    )

    $rgName = "TestPlanRG"

    New-ResourceGroup -ResourceGroupName $rgName

    New-Plan -PlanName $PlanName -ResourceGroupName $rgName -Services $Services

    $plan = Get-Plan -PlanName $PlanName -ResourceGroupName $rgName
    Assert-NotNull $plan
    Assert-True { $plan.Properties.DisplayName -eq  $PlanName}

    Set-Plan -Plan $plan -ResourceGroup $rgName -State $State

    if (!$DoNotDelete)
    {
        Remove-Plan -PlanName $PlanName -ResourceGroupName $rgName
        Remove-ResourceGroup -ResourceGroupName $rgName
    }
 }

 <#
.Synopsis
    Creates and Deletes a new offer and plan. The plan and offer contains the Subscriptions and Sql services by default.
.EXAMPLE
    This example creates and deletes a new plan and offer
    Test-Offer
.EXAMPLE
    This example creates a offer named DefaultOffer, a plan named DefaultPlan and does not delete them
    Test-Offer -Services @("Microsoft.Subscriptions") -OfferName DefaultOffer -BasePlanName DefaultPlan -DoNotDelete
.NOTES
     The function is called only after Ignore-SelfSignedCert and Set-AzureStackEnvironment with the correct parameters
#>
function Test-Offer
{
    param
    (
        [Alias("Name")]
        [String] $OfferName ="TestOffer01",

        [String] $BasePlanName ="TestBasePlan01",

        [String] $ResourceGroupName ="TestRG01",

        [String[]] $Services=@("Microsoft.Subscriptions"),

        [ValidateSet("Public", "Private", "Decommissioned")]
        [String] $State = "Public",

        [Switch] $DoNotDelete
    )

    New-ResourceGroup -ResourceGroupName $ResourceGroupName

    $plan = New-Plan -PlanName $BasePlanName -ResourceGroupName $ResourceGroupName -Services $Services
    $plan = Get-Plan -PlanName $BasePlanName -ResourceGroupName $ResourceGroupName
    Assert-NotNull $plan
    Assert-True { $plan.Properties.DisplayName -eq  $BasePlanName}
    Set-Plan -Plan $plan -ResourceGroup $ResourceGroupName -State $State

    New-Offer -OfferName $OfferName -BasePlan $plan -ResourceGroupName $ResourceGroupName

    $offer = Get-Offer -OfferName $OfferName -ResourceGroupName $ResourceGroupName

    Set-Offer -Offer $offer -ResourceGroup $ResourceGroupName -State $State

    if (!$DoNotDelete)
    {
        Remove-Offer -OfferName $OfferName -ResourceGroupName $ResourceGroupName
        Remove-Plan -PlanName $BasePlanName -ResourceGroupName $ResourceGroupName
        Remove-ResourceGroup -ResourceGroupName $ResourceGroupName
    }
}


<#
.Synopsis
    Creates an offer having public delegated offers.
.EXAMPLE
    This example creates and deletes a new plan and offer
    Test-DelegatedOffer
#>
function Test-DelegatedOffer
{
    param
    (
        [String] $SubscriptionUser ="user@contoso.com",

        [String[]] $Services=@("Microsoft.Subscriptions","Microsoft.Sql"),

        [Switch] $DoNotDelete
    )

    $delegatedOfferName = "TestOfferDelegated"
    $delegatedPlanName = "TestPlanDelegated" 
    $offerName = "TestUberOffer"
    $planName = "TestUberPlan"  

    $rgName = "TestDelegatedOfferRG" 

    New-ResourceGroup -ResourceGroupName $rgName

    New-Plan -PlanName $delegatedPlanName -ResourceGroupName $rgName -Services $Services

    $delegatedPlan = Get-Plan -PlanName $delegatedPlanName -ResourceGroupName $rgName
    Assert-NotNull $delegatedPlan
    Assert-True {$delegatedPlan.Properties.DisplayName -eq  $delegatedPlanName}
    Set-Plan -Plan $delegatedPlan -ResourceGroup $rgName -State "Public"

    New-Offer -OfferName $delegatedOfferName -BasePlan $delegatedPlan -ResourceGroupName $rgName

    $delegatedOffer = Get-Offer -OfferName $delegatedOfferName -ResourceGroupName $rgName
    Assert-NotNull $delegatedOffer
    Set-Offer -Offer $delegatedOffer -ResourceGroup $rgName -State "Public"

    # Creating a plan having a delegated offer
    New-Plan -PlanName $planName -ResourceGroupName $rgName -Services $Services -DelegatedOfferName @($delegatedOfferName)

    $plan = Get-Plan -PlanName $planName -ResourceGroupName $rgName

    Assert-NotNull $plan
    Assert-True {$plan.Properties.DisplayName -eq  $planName}
    Set-Plan -Plan $plan -ResourceGroup $rgName -State "Public"

    New-Offer -OfferName $offerName -BasePlan $plan -ResourceGroupName $rgName

    $offer = Get-Offer -OfferName $offerName -ResourceGroupName $rgName
    Assert-NotNull $offer
    Set-Offer -Offer $offer -ResourceGroup $rgName -State "Public"

    if (!$DoNotDelete)
    {
        Remove-Offer -OfferName $delegatedOfferName -ResourceGroupName $rgName
        Remove-Plan -PlanName $delegatedPlanName -ResourceGroupName $rgName
        Remove-Offer -OfferName $OfferName -ResourceGroupName $rgName
        Remove-Plan -PlanName $PlanName -ResourceGroupName $rgName
        Remove-ResourceGroup -ResourceGroupName $rgName
    }
}

<#
.Synopsis
    Creates a new plan with Subscription service, then updates the Subscription service default quota
#>
function Test-UpdateSubscriptionServiceQuota
{
    $sqlOfferName = "TestUpdateQuotaOffer"
    $sqlPlanName = "TesUpdateQuotaPlan" 
    $resellerPlanName = "TestUpdateQuotaPlanReseller" 

    $sqlServices= @("Microsoft.Sql")
    $subscriptionServices= @("Microsoft.Subscriptions")

    $rgName = "TestUpdateQuotatRG"

    New-ResourceGroup -ResourceGroupName $rgName

    New-Plan -PlanName $sqlPlanName -ResourceGroupName $rgName -Services $sqlServices

    $sqlPlan = Get-Plan -PlanName $sqlPlanName -ResourceGroupName $rgName
    Assert-NotNull $sqlPlan
    Assert-True {$sqlPlan.Properties.DisplayName -eq  $sqlPlanName}
    Set-Plan -Plan $sqlPlan -ResourceGroup $rgName -State "Public"

    New-Offer -OfferName $sqlOfferName -BasePlan $sqlPlan -ResourceGroupName $rgName

    $sqlOffer = Get-Offer -OfferName $sqlOfferName -ResourceGroupName $rgName
    Assert-NotNull $sqlOffer
    Set-Offer -Offer $sqlOffer -ResourceGroup $rgName -State "Public"

    # Creating a reseller plan having a delegated offer
    New-Plan -PlanName $resellerPlanName -ResourceGroupName $rgName -Services $subscriptionServices -DelegatedOfferName @($sqlOfferName)

    $resellerplan = Get-Plan -PlanName $resellerPlanName -ResourceGroupName $rgName

    Assert-NotNull $resellerplan
    Assert-True {$resellerplan.Properties.DisplayName -eq  $resellerPlanName}

    $subscriptionsQutoas = $resellerplan.Properties.ServiceQuotas[0].QuotaSettings | ConvertFrom-Json
    $subscriptionsQutoas.delegatedProviderQuotas[0].maximumDelegationDepth = 5
    $subscriptionsQutoas.delegatedProviderQuotas[0].delegatedOffers[0].accessibilityState = "Private"

    $resellerplan.Properties.ServiceQuotas[0].QuotaSettings = $subscriptionsQutoas | ConvertTo-Json -Depth 5

    Set-Plan -Plan $resellerplan -ResourceGroup $rgName -State "Public"

    $updatedResellerplan = Get-Plan -PlanName $resellerPlanName -ResourceGroupName $rgName
    $updatedSubscriptionsQutoas = $updatedResellerplan.Properties.ServiceQuotas[0].QuotaSettings | ConvertFrom-Json

    Assert-AreEqual -expected $updatedSubscriptionsQutoas.delegatedProviderQuotas[0].maximumDelegationDepth -actual $subscriptionsQutoas.delegatedProviderQuotas[0].maximumDelegationDepth
    Assert-AreEqual -expected $updatedSubscriptionsQutoas.delegatedProviderQuotas[0].delegatedOffers[0].accessibilityState -actual $subscriptionsQutoas.delegatedProviderQuotas[0].delegatedOffers[0].accessibilityState

    # Add additional delegated offer to the subscription service for the existing reseller plan
    if ($AddDelegatedOffer)
    {
        $sqlOfferName1 = "TestUpdateQuotaOffer"
        $sqlPlanName1 = "TestUpdateQuotaPlan"

        New-Plan -PlanName $sqlPlanName1 -ResourceGroupName $rgName -Services $sqlServices
        $sqlPlan = Get-Plan -PlanName $sqlPlanName1 -ResourceGroupName $rgName
        Set-Plan -Plan $sqlPlan -ResourceGroup $rgName -State "Public"

        New-Offer -OfferName $sqlOfferName1 -BasePlan $sqlPlan -ResourceGroupName $rgName
        $sqlOffer = Get-Offer -OfferName $sqlOfferName1 -ResourceGroupName $rgName
        Set-Offer -Offer $sqlOffer -ResourceGroup $rgName -State "Public"

        $planQuota = $updatedResellerplan.Properties.ServiceQuotas[0].QuotaSettings | ConvertFrom-Json
        $resellerQuotasObject = $updatedResellerplan.Properties.ServiceQuotas[0].QuotaSettings | ConvertFrom-Json
        $resellerQuotasObject.delegatedProviderQuotas[0].delegatedOffers[0].offerName = $sqlOfferName1

        $planQuota.delegatedProviderQuotas[0].delegatedOffers +=  $resellerQuotasObject.delegatedProviderQuotas[0].delegatedOffers[0]

        $updatedResellerplan.Properties.ServiceQuotas[0].QuotaSettings = $planQuota | ConvertTo-Json -Depth 5

        Set-Plan -Plan  $updatedResellerplan -ResourceGroup $rgName -State "Public"

        $delegatedOfferAddedplan = Get-Plan -PlanName $resellerPlanName -ResourceGroupName $rgName
        $expectedQutoas = $delegatedOfferAddedplan.Properties.ServiceQuotas[0].QuotaSettings | ConvertFrom-Json

        Assert-AreEqual -expected "2" -actual $expectedQutoas.delegatedProviderQuotas[0].delegatedOffers.Count

        Remove-Offer -OfferName $sqlOfferName1 -ResourceGroupName $rgName
        Remove-Plan -PlanName $sqlPlanName1 -ResourceGroupName $rgName
    }

    Remove-Offer -OfferName $sqlOfferName -ResourceGroupName $rgName
    Remove-Plan -PlanName $sqlPlanName -ResourceGroupName $rgName
    Remove-Plan -PlanName $resellerPlanName -ResourceGroupName $rgName

    Remove-ResourceGroup -ResourceGroupName $rgName
}

<#
.Synopsis
    Creates a new plan with Subscription service, then updates the Subscription service default quota, then adds delegated offer
#>
function Test-AddDelegatedOffer
{
    $sqlOfferName = "TestAddDelegatedOffer"
    $sqlPlanName = "TesAddDelegatedPlan" 
    $resellerPlanName = "TestAddDelegatedPlanReseller" 

    $sqlServices= @("Microsoft.Sql")
    $subscriptionServices= @("Microsoft.Subscriptions")

    $rgName = "TestAddDelegatedRG"

    New-ResourceGroup -ResourceGroupName $rgName

    New-Plan -PlanName $sqlPlanName -ResourceGroupName $rgName -Services $sqlServices

    $sqlPlan = Get-Plan -PlanName $sqlPlanName -ResourceGroupName $rgName
    Assert-NotNull $sqlPlan
    Assert-True {$sqlPlan.Properties.DisplayName -eq  $sqlPlanName}
    Set-Plan -Plan $sqlPlan -ResourceGroup $rgName -State "Public"

    New-Offer -OfferName $sqlOfferName -BasePlan $sqlPlan -ResourceGroupName $rgName

    $sqlOffer = Get-Offer -OfferName $sqlOfferName -ResourceGroupName $rgName
    Assert-NotNull $sqlOffer
    Set-Offer -Offer $sqlOffer -ResourceGroup $rgName -State "Public"

    # Creating a reseller plan having a delegated offer
    New-Plan -PlanName $resellerPlanName -ResourceGroupName $rgName -Services $subscriptionServices -DelegatedOfferName @($sqlOfferName)

    $resellerplan = Get-Plan -PlanName $resellerPlanName -ResourceGroupName $rgName

    Assert-NotNull $resellerplan
    Assert-True {$resellerplan.Properties.DisplayName -eq  $resellerPlanName}

    $subscriptionsQutoas = $resellerplan.Properties.ServiceQuotas[0].QuotaSettings | ConvertFrom-Json
    $subscriptionsQutoas.delegatedProviderQuotas[0].maximumDelegationDepth = 5
    $subscriptionsQutoas.delegatedProviderQuotas[0].delegatedOffers[0].accessibilityState = "Private"

    $resellerplan.Properties.ServiceQuotas[0].QuotaSettings = $subscriptionsQutoas | ConvertTo-Json -Depth 5

    Set-Plan -Plan $resellerplan -ResourceGroup $rgName -State "Public"

    $updatedResellerplan = Get-Plan -PlanName $resellerPlanName -ResourceGroupName $rgName
    $updatedSubscriptionsQutoas = $updatedResellerplan.Properties.ServiceQuotas[0].QuotaSettings | ConvertFrom-Json

    Assert-AreEqual -expected $updatedSubscriptionsQutoas.delegatedProviderQuotas[0].maximumDelegationDepth -actual $subscriptionsQutoas.delegatedProviderQuotas[0].maximumDelegationDepth
    Assert-AreEqual -expected $updatedSubscriptionsQutoas.delegatedProviderQuotas[0].delegatedOffers[0].accessibilityState -actual $subscriptionsQutoas.delegatedProviderQuotas[0].delegatedOffers[0].accessibilityState

    $sqlOfferName1 = "TestAddDelegatedSqlOffer"
    $sqlPlanName1 = "TestAddDelegatedSqlPlan"

    New-Plan -PlanName $sqlPlanName1 -ResourceGroupName $rgName -Services $sqlServices
    $sqlPlan = Get-Plan -PlanName $sqlPlanName1 -ResourceGroupName $rgName
    Set-Plan -Plan $sqlPlan -ResourceGroup $rgName -State "Public"

    New-Offer -OfferName $sqlOfferName1 -BasePlan $sqlPlan -ResourceGroupName $rgName
    $sqlOffer = Get-Offer -OfferName $sqlOfferName1 -ResourceGroupName $rgName
    Set-Offer -Offer $sqlOffer -ResourceGroup $rgName -State "Public"

    $planQuota = $updatedResellerplan.Properties.ServiceQuotas[0].QuotaSettings | ConvertFrom-Json
    $resellerQuotasObject = $updatedResellerplan.Properties.ServiceQuotas[0].QuotaSettings | ConvertFrom-Json
    $resellerQuotasObject.delegatedProviderQuotas[0].delegatedOffers[0].offerName = $sqlOfferName1

    $planQuota.delegatedProviderQuotas[0].delegatedOffers +=  $resellerQuotasObject.delegatedProviderQuotas[0].delegatedOffers[0]

    $updatedResellerplan.Properties.ServiceQuotas[0].QuotaSettings = $planQuota | ConvertTo-Json -Depth 5

    Set-Plan -Plan  $updatedResellerplan -ResourceGroup $rgName -State "Public"

    $delegatedOfferAddedplan = Get-Plan -PlanName $resellerPlanName -ResourceGroupName $rgName
    $expectedQutoas = $delegatedOfferAddedplan.Properties.ServiceQuotas[0].QuotaSettings | ConvertFrom-Json

    Assert-AreEqual -expected "2" -actual $expectedQutoas.delegatedProviderQuotas[0].delegatedOffers.Count

    Remove-Offer -OfferName $sqlOfferName1 -ResourceGroupName $rgName
    Remove-Plan -PlanName $sqlPlanName1 -ResourceGroupName $rgName

    Remove-Offer -OfferName $sqlOfferName -ResourceGroupName $rgName
    Remove-Plan -PlanName $sqlPlanName -ResourceGroupName $rgName
    Remove-Plan -PlanName $resellerPlanName -ResourceGroupName $rgName

    Remove-ResourceGroup -ResourceGroupName $rgName
}

<#
.Synopsis
    Creates and Deletes a new ResourceGroup. 
.EXAMPLE
    This example creates and deletes a new resource group
    Test-ResourceGroup
#>
function Test-ResourceGroup
{
    param
    (
        [String] $ResourceGroupName ="TestRG1",

        [Switch] $DoNotDelete
    )

    New-AzureRmResourceGroup -Name $ResourceGroupName -Location "redmond"

    $rg = Get-AzureRmResourceGroup -Name $ResourceGroupName -Location "redmond"
    Assert-NotNull $rg 

    if (!$DoNotDelete)
    {
        Remove-AzureRmResourceGroup -Name $ResourceGroupName -Force
    }
 }


 <#
.Synopsis
    Creates and Deletes a new location. 
.EXAMPLE
    This example creates and deletes a new location
    Test-ManagedLocation
#>
 function Test-ManagedLocation
{
 param
    (
        [String] $Location="chicago"
    )

    $lattitude = 80.5
    $longitude = -45.5

    try
    {
        $loc = New-AzureRMManagedLocation -Name $Location -DisplayName $Location -Latitude 80.5 -Longitude -45.5

        Assert-NotNull $loc
        Assert-AreEqual $loc.Name $Location
        Assert-AreEqual $loc.Latitude $lattitude
        Assert-AreEqual $loc.Longitude $longitude
        Assert-AreEqual $loc.DisplayName $Location

        $loc2 = Get-AzureRMManagedLocation -Name $Location

        Assert-AreEqual $loc2.Name $Location
        Assert-AreEqual $loc2.Latitude $lattitude
        Assert-AreEqual $loc2.Longitude $longitude
        Assert-AreEqual $loc2.DisplayName $Location

        $lattitude = 90.0 

        $loc2.Latitude = $lattitude
        $loc2 | Set-AzureRMManagedLocation


        $loc3 = Get-AzureRMManagedLocation -Name $Location

        Assert-AreEqual $loc3.Name $Location
        Assert-AreEqual $loc3.Latitude $lattitude
        Assert-AreEqual $loc3.Longitude $longitude
        Assert-AreEqual $loc3.DisplayName $Location
    }
    finally
    {
        Remove-AzureRMManagedLocation -Name $Location
        Assert-Throws {Get-AzureRMManagedLocation -Name $Location }
    }
}


 <#
.Synopsis
    Creates and Deletes a new GalleryItem. 
#>
function Test-GalleryItem
{
    $resourceGroupName = "GalleryItems"
    $galleryItemName = "Microsoft.SimpleVMTemplate.1.0.0"
    $galleryApiVersion = "2015-04-01"

    try
    {
        New-AzureRmResourceGroup -Name $resourceGroupName  -Location redmond -Force
		
		[Microsoft.AzureStack.Commands.AddGalleryItem]::GalleryPackageIds.Enqueue("1988820c-2bcc-4682-9991-bec44e6b8324")
        $galleryItem = Add-AzureRMGalleryItem -ResourceGroup $resourceGroupName  -Name $galleryItemName -Path "Microsoft.SimpleVMTemplate.1.0.0.azpkg"  -Apiversion $GalleryApiVersion  –Verbose
        Assert-NotNull $galleryItem

        $galleryItem  = Get-AzureRMGalleryItem -Name $galleryItemName -ResourceGroup  $resourceGroupName -ApiVersion $galleryApiVersion
        Assert-AreEqual $galleryItem.Name $galleryItemName
    }
    finally
    {
        Remove-AzureRMGalleryItem -Name $GalleryItemName -ResourceGroup  $resourceGroupName -ApiVersion $galleryApiVersion
		Remove-ResourceGroup -ResourceGroupName $resourceGroupName
    }
}