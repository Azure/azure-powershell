### Example 1: Change the backup plan of a protection group
```powershell
Update-AzCommvaultProtectionGroup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name pg-prod-vms -Plan plan-weekly
```

Changes the protection group to use the backup plan plan-weekly.

### Example 2: Change the virtual machines of a protection group
```powershell
Update-AzCommvaultProtectionGroup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name pg-prod-vms -ResourceManual '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-app/providers/Microsoft.Compute/virtualMachines/vm-app02'
```

Changes the protection group so that it protects the specified virtual machine.

