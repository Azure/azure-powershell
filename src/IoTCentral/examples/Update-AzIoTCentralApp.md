### Example 1: Update the metadata of an IoT Central application.
```powershell
Update-AzIoTCentralApp -Name azpstest-iot -ResourceGroupName jinpei-gp -SkuName ST2 -DisplayName "My IoT Central App" -IdentityType 'SystemAssigned' -Subdomain "my-iot-central-app" -Template "iotc-pnp-preview@1.0.0" -Tag @{"IoTCentral"="apiversion20220601";"ABC"="123"}
```

```output
Location Name         ResourceGroupName
-------- ----         -----------------
westus   azpstest-iot jinpei-gp
```

Update the metadata of an IoT Central application.

### Example 2: Update the metadata of an IoT Central application.
```powershell
Get-AzIoTCentralApp -Name azpstest-iot -ResourceGroupName jinpei-gp | Update-AzIoTCentralApp -SkuName ST2 -DisplayName "My IoT Central App" -IdentityType 'SystemAssigned' -Subdomain "my-iot-central-app" -Template "iotc-pnp-preview@1.0.0" -Tag @{"IoTCentral"="apiversion20220601";"ABC"="123"}
```

```output
Location Name         ResourceGroupName
-------- ----         -----------------
westus   azpstest-iot jinpei-gp
```

Update the metadata of an IoT Central application.