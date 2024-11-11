---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azvirtualapplianceipconfiguration
schema: 2.0.0
---

# New-AzVirtualApplianceIpConfiguration

## SYNOPSIS
Defines an IP configuration for an interface of virtual appliance.

## SYNTAX

```
New-AzVirtualApplianceIpConfiguration -Name <String> -Primary <Boolean>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzVirtualApplianceIpConfiguration command defines an IP configuration for an interface of virtual appliance.

## EXAMPLES

### Example 1
```powershell
$ipConfig1 = New-AzVirtualApplianceIpConfiguration -Name "publicnicipconfig" -Primary $true
```

This command creates a new IP configuration with the name "publicnicipconfig" and sets it as the primary IP configuration.

### Example 2
```powershell
$ipConfig2 = New-AzVirtualApplianceIpConfiguration -Name "publicnicipconfig" -Primary $false
```

This command creates a new IP configuration with the name "publicnicipconfig" and sets it as the secondary IP configuration.

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

### -Name
The name of the IP configuration.

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

### -Primary
Indicates whether this IP configuration is the primary one.

```yaml
Type: System.Boolean
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

### Microsoft.Azure.Commands.Network.Models.PSVirtualApplianceIpConfiguration

## NOTES

## RELATED LINKS
