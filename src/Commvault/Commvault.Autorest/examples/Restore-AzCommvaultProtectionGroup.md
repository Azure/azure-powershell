### Example 1: Restore a protection group in place
```powershell
Restore-AzCommvaultProtectionGroup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name pg-prod-vms -InPlaceRestore -VMDestinationInfoVminfoList @{ SourceVMGuid = '40000000-aaaa-4bbb-8ccc-000000000000'; StorageAccountId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-restore/providers/Microsoft.Storage/storageAccounts/strestore01'; PowerOnVMAfterRestore = $true }
```

Restores the specified virtual machine of the protection group in place and powers it on after the restore completes.

### Example 2: Restore a protection group by using a JSON file
```powershell
Restore-AzCommvaultProtectionGroup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name pg-prod-vms -JsonFilePath '.\restore-request.json'
```

Restores the protection group by using the request body in the JSON file.

