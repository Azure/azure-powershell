---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
ms.assetid: 6FF04E82-4921-4F7B-83D0-6997316BC5FD
online version: https://learn.microsoft.com/powershell/module/az.storage/new-azstoragecontainersastoken
schema: 2.0.0
---

# New-AzStorageContainerSASToken

## SYNOPSIS
Generates an SAS token for an Azure storage container.

## SYNTAX

### SasPolicy
```
New-AzStorageContainerSASToken [-Name] <String> -Policy <String> [-Protocol <SharedAccessProtocol>]
 [-IPAddressOrRange <String>] [-StartTime <DateTime>] [-ExpiryTime <DateTime>] [-FullUri]
 [-EncryptionScope <String>] [-Context <IStorageContext>] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SasPermission
```
New-AzStorageContainerSASToken [-Name] <String> [-Permission <String>] [-Protocol <SharedAccessProtocol>]
 [-IPAddressOrRange <String>] [-StartTime <DateTime>] [-ExpiryTime <DateTime>] [-FullUri]
 [-EncryptionScope <String>] [-Context <IStorageContext>] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzStorageContainerSASToken** cmdlet generates a Shared Access Signature (SAS) token for an Azure storage container.

## EXAMPLES

### Example 1: Generate a container SAS token with full container permission
```powershell
New-AzStorageContainerSASToken -Name "Test" -Permission rwdl
```

This example generates a container SAS token with full container permission.

### Example 2: Generate multiple container SAS token by pipeline
```powershell
Get-AzStorageContainer -Container test* | New-AzStorageContainerSASToken -Permission rwdl
```

This example generates multiple container SAS tokens by using the pipeline.

### Example 3: Generate container SAS token with shared access policy
```powershell
New-AzStorageContainerSASToken -Name "Test" -Policy "PolicyName"
```

This example generates a container SAS token with shared access policy.

### Example 3: Generate a User Identity container SAS token with storage context based on OAuth authentication
```powershell
$ctx = New-AzStorageContext -StorageAccountName $accountName -UseConnectedAccount
$StartTime = Get-Date
$EndTime = $startTime.AddDays(6)
New-AzStorageContainerSASToken -Name "ContainerName" -Permission rwd -StartTime $StartTime -ExpiryTime $EndTime -context $ctx
```

This example generates a User Identity container SAS token with storage context based on OAuth authentication

## PARAMETERS

### -Context
Specifies an Azure storage context.
You can create it by using the New-AzStorageContext cmdlet.
When the storage context is based on OAuth authentication, will generates a User Identity container SAS token.

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
Specifies the time at which the shared access signature becomes invalid.
If the user sets the start time but not the expiry time, the expiry time is set to the start time plus one hour.
If neither the start time nor the expiry time is specified, the expiry time is set to the current time plus one hour.
When the storage context is based on OAuth authentication, the expire time must be in 7 days from current time, and must not be earlier than current time.

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

### -FullUri
Indicates that this cmdlet return the full blob URI and the shared access signature token.

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

### -IPAddressOrRange
Specifies the IP address or range of IP addresses from which to accept requests, such as 168.1.5.65 or 168.1.5.60-168.1.5.70.
The range is inclusive.

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

### -Name
Specifies an Azure storage container name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: N, Container

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Permission
Specifies permissions for a storage container.
It is important to note that this is a string, like `rwd` (for Read, Write and Delete). The permissions that are supported for container resource type are described [here](https://learn.microsoft.com/rest/api/storageservices/create-service-sas#permissions-for-a-directory-container-or-blob).

```yaml
Type: System.String
Parameter Sets: SasPermission
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Policy
Specifies an Azure Stored Access Policy.

```yaml
Type: System.String
Parameter Sets: SasPolicy
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
Specifies the protocol permitted for a request.
The acceptable values for this parameter are:
* HttpsOnly
* HttpsOrHttp
The default value is HttpsOrHttp.

```yaml
Type: System.Nullable`1[Microsoft.Azure.Storage.SharedAccessProtocol]
Parameter Sets: (All)
Aliases:
Accepted values: HttpsOnly, HttpsOrHttp

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTime
Specifies the time at which the shared access signature becomes valid.

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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### System.String

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS

[New-AzStorageBlobSASToken](./New-AzStorageBlobSASToken.md)
