---
external help file: Microsoft.Azure.Commands.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
ms.assetid: 7A929BA8-02D9-4BBE-AFF3-B8781F8DDAD9
online version: https://docs.microsoft.com/en-us/powershell/module/Az.keyvault/remove-Azkeyvault
schema: 2.0.0
---

# Remove-AzKeyVault

## SYNOPSIS
Deletes a key vault.

## SYNTAX

### ByAvailableVault
```
Remove-AzKeyVault [-VaultName] <String> [[-ResourceGroupName] <String>] [[-Location] <String>] [-Force]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByDeletedVault
```
Remove-AzKeyVault [-VaultName] <String> [-Location] <String> [-Force] [-InRemovedState] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzKeyVault** cmdlet deletes the specified key vault.
It also deletes all keys and secrets contained in that instance.

Note that although specifying the resource group is optional for this cmdlet, you should so for better performance.

## EXAMPLES

### Example 1: Remove a key vault
```
PS C:\>Remove-AzKeyVault -VaultName "Contoso03Vault"
```

This command removes the key vault named Contoso03Vault from your current subscription.

### Example 2: Remove a key vault from a specified resource group
```
PS C:\>Remove-AzKeyVault -VaultName "Contoso03Vault" -ResourceGroupName "Group14"
```

This command removes the key vault named Contoso03Vault from the named resource group.
If you do not specify the resource group name, the cmdlet searches for the named key vault to delete in your current subscription.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Indicates that the cmdlet does not prompt you for confirmation.
By default, this cmdlet prompts you to confirm that you want to delete the key vault.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InRemovedState
Remove the previously deleted vault permanently.

```yaml
Type: SwitchParameter
Parameter Sets: ByDeletedVault
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of the deleted vault.

```yaml
Type: String
Parameter Sets: ByAvailableVault
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ByDeletedVault
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of a resource group.

```yaml
Type: String
Parameter Sets: ByAvailableVault
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VaultName
Specifies the name of the key vault to remove.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
The cmdlet is not run.Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
This cmdlet does not accept any input.

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzKeyVault](./Get-AzKeyVault.md)

[New-AzKeyVault](./New-AzKeyVault.md)
