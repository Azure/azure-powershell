### Example 1: List the IoTCentral data.
```powershell
Get-AzIoTCentralApp
```

```output
Location Name         ResourceGroupName
-------- ----         -----------------
westus   azpstest-iot azpstest-gp
```

List the IoTCentral data.

### Example 2: Gets the metadata of Resource Group.
```powershell
Get-AzIoTCentralApp -ResourceGroupName azpstest-gp
```

```output
Location Name         ResourceGroupName
-------- ----         -----------------
westus   azpstest-iot azpstest-gp
```

Gets the metadata of Resource Group.

### Example 3: Get the metadata of an IoT Central application.
```powershell
Get-AzIoTCentralApp -Name azpstest-iot -ResourceGroupName azpstest-gp
```

```output
Location Name         ResourceGroupName
-------- ----         -----------------
westus   azpstest-iot azpstest-gp
```

Get the metadata of an IoT Central application.