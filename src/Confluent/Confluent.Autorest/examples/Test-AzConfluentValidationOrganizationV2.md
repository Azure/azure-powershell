### Example 1: Validate organization configuration (v2)
```powershell
Test-AzConfluentValidationOrganizationV2 -ResourceGroupName confluent-rg -Location eastus -OrganizationName confluentorg-01
```

```output
IsValid  Message                              ValidationErrors
-------  -------                              ----------------
True     Organization configuration is valid  @()
```

This command validates the organization configuration using the v2 validation endpoint.

### Example 2: Validate with user details
```powershell
Test-AzConfluentValidationOrganizationV2 -ResourceGroupName confluent-rg -Location eastus -OrganizationName confluentorg-01 -UserDetail @{Email="admin@contoso.com"; FirstName="Admin"; LastName="User"}
```

This command validates organization with user information for the organization owner.

