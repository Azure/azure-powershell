---
external help file:
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/get-azkeyvaultkey
schema: 2.0.0
---

# Get-AzKeyVaultKey

## SYNOPSIS
The get key operation is applicable to all key types.
If the requested key is symmetric, then no key material is released in the response.
This operation requires the keys/get permission.

## SYNTAX

### Get1 (Default)
```
Get-AzKeyVaultKey [-KeyVaultDnsSuffix <String>] [-VaultName <String>] [-MaxResult <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzKeyVaultKey -InputObject <IKeyVaultIdentity> [-KeyVaultDnsSuffix <String>] [-VaultName <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzKeyVaultKey -Name <String> -Version <String> [-KeyVaultDnsSuffix <String>] [-VaultName <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListVersions
```
Get-AzKeyVaultKey -Name <String> -IncludeVersions [-VaultBaseUrl <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetDeleted
```
Get-AzKeyVaultKey -InRemovedState [-VaultBaseUrl <String>] [-MaxResult <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetDeleted1
```
Get-AzKeyVaultKey -Name <String> -InRemovedState [-VaultBaseUrl <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
The get key operation is applicable to all key types.
If the requested key is symmetric, then no key material is released in the response.
This operation requires the keys/get permission.

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
Signals to include versions of the key in the output.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListVersions
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

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
Signals that deleted key vault key should be returned.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetDeleted, GetDeleted1
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyVaultDnsSuffix
MISSING DESCRIPTION 06

```yaml
Type: System.String
Parameter Sets: Get1, GetViaIdentity, Get
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
Parameter Sets: Get1, GetDeleted
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the key to get.

```yaml
Type: System.String
Parameter Sets: Get, ListVersions, GetDeleted1
Aliases: KeyName

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
Parameter Sets: ListVersions, GetDeleted, GetDeleted1
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
Parameter Sets: Get1, GetViaIdentity, Get
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Version
Adding the version parameter retrieves a specific version of a key.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: KeyVersion

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

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeyBundle

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeyItem

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IDeletedKeyItem

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IDeletedKeyBundle

## ALIASES

## NOTES

## RELATED LINKS

