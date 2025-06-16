---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-azpurviewazuredataexplorermsiscanobject
schema: 2.0.0
---

# New-AzPurviewAzureDataExplorerMsiScanObject

## SYNOPSIS
Create an in-memory object for AzureDataExplorerMsiScan.

## SYNTAX

```
New-AzPurviewAzureDataExplorerMsiScanObject [-CollectionReferenceName <String>] [-CollectionType <String>]
 [-ConnectedViaReferenceName <String>] [-Database <String>] [-ScanRulesetName <String>]
 [-ScanRulesetType <String>] [-Worker <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureDataExplorerMsiScan.

## EXAMPLES

### Example 1: Create Azure Data Explorer Msi scan object
```powershell
New-AzPurviewAzureDataExplorerMsiScanObject -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -ScanRulesetName 'AzureDataExplorer' -ScanRulesetType 'System'
```

```output
CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
Database                  :
Id                        :
Kind                      : AzureDataExplorerMsi
LastModifiedAt            :
Name                      :
Result                    :
ScanRulesetName           : AzureDataExplorer
ScanRulesetType           : System
Worker                    :
```

Create Azure Data Explorer Credential scan object

## PARAMETERS

### -CollectionReferenceName


```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CollectionType


```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectedViaReferenceName


```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Database


```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScanRulesetName


```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScanRulesetType


```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Worker


```yaml
Type: System.Int32
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.AzureDataExplorerMsiScan

## NOTES

## RELATED LINKS

