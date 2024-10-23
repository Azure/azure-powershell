---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
ms.assetid: 7039528F-42AE-45DB-BF81-FE5003F8AEE2
online version: https://learn.microsoft.com/powershell/module/az.sql/new-azsqlserver
schema: 2.0.0
---

# New-AzSqlServer

## SYNOPSIS
Creates a SQL Database server.

## SYNTAX

```
New-AzSqlServer -ServerName <String> [-SqlAdministratorCredentials <PSCredential>] -Location <String>
 [-Tags <Hashtable>] [-ServerVersion <String>] [-AssignIdentity] [-PublicNetworkAccess <String>]
 [-RestrictOutboundNetworkAccess <String>] [-MinimalTlsVersion <String>]
 [-PrimaryUserAssignedIdentityId <String>] [-KeyId <String>]
 [-UserAssignedIdentityId <System.Collections.Generic.List`1[System.String]>] [-IdentityType <String>] [-AsJob]
 [-EnableActiveDirectoryOnlyAuthentication] [-ExternalAdminName <String>] [-ExternalAdminSID <Guid>]
 [-FederatedClientId <Guid>] [-ResourceGroupName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzSqlServer** cmdlet creates an Azure SQL Database server.

## EXAMPLES

### Example 1: Create a new Azure SQL Database server
```powershell
New-AzSqlServer -ResourceGroupName "ResourceGroup01" -Location "Central US" -ServerName "server01" -ServerVersion "12.0" -SqlAdministratorCredentials (Get-Credential)
```

```output
ResourceGroupName        : resourcegroup01
ServerName               : server01
Location                 : Central US
SqlAdministratorLogin    : adminLogin
SqlAdministratorPassword :
ServerVersion            : 12.0
Tags                     :
```

This command creates a version 12 Azure SQL Database server.

### Example 2: Create a new Azure SQL Database server with External (Microsoft Entra ID) Administrator, Microsoft Entra-only Authentication and no SqlAdministratorCredentials
<!-- Skip: Output cannot be splitted from code -->
```powershell
New-AzSqlServer -ResourceGroupName "ResourceGroup01" -Location "Central US" -ServerName "server01" -ServerVersion "12.0" -ExternalAdminName DummyLogin -EnableActiveDirectoryOnlyAuthentication
ResourceGroupName        : resourcegroup01
ServerName               : server01
Location                 : Central US
SqlAdministratorLogin    : adminLogin
SqlAdministratorPassword :
ServerVersion            : 12.0
Tags                     :
Administrators           :

$val = Get-AzSqlServer -ResourceGroupName "ResourceGroup01" -ServerName "server01" -ExpandActiveDirectoryAdministrator
ResourceGroupName        : resourcegroup01
ServerName               : server01
Location                 : Central US
SqlAdministratorLogin    : randomLogin
SqlAdministratorPassword :
ServerVersion            : 12.0
Tags                     :
Administrators           : Microsoft.Azure.Management.Sql.Models.ServerExternalAdministrator

$val.Administrators
AdministratorType         : ActiveDirectory
PrincipalType             : Group
Login                     : DummyLogin
Sid                       : df7667b8-f9fd-4029-a0e3-b43c75ce9538
TenantId                  : 00001111-aaaa-2222-bbbb-3333cccc4444
AzureADOnlyAuthentication : True
```

This command creates a version 12 Azure SQL Database server with external administrator properties and Microsoft Entra-only authentication enabled.

### Example 3: Create a new Azure SQL Database server with TDE CMK
```powershell
New-AzSqlServer -ResourceGroupName "ResourceGroup01" -Location "East US" -ServerName "server01" -ServerVersion "12.0" -SqlAdministratorCredentials (Get-Credential) -AssignIdentity -IdentityType "UserAssigned" -PrimaryUserAssignedIdentityId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity01" -UserAssignedIdentityId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity01" -KeyId "https://contoso.vault.azure.net/keys/contosokey/01234567890123456789012345678901"
```

```output
ResourceGroupName        : resourcegroup01
ServerName               : server01
Location                 : East US
SqlAdministratorLogin    : adminLogin
SqlAdministratorPassword :
ServerVersion            : 12.0
Tags                     :
Identity                 : Microsoft.Azure.Management.Sql.Models.ResourceIdentity
KeyId                    : https://contoso.vault.azure.net/keys/contosokey/01234567890123456789012345678901
PrimaryUserAssignedIdentityId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity01
```

This command creates a version 12 Azure SQL Database server with TDE CMK enabled.

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -AssignIdentity
Generate and assign a Microsoft Entra identity for this server for use with key management services like Azure KeyVault.

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

### -EnableActiveDirectoryOnlyAuthentication
Enable Active Directory Only Authentication on the server.

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

### -ExternalAdminName
Specifies the display name of the user, group or application which is the Microsoft Entra administrator for the server. This display name must exist in the active directory associated with the current subscription.

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

### -ExternalAdminSID
Specifies the object ID of the user, group or application which is the Microsoft Entra administrator.

```yaml
Type: System.Nullable`1[System.Guid]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FederatedClientId
Specifies the Federated client ID of the server when using Cross-Tenant CMK, Do not set this value if you do not intent to use Cross-Tenant CMK

```yaml
Type: System.Nullable`1[System.Guid]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Type of identity to be assigned to the server. Possible values are SystemAsssigned, UserAssigned, 'SystemAssigned,UserAssigned' and None.

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

### -KeyId
The Azure Key Vault URI that is used for encryption.

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
Specifies the location of the data center where this cmdlet creates the server.

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

### -MinimalTlsVersion
The minimal TLS version to enforce for Sql Server

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: None, 1.0, 1.1, 1.2

Required: False
Position: Named
Default value: 1.2
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrimaryUserAssignedIdentityId
The primary User Managed Identity(UMI) id.

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

### -PublicNetworkAccess
Takes a flag, enabled/disabled, to specify whether public network access to server is allowed or not.
When disabled, only connections made through Private Links can reach this server.

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
Specifies the name of the resource group to which this cmdlet assigns the server.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RestrictOutboundNetworkAccess
When enabled, only outbound connections allowed by the outbound firewall rules will succeed.

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

### -ServerName
Specifies the name of the new server.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerVersion
Specifies the version of the new server. The acceptable values for this parameter are: 2.0 and 12.0.
Specify 2.0 to create a version 11 server, or 12.0 to create a version 12 server.

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

### -SqlAdministratorCredentials
Specifies the SQL Database server administrator credentials for the new server. To obtain a
**PSCredential** object, use the Get-Credential cmdlet. For more information, type `Get-Help
Get-Credential`.

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tags
Key-value pairs in the form of a hash table. For example:
@{key0="value0";key1=$null;key2="value2"}

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases: Tag

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentityId
The list of user assigned identities.

```yaml
Type: System.Collections.Generic.List`1[System.String]
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
Default value: False
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.Server.Model.AzureSqlServerModel

## NOTES

## RELATED LINKS

[Get-AzSqlServer](./Get-AzSqlServer.md)

[Remove-AzSqlServer](./Remove-AzSqlServer.md)

[Set-AzSqlServer](./Set-AzSqlServer.md)

[New-AzSqlServerFirewallRule](./New-AzSqlServerFirewallRule.md)

[SQL Database Documentation](https://learn.microsoft.com/azure/sql-database/)
