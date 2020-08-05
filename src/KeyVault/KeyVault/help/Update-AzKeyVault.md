---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/update-azkeyvault
schema: 2.0.0
---

# Update-AzKeyVault

## SYNOPSIS
Update the state of an Azure key vault.

## SYNTAX

### UpdateKeyVaultByNameParameterSet (Default)
```
Update-AzKeyVault -ResourceGroupName <String> -VaultName <String> [-EnableSoftDelete] [-EnablePurgeProtection]
 [-SoftDeleteRetentionInDays <Int32>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateManagedHsmByNameParameterSet
```
Update-AzKeyVault -ResourceGroupName <String> -VaultName <String> [-SoftDeleteRetentionInDays <Int32>] [-Hsm]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateKeyVaultByInputObjectParameterSet
```
Update-AzKeyVault -InputObject <PSKeyVaultIdentityItem> [-EnableSoftDelete] [-EnablePurgeProtection]
 [-SoftDeleteRetentionInDays <Int32>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateManagedHsmByInputObjectParameterSet
```
Update-AzKeyVault -InputObject <PSKeyVaultIdentityItem> [-SoftDeleteRetentionInDays <Int32>] [-Hsm]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateKeyVaultUByResourceIdParameterSet
```
Update-AzKeyVault -ResourceId <String> [-EnableSoftDelete] [-EnablePurgeProtection]
 [-SoftDeleteRetentionInDays <Int32>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateManagedHsmUByResourceIdParameterSet
```
Update-AzKeyVault -ResourceId <String> [-SoftDeleteRetentionInDays <Int32>] [-Hsm]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet updates the state of an Azure key vault.
Please note updating some of the properties is an irreversible action, for example once soft delete has been enabled, it cannot be disabled anymore.

## EXAMPLES

### Example 1
```powershell
PS C:\> Update-AzKeyVault -VaultName $keyVaultName -ResourceGroupName $resourceGroupName -EnableSoftDelete
```

Enables soft delete on the key vault named `$keyVaultName` in resource group `$resourceGroupName`.

### Example 1
```powershell
PS C:\> Get-AzKeyVault -VaultName $keyVaultName -ResourceGroupName $resourceGroupName | Update-AzKeyVault -EnablePurgeProtection
```

Enables purge protection using piping syntax.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnablePurgeProtection
Enable the purge protection functionality for this key vault.
Once enabled it cannot be disabled.
It requires soft-delete to be turned on.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateKeyVaultByNameParameterSet, UpdateKeyVaultByInputObjectParameterSet, UpdateKeyVaultUByResourceIdParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableSoftDelete
Enable the soft-delete functionality for this key vault.
Once enabled it cannot be disabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateKeyVaultByNameParameterSet, UpdateKeyVaultByInputObjectParameterSet, UpdateKeyVaultUByResourceIdParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Hsm
Specifies the type of this vault as MHSM.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateManagedHsmByNameParameterSet, UpdateManagedHsmByInputObjectParameterSet, UpdateManagedHsmUByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Key vault object.

```yaml
Type: Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultIdentityItem
Parameter Sets: UpdateKeyVaultByInputObjectParameterSet, UpdateManagedHsmByInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: UpdateKeyVaultByNameParameterSet, UpdateManagedHsmByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Resource ID of the key vault.

```yaml
Type: System.String
Parameter Sets: UpdateKeyVaultUByResourceIdParameterSet, UpdateManagedHsmUByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SoftDeleteRetentionInDays
Specifies how long deleted resources are retained, and how long until a vault or an object in the deleted state can be purged. The default is 90 days.

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

### -VaultName
Name of the key vault.

```yaml
Type: System.String
Parameter Sets: UpdateKeyVaultByNameParameterSet, UpdateManagedHsmByNameParameterSet
Aliases: Name

Required: True
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

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVault

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVault

## NOTES

## RELATED LINKS
