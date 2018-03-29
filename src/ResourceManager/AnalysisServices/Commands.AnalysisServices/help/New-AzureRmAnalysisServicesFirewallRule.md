---
external help file: Microsoft.Azure.Commands.AnalysisServices.dll-Help.xml
Module Name: AzureRM.AnalysisServices
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.analysisservices/new-azurermanalysisservicesfirewallrule
schema: 2.0.0
---

# New-AzureRmAnalysisServicesFirewallRule

## SYNOPSIS
Creates a new Analysis Services firewall rule

## SYNTAX

```
New-AzureRmAnalysisServicesFirewallRule [-FirewallRuleName] <String> [-RangeStart] <String> [-RangeEnd] <String>
```

## DESCRIPTION
The New-AzureRmAnalysisServicesFirewallRule creates a new firewall rule object.

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmAnalysisServicesFirewallRule -FirewallRuleName rule1 -RangeStart 0.0.0.0 -RangeEnd 255.255.255.255
```

Creates a firewall rule named rule1 with start range 0.0.0.0 and end range 255.255.255.255

## PARAMETERS

### -FirewallRuleName
Name of firewall rule

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RangeStart
The range start of a firewall rule

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RangeEnd
The range end of a firewall rule

```yaml
Type: String
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.AnalysisServices.Models.AzureAnalysisServicesFirewallRule

## RELATED LINKS

[New-AzureRmAnalysisServicesFirewallConfig](./New-AzureRmAnalysisServicesFirewallConfig.md)