### Example 1: Create a computefleet organization
```powershell
New-AzComputeFleetOrganization -ResourceGroupName azure-rg-test -Name computefleetorg-02-pwsh -Location eastus -OfferDetailId "computefleet-cloud-azure-prod" -OfferDetailPlanId "computefleet-cloud-azure-payg-prod" -OfferDetailPlanName "ComputeFleet Cloud - Pay as you Go" -OfferDetailPublisherId "computefleetinc" -OfferDetailTermUnit "P1M" -UserDetailEmailAddress "xxxx@microsoft.com"
```

```output
Location Name                   Type
-------- ----                   ----
eastus   computefleetorg-02-pwsh Microsoft.ComputeFleet/organizations
```

This command creates a computefleet organization.


