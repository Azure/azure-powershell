---
external help file:
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserenvironmenttype
schema: 2.0.0
---

# Get-AzDevCenterUserEnvironmentType

## SYNOPSIS
Lists all environment types configured for a project.

## SYNTAX

### List (Default)
```
Get-AzDevCenterUserEnvironmentType -Endpoint <String> -ProjectName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListByDevCenter
```
Get-AzDevCenterUserEnvironmentType -DevCenter <String> -ProjectName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists all environment types configured for a project.

## EXAMPLES

### Example 1: List environment types by endpoint and project
```powershell
Get-AzDevCenterUserEnvironmentType -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject
```

This command lists environment types under the project "DevProject".

### Example 2: List environment types by dev center and project
```powershell
Get-AzDevCenterUserEnvironmentType -DevCenter Contoso -ProjectName DevProject
```

This command lists environment types under the project "DevProject".

## PARAMETERS

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

### -DevCenter
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: ListByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
The DevCenter-specific URI to operate on.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
The DevCenter Project upon which to execute operations.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20230401.IEnvironmentType

## NOTES

ALIASES

## RELATED LINKS

