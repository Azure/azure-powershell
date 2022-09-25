### Example 1: Creates or updates instance.
```powershell
New-AzDeviceUpdateInstance -AccountName azpstest-account -Name azpstest-instance -ResourceGroupName azpstest_gp -Location eastus -IotHubId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azpstest_gp/providers/Microsoft.Devices/IotHubs/azpstest-iothub" -EnableDiagnostic:$false -DiagnosticStoragePropertyResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azpstest_gp/providers/Microsoft.Storage/storageAccounts/azpsteststorageaccount" -DiagnosticStoragePropertyConnectionString "De******et"
```

```output
AccountName      Name              Location ResourceGroupName
-----------      ----              -------- -----------------
azpstest-account azpstest-instance eastus   azpstest_gp
```

Creates or updates instance.