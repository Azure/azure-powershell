---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# New-AzVirtualApplianceNetworkInterfaceConfiguration

## SYNOPSIS
Defines a Interface Configuration for Network Profile of Virtual Appliance.

## SYNTAX

```
New-AzVirtualApplianceNetworkInterfaceConfiguration -NicType <String>
 -IpConfigurations <PSVirtualApplianceIpConfiguration[]> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzVirtualApplianceNetworkInterfaceConfiguration command defines configuration for a network interface of a virtual appliance.

## EXAMPLES

### Example 1
```powershell
PS C:\> $nicConfig1 = New-AzVirtualApplianceNetworkInterfaceConfiguration -NicType "PublicNic" -IpConfigurations $ipConfig1, $ipConfig2
```

Creating a new network interface configuration with nicType PublicNic and IP configurations $ipConfig1 and $ipConfig2.

### Example 2
```powershell
PS C:\> $nicConfig2 = New-AzVirtualApplianceNetworkInterfaceConfiguration -NicType "PrivateNic" -IpConfigurations $ipConfig3, $ipConfig4
```

Creating a new network interface configuration with nicType PrivateNic and IP configurations $ipConfig3 and $ipConfig4.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IpConfigurations
The IP configurations of the network interface configuration.

```yaml
Type: PSVirtualApplianceIpConfiguration[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NicType
The type of the network interface configuration.

```yaml
Type: String
Parameter Sets: (All)
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
Type: SwitchParameter
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
Type: SwitchParameter
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualApplianceNetworkInterfaceConfiguration

## NOTES

## RELATED LINKS
