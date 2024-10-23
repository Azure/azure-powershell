---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azvirtualappliancenetworkinterfaceconfiguration
schema: 2.0.0
---

# New-AzVirtualApplianceNetworkInterfaceConfiguration

## SYNOPSIS
Defines a Interface Configuration for Network Profile of Virtual Appliance.

## SYNTAX

```
New-AzVirtualApplianceNetworkInterfaceConfiguration -NicType <String>
 -IpConfiguration <PSVirtualApplianceIpConfiguration[]> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzVirtualApplianceNetworkInterfaceConfiguration command defines configuration for a network interface of a virtual appliance.

## EXAMPLES

### Example 1
```powershell
$ipConfig1 = New-AzVirtualApplianceIpConfiguration -Name "publicnicipconfig" -Primary $true
$ipConfig2 = New-AzVirtualApplianceIpConfiguration -Name "publicnicipconfig-2" -Primary $false
$nicConfig1 = New-AzVirtualApplianceNetworkInterfaceConfiguration -NicType "PublicNic" -IpConfiguration $ipConfig1, $ipConfig2
```

Creating a new network interface configuration with nicType PublicNic and IP configurations $ipConfig1 and $ipConfig2.

### Example 2
```powershell
$ipConfig3 = New-AzVirtualApplianceIpConfiguration -Name "privatenicipconfig" -Primary $true
$ipConfig4 = New-AzVirtualApplianceIpConfiguration -Name "privatenicipconfig-2" -Primary $false
$nicConfig2 = New-AzVirtualApplianceNetworkInterfaceConfiguration -NicType "PrivateNic" -IpConfiguration $ipConfig3, $ipConfig4
```

Creating a new network interface configuration with nicType PrivateNic and IP configurations $ipConfig3 and $ipConfig4.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IpConfiguration
The IP configurations of the network interface configuration.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualApplianceIpConfiguration[]
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
Type: System.String
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualApplianceNetworkInterfaceConfiguration

## NOTES

## RELATED LINKS
