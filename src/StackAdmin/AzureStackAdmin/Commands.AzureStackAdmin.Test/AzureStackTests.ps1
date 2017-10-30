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
    Test-TenantSubscription -Services @("Microsoft.Subscriptions")
.NOTES
     The function is called only after Ignore-SelfSignedCert and Set-AzureStackEnvironment with the correct parameters
#>
function Test-TenantSubscription
{
    param
    (
        # Specifies the user name for the subscription
        [String] $SubscriptionUser="test@waptestad.onmicrosoft.com",

        # Preferred Offer Name
        [String] $OfferName,

        # Preferred Plan Name
        [String] $BasePlanName,

        # Preferred Resource Group Name
        [String] $ResourceGroupName,

        # State of the Offer
        [ValidateSet("Public", "Private", "Decommissioned")]
        [String] $State = "Public",

        # Specifies the services included in the plan, offer and subscription
        [String[]] $Services=@("Microsoft.Subscriptions"),

        # Specifies whether to delete the created resources
        [Switch] $DoNotDelete,

        # Specifies whether to delete the resource group
        [Switch] $DoNotDeleteResourceGroup
    )

    if (!$OfferName)
    {
        $OfferName = "TestOffer0-TestTenantSubscription"
    }

    if (!$BasePlanName)
    {
        $BasePlanName = "TestPlan0-TestTenantSubscription" 
    }

    if (!$ResourceGroupName)
    {
        $ResourceGroupName = "TestRG0-TestTenantSubscription" 
    }

    New-ResourceGroup -ResourceGroupName $ResourceGroupName

    New-Plan -PlanName $BasePlanName -ResourceGroupName $ResourceGroupName -Services $Services
    $plan = Get-Plan -PlanName $BasePlanName -ResourceGroupName $ResourceGroupName

    New-Offer -OfferName $offerName -BasePlanIds @($plan.Id) -ResourceGroupName $ResourceGroupName

    $offer = Get-Offer -OfferName $offerName -ResourceGroupName $ResourceGroupName

    Set-Offer -Offer $offer -ResourceGroup $ResourceGroupName -State $State

    $publicOffer = Get-Offer -OfferName $offerName
	
	#
	[Microsoft.AzureStack.Commands.NewTenantSubscription]::SubscriptionIds.Enqueue("8E7DD69E-9AB2-44A1-94D8-F7BC8E12645E")
    # Creating subscription as an admin
    $subscription = New-Subscription -SubscriptionUser $SubscriptionUser -OfferId $offer.Id

    if (!$DoNotDelete)
    {
        Remove-Subscription -TargetSubscriptionId $subscription.SubscriptionId
        Remove-Offer -OfferName $offerName -ResourceGroupName $ResourceGroupName
        Remove-Plan -PlanName $BasePlanName -ResourceGroupName $ResourceGroupName

        if (!$DoNotDeleteResourceGroup)
        {
            Remove-ResourceGroup -ResourceGroupName $ResourceGroupName
        }
    }
}

<#
.Synopsis
   Acquire token as Tenant user and then subscribe to offer and deletes the created plan, offer, subscription resources
   The plan and offer contains the Subscriptions and Sql services by default. For simplicity, the tenant user is assumed to be the same account
.EXAMPLE
    This example creates the subscription  with a new plan and offer. It deletes the created resources as well
    Test-TenantSubscribeToOffer

.EXAMPLE
    This example creates the subscription  with a new plan and offer. It does not delete the created resources
    Test-TenantSubscribeToOffer -DoNotDelete
.EXAMPLE
    This example creates the reseller subscription  with a new plan and offer. It deletes the created resources as well
    Test-TenantSubscribeToOffer -Services @("Microsoft.Subscriptions")
.NOTES
     The function is called only after Ignore-SelfSignedCert and Set-AzureStackEnvironment with the correct parameters
#>
function Test-TenantSubscribeToOffer
{
    param
    (
        [String[]] $Services=@("Microsoft.Subscriptions"),

        # Preferred Resource Group Name
        [String] $ResourceGroupName,

        # Specifies whether to register the  subscription with resource provider
        [Switch] $RegisterWithResourceProvider,

        # Specifies whether to delete the created resources
        [Switch] $DoNotDelete,

        # Specifies whether to delete the Resource Group
        [Switch] $DoNotDeleteResourceGroup
    )

    $offerName = "TestOffer-TenantSubscribeToOffer2"
    $planName = "TestPlan-TenantSubscribeToOffer2"

    if (!$ResourceGroupName)
    {
        $ResourceGroupName = "TestRG-TenantSubscribeToOffer2"
    }
        
    $subDisplayName = "${TenantUserCredential.UserName} Test Subscription"

    New-ResourceGroup -ResourceGroupName $ResourceGroupName

    New-Plan -PlanName $planName -ResourceGroupName $ResourceGroupName -Services $Services
    $plan = Get-Plan -PlanName $planName -ResourceGroupName $ResourceGroupName

    New-Offer -OfferName $offerName -BasePlanIds @($plan.Id) -ResourceGroupName $ResourceGroupName
    $offer = Get-Offer -OfferName $offerName -ResourceGroupName $ResourceGroupName

    Set-Offer -Offer $offer -ResourceGroup $ResourceGroupName -State "Public"

    # Get the created offer as the tenant
    $tenantOffer = Get-Offer -OfferName $offerName

	[Microsoft.AzureStack.Commands.NewTenantSubscription]::SubscriptionIds.Enqueue("8E7DD69E-9AA2-44A1-94D8-F7BC8E12645E")
    # Subscribing to the offer as tenant
    $subscription = New-Subscription -OfferId $tenantOffer.Id

    $tenantSubscriptionId = $subscription.SubscriptionId
    Set-AzureRmContext -SubscriptionId $tenantSubscriptionId
    Write-Verbose "Selected subscription ID - $tenantSubscriptionId"

    if($RegisterWithResourceProvider)
    {
        # Register with the resource providers to force subscrintion notification to the RPs
        # Otherwise Suscription Notification happens automatically when the first resource is created (Only through templated deployment)
        Register-ResourceProvider -Namespaces $Services
    }

    if (!$DoNotDelete)
    {
        if($RegisterWithResourceProvider)
        {
            # UnRegister with the resource providers so that the subscription could be deleted
            Unregister-ResourceProvider -Namespaces $Services
        }
        
        # Set context to admin suscription so as to remove all the resources
        Set-AzureRmContext -SubscriptionID $Global:AzureStackConfig.SubscriptionId
        
        Remove-Subscription -TargetSubscriptionId $subscription.SubscriptionId
        Remove-Offer -OfferName $offerName -ResourceGroupName $ResourceGroupName
        Remove-Plan -PlanName $planName -ResourceGroupName $ResourceGroupName
        
        if (!$DoNotDeleteResourceGroup)
        {
            Remove-ResourceGroup -ResourceGroupName $ResourceGroupName
        }
    }
 }

 <#
.Synopsis
   Acquire token as Tenant user and then subscribe to the created offer, creates a storage account and then  deletes the created plan, offer, 
   subscription, storage account resources
.EXAMPLE
    This example creates the subscription  with a new plan and offer. It deletes the created resources as well
    Test-StorageAccount -TenantUserCredential $credential
#>
function Test-StorageAccount
{
    param
    (
        [Parameter(Mandatory=$true)]
        [PSCredential] $TenantUserCredential,

        # Preferred Resource Group Name
        [String] $ResourceGroupName,

        # Specifies whether to delete the created resources
        [Switch] $DoNotDelete,

        # Specifies whether to delete the Resource Group
        [Switch] $DoNotDeleteResourceGroup
    )

    $offerName = "TestOffer-"  + [Guid]::NewGuid().ToString()
    $planName = "TestPlan-"  + [Guid]::NewGuid().ToString()
    
    if (!$ResourceGroupName)
    {
        $ResourceGroupName = "TestRG-" + [Guid]::NewGuid().ToString()
    }

    $storageAccountRG = "TestSaRg-" + [Guid]::NewGuid().ToString()
    $storageAccountName  = "kataltest"

    $services = @("Microsoft.Storage")
    $subDisplayName = "$($TenantUserCredential.UserName) Test Subscription"

    New-ResourceGroup -ResourceGroupName $ResourceGroupName

    New-Plan -PlanName $planName -ResourceGroupName $ResourceGroupName -Services $Services
    $plan = Get-Plan -PlanName $planName -ResourceGroupName $ResourceGroupName

    New-Offer -OfferName $offerName -BasePlanIds @($plan.Id) -ResourceGroupName $ResourceGroupName
    $offer = Get-Offer -OfferName $offerName -ResourceGroupName $ResourceGroupName

    Set-Offer -Offer $offer -ResourceGroup $ResourceGroupName -State "Public"

    # Login as the subscription user
  	$environment = Get-AzureRmEnvironment -Name $AzureStackConfig.AzureStackMachineName
	Connect-AzureRmAccount -Environment $environment -Credential $TenantUserCredential        

    # Get the created offer as the tenant
    $tenantOffer = Get-Offer -OfferName $offerName

    # Subscribing to the offer as tenant
    $subscription = New-Subscription -OfferId $tenantOffer.Id

    $tenantSubscriptionId = $subscription.SubscriptionId
    Set-AzureRmContext -SubscriptionId $tenantSubscriptionId
    Write-Verbose "Selected subscription ID - $tenantSubscriptionId"

    # Register with the resource providers to force subscrintion notification to the RPs
    # Otherwise Suscription Notification happens automatically when the first resource is created (Only through templated deployment)
    Register-ResourceProvider -Namespaces $Services

    New-ResourceGroup -ResourceGroupName $storageAccountRG

    New-AzureRmStorageAccount -ResourceGroupName $storageAccountRG -Name $storageAccountName -Location $Global:AzureStackConfig.ArmLocation -Type Standard_LRS

    $sa = Get-AzureRmStorageAccount -ResourceGroupName $storageAccountRG -Name $storageAccountName

    Assert-NotNull $sa

    if (!$DoNotDelete)
    {
        
        Remove-AzureRmStorageAccount -ResourceGroupName $storageAccountRG -Name $storageAccountName
        Remove-ResourceGroup -ResourceGroupName $storageAccountRG

        # UnRegister with the resource providers so that the subscription could be deleted
        Unregister-ResourceProvider -Namespaces $Services

        # Set context to admin suscription so as to remove all the resources
        Set-AzureRmContext -SubscriptionID $Global:AzureStackConfig.SubscriptionId
        
        Remove-Subscription -TargetSubscriptionId $subscription.SubscriptionId
        Remove-Offer -OfferName $offerName -ResourceGroupName $ResourceGroupName
        Remove-Plan -PlanName $planName -ResourceGroupName $ResourceGroupName

        if (!$DoNotDeleteResourceGroup)
        {
            Remove-ResourceGroup -ResourceGroupName $ResourceGroupName
        }
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
        [String] $PlanName,

        [String[]] $Services=@("Microsoft.Subscriptions"),

        # Preferred Resource Group Name
        [String] $ResourceGroupName,

        [ValidateSet("Public", "Private", "Decommissioned")]
        [String] $State = "Public",

        [Switch] $DoNotDelete,

        # Specifies whether to delete the Resource Group
        [Switch] $DoNotDeleteResourceGroup
    )

    if (!$PlanName)
    {
        $PlanName = "TestPlan"
    }

    if (!$ResourceGroupName)
    {
        $ResourceGroupName = "TestRG-Plan"
    }

    New-ResourceGroup -ResourceGroupName $ResourceGroupName

    New-Plan -PlanName $PlanName -ResourceGroupName $ResourceGroupName -Services $Services

    $plan = Get-Plan -PlanName $PlanName -ResourceGroupName $ResourceGroupName
    Assert-NotNull $plan
    Assert-True { $plan.Properties.DisplayName -eq  $PlanName}

    $plan.Properties.Description = "Test Description"
    Set-Plan -Plan $plan -ResourceGroup $ResourceGroupName

    $plan = Get-Plan -PlanName $PlanName -ResourceGroupName $ResourceGroupName
    Assert-NotNull $plan
    Assert-True { $plan.Properties.Description -eq  "Test Description"}

    if (!$DoNotDelete)
    {
        Remove-Plan -PlanName $PlanName -ResourceGroupName $ResourceGroupName

        if (!$DoNotDeleteResourceGroup)
        {
            Remove-ResourceGroup -ResourceGroupName $ResourceGroupName
        }
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
        [String] $OfferName,

        [String] $BasePlanName,

        [String] $ResourceGroupName,

        [String[]] $Services=@("Microsoft.Subscriptions"),

        [ValidateSet("Public", "Private", "Decommissioned")]
        [String] $State = "Public",

        [Switch] $DoNotDelete,

        [Switch] $DoNotDeleteResourceGroup
    )

    if (!$OfferName)
    {
        $OfferName = "TestOffer"  
    }

    if (!$BasePlanName)
    {
        $BasePlanName = "TestPlan-TestOffer"  
    }

    if (!$ResourceGroupName)
    {
        $ResourceGroupName = "TestRG-TestOffer"
    }

    New-ResourceGroup -ResourceGroupName $ResourceGroupName

    $plan = New-Plan -PlanName $BasePlanName -ResourceGroupName $ResourceGroupName -Services $Services
    $plan = Get-Plan -PlanName $BasePlanName -ResourceGroupName $ResourceGroupName
    Assert-NotNull $plan
    Assert-True { $plan.Properties.DisplayName -eq  $BasePlanName}

    New-Offer -OfferName $OfferName -BasePlanIds @($plan.Id) -ResourceGroupName $ResourceGroupName

    $offer = Get-Offer -OfferName $OfferName -ResourceGroupName $ResourceGroupName

    Set-Offer -Offer $offer -ResourceGroup $ResourceGroupName -State $State

    if (!$DoNotDelete)
    {
        Remove-Offer -OfferName $OfferName -ResourceGroupName $ResourceGroupName
        Remove-Plan -PlanName $BasePlanName -ResourceGroupName $ResourceGroupName
        
        if (!$DoNotDeleteResourceGroup)
        {
            Remove-ResourceGroup -ResourceGroupName $ResourceGroupName
        }
    }
}


<#
.Synopsis
    Creates an offer having public delegated offers. Creates a subscription for the user
.EXAMPLE
    This example creates and deletes a new plan and offer
    Test-Offer
.EXAMPLE
    This example creates a offer named DefaultOffer, a plan named DefaultPlan and does not delete them
    Test-Offer -Services @("Microsoft.Subscriptions") -OfferName DefaultOffer -BasePlanName DefaultPlan -DoNotDelete
.NOTES
     The function is called only after Ignore-SelfSignedCert and Set-AzureStackEnvironment with the correct parameters
#>
function Test-DelegatedOffer
{
    param
    (
        [Parameter(Mandatory=$true)]
        [PSCredential] $TenantUserCredential,

        [String[]] $Services=@("Microsoft.Subscriptions","Microsoft.Sql"),

        [Switch] $DoNotDelete
    )

    $delegatedOfferName = "TestOfferDelegated-"  + [Guid]::NewGuid().ToString()
    $delegatedPlanName = "TestPlanDelegated-"  + [Guid]::NewGuid().ToString()
    $offerName = "TestOffer-"  + [Guid]::NewGuid().ToString()
    $planName = "TestPlan-"  + [Guid]::NewGuid().ToString()

    $rgName = "TestRG-" + [Guid]::NewGuid().ToString()

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

    $token =  Get-EnvironmentSpecificToken -Credential $TenantUserCredential

    # Check whether the plan created is visible for the tenant
    $tenantOffer = Get-Offer -OfferName $offerName -Token $token
    $subDisplayName = "$SubscriptionUser Test Subscription"

    # Creating a subscription with Tenant Token
    $subscription = New-Subscription -OfferId $tenantOffer.Id -Token $token

    # Get the delegated offer, with the reseller token
    $resellerViewOffer = Get-Offer -OfferName $delegatedOfferName -Token $token
    Assert-NotNull $resellerViewOffer
    Assert-True { $resellerViewOffer.DisplayName -eq $delegatedOfferName }

    if (!$DoNotDelete)
    {
        Remove-Subscription -TargetSubscriptionId $subscription.SubscriptionId
        Remove-Offer -OfferName $delegatedOfferName -ResourceGroupName $rgName
        Remove-Plan -PlanName $delegatedPlanName -ResourceGroupName $rgName
        Remove-Offer -OfferName $OfferName -ResourceGroupName $rgName
        Remove-Plan -PlanName $PlanName -ResourceGroupName $rgName
        
        if (!$DoNotDeleteResourceGroup)
        {
            Remove-ResourceGroup -ResourceGroupName $ResourceGroupName
        }
    }
}

<#
.Synopsis
    Creates a new plan with Subscription service, then add a sql service to the plan
.NOTES
     The function is called only after Ignore-SelfSignedCert and Set-AzureStackEnvironment with the correct parameters
#>
function Test-AddServiceToPlan
{
    param
    (
        [Parameter(Mandatory=$true)]
        [PSCredential] $TenantUserCredential,

        [String] $ResourceGroupName,

        [Switch] $DoNotDelete,

        [Switch] $DoNotDeleteResourceGroup
    )

    $sqlOfferName = "TestOfferSQL-AddServiceToPlan1" 
    $sqlPlanName = "TestPlanSQL-AddServiceToPlan1"  
    $resellerPlanName = "TestPlanReseller-AddServiceToPlan1" 
    $resellerOfferName = "OfferReseller-AddServiceToPlan1"

    $sqlServices= @("Microsoft.Sql")
    $subscriptionServices= @("Microsoft.Subscriptions")

    if (!$ResourceGroupName)
    {
        $ResourceGroupName = "TestRG-" + [Guid]::NewGuid().ToString()
    }

    New-ResourceGroup -ResourceGroupName $ResourceGroupName

    New-Plan -PlanName $sqlPlanName -ResourceGroupName $ResourceGroupName -Services $sqlServices

    $sqlPlan = Get-Plan -PlanName $sqlPlanName -ResourceGroupName $ResourceGroupName
    Assert-NotNull $sqlPlan
    Assert-True {$sqlPlan.Properties.DisplayName -eq  $sqlPlanName}

    New-Offer -OfferName $sqlOfferName -BasePlanIds @($sqlPlan.Id)  -ResourceGroupName $ResourceGroupName

    $sqlOffer = Get-Offer -OfferName $sqlOfferName -ResourceGroupName $ResourceGroupName
    Assert-NotNull $sqlOffer
    Set-Offer -Offer $sqlOffer -ResourceGroup $ResourceGroupName -State "Public"

    # Creating a reseller plan having a delegated offer
    New-Plan -PlanName $resellerPlanName -ResourceGroupName $ResourceGroupName -Services $subscriptionServices

    $resellerplan = Get-Plan -PlanName $resellerPlanName -ResourceGroupName $ResourceGroupName

    # Create a reseller Offer
    New-Offer -OfferName $resellerOfferName -BasePlanIds @($resellerplan.Id) -ResourceGroupName $ResourceGroupName

    $resellerOffer = Get-Offer -OfferName $resellerOfferName -ResourceGroupName $ResourceGroupName
    Assert-NotNull $resellerOffer
    Set-Offer -Offer $resellerOffer -ResourceGroup $ResourceGroupName -State "Public"

    $token =  Get-EnvironmentSpecificToken -Credential $TenantUserCredential

    # Check whether the plan created is visible for the tenant
    $tenantOffer = Get-Offer -OfferName $resellerOfferName -Token $token
    $subDisplayName = "$SubscriptionUser Test Subscription"

    # Creating a subscription with Tenant Token
    $subscription = New-Subscription -OfferId $tenantOffer.Id -Token $token

    # Add sql service to existing plan
    $serviceQuotas = Get-ServiceQuotas  -Services $sqlServices 
    $resellerplan.properties.quotaIds.Add($serviceQuotas)
    Set-Plan -Plan $resellerplan -ResourceGroup $ResourceGroupName

    $resellerplan = Get-Plan -PlanName $resellerPlanName -ResourceGroupName $ResourceGroupName

    Assert-AreEqual -expected "2" -actual $resellerplan.properties.quotaIds.Count

    # Get the subscription after adding a sql service to the plan
    $updatedSubscription = Get-Subscription -SubscriptionId $subscription.SubscriptionId

    if (!$DoNotDelete)
    {
        Remove-Subscription -TargetSubscriptionId $subscription.SubscriptionId
        Remove-Offer -OfferName $resellerOfferName -ResourceGroupName $ResourceGroupName
        Remove-Offer -OfferName $sqlOfferName -ResourceGroupName $ResourceGroupName
        Remove-Plan -PlanName $sqlPlanName -ResourceGroupName $ResourceGroupName

        if (!$DoNotDeleteResourceGroup)
        {
            Remove-ResourceGroup -PlanName $resellerPlanName -ResourceGroupName $ResourceGroupName
        }
    }
}

function Test-ManagedLocation
{
 param
    (
        [String] $Location="chicago5"
    )

    $lattitude = 80.5
    $longitude = -45.5

    try
    {
        $loc = New-AzsLocation -Name $Location -DisplayName $Location -Latitude 80.5 -Longitude -45.5

        Assert-NotNull $loc
        Assert-AreEqual $loc.Name $Location
        Assert-AreEqual $loc.Latitude $lattitude
        Assert-AreEqual $loc.Longitude $longitude
        Assert-AreEqual $loc.DisplayName $Location

        $loc2 = Get-AzsLocation -Name $Location

        Assert-AreEqual $loc2.Name $Location
        Assert-AreEqual $loc2.Latitude $lattitude
        Assert-AreEqual $loc2.Longitude $longitude
        Assert-AreEqual $loc2.DisplayName $Location

        $lattitude = 90.0 

        $loc2.Latitude = $lattitude
        $loc2 | Set-AzsLocation


        $loc3 = Get-AzsLocation -Name $Location

        Assert-AreEqual $loc3.Name $Location
        Assert-AreEqual $loc3.Latitude $lattitude
        Assert-AreEqual $loc3.Longitude $longitude
        Assert-AreEqual $loc3.DisplayName $Location
    }
    finally
    {
        Remove-AzsLocation -Name $Location
        Assert-Throws {Get-AzsLocation -Name $Location }
    }
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

    New-AzureRmResourceGroup -Name $ResourceGroupName -Location "local"

    $rg = Get-AzureRmResourceGroup -Name $ResourceGroupName -Location "local"
    Assert-NotNull $rg 

    if (!$DoNotDelete)
    {
        Remove-AzureRmResourceGroup -Name $ResourceGroupName -Force
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

    try
    {
        New-AzureRmResourceGroup -Name $resourceGroupName  -Location local -Force
		
		[Microsoft.AzureStack.Commands.AddGalleryItem]::GalleryPackageIds.Enqueue("1988820c-2bcc-4682-9991-bec44e6b8324")
        $galleryItem = Add-AzsGalleryItem -ResourceGroupName $resourceGroupName  -Name $galleryItemName -Path "Microsoft.SimpleVMTemplate.1.0.0.azpkg"  –Verbose
        Assert-NotNull $galleryItem

        $galleryItem  = Get-AzsGalleryItem -Name $galleryItemName -ResourceGroupName  $resourceGroupName
        Assert-AreEqual $galleryItem.Name $galleryItemName
    }
    finally
    {
        Remove-AzsGalleryItem -Name $GalleryItemName -ResourceGroupName  $resourceGroupName
		Remove-ResourceGroup -ResourceGroupName $resourceGroupName
    }
}