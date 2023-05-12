---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.MachineLearningServices/new-AzMLWorkspaceDatabricksObject
schema: 2.0.0
---

# New-AzMLWorkspaceDatabricksObject

## SYNOPSIS
Create an in-memory object for Databricks.

## SYNTAX

```
New-AzMLWorkspaceDatabricksObject [-AccessToken <String>] [-Description <String>]
 [-DisableLocalAuth <Boolean>] [-ResourceId <String>] [-WorkspaceUrl <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Databricks.

## EXAMPLES

### Example 1: Create an in-memory object for Databricks
```powershell
New-AzMLWorkspaceDatabricksObject
```

```output
New-AzMLWorkspaceDatabricksObject
```

Create an in-memory object for Databricks

## PARAMETERS

### -AccessToken
Databricks access token.

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

### -Description
The description of the Machine Learning compute.

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

### -DisableLocalAuth
Opt-out of local authentication and ensure customers can use only MSI and AAD exclusively for authentication.

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

### -ResourceId
ARM resource id of the underlying compute.

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

### -WorkspaceUrl
Workspace Url.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.Databricks

## NOTES

ALIASES

## RELATED LINKS

