---
external help file: Microsoft.Azure.Commands.EventHub.dll-Help.xml
Module Name: AzureRM.EventHub
online version: 
schema: 2.0.0
---

# Set-AzureRmEventHubDRConfigurationsFailOver

## SYNOPSIS
envokes GEO DR failover and reconfigure the alias to point to the secondary namespace

## SYNTAX

```
Set-AzureRmEventHubDRConfigurationsFailOver [-ResourceGroupName] <String> [-Namespace] <String>
 [-Name] <String>
```

## DESCRIPTION
The **Set-AzureRmEventHubDRConfigurationsFailOver** cmdlet envokes GEO DR failover and reconfigure the alias to point to the secondary namespace

## EXAMPLES

### Example 1
```
PS C:\>Set-AzureRmEventHubDRConfigurationsFailOver -ResourceGroupName "SampleResourceGroup" -Namespace "SampleNamespace_Secondary" -Name "SampleDRCongifName"
```

Envokes the Failover over alias "SampleDRCongifName", reconfigures and point to Secondary namespace "SampleNamespace_Secondary"

## PARAMETERS

### -Name
DR Configuration Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Namespace
Namespace Name - Secondary Namespace

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

