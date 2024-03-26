---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
ms.assetid: 30CC0D80-505A-4988-B4EC-3B7BC5B76F5D
online version: https://learn.microsoft.com/powershell/module/az.storage/remove-azstoragetablestoredaccesspolicy
schema: 2.0.0
---

# Remove-AzStorageTableStoredAccessPolicy

## SYNOPSIS
Removes a stored access policy from an Azure storage table.

## SYNTAX

```
Remove-AzStorageTableStoredAccessPolicy [-Table] <String> [-Policy] <String> [-PassThru]
 [-Context <IStorageContext>] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzStorageTableStoredAccessPolicy** cmdlet removes a stored access policy from an Azure storage table.

## EXAMPLES

### Example 1: Remove a stored access policy from a storage table
```powershell
Remove-AzStorageTableStoredAccessPolicy -Table "MyTable" -Policy "Policy05"
```

This command removes policy named Policy05 from storage table named MyTable.

## PARAMETERS

### -Context
Specifies an Azure storage context.
To obtain a storage context, use the New-AzStorageContext cmdlet.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Indicates that this cmdlet returns a **Boolean** that reflects the success of the operation.
By default, this cmdlet does not return a value.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Policy
Specifies the name of the stored access policy that this cmdlet removes.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -Table
Specifies the Azure table name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: N, Name

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Default value: False
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Get-AzStorageTableStoredAccessPolicy](./Get-AzStorageTableStoredAccessPolicy.md)

[New-AzStorageContext](./New-AzStorageContext.md)

[New-AzStorageTableStoredAccessPolicy](./New-AzStorageTableStoredAccessPolicy.md)

[Set-AzStorageTableStoredAccessPolicy](./Set-AzStorageTableStoredAccessPolicy.md)
