---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-azpurviewadlsgen2msiscanobject
schema: 2.0.0
---

# New-AzPurviewAdlsGen2MsiScanObject

## SYNOPSIS
Create an in-memory object for AdlsGen2MsiScan.

## SYNTAX

```
New-AzPurviewAdlsGen2MsiScanObject [-CollectionReferenceName <String>] [-CollectionType <String>]
 [-ConnectedViaReferenceName <String>] [-ScanRulesetName <String>] [-ScanRulesetType <String>]
 [-Worker <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AdlsGen2MsiScan.

## EXAMPLES

### Example 1: Create AdlsGen2 Msi scan object
```powershell
New-AzPurviewAdlsGen2MsiScanObject -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -ScanRulesetName 'AdlsGen2' -ScanRulesetType 'System'
```

```output
CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
Id                        :
Kind                      : AdlsGen2Msi
LastModifiedAt            :
Name                      :
Result                    :
ScanRulesetName           : AdlsGen2
ScanRulesetType           : System
Worker                    :
```

Create AdlsGen2 Msi scan object

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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.AdlsGen2MsiScan

## NOTES

## RELATED LINKS
