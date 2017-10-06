---
external help file: Microsoft.Azure.Commands.EventHub.dll-Help.xml
Module Name: AzureRM.EventHub
online version: 
schema: 2.0.0
---

# Set-AzureRmEventHubDRConfigurationsBreakPairing

## SYNOPSIS
This operation disables the Disaster Recovery and stops replicating changes from primary to secondary namespaces

## SYNTAX

```
Set-AzureRmEventHubDRConfigurationsBreakPairing [-ResourceGroupName] <String> [-Namespace] <String>
 [-Name] <String>
```

## DESCRIPTION
The **Set-AzureRmEventHubDRConfigurationsBreakPairing** cmdlet disables the Disaster Recovery and stops replicating changes from primary to secondary namespaces

## EXAMPLES

### Example 1
```
PS C:\> Set-AzureRmEventHubDRConfigurationsBreakPairing -ResourceGroupName "SampleResourceGroup" -Namespace "SampleNamespace_Primary" -Name "SampleDRCongifName"
```

This operation disables the Disaster Recovery and stops replicating changes from primary to secondary namespaces

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
Namespace Name - Primary Namespace

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

