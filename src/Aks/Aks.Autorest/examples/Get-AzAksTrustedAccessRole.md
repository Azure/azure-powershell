### Example 1: List supported trusted access roles
```powershell
Get-AzAksTrustedAccessRole -Location eastus
```

```output
Name                                       SourceResourceType
----                                       ------------------
backup-operator                            Microsoft.DataProtection/backupVaults
mlworkload                                 Microsoft.MachineLearningServices/workspaces
inference-v1                               Microsoft.MachineLearningServices/workspaces
microsoft-defender-operator                Microsoft.Security/pricings
microsoft-defender-policy-operator         Microsoft.Security/pricings
microsoft-defender-network-policy-operator Microsoft.Security/pricings
mdc-response-operator                      Microsoft.Security/pricings
```

List supported trusted access roles.

