---
external help file: Microsoft.Azure.Commands.AzureBackup.dll-Help.xml
Module Name: AzureRM.Backup
ms.assetid: 698DCD00-13C0-4C36-A74B-35215D608339
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.backup/remove-azurermbackupvault
schema: 2.0.0
---

# Remove-AzureRmBackupVault

## SYNOPSIS
Deletes a Backup vault.

## SYNTAX

```
Remove-AzureRmBackupVault [-Force] [-Vault] <AzureRMBackupVault> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmBackupVault** cmdlet deletes an Azure Backup vault.

Before you can delete a Backup vault, it must be empty.
Use the **Remove-AzureRmBackupContainer** cmdlet to remove infrastructure as a service (IaaS) virtual machine backup data from the vault.
Use the **Delete-RegisteredServer** cmdlet to remove other registered servers and backup data.

## EXAMPLES

### Example 1: Delete an Azure Backup vault
```
PS C:\>Get-AzureRmBackupVault -Name "Vault03" | Remove-AzureRmBackupVault
```

This command gets the Azure Backup vault named Vault03 by using the **Get-AzureRmBackupVault** cmdlet.
The command passes that vault to the current cmdlet by using the pipeline operator.
The current cmdlet removes the vault.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Vault
Specifies a Backup vault that this cmdlet removes.
To obtain an **AzureRmBackupVault**, use the Get-AzureRmBackupVault cmdlet.

```yaml
Type: AzureRMBackupVault
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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

### AzureRMBackupVault

## OUTPUTS

### None

## NOTES
* None

## RELATED LINKS

[Get-AzureRmBackupVault](./Get-AzureRmBackupVault.md)

[New-AzureRmBackupVault](./New-AzureRmBackupVault.md)

[Set-AzureRmBackupVault](./Set-AzureRmBackupVault.md)


