---
external help file: Microsoft.Azure.Commands.AnalysisServices.dll-Help.xml
Module Name: AzureRM.AnalysisServices
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.analysisservices/new-azurermanalysisservicesfirewallconfig
schema: 2.0.0
---

# New-AzureRmAnalysisServicesFirewallConfig

## SYNOPSIS
Creates a new Analysis Services firewall config 

## SYNTAX

```
New-AzureRmAnalysisServicesFirewallConfig [-EnablePowerBIService] <Boolean> [-FirewallRules] <list of firewall rule> 
```

## DESCRIPTION
The New-AzureRmAnalysisServicesFirewallConfig creates a new firewall config object

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmAnalysisServicesFirewallConfig -EnablePowerBIService $False -FirewallRules $TheFirewallRules
```

Creates a firewall rule config without enabling power bi service.

## PARAMETERS

### -EnablePowerBIService
A flag to indicate if enable PowerBI service

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FirewallRules
A list of firewall rules

```yaml
Type: List<Microsoft.Azure.Commands.AnalysisServices.Models.AzureAnalysisServicesFirewallRule>
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.AnalysisServices.Models.AzureAnalysisServicesFirewallConfig

## RELATED LINKS

[New-AzureRmAnalysisServicesFirewallConfig](./New-AzureRmAnalysisServicesFirewallConfig.md)