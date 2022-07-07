### Example 1: Create or update the metadata of an IoT Central application.
```powershell
New-AzIoTCentralApp -Name azpstest-iot -ResourceGroupName azpstest-gp -Location westus -SkuName ST2 -DisplayName "My IoT Central App" -IdentityType 'SystemAssigned' -Subdomain "my-iot-central-app" -Template "iotc-pnp-preview@1.0.0" -Tag @{"IoTCentral"="apiversion20220601"}
```

```output
Location Name         ResourceGroupName
-------- ----         -----------------
westus   azpstest-iot azpstest-gp
```

Create or update the metadata of an IoT Central application.
The usual pattern to modify a property is to retrieve the IoT Central application metadata and security metadata, and then combine them with the modified values in a new body to update the IoT Central application.