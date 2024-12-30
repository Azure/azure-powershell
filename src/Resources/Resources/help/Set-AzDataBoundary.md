---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/set-azdataboundary
schema: 2.0.0
---

# Set-AzDataBoundary

## SYNOPSIS
Opt-in tenant to data boundary.

## SYNTAX

### PutExpanded (Default)
```
Set-AzDataBoundary [-DataBoundary <String>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Put
```
Set-AzDataBoundary -DataBoundaryDefinition <IDataBoundaryDefinition> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PutViaJsonFilePath
```
Set-AzDataBoundary -JsonFilePath <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PutViaJsonString
```
Set-AzDataBoundary -JsonString <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Opt-in tenant to data boundary.

## EXAMPLES

### Example 1: Set Tenant Level Data Boundary
```powershell
$dataBoundary = "EU"
Set-AzDataBoundary -DataBoundary $dataBoundary
```

```output
Name                                    Id                                                                                      Properties 
--------                                ----                                                                                    ------------
00000000-0000-0000-0000-000000000000    /providers/Microsoft.Resources/dataBoundaries/00000000-0000-0000-0000-000000000000      dataBoundary: EU, provisioningState: Created
```

Sets the dataBoundary at the tenant level.

## PARAMETERS

### -DataBoundary
The data boundary definition.

```yaml
Type: System.String
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataBoundaryDefinition
A data boundary definition.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoundary.Models.IDataBoundaryDefinition
Parameter Sets: Put
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Put operation

```yaml
Type: System.String
Parameter Sets: PutViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Put operation

```yaml
Type: System.String
Parameter Sets: PutViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBoundary.Models.IDataBoundaryDefinition

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBoundary.Models.IDataBoundaryDefinition

## NOTES

## RELATED LINKS
