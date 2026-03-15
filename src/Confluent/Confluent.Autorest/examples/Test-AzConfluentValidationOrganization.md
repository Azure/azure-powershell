### Example 1: Validate organization configuration
```powershell
Test-AzConfluentValidationOrganization -ResourceGroupName confluent-rg -Location eastus -OrganizationName confluentorg-01
```

```output
IsValid  Message
-------  -------
True     Organization configuration is valid
```

This command validates the organization configuration before creation.

### Example 2: Validate with offer details
```powershell
Test-AzConfluentValidationOrganization -ResourceGroupName confluent-rg -Location eastus -OrganizationName confluentorg-01 -OfferDetail @{PublisherId="confluent"; Id="confluent-cloud-azure-prod"; PlanId="confluent-cloud-azure-payg-prod"}
```

This command validates organization configuration with specific marketplace offer details.

