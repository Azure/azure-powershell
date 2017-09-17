---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: 
schema: 2.0.0
---

# Get-AzureRmVirtualNetworkGatewaySupportedVpnDevices

## SYNOPSIS
This commandlet returns a list of supported VPN device brands, models, and firmware versions.

## SYNTAX

```
Get-AzureRmVirtualNetworkGatewaySupportedVpnDevices [-Name <String>] -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
This commandlet returns a list of supported VPN device brands, models, and firmware versions.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmVirtualNetworkGatewaySupportedVpnDevices -ResourceGroupName TestRG -Name TestGateway 
<?xml version="1.0" encoding="utf-8"?>
<RpVpnDeviceList version="1.0">
  <Vendor name="Cisco-Test">
    <DeviceFamily name="IOS-Test">
       <FirmwareVersion name="20" />
    </DeviceFamily>
  </Vendor>
</RpVpnDeviceList>

```

Returns list of supported VPN device brands, models and firmware versions:
<?xml version="1.0" encoding="utf-8"?>
"<RpVpnDeviceList version="1.0">
  <Vendor name="Cisco-Test">
    <DeviceFamily name="IOS-Test">
       <FirmwareVersion name="20" />
    </DeviceFamily>
  </Vendor>
</RpVpnDeviceList>"

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String


## OUTPUTS

### System.String


## NOTES

## RELATED LINKS

