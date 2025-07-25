### Example 1: Get all Windows IoT services under a subscription
```powershell
Get-AzWindowsIotServicesDevice
```
```output
Location Name    Type                                Etag
-------- ----    ----                                ----
West US  wsi-t01 Microsoft.WindowsIoT/DeviceServices "5c006e63-0000-0700-0000-5faa37830000"
eastus   wsi-t02 Microsoft.WindowsIoT/DeviceServices "5c006ad2-0000-0700-0000-5faa3e090000"
```

This command gets all Windows IoT services under a subscription.

### Example 2: Get all Windows IoT services under a resource group
```powershell
Get-AzWindowsIotServicesDevice -ResourceGroupName azure-rg-test
```
```output
Location Name    Type                                Etag
-------- ----    ----                                ----
West US  wsi-t01 Microsoft.WindowsIoT/DeviceServices "5c006e63-0000-0700-0000-5faa37830000"
eastus   wsi-t02 Microsoft.WindowsIoT/DeviceServices "5c006ad2-0000-0700-0000-5faa3e090000"
```

This command gets all Windows IoT services under a resource group.

### Example 3: Get a Windows IoT service by name
```powershell
Get-AzWindowsIotServicesDevice -ResourceGroupName azure-rg-test -Name wsi-t01
```
```output
Location Name    Type                                Etag
-------- ----    ----                                ----
West US  wsi-t01 Microsoft.WindowsIoT/DeviceServices "5c006e63-0000-0700-0000-5faa37830000"
```

This command gets a Windows IoT service by name.

### Example 4: Get a Windows IoT service by object
```powershell
$wsi = New-AzWindowsIotServicesDevice -Name wsi-t01 -ResourceGroupName azure-rg-test -Location eastus -Quantity 10 -BillingDomainName 'microsoft.onmicrosoft.com' -AdminDomainName 'microsoft.onmicrosoft.com'
Get-AzWindowsIotServicesDevice -InputObject $wsi
```
```output
Location Name    Type                                Etag
-------- ----    ----                                ----
West US  wsi-t01 Microsoft.WindowsIoT/DeviceServices "5c006e63-0000-0700-0000-5faa37830000"
```

This command gets a Windows IoT service by object.

### Example 5: Get a Windows IoT service by pipeline
```powershell
$wsi = New-AzWindowsIotServicesDevice -Name wsi-t01 -ResourceGroupName azure-rg-test -Location eastus -Quantity 10 -BillingDomainName 'microsoft.onmicrosoft.com' -AdminDomainName 'microsoft.onmicrosoft.com' | Get-AzWindowsIotServicesDevice
```
```output
Location Name    Type                                Etag
-------- ----    ----                                ----
West US  wsi-t01 Microsoft.WindowsIoT/DeviceServices "5c006e63-0000-0700-0000-5faa37830000"
```

This command gets a Windows IoT service by pipeline.