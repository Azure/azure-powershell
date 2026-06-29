---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/remove-azkeyvaultmanagedhsmekmconnection
schema: 2.0.0
---

# Remove-AzKeyVaultManagedHsmEkmConnection

## SYNOPSIS
Deletes the External Key Manager (EKM) connection from a Managed HSM. (Preview)

## SYNTAX

### ByHsmName (Default)
```
Remove-AzKeyVaultEkmConnection [-HsmName] <String> [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByHsmId
```
Remove-AzKeyVaultEkmConnection [-HsmId] <String> [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByInputObject
```
Remove-AzKeyVaultEkmConnection [-HsmObject] <PSManagedHsm> [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzKeyVaultEkmConnection** cmdlet deletes the External Key Manager (EKM) connection from a Managed HSM. This feature is in preview.

## EXAMPLES

### Example 1: Delete the EKM connection on a Managed HSM
```powershell
Remove-AzKeyVaultEkmConnection -HsmName testmhsm
```

This cmdlet deletes the EKM connection from the Managed HSM named `testmhsm`.

### Example 2: Delete the EKM connection and return the deleted object
```powershell
Remove-AzKeyVaultEkmConnection -HsmName testmhsm -PassThru
```

This cmdlet deletes the EKM connection from the Managed HSM named `testmhsm` and returns the deleted connection.

## PARAMETERS

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

### -HsmId
Resource Id of the HSM.

```yaml
Type: System.String
Parameter Sets: ByHsmId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HsmName
Name of the HSM.

```yaml
Type: System.String
Parameter Sets: ByHsmName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HsmObject
HSM object.

```yaml
Type: Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Cmdlet does not return an object by default. If this switch is specified, the deleted EKM connection is returned.

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

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultEkmConnection

## NOTES

## RELATED LINKS

[Get-AzKeyVaultEkmConnection](./Get-AzKeyVaultEkmConnection.md)

[New-AzKeyVaultEkmConnection](./New-AzKeyVaultEkmConnection.md)
