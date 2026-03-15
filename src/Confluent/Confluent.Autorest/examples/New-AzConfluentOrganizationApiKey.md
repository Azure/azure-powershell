### Example 1: Create a new organization API key
```powershell
New-AzConfluentOrganizationApiKey -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -Description "API key for automation"
```

```output
Id          Description                   Created
--          -----------                   -------
key-new123  API key for automation        2026-02-19 10:00:00
```

This command creates a new API key for the organization.

### Example 2: Create API key with owner
```powershell
New-AzConfluentOrganizationApiKey -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -Description "Service account key" -Owner "User:sa-123"
```

This command creates an API key owned by a specific service account.

