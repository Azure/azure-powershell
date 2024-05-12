---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# New-AzVirtualApplianceInboundSecurityPropertyRules

## SYNOPSIS
Define Inbound Security Rule property: Rules

## SYNTAX

```
New-AzVirtualApplianceInboundSecurityPropertyRules -Name <String> [-Protocol <String>]
 -SourceAddressPrefix <String> [-DestinationPortRange <Int32>] [-DestinationPortRanges <String[]>]
 -AppliesOn <String[]> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzVirtualApplianceInboundSecurityPropertyRules command defines a specific rule configuration for the the Inbound Security Rule on a Network Virtual Appliance resource.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzVirtualApplianceInboundSecurityPropertyRules -Name InboundRule1 -Protocol TCP -SourceAddressPrefix * -DestinationPortRanges "80-120","121-124" -AppliesOn "publicip1"
```

The above command defines the rule configuration having values as below:

Name: InboundRule1
Protocol: TCP
Source Address Prefix: *
Destination Port Ranges: "80-120" & "121-124"
Applies on: publicip1

The rule with above property will configure a corresponding NSG rule and a Load Balancing rule on the SLB attached to the NVA, the LB rule will have the Frontned IP as publicip1

## PARAMETERS

### -AppliesOn
The Applies On value of the rule for the SLP IP/Interface

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -DestinationPortRange
Destination Port Range of the rule

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationPortRanges
Destination Port Ranges of the rule

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Inbound Security property rule

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

### -Protocol
Rule protocol

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Tcp, Udp, *

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceAddressPrefix
The Source Address Prefix of the rule

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

### Microsoft.Azure.Commands.Network.Models.PSInboundSecurityPropertyRules

## NOTES

## RELATED LINKS
