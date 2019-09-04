---
external help file:
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/get-azkeyvaultcertificate
schema: 2.0.0
---

# Get-AzKeyVaultCertificate

## SYNOPSIS
Gets information about a specific certificate.
This operation requires the certificates/get permission.

## SYNTAX

### GetDeleted (Default)
```
Get-AzKeyVaultCertificate -InRemovedState [-VaultBaseUrl <String>] [-MaxResult <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzKeyVaultCertificate -Name <String> -Version <String> [-KeyVaultDnsSuffix <String>] [-VaultName <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetDeleted1
```
Get-AzKeyVaultCertificate -InRemovedState -Name <String> [-VaultBaseUrl <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzKeyVaultCertificate -InputObject <IKeyVaultIdentity> [-KeyVaultDnsSuffix <String>] [-VaultName <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListVersions
```
Get-AzKeyVaultCertificate -IncludeVersions -Name <String> [-VaultBaseUrl <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets information about a specific certificate.
This operation requires the certificates/get permission.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IncludeVersions
Signals to include the versions of the certificate in the output.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListVersions
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.IKeyVaultIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -InRemovedState
Signals that deleted key vault certificates should be returned.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetDeleted, GetDeleted1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyVaultDnsSuffix
MISSING DESCRIPTION 06

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MaxResult
Maximum number of results to return in a page.
If not specified the service will return up to 25 results.

```yaml
Type: System.Int32
Parameter Sets: GetDeleted
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the certificate in the given vault.

```yaml
Type: System.String
Parameter Sets: Get, GetDeleted1, ListVersions
Aliases: CertificateName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VaultBaseUrl
MISSING DESCRIPTION 06

```yaml
Type: System.String
Parameter Sets: GetDeleted, GetDeleted1, ListVersions
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VaultName
MISSING DESCRIPTION 06

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Version
The version of the certificate.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: CertificateVersion

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.IKeyVaultIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.ICertificateBundle

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IDeletedCertificateBundle

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IDeletedCertificateItem

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### INPUTOBJECT <IKeyVaultIdentity>: Identity Parameter
  - `[CertificateName <String>]`: The name of the certificate.
  - `[CertificateVersion <String>]`: The version of the certificate.
  - `[Id <String>]`: Resource identity path
  - `[IssuerName <String>]`: The name of the issuer.
  - `[KeyName <String>]`: The name for the new key. The system will generate the version name for the new key.
  - `[KeyVersion <String>]`: The version of the key to update.
  - `[Location <String>]`: The location of the deleted vault.
  - `[OperationKind <AccessPolicyUpdateKind?>]`: Name of the operation
  - `[ResourceGroupName <String>]`: The name of the Resource Group to which the server belongs.
  - `[SasDefinitionName <String>]`: The name of the SAS definition.
  - `[SecretName <String>]`: The name of the secret.
  - `[SecretVersion <String>]`: The version of the secret.
  - `[StorageAccountName <String>]`: The name of the storage account.
  - `[SubscriptionId <String>]`: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[VaultName <String>]`: Name of the vault

## RELATED LINKS

