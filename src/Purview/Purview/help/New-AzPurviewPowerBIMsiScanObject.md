---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-azpurviewpowerbimsiscanobject
schema: 2.0.0
---

# New-AzPurviewPowerBIMsiScanObject

## SYNOPSIS
Create an in-memory object for PowerBIMsiScan.

## SYNTAX

```
New-AzPurviewPowerBIMsiScanObject [-CollectionReferenceName <String>] [-CollectionType <String>]
 [-ConnectedViaReferenceName <String>] [-IncludePersonalWorkspace <Boolean>] [-ScanRulesetName <String>]
 [-ScanRulesetType <String>] [-Worker <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PowerBIMsiScan.

## EXAMPLES

### Example 1: Create PowerBI delegated scan object
```powershell
New-AzPurviewPowerBIMsiScanObject -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -IncludePersonalWorkspace $true
```

```output
CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
Id                        :
IncludePersonalWorkspace  : True
Kind                      : PowerBIMsi
LastModifiedAt            :
Name                      :
Result                    :
ScanRulesetName           :
ScanRulesetType           :
Worker                    :
```

Create PowerBI delegated scan object

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

### -IncludePersonalWorkspace

```yaml
Type: System.Boolean
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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.PowerBiMsiScan

## NOTES

## RELATED LINKS
