---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/get-azkeyvaultekmconnectioncertificate
schema: 2.0.0
---

# Get-AzKeyVaultEkmConnectionCertificate

## SYNOPSIS
Gets the EKM proxy client certificate information from a Managed HSM. (Preview)

## SYNTAX

### ByHsmName (Default)
```
Get-AzKeyVaultEkmConnectionCertificate [-HsmName] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByHsmId
```
Get-AzKeyVaultEkmConnectionCertificate [-HsmId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByInputObject
```
Get-AzKeyVaultEkmConnectionCertificate [-HsmObject] <PSManagedHsm> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzKeyVaultEkmConnectionCertificate** cmdlet gets the EKM proxy client certificate information (subject common name and CA certificates) from a Managed HSM. This feature is in preview.

## EXAMPLES

### Example 1: Get the EKM proxy client certificate from a Managed HSM
```powershell
Get-AzKeyVaultEkmConnectionCertificate -HsmName testmhsm
```

This cmdlet gets the EKM proxy client certificate information from the Managed HSM named `testmhsm`.

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

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultEkmConnectionCertificate

## NOTES

## RELATED LINKS

[Get-AzKeyVaultEkmConnection](./Get-AzKeyVaultEkmConnection.md)
