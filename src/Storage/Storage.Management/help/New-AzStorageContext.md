---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
ms.assetid: 383402B2-6B7C-41AB-AFF9-36C86156B0A9
online version: https://learn.microsoft.com/powershell/module/az.storage/new-azstoragecontext
schema: 2.0.0
---

# New-AzStorageContext

## SYNOPSIS
Creates an Azure Storage context.

## SYNTAX

### OAuthAccount (Default)
```
New-AzStorageContext [-StorageAccountName] <String> [-UseConnectedAccount] [-Protocol <String>]
 [-Endpoint <String>] [-EnableFileBackupRequestIntent] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### AccountNameAndKey
```
New-AzStorageContext [-StorageAccountName] <String> [-StorageAccountKey] <String> [-Protocol <String>]
 [-Endpoint <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### AccountNameAndKeyEnvironment
```
New-AzStorageContext [-StorageAccountName] <String> [-StorageAccountKey] <String> [-Protocol <String>]
 -Environment <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### AnonymousAccount
```
New-AzStorageContext [-StorageAccountName] <String> [-Anonymous] [-Protocol <String>] [-Endpoint <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### AnonymousAccountEnvironment
```
New-AzStorageContext [-StorageAccountName] <String> [-Anonymous] [-Protocol <String>] -Environment <String>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### SasToken
```
New-AzStorageContext [-StorageAccountName] <String> -SasToken <String> [-Protocol <String>]
 [-Endpoint <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### SasTokenWithAzureEnvironment
```
New-AzStorageContext [-StorageAccountName] <String> -SasToken <String> -Environment <String>
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### OAuthAccountEnvironment
```
New-AzStorageContext [-StorageAccountName] <String> [-UseConnectedAccount] [-Protocol <String>]
 -Environment <String> [-EnableFileBackupRequestIntent] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### AccountNameAndKeyServiceEndpoint
```
New-AzStorageContext [-StorageAccountName] <String> [-StorageAccountKey] <String> -BlobEndpoint <String>
 [-FileEndpoint <String>] [-QueueEndpoint <String>] [-TableEndpoint <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### SasTokenServiceEndpoint
```
New-AzStorageContext -SasToken <String> [-BlobEndpoint <String>] [-FileEndpoint <String>]
 [-QueueEndpoint <String>] [-TableEndpoint <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ConnectionString
```
New-AzStorageContext -ConnectionString <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### LocalDevelopment
```
New-AzStorageContext [-Local] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### AnonymousAccountServiceEndpoint
```
New-AzStorageContext [-Anonymous] [-BlobEndpoint <String>] [-FileEndpoint <String>] [-QueueEndpoint <String>]
 [-TableEndpoint <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### OAuthAccountServiceEndpoint
```
New-AzStorageContext [-UseConnectedAccount] [-BlobEndpoint <String>] [-FileEndpoint <String>]
 [-QueueEndpoint <String>] [-TableEndpoint <String>] [-EnableFileBackupRequestIntent]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzStorageContext** cmdlet creates an Azure Storage context.
The default Authentication of a Storage Context is OAuth (Microsoft Entra ID), if only input Storage account name.
See details of authentication of the Storage Service in https://learn.microsoft.com/rest/api/storageservices/authorization-for-the-azure-storage-services.

## EXAMPLES

### Example 1: Create a context by specifying a storage account name and key
```powershell
New-AzStorageContext -StorageAccountName "ContosoGeneral" -StorageAccountKey "< Storage Key for ContosoGeneral ends with == >"
```

This command creates a context for the account named ContosoGeneral that uses the specified key.

### Example 2: Create a context by specifying a connection string
```powershell
New-AzStorageContext -ConnectionString "DefaultEndpointsProtocol=https;AccountName=ContosoGeneral;AccountKey=< Storage Key for ContosoGeneral ends with == >;"
```

This command creates a context based on the specified connection string for the account ContosoGeneral.

### Example 3: Create a context for an anonymous storage account
```powershell
New-AzStorageContext -StorageAccountName "ContosoGeneral" -Anonymous -Protocol "http"
```

This command creates a context for anonymous use for the account named ContosoGeneral.
The command specifies HTTP as a connection protocol.

### Example 4: Create a context by using the local development storage account
```powershell
New-AzStorageContext -Local
```

This command creates a context by using the local development storage account.
The command specifies the *Local* parameter.

### Example 5: Get the container for the local developer storage account
```powershell
New-AzStorageContext -Local | Get-AzStorageContainer
```

This command creates a context by using the local development storage account, and then passes the new context to the **Get-AzStorageContainer** cmdlet by using the pipeline operator.
The command gets the Azure Storage container for the local developer storage account.

### Example 6: Get multiple containers
```powershell
$Context01 = New-AzStorageContext -Local 
$Context02 = New-AzStorageContext -StorageAccountName "ContosoGeneral" -StorageAccountKey "< Storage Key for ContosoGeneral ends with == >"
($Context01, $Context02) | Get-AzStorageContainer
```

The first command creates a context by using the local development storage account, and then stores that context in the $Context01 variable.
The second command creates a context for the account named ContosoGeneral that uses the specified key, and then stores that context in the $Context02 variable.
The final command gets the containers for the contexts stored in $Context01 and $Context02 by using **Get-AzStorageContainer**.

### Example 7: Create a context with an endpoint
```powershell
New-AzStorageContext -StorageAccountName "ContosoGeneral" -StorageAccountKey "< Storage Key for ContosoGeneral ends with == >" -Endpoint "contosoaccount.core.windows.net"
```

This command creates an Azure Storage context that has the specified storage endpoint.
The command creates the context for the account named ContosoGeneral that uses the specified key.

### Example 8: Create a context with a specified environment
```powershell
New-AzStorageContext -StorageAccountName "ContosoGeneral" -StorageAccountKey "< Storage Key for ContosoGeneral ends with == >" -Environment "AzureChinaCloud"
```

This command creates an Azure storage context that has the specified Azure environment.
The command creates the context for the account named ContosoGeneral that uses the specified key.

### Example 9: Create a context by using an SAS token
```powershell
$SasToken = New-AzStorageContainerSASToken -Name "ContosoMain" -Permission "rad"
$Context = New-AzStorageContext -StorageAccountName "ContosoGeneral" -SasToken $SasToken
$Context | Get-AzStorageBlob -Container "ContosoMain"
```

The first command generates an SAS token by using the **New-AzStorageContainerSASToken** cmdlet for the container named ContosoMain, and then stores that token in the $SasToken variable.
That token is for read, add, update, and delete permissions.
The second command creates a context for the account named ContosoGeneral that uses the SAS token stored in $SasToken, and then stores that context in the $Context variable.
The final command lists all the blobs associated with the container named ContosoMain by using the context stored in $Context.

### Example 10: Create a context by using the OAuth Authentication
```powershell
Connect-AzAccount
$Context = New-AzStorageContext -StorageAccountName "myaccountname" -UseConnectedAccount
```

This command creates a context by using the OAuth (Microsoft Entra ID) Authentication.

### Example 11: Create a context by specifying a storage account name, storage account key and custom blob endpoint
```powershell
New-AzStorageContext -StorageAccountName "myaccountname" -StorageAccountKey "< Storage Key for myaccountname ends with == >" -BlobEndpoint "https://myaccountname.blob.core.windows.net/"
```

This command creates a context for the account named myaccountname with a key for the account, and specified blob endpoint. 

### Example 12: Create a context for an anonymous storage account with specified blob endpoint
```powershell
New-AzStorageContext -Anonymous -BlobEndpoint "https://myaccountname.blob.core.windows.net/"
```

This command creates a context for anonymous use for the account named myaccountname, with specified blob enpoint. 

### Example 13: Create a context by using an SAS token with specified endpoints
```powershell
$SasToken = New-AzStorageContainerSASToken -Name "MyContainer" -Permission "rad"
New-AzStorageContext -SasToken $SasToken -BlobEndpoint "https://myaccountname.blob.core.windows.net/" -TableEndpoint "https://myaccountname.table.core.windows.net/" -FileEndpoint "https://myaccountname.file.core.windows.net/" -QueueEndpoint "https://myaccountname.queue.core.windows.net/"
```

The first command generates an SAS token by using the New-AzStorageContainerSASToken cmdlet for the container named MyContainer, and then stores that token in the $SasToken variable.
The second command creates a context that uses the SAS token and a specified blob endpoint, table endpoint, file endpoint, and queue endpoint. 

### Example 14: Create a context by using the OAuth Authentication with a specified blob endpoint
```powershell
New-AzStorageContext -UseConnectedAccount -BlobEndpoint  "https://myaccountname.blob.core.windows.net/"
```

This command creates a context by using the OAuth authentication with a specified blob endpoint.

### Example 15: Create a context by using the OAuth Authentication on File service
```powershell
New-AzStorageContext -StorageAccountName "myaccountname" -UseConnectedAccount -EnableFileBackupRequestIntent
```

This command creates a context to use the OAuth (Microsoft Entra ID) authentication on File service.
Parameter '-EnableFileBackupRequestIntent' is required to use OAuth (Microsoft Entra ID) Authentication for File service. This will bypass any file/directory level permission checks and allow access, based on the allowed data actions, even if there are ACLs in place for those files/directories.

## PARAMETERS

### -Anonymous
Indicates that this cmdlet creates an Azure Storage context for anonymous logon.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AnonymousAccount, AnonymousAccountEnvironment, AnonymousAccountServiceEndpoint
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlobEndpoint
Azure storage blob service endpoint

```yaml
Type: System.String
Parameter Sets: AccountNameAndKeyServiceEndpoint
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: SasTokenServiceEndpoint, AnonymousAccountServiceEndpoint, OAuthAccountServiceEndpoint
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionString
Specifies a connection string for the Azure Storage context.

```yaml
Type: System.String
Parameter Sets: ConnectionString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableFileBackupRequestIntent
Required parameter to use with OAuth (Microsoft Entra ID) Authentication for Files. This will bypass any file/directory level permission checks and allow access, based on the allowed data actions, even if there are ACLs in place for those files/directories.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: OAuthAccount, OAuthAccountEnvironment, OAuthAccountServiceEndpoint
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
Specifies the endpoint for the Azure Storage context.

```yaml
Type: System.String
Parameter Sets: OAuthAccount, AccountNameAndKey, AnonymousAccount, SasToken
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Environment
Specifies the Azure environment.
The acceptable values for this parameter are: AzureCloud and AzureChinaCloud.
For more information, type `Get-Help Get-AzEnvironment`.

```yaml
Type: System.String
Parameter Sets: AccountNameAndKeyEnvironment, AnonymousAccountEnvironment
Aliases: Name, EnvironmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: SasTokenWithAzureEnvironment, OAuthAccountEnvironment
Aliases: Name, EnvironmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -FileEndpoint
Azure storage file service endpoint

```yaml
Type: System.String
Parameter Sets: AccountNameAndKeyServiceEndpoint, SasTokenServiceEndpoint, AnonymousAccountServiceEndpoint, OAuthAccountServiceEndpoint
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Local
Indicates that this cmdlet creates a context by using the local development storage account.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: LocalDevelopment
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Protocol
Transfer Protocol (https/http).

```yaml
Type: System.String
Parameter Sets: OAuthAccount, AccountNameAndKey, AccountNameAndKeyEnvironment, AnonymousAccount, AnonymousAccountEnvironment, SasToken, OAuthAccountEnvironment
Aliases:
Accepted values: Http, Https

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueueEndpoint
Azure storage queue service endpoint

```yaml
Type: System.String
Parameter Sets: AccountNameAndKeyServiceEndpoint, SasTokenServiceEndpoint, AnonymousAccountServiceEndpoint, OAuthAccountServiceEndpoint
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SasToken
Specifies a Shared Access Signature (SAS) token for the context.

```yaml
Type: System.String
Parameter Sets: SasToken, SasTokenWithAzureEnvironment, SasTokenServiceEndpoint
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountKey
Specifies an Azure Storage account key.
This cmdlet creates a context for the key that this parameter specifies.

```yaml
Type: System.String
Parameter Sets: AccountNameAndKey, AccountNameAndKeyEnvironment, AccountNameAndKeyServiceEndpoint
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountName
Specifies an Azure Storage account name.
This cmdlet creates a context for the account that this parameter specifies.

```yaml
Type: System.String
Parameter Sets: OAuthAccount, AccountNameAndKey, AccountNameAndKeyEnvironment, AnonymousAccount, AnonymousAccountEnvironment, SasToken, SasTokenWithAzureEnvironment, OAuthAccountEnvironment, AccountNameAndKeyServiceEndpoint
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TableEndpoint
Azure storage table service endpoint

```yaml
Type: System.String
Parameter Sets: AccountNameAndKeyServiceEndpoint, SasTokenServiceEndpoint, AnonymousAccountServiceEndpoint, OAuthAccountServiceEndpoint
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseConnectedAccount
Indicates that this cmdlet creates an Azure Storage context with OAuth (Microsoft Entra ID) Authentication.
The cmdlet will use OAuth Authentication by default, when other authentication not specified.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: OAuthAccount, OAuthAccountEnvironment, OAuthAccountServiceEndpoint
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

### System.String

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Storage.AzureStorageContext

## NOTES

## RELATED LINKS

[Get-AzStorageBlob](./Get-AzStorageBlob.md)

[New-AzStorageContainerSASToken](./New-AzStorageContainerSASToken.md)
