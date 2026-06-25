### Example 1: Create an EdgeAction rule action object
```powershell
New-AzFrontDoorCdnRuleEdgeActionObject -ParameterInvocationPoint ClientRequest -ParameterTypeName DeliveryRuleEdgeActionParameters -ReferenceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testps-rg-da16jm/providers/Microsoft.Cdn/edgeActions/edgeaction001"
```

Creates an in-memory EdgeAction rule action object.
