---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CodeSigning.dll-Help.xml
Module Name: Az.CodeSigning
ms.assetid: 846F781C-73A3-4BBE-ABD9-897371109FBE
online version: https://learn.microsoft.com/powershell/module/az.codesigning/submit-azcodesigningcipolicysigning
schema: 2.0.0
---

# Submit-AzCodeSigningCIPolicySigning

## SYNOPSIS
Submit CI Policy signing to Azure.CodeSigning

## SYNTAX

### InteractiveSubmit (Default)
```
Add-AzKeyVaultKey [-VaultName] <String> [-Name] <String> -Destination <String> [-Disable] [-KeyOps <String[]>]
 [-Expires <DateTime>] [-NotBefore <DateTime>] [-Tag <Hashtable>] [-Size <Int32>] [-KeyType <String>]
 [-Exportable] [-Immutable] [-ReleasePolicyPath <String>] [-UseDefaultCVMPolicy]
 [-CurveName <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```


## DESCRIPTION
The **Add-AzKeyVaultKey** cmdlet creates a key in a key vault in Azure Key Vault, or imports a key into a key vault.
Use this cmdlet to add keys by using any of the following methods:
- Create a key in a hardware security module (HSM) in the Key Vault service.
- Create a key in software in the Key Vault service.
- Import a key from your own hardware security module (HSM) to HSMs in the Key Vault service.
- Import a key from a .pfx file on your computer.
- Import a key from a .pfx file on your computer to hardware security modules (HSMs) in the Key Vault service.
For any of these operations, you can provide key attributes or accept default settings.
If you create or import a key that has the same name as an existing key in your key vault, the
original key is updated with the values that you specify for the new key. You can access the
previous values by using the version-specific URI for that version of the key. To learn about key
versions and the URI structure, see [About Keys and Secrets](http://go.microsoft.com/fwlink/?linkid=518560)
in the Key Vault REST API documentation.
Note: To import a key from your own hardware security module, you must first generate a BYOK
package (a file with a .byok file name extension) by using the Azure Key Vault BYOK toolset. For
more information, see
[How to Generate and Transfer HSM-Protected Keys for Azure Key Vault](http://go.microsoft.com/fwlink/?LinkId=522252).
As a best practice, back up your key after it is created or updated, by using the
Backup-AzKeyVaultKey cmdlet. There is no undelete functionality, so if you accidentally delete
your key or delete it and then change your mind, the key is not recoverable unless you have a
backup of it that you can restore.

## EXAMPLES

### Example 1: Create a key
```powershell
Add-AzKeyVaultKey -VaultName 'contoso' -Name 'ITSoftware' -Destination 'Software'
```

```output
Vault/HSM Name : contoso
Name           : ITSoftware
Key Type       : RSA
Key Size       : 2048
Curve Name     : 
Version        : 67da57e9cadf48a2ad8d366b115843ab
Id             : https://contoso.vault.azure.net:443/keys/ITSoftware/67da57e9cadf48a2ad8d366b115843ab
Enabled        : True
Expires        :
Not Before     :
Created        : 5/21/2018 11:10:58 PM
Updated        : 5/21/2018 11:10:58 PM
Purge Disabled : False
Tags           :
```

This command creates a software-protected key named ITSoftware in the key vault named Contoso.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

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

### -Destination
Specifies whether to add the key as a software-protected key or an HSM-protected key in the Key Vault service.
Valid values are: HSM and Software.
Note: To use HSM as your destination, you must have a key vault that supports HSMs. For more
information about the service tiers and capabilities for Azure Key Vault, see the
[Azure Key Vault Pricing website](http://go.microsoft.com/fwlink/?linkid=512521).
This parameter is required when you create a new key. If you import a key by using the
*KeyFilePath* parameter, this parameter is optional:
- If you do not specify this parameter, and this cmdlet imports a key that has .byok file name
extension, it imports that key as an HSM-protected key. The cmdlet cannot import that key as
software-protected key.
- If you do not specify this parameter, and this cmdlet imports a key that has a .pfx file name
extension, it imports the key as a software-protected key.

```yaml
Type: System.String
Parameter Sets: InteractiveCreate, InputObjectCreate, ResourceIdCreate
Aliases:
Accepted values: HSM, Software

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: InteractiveImport, InputObjectImport, ResourceIdImport
Aliases:
Accepted values: HSM, Software

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Disable
Indicates that the key you are adding is set to an initial state of disabled. Any attempt to use
the key will fail. Use this parameter if you are preloading keys that you intend to enable later.

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

### -Expires
Specifies the expiration time, as a **DateTime** object, for the key that this cmdlet adds. This
parameter uses Coordinated Universal Time (UTC). To obtain a **DateTime** object, use the
**Get-Date** cmdlet. For more information, type `Get-Help Get-Date`. If you do not specify this
parameter, the key does not expire.

```yaml
Type: System.Nullable`1[System.DateTime]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exportable
Indicates if the private key can be exported.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: InteractiveCreate, InputObjectCreate, ResourceIdCreate, HsmInteractiveCreate, HsmInputObjectCreate, HsmResourceIdCreate
Aliases:

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

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultKey

## NOTES

## RELATED LINKS

[Backup-AzKeyVaultKey](./Backup-AzKeyVaultKey.md)

[Get-AzKeyVaultKey](./Get-AzKeyVaultKey.md)

[Remove-AzKeyVaultKey](./Remove-AzKeyVaultKey.md)
