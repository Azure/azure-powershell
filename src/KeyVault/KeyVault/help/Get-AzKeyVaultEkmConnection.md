---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/get-azkeyvaultekmconnection
schema: 2.0.0
---

# Get-AzKeyVaultEkmConnection

## SYNOPSIS
Gets the External Key Manager (EKM) connection configured on a Managed HSM. (Preview)

## SYNTAX

### ByHsmName (Default)
```
Get-AzKeyVaultEkmConnection [-HsmName] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByHsmId
```
Get-AzKeyVaultEkmConnection [-HsmId] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByInputObject
```
Get-AzKeyVaultEkmConnection [-HsmObject] <PSManagedHsm> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzKeyVaultEkmConnection** cmdlet gets the External Key Manager (EKM) connection currently configured on a Managed HSM. This feature is in preview.

## EXAMPLES

### Example 1: Get the EKM connection on a Managed HSM
```powershell
Get-AzKeyVaultEkmConnection -HsmName testmhsm
```

This cmdlet gets the EKM connection configured on the Managed HSM named `testmhsm`.

### Example 2: Get the EKM connection by piping the HSM object
```powershell
Get-AzKeyVaultManagedHsm -Name testmhsm | Get-AzKeyVaultEkmConnection
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

[New-AzKeyVaultEkmConnection](./New-AzKeyVaultEkmConnection.md)

[Update-AzKeyVaultEkmConnection](./Update-AzKeyVaultEkmConnection.md)

[Remove-AzKeyVaultEkmConnection](./Remove-AzKeyVaultEkmConnection.md)

[Test-AzKeyVaultEkmConnection](./Test-AzKeyVaultEkmConnection.md)
