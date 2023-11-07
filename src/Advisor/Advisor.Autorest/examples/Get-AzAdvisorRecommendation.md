### Example 1: List Recommendation by subscriptionId and resource group name
```powershell
 Get-AzAdvisorRecommendation -ResourceGroupName lnxtest -Category HighAvailability
```

```output
Name                                 Category         Resource Group Impact ImpactedValue ImpactedField
----                                 --------         -------------- ------ ------------- -------------
71411b72-e7de-9dc2-308b-5c60252e1456 HighAvailability lnxtest        Medium lnxtest-vnet  MICROSOFT.NETWORK/VIRTUALNETWORKS
bf8ebdfd-6caa-9f55-53ae-ffafefbf3a7c HighAvailability lnxtest        Medium advisortest   MICROSOFT.NETWORK/VIRTUALNETWORKS
339071fa-d66a-be4f-9cf8-22b67552b287 HighAvailability lnxtest        Medium advisor-test  MICROSOFT.NETWORK/VIRTUALNETWORKS
```

List Recommendation by subscriptionId

### Example 2: List Recommendation by subscriptionId and filter
```powershell
Get-AzAdvisorRecommendation -filter "Category eq 'HighAvailability' and ResourceGroup eq 'lnxtest'"
```

```output
Name                                 Category         Resource Group Impact ImpactedValue ImpactedField
----                                 --------         -------------- ------ ------------- -------------
71411b72-e7de-9dc2-308b-5c60252e1456 HighAvailability lnxtest        Medium lnxtest-vnet  MICROSOFT.NETWORK/VIRTUALNETWORKS
bf8ebdfd-6caa-9f55-53ae-ffafefbf3a7c HighAvailability lnxtest        Medium advisortest   MICROSOFT.NETWORK/VIRTUALNETWORKS
339071fa-d66a-be4f-9cf8-22b67552b287 HighAvailability lnxtest        Medium advisor-test  MICROSOFT.NETWORK/VIRTUALNETWORKS
```

List Recommendation by subscriptionId and filter




### Example 3: Get Recommendation by Id and resource Id
```powershell
Get-AzAdvisorRecommendation -Id 42963553-61de-5334-2d2e-47f3a0099d41 -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f
```

```output
Name                                 Category Resource Group   Impact ImpactedValue    ImpactedField
----                                 -------- --------------   ------ -------------    -------------
42963553-61de-5334-2d2e-47f3a0099d41 Security automanagehcrprg High   arcbox-capi-mgmt Microsoft.Compute/virtualMachines
```

Get Recommendation by Id and resource Id



