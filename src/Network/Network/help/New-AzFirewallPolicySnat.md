---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azfirewallpolicysnat
schema: 2.0.0
---

# New-AzFirewallPolicySnat

## SYNOPSIS
Creates SNAT configuration of PrivateRange and AutoLearnPrivateRanges for the firewall policy

## SYNTAX

```
New-AzFirewallPolicySnat [-PrivateRange <String[]>] [-AutoLearnPrivateRange]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The New-AzFirewallPolicySnat is used to configure Private Ranges and auto learn private ranges for a firewall policy.

## EXAMPLES

### Example 1
```powershell
New-AzFirewallPolicySnat -PrivateRange @("3.3.0.0/24", "98.0.0.0/8","10.227.16.0/20") -AutoLearnPrivateRange
```

```output
PrivateRange	            : ["3.3.0.0/24", "98.0.0.0/8","10.227.16.0/20"]	
		AutoLearnPrivateRanges	    : Enabled
```

This example configures private IP addresses/IP ranges to which traffic will not be SNATed and enables auto learn of private ip ranges in Firewall Policy.

### Example 2
```powershell
New-AzFirewallPolicySnat -PrivateRange @("3.3.0.0/24", "98.0.0.0/8","10.227.16.0/20")
```

```output
PrivateRange	            : ["3.3.0.0/24", "98.0.0.0/8","10.227.16.0/20"]	
	 AutoLearnPrivateRanges	    : Disabled
```

This example configures private IP addresses/IP ranges to which traffic will not be SNATed and disables auto learn of private ip ranges in Firewall Policy.

## PARAMETERS

### -AutoLearnPrivateRange
Enable/disable auto learn private ranges.
By default it is disabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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

### -PrivateRange
The Private IP Range

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPolicySNAT

## NOTES

## RELATED LINKS

[New-AzFireWallPolicy](./New-AzFireWallPolicy.md)

[Set-AzFireWallPolicy](./Set-AzFireWallPolicy.md)
