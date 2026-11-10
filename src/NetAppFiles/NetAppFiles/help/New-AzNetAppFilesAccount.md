---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/new-aznetappfilesaccount
schema: 2.0.0
---

# New-AzNetAppFilesAccount

## SYNOPSIS
Creates a new Azure NetApp Files (ANF) account.

## SYNTAX

```
New-AzNetAppFilesAccount -ResourceGroupName <String> -Location <String> -Name <String>
 [-ActiveDirectory <PSNetAppFilesActiveDirectory[]>] [-Encryption <PSNetAppFilesAccountEncryption>]
 [-LdapConfiguration <PSNetAppFilesLdapConfiguration>]
 [-EncryptionKeySource <String>] [-KeyVaultKeyName <String>] [-KeyVaultResourceId <String>]
 [-KeyVaultUri <String>] [-IdentityType <String>] [-UserAssignedIdentity <String>]
 [-FederatedClientId <String>] [-NfsV4IdDomain <String>] [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetAppFilesAccount** cmdlet creates an ANF account.

## EXAMPLES

### Example 1: Create an ANF account
```powershell
New-AzNetAppFilesAccount -ResourceGroupName "MyRG" -Name "MyAnfAccount" -Location "westus2"
```

```output
Location          : westus2
Id                : /subscriptions/mySubs/resourceGroups/MyRG/providers/Microsoft.NetApp/netAppAccounts/MyAnfAccount
Name              : MyAnfAccount
Type              : Microsoft.NetApp/netAppAccounts
Tags              :
ProvisioningState : Succeeded
```

This command creates the new ANF account "MyAnfAccount".

### Example 2: Create an account with LDAP configuration
```powershell
$ldap = @{
    Domain = "example.com"
    LdapServers = @("10.0.0.4", "10.0.0.5")
    SecureLdapType = "None"
    BindAuthenticationLevel = "Anonymous"
    UserDN = "ou=users,dc=example,dc=com"
    GroupDN = "ou=groups,dc=example,dc=com"
}
New-AzNetAppFilesAccount -ResourceGroupName "MyRG" -Name "MyAnfAccount" -Location "westus2" -LdapConfiguration $ldap
```

Creates an account using the specified LDAP servers and search distinguished names. For encrypted transport, use `LdapOverTLS` and supply the certificate and DNS settings described below.

## PARAMETERS

### -LdapConfiguration
LDAP server, search, transport security, and bind authentication settings for the account. Accepts a PSNetAppFilesLdapConfiguration object or a hashtable with these properties:

- `Domain`, `LdapServers`: LDAP domain and server IPv4 addresses.
- `SecureLdapType`: `None` or `LdapOverTLS`.
- `ServerCACertificate`, `CertificateCNHost`, `DnsServers`: Base64-encoded LDAP server CA certificate, certificate common-name host, and DNS server IPv4 addresses for LDAP over TLS.
- `LdapPort`: LDAP port; the service defaults to 389.
- `UserDN`, `GroupDN`, `NetGroupDN`: Distinguished names that override the base search distinguished name.
- `BindAuthenticationLevel`: `Anonymous` or `Simple`.
- `BindDN`: Distinguished name used to bind to the LDAP server.
- `BindPasswordAkvConfig`: Nested hashtable or PSNetAppFilesBindPasswordAkvConfig object with `AzureKeyVaultUri`, `SecretName`, and `UserAssignedIdentity`, identifying the Key Vault secret containing the bind password and the identity used to access it. Do not provide the password itself.

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesLdapConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActiveDirectory
A hashtable array which represents the active directories

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesActiveDirectory[]
Parameter Sets: (All)
Aliases:

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

### -Encryption
A hashtable which represents the Encryption settings

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesAccountEncryption
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionKeySource
The encryption keySource (provider). Possible values: Microsoft.NetApp, Microsoft.KeyVault

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

### -FederatedClientId
ClientId of the multi-tenant AAD Application. Used to access cross-tenant KeyVaults.

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

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

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

### -KeyVaultKeyName
The name of KeyVault key

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

### -KeyVaultResourceId
The resource ID of KeyVault.

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

### -KeyVaultUri
The Uri of KeyVault.

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

### -Location
The location of the resource

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

### -Name
The name of the ANF account

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AccountName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NfsV4IdDomain
Domain for NFSv4 user ID mapping. This property will be set for all NetApp accounts in the subscription and region and only affect non ldap NFSv4 volumes.

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

### -ResourceGroupName
The resource group of the ANF account

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

### -Tag
A hashtable which represents resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases: Tags

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The ARM resource identifier of the user assigned identity used to authenticate with key vault. Applicable if identity.type has 'UserAssigned'. It should match key of identity.userAssignedIdentities

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

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesAccount

## NOTES

## RELATED LINKS

[Get-AzNetAppFilesAccount](./Get-AzNetAppFilesAccount.md)
[Remove-AzNetAppFilesAccount](./Remove-AzNetAppFilesAccount.md)
[Set-AzNetAppFilesAccount](./Set-AzNetAppFilesAccount.md)
[Update-AzNetAppFilesAccount](./Update-AzNetAppFilesAccount.md)
[Get-AzNetAppFilesActiveDirectory](./Get-AzNetAppFilesActiveDirectory.md)
[New-AzNetAppFilesActiveDirectory](./New-AzNetAppFilesActiveDirectory.md)
[Remove-AzNetAppFilesActiveDirectory](./Remove-AzNetAppFilesActiveDirectory.md)
[Update-AzNetAppFilesActiveDirectory](./Update-AzNetAppFilesActiveDirectory.md)
