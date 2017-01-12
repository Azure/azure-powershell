---
external help file: Microsoft.Azure.Commands.AnalysisServices.dll-Help.xml
online version: 
schema: 2.0.0
---

# Suspend-AzureRmAnalysisServicesServer

## SYNOPSIS
Suspends an instance of Analysis Services server

## SYNTAX

```
Suspend-AzureRmAnalysisServicesServer [[-ResourceGroupName] <String>] [-Name] <String> [-PassThru] [-WhatIf]
 [-Confirm]
```

## DESCRIPTION
The Suspend-AzureRmAnalysisServicesServer cmdlet suspends an instance of Analysis Services server

## EXAMPLES

### Example 1
```
PS C:\> Suspend-AzureRmAnalysisServicesServer -Name "testserver" -ResourceGroupName "testgroup"
```

This command will suspend an active server named testserver in the resourcegroup testgroup

## PARAMETERS

### -Name
Name of the Analysis Services server

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

### -PassThru
Will return the deleted server details if the operation completes successfully

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Azure resource group to which the server belongs

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts user to confirm whether to perform the operation

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
Describes the actions the current operation will perform without actually performing them

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

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.AnalysisServices.Models.AzureAnalysisServicesServer

## NOTES
Alias: Suspend-AzureAs

## RELATED LINKS
[Get-AzureRmAnalysisServicesServer](./Get-AzureRmAnalysisServicesServer.md)

[Resume-AzureRmAnalysisServicesServer](./Resume-AzureRmAnalysisServicesServer.md)

