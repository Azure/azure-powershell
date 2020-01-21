$global:SkippedTests = @(
)

# Multiple tests
$global:Location = (Get-AzLocation)[0].Name
$global:ResourceGroupName = "system." + "$($global:Location)"

# Acquired plan tests
$global:TargetSubscriptionId = "89d3387e-d050-4769-a15f-2d9f0dd85015"
$global:SubscriptionId = (Get-AzContext).Subscription.Id
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