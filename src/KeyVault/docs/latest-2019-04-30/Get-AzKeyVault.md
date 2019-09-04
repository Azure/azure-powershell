---
external help file:
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/get-azkeyvault
schema: 2.0.0
---

# Get-AzKeyVault

## SYNOPSIS
Gets the specified Azure key vault.

## SYNTAX

### List3 (Default)
```
Get-AzKeyVault -SubscriptionId <String[]> [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzKeyVault -Name <String> -ResourceGroupName <String> -SubscriptionId <String[]>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetDeleted
```
Get-AzKeyVault -InRemovedState -Location <String> -Name <String> -SubscriptionId <String[]>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzKeyVault -InputObject <IKeyVaultIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List2
```
Get-AzKeyVault -ResourceGroupName <String> -SubscriptionId <String[]> [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListDeleted
```
Get-AzKeyVault -InRemovedState -SubscriptionId <String[]> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the specified Azure key vault.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.IKeyVaultIdentity
Parameter Sets: GetViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -InRemovedState
Signals that deleted key vaults should be returned.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetDeleted, ListDeleted
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
The location of the deleted vault.

```yaml
Type: System.String
Parameter Sets: GetDeleted
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the vault.

```yaml
Type: System.String
Parameter Sets: Get1, GetDeleted
Aliases: VaultName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the Resource Group to which the vault belongs.

```yaml
Type: System.String
Parameter Sets: Get1, List2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get1, GetDeleted, List2, List3, ListDeleted
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Top
Maximum number of results to return.

```yaml
Type: System.Int32
Parameter Sets: List2, List3
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20180214.IDeletedVault

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20180214.IVault

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

