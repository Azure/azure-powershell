---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/test-azkeyvaultmanagedhsmekmconnection
schema: 2.0.0
---

# Test-AzKeyVaultManagedHsmEkmConnection

## SYNOPSIS
Checks connectivity and authentication between a Managed HSM and its EKM proxy. (Preview)

## SYNTAX

### ByHsmName (Default)
```
Test-AzKeyVaultEkmConnection [-HsmName] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByHsmId
```
Test-AzKeyVaultEkmConnection [-HsmId] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByInputObject
```
Test-AzKeyVaultEkmConnection [-HsmObject] <PSManagedHsm> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Test-AzKeyVaultEkmConnection** cmdlet validates connectivity and authentication between a Managed HSM and its configured External Key Manager (EKM) proxy, and returns metadata reported by the proxy. This feature is in preview.

## EXAMPLES

### Example 1: Check the EKM connection on a Managed HSM
```powershell
Test-AzKeyVaultEkmConnection -HsmName testmhsm
```

This cmdlet probes the EKM connection on the Managed HSM named `testmhsm` and returns the EKM vendor and product information reported by the proxy.

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

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultEkmProxyInfo

## NOTES

## RELATED LINKS

[Get-AzKeyVaultEkmConnection](./Get-AzKeyVaultEkmConnection.md)

[New-AzKeyVaultEkmConnection](./New-AzKeyVaultEkmConnection.md)
