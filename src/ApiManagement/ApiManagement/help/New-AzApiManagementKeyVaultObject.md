---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ApiManagement.ServiceManagement.dll-Help.xml
Module Name: Az.ApiManagement
online version: https://docs.microsoft.com/powershell/module/az.apimanagement/new-azapimanagementkeyvaultobject
schema: 2.0.0
---

# New-AzApiManagementKeyVaultObject

## SYNOPSIS
Creates an instance of PsApiManagementKeyVaultObject.

## SYNTAX

```
New-AzApiManagementKeyVaultObject -SecretIdentifier <String> [-IdentityClientId <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApiManagementKeyVaultObject** cmdlet creates an instance of PsApiManagementKeyVaultObjecte.

## EXAMPLES

### Example 1 : Create a keyVault Namedvalue
```powershell
$secretIdentifier = 'https://contoso.vault.azure.net/secrets/xxxx'
$keyvault = New-AzApiManagementKeyVaultObject -SecretIdentifier $secretIdentifier 
$keyVaultNamedValue = New-AzApiManagementNamedValue -Context $context -NamedValueId $keyVaultNamedValueId -Name $keyVaultNamedValueName -keyVault $keyvault -Secret
```

The first command creates a keyvault.
The second command creates a named value using secret from this keyvault.

### Example 2 : Create a keyVault Certificate
```powershell
$secretIdentifier = 'https://contoso.vault.azure.net/secrets/xxxx'
$keyvault = New-AzApiManagementKeyVaultObject -SecretIdentifier $secretIdentifier 
$keyVaultcert = New-AzApiManagementCertificate -Context $context -CertificateId $kvcertId -KeyVault $keyvault
```

The first command creates a keyvault.
The second command creates a certificate using secret from this keyvault.

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

### -IdentityClientId
Identity Client Id of the user-assigned Managed Identity.
Will default system-assigned if leave empty.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretIdentifier
Secret Identifier of this Key Vault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementKeyVaultEntity

## NOTES

## RELATED LINKS
