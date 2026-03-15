### Example 1: Create a new environment
```powershell
New-AzConfluentEnvironment -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -Name production -DisplayName "Production Environment"
```

```output
Id          Name        DisplayName                StreamGovernanceConfig
--          ----        -----------                ----------------------
env-new123  production  Production Environment     Essentials
```

This command creates a new environment in the Confluent organization.

### Example 2: Create environment with governance
```powershell
New-AzConfluentEnvironment -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -Name compliance-env -DisplayName "Compliance Environment" -GovernancePackage "Advanced"
```

This command creates an environment with advanced stream governance capabilities.

