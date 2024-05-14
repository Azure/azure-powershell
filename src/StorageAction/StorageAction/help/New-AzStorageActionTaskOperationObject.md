---
external help file: Az.StorageAction-help.xml
Module Name: Az.StorageAction
online version: https://learn.microsoft.com/powershell/module/Az.StorageAction/new-azstorageactiontaskoperationobject
schema: 2.0.0
---

# New-AzStorageActionTaskOperationObject

## SYNOPSIS
Create an in-memory object for StorageTaskOperation.

## SYNTAX

```
New-AzStorageActionTaskOperationObject -Name <String> [-OnFailure <String>] [-OnSuccess <String>]
 [-Parameter <IStorageTaskOperationParameters>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StorageTaskOperation.

## EXAMPLES

### Example 1: Create a operation object
```powershell
New-AzStorageActionTaskOperationObject -Name SetBlobTier -Parameter @{"tier"= "Hot"} -OnFailure break -OnSuccess continue | Format-List
```

```output
Name      : SetBlobTier
OnFailure : break
OnSuccess : continue
Parameter : {
              "tier": "Hot"
            }
```

This command creates a operation object.

## PARAMETERS

### -Name
The operation to be performed on the object.

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

### -OnFailure
Action to be taken when the operation fails for a object.

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

### -OnSuccess
Action to be taken when the operation is successful for a object.

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

### -Parameter
Key-value parameters for the operation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTaskOperationParameters
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.StorageTaskOperation

## NOTES

## RELATED LINKS
