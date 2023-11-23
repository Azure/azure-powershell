### Example 1: Remove a Windows IoT services by name
```powershell
PS C:\> Remove-AzWindowsIotServicesDevice -Name wsi-t03 -ResourceGroupName azure-rg-test

```

This command removes a Windows IoT services by name.

### Example 2: Remove a Windows IoT services by pipeline
```powershell
PS C:\> Get-AzWindowsIotServicesDevice -ResourceGroupName azure-rg-test -Name wsi-t01 | Remove-AzWindowsIotServicesDevice


```

This command removes a Windows IoT services by pipeline.

