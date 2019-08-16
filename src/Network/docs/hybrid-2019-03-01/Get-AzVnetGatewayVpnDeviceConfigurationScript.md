---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/get-azvnetgatewayvpndeviceconfigurationscript
schema: 2.0.0
---

# Get-AzVnetGatewayVpnDeviceConfigurationScript

## SYNOPSIS
Gets a xml format representation for vpn device configuration script.

## SYNTAX

### ScriptExpanded1 (Default)
```
Get-AzVnetGatewayVpnDeviceConfigurationScript -Name <String> -ResourceGroupName <String>
 -SubscriptionId <String[]> [-DeviceFamily <String>] [-FirmwareVersion <String>] [-Vendor <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Script1
```
Get-AzVnetGatewayVpnDeviceConfigurationScript -Name <String> -ResourceGroupName <String>
 -SubscriptionId <String[]> -VpnDeviceConfigurationScript <IVpnDeviceScriptParameters>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ScriptViaIdentityExpanded1
```
Get-AzVnetGatewayVpnDeviceConfigurationScript -InputObject <INetworkIdentity> [-DeviceFamily <String>]
 [-FirmwareVersion <String>] [-Vendor <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ScriptViaIdentity1
```
Get-AzVnetGatewayVpnDeviceConfigurationScript -InputObject <INetworkIdentity>
 -VpnDeviceConfigurationScript <IVpnDeviceScriptParameters> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a xml format representation for vpn device configuration script.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

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
Dynamic: False
```

### -DeviceFamily
The device family for the vpn device.

```yaml
Type: System.String
Parameter Sets: ScriptExpanded1, ScriptViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FirmwareVersion
The firmware version for the vpn device.

```yaml
Type: System.String
Parameter Sets: ScriptExpanded1, ScriptViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: ScriptViaIdentityExpanded1, ScriptViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the virtual network gateway connection for which the configuration script is generated.

```yaml
Type: System.String
Parameter Sets: ScriptExpanded1, Script1
Aliases: VirtualNetworkGatewayConnectionName, VnetGatewayConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: ScriptExpanded1, Script1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: ScriptExpanded1, Script1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Vendor
The vendor for the vpn device.

```yaml
Type: System.String
Parameter Sets: ScriptExpanded1, ScriptViaIdentityExpanded1
Aliases: DeviceVendor

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VpnDeviceConfigurationScript
Vpn device configuration script generation parameters
To construct, see NOTES section for VPNDEVICECONFIGURATIONSCRIPT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnDeviceScriptParameters
Parameter Sets: Script1, ScriptViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnDeviceScriptParameters

## OUTPUTS

### System.String

## ALIASES

### Get-AzVirtualNetworkGatewayConnectionVpnDeviceConfigScript

### Get-AzVirtualNetworkGatewayVpnDeviceConfigurationScript

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### VPNDEVICECONFIGURATIONSCRIPT <IVpnDeviceScriptParameters>: Vpn device configuration script generation parameters
  - `[DeviceFamily <String>]`: The device family for the vpn device.
  - `[FirmwareVersion <String>]`: The firmware version for the vpn device.
  - `[Vendor <String>]`: The vendor for the vpn device.

## RELATED LINKS

