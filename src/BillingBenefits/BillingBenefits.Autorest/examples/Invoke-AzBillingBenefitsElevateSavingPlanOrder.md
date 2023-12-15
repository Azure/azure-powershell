### Example 1: Elevate savings plan order
```powershell
Invoke-AzBillingBenefitsElevateSavingPlanOrder -SavingsPlanOrderId "e0b1f446-5684-4fa6-a0c8-d394368eda11"
```

```output
Name                                 PrincipalId                          RoleDefinitionId                                                                        Scope
----                                 -----------                          ----------------                                                                        -----
5c545baf-2ef5-4016-9c31-6e0e23c397a0 067e7443-3a55-40b6-a2d8-0a7a12a9da2d /providers/Microsoft.Authorization/roleDefinitions/8e3af657-a8ff-443c-a75c-2fe8c4bcb635 /providers/Microsoft.BillingBenefits/savingsplanorders/e45905d2-9207-4f24-8549-f615c203b49b
```

Elevate savings plan order

### Example 2: Elevate savings plan order via identiy
```powershell
$identity = @{
            SavingsPlanOrderId = "e45905d2-9207-4f24-8549-f615c203b49b"
}

$response = Invoke-AzBillingBenefitsElevateSavingPlanOrder -InputObject $identity
```

```output
Name                                 PrincipalId                          RoleDefinitionId                                                                        Scope
----                                 -----------                          ----------------                                                                        -----
5c545baf-2ef5-4016-9c31-6e0e23c397a0 067e7443-3a55-40b6-a2d8-0a7a12a9da2d /providers/Microsoft.Authorization/roleDefinitions/8e3af657-a8ff-443c-a75c-2fe8c4bcb635 /providers/Microsoft.BillingBenefits/savingsplanorders/e45905d2-9207-4f24-8549-f615c203b49b
```

Elevate savings plan order
