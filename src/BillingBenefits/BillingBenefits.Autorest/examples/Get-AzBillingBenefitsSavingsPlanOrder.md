### Example 1: List savings plan orders
```powershell
Get-AzBillingBenefitsSavingsPlanOrder
```

```output
OrderId                              SkuName              Status    ExpiryDate             Term BillingPlan
-------                              -------              ------    ----------             ---- -----------
23420e73-752b-47e8-96d9-6f9ac2bcee27 Compute_Savings_Plan Succeeded 11/30/2023 11:22:53 PM P1Y  P1M        
953fc18d-04d6-4f8a-9f51-6b784cbc4d2a Compute_Savings_Plan Succeeded 11/30/2025 12:36:25 AM P3Y  P1M        
a05e9e28-0adf-4e73-8e24-87bf51ab6cdc Compute_Savings_Plan Succeeded 11/29/2025 2:51:18 AM  P3Y  P1M        
1a06f5fc-2152-40ec-9675-f890ab680df9 Compute_Savings_Plan Succeeded 11/29/2025 2:48:30 AM  P3Y  P1M  
```

List savings plan orders

### Example 2: Get a single savings plan order
```powershell
Get-AzBillingBenefitsSavingsPlanOrder -Id 23420e73-752b-47e8-96d9-6f9ac2bcee27
```

```output
OrderId                              SkuName              Status    ExpiryDate             Term BillingPlan
-------                              -------              ------    ----------             ---- -----------
23420e73-752b-47e8-96d9-6f9ac2bcee27 Compute_Savings_Plan Succeeded 11/30/2023 11:22:53 PM P1Y  P1M
```

Get a single savings plan order
