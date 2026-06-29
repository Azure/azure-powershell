---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/get-azkeyvaultmanagedhsmekmconnection
schema: 2.0.0
---

# Get-AzKeyVaultManagedHsmEkmConnection

## SYNOPSIS
Gets the External Key Manager (EKM) connection configured on a Managed HSM. (Preview)

## SYNTAX

### ByHsmName (Default)
```
Get-AzKeyVaultManagedHsmEkmConnection [-HsmName] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByHsmId
```
Get-AzKeyVaultManagedHsmEkmConnection [-HsmId] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByInputObject
```
Get-AzKeyVaultManagedHsmEkmConnection [-HsmObject] <PSManagedHsm> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzKeyVaultManagedHsmEkmConnection** cmdlet gets the External Key Manager (EKM) connection currently configured on a Managed HSM. This feature is in preview.

## EXAMPLES

### Example 1: Get the EKM connection on a Managed HSM
```powershell
Get-AzKeyVaultManagedHsmEkmConnection -HsmName testmhsm
```

This cmdlet gets the EKM connection configured on the Managed HSM named `testmhsm`.

### Example 2: Get the EKM connection by piping the HSM object
```powershell
Get-AzKeyVaultManagedHsm -Name testmhsm | Get-AzKeyVaultManagedHsmEkmConnection
```

This cmdlet gets the EKM connection on the Managed HSM named `testmhsm` by piping the HSM object.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultEkmConnection

## NOTES

## RELATED LINKS

[New-AzKeyVaultManagedHsmEkmConnection](./New-AzKeyVaultManagedHsmEkmConnection.md)

[Update-AzKeyVaultManagedHsmEkmConnection](./Update-AzKeyVaultManagedHsmEkmConnection.md)

[Remove-AzKeyVaultManagedHsmEkmConnection](./Remove-AzKeyVaultManagedHsmEkmConnection.md)

[Test-AzKeyVaultManagedHsmEkmConnection](./Test-AzKeyVaultManagedHsmEkmConnection.md)
