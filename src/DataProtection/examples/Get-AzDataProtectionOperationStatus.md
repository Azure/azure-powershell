### Example 1: Get operation status for a long running operation
```powershell
$operationResponse = Test-AzDataProtectionBackupInstanceReadiness -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subId -BackupInstance $backupInstanceClientObject.Property -NoWait
$operationId = $operationResponse.Target.Split("/")[-1].Split("?")[0]
Get-AzDataProtectionOperationStatus -OperationId $operationId -Location $vault.Location -SubscriptionId $subId
While((Get-AzDataProtectionOperationStatus -OperationId $operationId -Location $vault.Location -SubscriptionId $subId).Status -eq "Inprogress"){
	Start-Sleep -Seconds 10
}
```

```output
EndTime              Name                                                                                                 StartTime            Status
-------              ----                                                                                                 ---------            ------
5/6/2023 11:44:42 AM N2E2NGU0YzItMzZjNC00MDUwLTlmZGYtMGNlZTFjMmI4MWRhO2U3MjRiMGExLTM3NGItNGYwYS05ZDRlLTQxZWQ5Nzg5MzhkZg== 5/6/2023 11:44:21 AM Succeeded
```

First command fetches the operation response for a long running operation, using the the parameter -NoWait. This is to run the operation in async mode.
Second command splits the operationResponse to get the operationId.
Third command fetches the operation status in async way.
Fourth command fetches the operation status in a loop until it succeeds, while waiting 10 seconds before each iteration.
