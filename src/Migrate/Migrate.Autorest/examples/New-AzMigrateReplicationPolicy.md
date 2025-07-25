### Example 1: Create a replication policy
```powershell
$providerSpecificPolicy = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtPolicyCreationInput]::new()
$providerSpecificPolicy.AppConsistentFrequencyInMinute = 240
$providerSpecificPolicy.InstanceType = "VMwareCbt"
$providerSpecificPolicy.RecoveryPointHistoryInMinute = 4320
$providerSpecificPolicy.CrashConsistentFrequencyInMinute = 60
New-AzMigrateReplicationPolicy -PolicyName TestPolicy -ResourceGroupName ResourceGroup -ResourceName VaultName -SubscriptionId SubscriptionId -ProviderSpecificInput $providerSpecificPolicy
```

```output
Location Name       Type
-------- ----       ----
         TestPolicy Microsoft.RecoveryServices/vaults/replicationPolicies
         
```

Creates a policy for VmWare Cbt



