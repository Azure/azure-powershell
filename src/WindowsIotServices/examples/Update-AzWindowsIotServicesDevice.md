### Example 1: Update a Windows IoT services by name
```powershell
Update-AzWindowsIotServicesDevice -Name wsi-t03 -ResourceGroupName azure-rg-test -Quantity 10
```
```output
Location Name    Type                                Etag
-------- ----    ----                                ----
eastus   wsi-t03 Microsoft.WindowsIoT/DeviceServices "5d006a5c-0000-0700-0000-5faa46760000"
```

This command updates a Windows IoT services by name.

### Example 2: Update a Windows IoT services by pipeline
```powershell
Get-AzWindowsIotServicesDevice -Name wsi-t03 -ResourceGroupName azure-rg-test | Update-AzWindowsIotServicesDevice -Quantity 100 -Tag @{'oper'='update'}
```
```output
Location Name    Type                                Etag
-------- ----    ----                                ----
West US  wsi-t01 Microsoft.WindowsIoT/DeviceServices "5d005f5f-0000-0700-0000-5faa46ae0000"
```

This command updates a Windows IoT services by pipeline.