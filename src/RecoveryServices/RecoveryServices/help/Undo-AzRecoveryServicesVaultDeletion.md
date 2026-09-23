---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/undo-azrecoveryservicesvaultdeletion
schema: 2.0.0
---

# Undo-AzRecoveryServicesVaultDeletion

## SYNOPSIS
Undeletes a soft-deleted Recovery Services vault.

## SYNTAX

```
Undo-AzRecoveryServicesVaultDeletion [-ResourceGroupName] <String> [-Name] <String> [-Location] <String>
 [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The Undo-AzRecoveryServicesVaultDeletion cmdlet undeletes a soft-deleted Recovery Services vault back to an active state. When a Recovery Services vault is deleted, it enters a soft-deleted state where it can be recovered within the retention period. This cmdlet reverses the deletion operation and makes the vault active again with all its previous configuration.

## EXAMPLES

### Example 1: Undelete a soft-deleted vault
```powershell
$sdVault = Get-AzRecoveryServicesSoftDeletedVault -Location westus | Where-Object { $_.Properties.VaultId -match "wus-vault" }
Undo-AzRecoveryServicesVaultDeletion -ResourceGroupName $sdVault.ResourceGroupName -Name $sdVault.Name -Location "westus"
```

Undeletes a soft-deleted Recovery Services vault by specifying the resource group name, vault name, and location.

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

### -Force
Forces the command to run without asking for user confirmation. When specified, the cmdlet will not prompt for confirmation before undeleting the vault.

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

### -Location
The Azure location where the soft-deleted vault is located. This must match the location where the vault was originally created and deleted.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the soft-deleted Recovery Services vault to undelete.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the vault was located before deletion.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
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

### None

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS
