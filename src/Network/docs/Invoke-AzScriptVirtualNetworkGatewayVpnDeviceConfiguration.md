---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/invoke-azscriptvirtualnetworkgatewayvpndeviceconfiguration
schema: 2.0.0
---

# Invoke-AzScriptVirtualNetworkGatewayVpnDeviceConfiguration

## SYNOPSIS
Gets a xml format representation for vpn device configuration script.

## SYNTAX

### Script (Default)
```
Invoke-AzScriptVirtualNetworkGatewayVpnDeviceConfiguration -ResourceGroupName <String> -SubscriptionId <String>
 -VirtualNetworkGatewayConnectionName <String> [-Parameter <IVpnDeviceScriptParameters>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ScriptExpanded
```
Invoke-AzScriptVirtualNetworkGatewayVpnDeviceConfiguration -ResourceGroupName <String> -SubscriptionId <String>
 -VirtualNetworkGatewayConnectionName <String> [-DeviceFamily <String>] [-FirmwareVersion <String>]
 [-Vendor <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ScriptViaIdentityExpanded
```
Invoke-AzScriptVirtualNetworkGatewayVpnDeviceConfiguration -InputObject <INetworkIdentity>
 [-DeviceFamily <String>] [-FirmwareVersion <String>] [-Vendor <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ScriptViaIdentity
```
Invoke-AzScriptVirtualNetworkGatewayVpnDeviceConfiguration -InputObject <INetworkIdentity>
 [-Parameter <IVpnDeviceScriptParameters>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a xml format representation for vpn device configuration script.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceFamily
The device family for the vpn device.

```yaml
Type: System.String
Parameter Sets: ScriptExpanded, ScriptViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FirmwareVersion
The firmware version for the vpn device.

```yaml
Type: System.String
Parameter Sets: ScriptExpanded, ScriptViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: ScriptViaIdentityExpanded, ScriptViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Parameter
Vpn device configuration script generation parameters

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnDeviceScriptParameters
Parameter Sets: Script, ScriptViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Script, ScriptExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Script, ScriptExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Vendor
The vendor for the vpn device.

```yaml
Type: System.String
Parameter Sets: ScriptExpanded, ScriptViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkGatewayConnectionName
The name of the virtual network gateway connection for which the configuration script is generated.

```yaml
Type: System.String
Parameter Sets: Script, ScriptExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.String
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/invoke-azscriptvirtualnetworkgatewayvpndeviceconfiguration](https://docs.microsoft.com/en-us/powershell/module/az.network/invoke-azscriptvirtualnetworkgatewayvpndeviceconfiguration)

