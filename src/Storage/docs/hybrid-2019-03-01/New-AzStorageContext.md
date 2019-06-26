---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/new-azstoragecontext
schema: 2.0.0
---

# New-AzStorageContext

## SYNOPSIS


## SYNTAX

### OAuthAccount (Default)
```
New-AzStorageContext [-StorageAccountName] <String> [-UseConnectedAccount] [-Protocol <String>]
 [-Endpoint <String>] [<CommonParameters>]
```

### OAuthAccountEnvironment
```
New-AzStorageContext [-StorageAccountName] <String> -Environment <String> [-UseConnectedAccount]
 [-Protocol <String>] [<CommonParameters>]
```

### SasTokenWithAzureEnvironment
```
New-AzStorageContext [-StorageAccountName] <String> -Environment <String> -SasToken <String>
 [<CommonParameters>]
```

### SasToken
```
New-AzStorageContext [-StorageAccountName] <String> -SasToken <String> [-Protocol <String>]
 [-Endpoint <String>] [<CommonParameters>]
```

### AnonymousAccountEnvironment
```
New-AzStorageContext [-StorageAccountName] <String> -Environment <String> -Anonymous [-Protocol <String>]
 [<CommonParameters>]
```

### AnonymousAccount
```
New-AzStorageContext [-StorageAccountName] <String> -Anonymous [-Protocol <String>] [-Endpoint <String>]
 [<CommonParameters>]
```

### AccountNameAndKeyEnvironment
```
New-AzStorageContext [-StorageAccountName] <String> [-StorageAccountKey] <String> -Environment <String>
 [-Protocol <String>] [<CommonParameters>]
```

### AccountNameAndKey
```
New-AzStorageContext [-StorageAccountName] <String> [-StorageAccountKey] <String> [-Protocol <String>]
 [-Endpoint <String>] [<CommonParameters>]
```

### ConnectionString
```
New-AzStorageContext -ConnectionString <String> [<CommonParameters>]
```

### LocalDevelopment
```
New-AzStorageContext -Local [<CommonParameters>]
```

## DESCRIPTION


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

### -Anonymous
Use anonymous storage account

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AnonymousAccountEnvironment, AnonymousAccount
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ConnectionString
Azure Storage Connection String

```yaml
Type: System.String
Parameter Sets: ConnectionString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Endpoint
Azure storage endpoint

```yaml
Type: System.String
Parameter Sets: OAuthAccount, SasToken, AnonymousAccount, AccountNameAndKey
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Environment
Azure environment name

```yaml
Type: System.String
Parameter Sets: OAuthAccountEnvironment, SasTokenWithAzureEnvironment, AnonymousAccountEnvironment, AccountNameAndKeyEnvironment
Aliases: Name, EnvironmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
Dynamic: False
```

### -Local
Use local development storage account

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: LocalDevelopment
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Protocol
Protocol specification (HTTP or HTTPS), default is HTTPS

```yaml
Type: System.String
Parameter Sets: OAuthAccount, OAuthAccountEnvironment, SasToken, AnonymousAccountEnvironment, AnonymousAccount, AccountNameAndKeyEnvironment, AccountNameAndKey
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SasToken
Azure Storage SAS Token

```yaml
Type: System.String
Parameter Sets: SasTokenWithAzureEnvironment, SasToken
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -StorageAccountKey
Azure Storage Account Key

```yaml
Type: System.String
Parameter Sets: AccountNameAndKeyEnvironment, AccountNameAndKey
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -StorageAccountName
Azure Storage Account Name

```yaml
Type: System.String
Parameter Sets: OAuthAccount, OAuthAccountEnvironment, SasTokenWithAzureEnvironment, SasToken, AnonymousAccountEnvironment, AnonymousAccount, AccountNameAndKeyEnvironment, AccountNameAndKey
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -UseConnectedAccount
Use OAuth storage account

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: OAuthAccount, OAuthAccountEnvironment
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Storage.AzureStorageContext

## ALIASES

## NOTES

## RELATED LINKS

