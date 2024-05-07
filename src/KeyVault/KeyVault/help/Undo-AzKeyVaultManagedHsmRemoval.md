---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/undo-azkeyvaultmanagedhsmremoval
schema: 2.0.0
---

# Undo-AzKeyVaultManagedHsmRemoval

## SYNOPSIS
Recover a managed HSM.

## SYNTAX

### Default (Default)
```
Undo-AzKeyVaultManagedHsmRemoval [-Name] <String> [-ResourceGroupName] <String> [-Location] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-SubscriptionId <String>] [<CommonParameters>]
```

### InputObject
```
Undo-AzKeyVaultManagedHsmRemoval [-InputObject] <PSDeletedManagedHsm>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Recover a previously deleted HSM for which soft delete was enabled.

## EXAMPLES

### Example 1: Recover a deleted HSM
```powershell
Undo-AzKeyVaultManagedHsmRemoval -Name test001 -ResourceGroupName test-rg -Location westus
```

```output
Name   Resource Group Name Location SKU        ProvisioningState
----   ------------------- -------- ---        -----------------
test001 test-rg              West US  StandardB1 Succeeded
```

This command recovers a managed HSM called `test001` from deleted state.

### Example 2: Recover a deleted HSM by piping
```powershell
Get-AzKeyVaultManagedHsm -Name test001 -Location westus -InRemovedState | Undo-AzKeyVaultManagedHsmRemoval
```

```output
Name   Resource Group Name Location SKU        ProvisioningState
----   ------------------- -------- ---        -----------------
test001 test-rg              West US  StandardB1 Succeeded
```

This command recovers a managed HSM called `test001` from deleted state by piping.

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

### -InputObject
Deleted HSM object

```yaml
Type: Microsoft.Azure.Commands.KeyVault.Models.PSDeletedManagedHsm
Parameter Sets: InputObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Specifies the deleted HSM original Azure region.

```yaml
Type: System.String
Parameter Sets: Default
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
HSM name.
Cmdlet constructs the FQDN of a managed HSM based on the name and currently selected environment.

```yaml
Type: System.String
Parameter Sets: Default
Aliases: HsmName

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the deleted HSM resource group.

```yaml
Type: System.String
Parameter Sets: Default
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the subscription.

By default, cmdlets are executed in the subscription that is set in the current context.
If the user specifies another subscription, the current cmdlet is executed in the subscription specified by the user.

Overriding subscriptions only take effect during the lifecycle of the current cmdlet.
It does not change the subscription in the context, and does not affect subsequent cmdlets.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
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

### Microsoft.Azure.Commands.KeyVault.Models.PSDeletedManagedHsm

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm

## NOTES

## RELATED LINKS

[New-AzKeyVaultManagedHsm](./New-AzKeyVaultManagedHsm.md)

[Get-AzKeyVaultManagedHsm](./Get-AzKeyVaultManagedHsm.md)

[Remove-AzKeyVaultManagedHsm](./Remove-AzKeyVaultManagedHsm.md)

[Update-AzKeyVaultManagedHsm](./Update-AzKeyVaultManagedHsm.md)
