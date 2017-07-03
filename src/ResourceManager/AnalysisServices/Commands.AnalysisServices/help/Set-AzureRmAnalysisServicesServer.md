---
external help file: Microsoft.Azure.Commands.AnalysisServices.dll-Help.xml
online version:
schema: 2.0.0
---

# Set-AzureRmAnalysisServicesServer

## SYNOPSIS
Modifies  an instance of Analysis Services server

## SYNTAX

```
Set-AzureRmAnalysisServicesServer [-Name] <String> [[-ResourceGroupName] <String>] [[-Sku] <String>]
 [[-Tag] <Hashtable>] [[-Administrator] <String>] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Set-AzureRmAnalysisServicesServer cmdlet modifies an instance of Analysis Services server

## EXAMPLES

### Example 1
```
PS C:\> Set-AzureRmAnalysisServicesServer -Name "testserver" -ResourceGroupName "testgroup" -Tag @{key0="value0";key1=$null;key2="value2"} -Administrator "testuser1@contoso.com"
```

Modifies the server named testserver in resourcegroup testgroup to set the tags as key1:value1 and key2:value2 and administrator to testuser1@contoso.com

## PARAMETERS

### -Administrator
A string representing a comma separated list of users or groups to be set as administrators on the server.
The users or groups need to be specified UPN format, for example: user@contoso.com or groups@contoso.com

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -Sku
The name of the Sku for the server.
The supported values are 'S0', 'S1', 'S2', 'S4' for the Standard tier; 'B1', 'B2' for the Basic tier and 'D1' for Development tier.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: S1, S2, S4, B1, B2, D1

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Key-value pairs in the form of a hash table. For example:

@{key0="value0";key1=$null;key2="value2"}

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Management.Analysis.Models.AnalysisServicesServer

## NOTES
Alias: Set-AzureAs

## RELATED LINKS

[Get-AzureRmAnalysisServicesServer](./Get-AzureRmAnalysisServicesServer.md)

[Remove-AzureRmAnalysisServicesServer](./Remove-AzureRmAnalysisServicesServer.md)
