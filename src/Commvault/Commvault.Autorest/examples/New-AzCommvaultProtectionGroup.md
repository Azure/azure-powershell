### Example 1: Create a protection group for specific virtual machines
```powershell
New-AzCommvaultProtectionGroup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -ProtectionGroupName pg-prod-vms -Plan plan-daily -ResourceManual '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-app/providers/Microsoft.Compute/virtualMachines/vm-app01'
```

Creates a protection group that protects the specified virtual machine with the backup plan plan-daily.

### Example 2: Create a protection group that selects virtual machines by a rule
```powershell
$rule = @{ Property = 'resourceGroup'; Operator = 'contains'; Value = 'prod' }
New-AzCommvaultProtectionGroup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -ProtectionGroupName pg-prod-vms -Plan plan-daily -MatchRule $rule -MatchRuleMatchType 'all'
```

Creates a protection group that protects the virtual machines whose resource group name contains prod.

