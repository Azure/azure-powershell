---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/new-azdatalakegen2sastoken
schema: 2.0.0
---

# New-AzDataLakeGen2SasToken

## SYNOPSIS
Generates a SAS token for Azure DatalakeGen2 item.

## SYNTAX

### ReceiveManual (Default)
```
New-AzDataLakeGen2SasToken [-FileSystem] <String> [-Path <String>] [-Permission <String>]
 [-Protocol <SasProtocol>] [-IPAddressOrRange <String>] [-StartTime <DateTimeOffset>]
 [-ExpiryTime <DateTimeOffset>] [-EncryptionScope <String>] [-FullUri] [-Context <IStorageContext>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ItemPipeline
```
New-AzDataLakeGen2SasToken -InputObject <AzureDataLakeGen2Item> [-Permission <String>]
 [-Protocol <SasProtocol>] [-IPAddressOrRange <String>] [-StartTime <DateTimeOffset>]
 [-ExpiryTime <DateTimeOffset>] [-EncryptionScope <String>] [-FullUri] [-Context <IStorageContext>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzDataLakeGen2SasToken** cmdlet generates a Shared Access Signature (SAS) token for an Azure DatalakeGen2 item.

## EXAMPLES

### Example 1: Generate a SAS token with full permission
```powershell
New-AzDataLakeGen2SasToken -FileSystem "filesystem1" -Path "dir1/dir2" -Permission racwdlmeop
```

This example generates a DatalakeGen2 SAS token with full permission.

### Example 2: Generate a SAS token with specific StartTime, ExpireTime, Protocal, IPAddressOrRange, Encryption Scope, by pipeline a datalakegen2 item
```powershell
Get-AzDataLakeGen2Item -FileSystem test -Path "testdir/dir2" | New-AzDataLakeGen2SasToken -Permission rw -Protocol Https -IPAddressOrRange 10.0.0.0-12.10.0.0 -StartTime (Get-Date) -ExpiryTime (Get-Date).AddDays(6) -EncryptionScope scopename
```

This example generates a DatalakeGen2 SAS token by pipeline a datalake gen2 item, and with specific StartTime, ExpireTime, Protocal, IPAddressOrRange, Encryption Scope.

## PARAMETERS

### -Context
Azure Storage Context Object

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionScope
Encryption scope to use when sending requests authorized with this SAS URI.

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

### -ExpiryTime
Expiry Time

```yaml
Type: System.Nullable`1[System.DateTimeOffset]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileSystem
FileSystem name

```yaml
Type: System.String
Parameter Sets: ReceiveManual
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FullUri
Display full uri with sas token

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

### -InputObject
Azure Datalake Gen2 Item Object to remove.

```yaml
Type: Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureDataLakeGen2Item
Parameter Sets: ItemPipeline
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IPAddressOrRange
IP, or IP range ACL (access control list) that the request would be accepted by Azure Storage.

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

### -Path
The path in the specified FileSystem that should be retrieved.
Can be a file or directory In the format 'directory/file.txt' or 'directory1/directory2/'.
Skip set this parameter to get the root directory of the Filesystem.

```yaml
Type: System.String
Parameter Sets: ReceiveManual
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Permission
Permissions for a blob.
Permissions can be any not-empty subset of "racwdlmeop".

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
Protocol can be used in the request with this SAS token.

```yaml
Type: System.Nullable`1[Azure.Storage.Sas.SasProtocol]
Parameter Sets: (All)
Aliases:
Accepted values: None, HttpsAndHttp, Https

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTime
Start Time

```yaml
Type: System.Nullable`1[System.DateTimeOffset]
Parameter Sets: (All)
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

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureDataLakeGen2Item

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
