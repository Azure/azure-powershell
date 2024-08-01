---
external help file: Az.MachineLearningServices-help.xml
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/Az.MachineLearningServices/new-AzMLWorkspaceIdAssetReferenceObject
schema: 2.0.0
---

# New-AzMLWorkspaceIdAssetReferenceObject

## SYNOPSIS
Create an in-memory object for IdAssetReference.

## SYNTAX

```
New-AzMLWorkspaceIdAssetReferenceObject -AssetId <String> -ReferenceType <ReferenceType>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for IdAssetReference.

## EXAMPLES

### Example 1: Create model reference
```powershell
$model = Get-AzMLWorkspaceModelVersion -ResourceGroupName group-test -WorkspaceName mlworkspace-test -Version 1 -Name model1
New-AzMLWorkspaceIdAssetReferenceObject -AssetId $model.Id -ReferenceType 'Id'
```

```output
ReferenceType AssetId
------------- -------
Id            /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test/models/model1
```

This command creates model reference object.

## PARAMETERS

### -AssetId
[Required] ARM resource ID of the asset.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReferenceType
[Required] Specifies the type of asset reference.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ReferenceType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IdAssetReference

## NOTES

## RELATED LINKS
