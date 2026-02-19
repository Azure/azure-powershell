### Example 1: Update an environment display name
```powershell
Set-AzConfluentEnvironment -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -DisplayName "Updated Production"
```

```output
Id          Name        DisplayName           StreamGovernanceConfig
--          ----        -----------           ----------------------
env-abc123  prod-env    Updated Production    Essentials
```

This command updates the display name of an environment.

### Example 2: Update environment governance package
```powershell
Set-AzConfluentEnvironment -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -GovernancePackage "Advanced"
```

This command upgrades the stream governance package for the environment.

