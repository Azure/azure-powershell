---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll-Help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/update-azstorageblobserviceproperty
schema: 2.0.0
---

# Update-AzStorageBlobServiceProperty

## SYNOPSIS
Modifies the service properties for the Azure Storage Blob service.

## SYNTAX

### AccountName (Default)
```
Update-AzStorageBlobServiceProperty [-ResourceGroupName] <String> [-StorageAccountName] <String>
 [-DefaultServiceVersion <String>] [-EnableChangeFeed <Boolean>] [-ChangeFeedRetentionInDays <Int32>]
 [-IsVersioningEnabled <Boolean>] [-CorsRule <PSCorsRule[]>] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AccountObject
```
Update-AzStorageBlobServiceProperty -StorageAccount <PSStorageAccount> [-DefaultServiceVersion <String>]
 [-EnableChangeFeed <Boolean>] [-ChangeFeedRetentionInDays <Int32>] [-IsVersioningEnabled <Boolean>]
 [-CorsRule <PSCorsRule[]>] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BlobServicePropertiesResourceId
```
Update-AzStorageBlobServiceProperty [-ResourceId] <String> [-DefaultServiceVersion <String>]
 [-EnableChangeFeed <Boolean>] [-ChangeFeedRetentionInDays <Int32>] [-IsVersioningEnabled <Boolean>]
 [-CorsRule <PSCorsRule[]>] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzStorageBlobServiceProperty** cmdlet modifies the service properties for the Azure Storage Blob service.

## EXAMPLES

### Example 1: Set Blob service DefaultServiceVersion to 2018-03-28
```powershell
Update-AzStorageBlobServiceProperty -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -DefaultServiceVersion 2018-03-28
```

```output
StorageAccountName            : mystorageaccount
ResourceGroupName             : myresourcegroup
DefaultServiceVersion         : 2018-03-28
DeleteRetentionPolicy.Enabled : False
DeleteRetentionPolicy.Days    : 
RestorePolicy.Enabled         : 
RestorePolicy.Days            : 
ChangeFeed.Enabled            : 
ChangeFeed.RetentionInDays    :
IsVersioningEnabled           :
```

This command sets the DefaultServiceVersion of Blob Service to 2018-03-28.

### Example 2: Enable Changefeed on Blob service of a Storage account with ChangeFeedRetentionInDays as 5 days
```powershell
Update-AzStorageBlobServiceProperty -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -EnableChangeFeed $true -ChangeFeedRetentionInDays 5
```

```output
StorageAccountName            : mystorageaccount
ResourceGroupName             : myresourcegroup
DefaultServiceVersion         : 
DeleteRetentionPolicy.Enabled : False
DeleteRetentionPolicy.Days    : 
RestorePolicy.Enabled         : 
RestorePolicy.Days            : 
ChangeFeed.Enabled            : True
ChangeFeed.RetentionInDays    : 5
IsVersioningEnabled           :
```

This command enables Changefeed on Blob service of a Storage account with ChangeFeedRetentionInDays as 5 days.
Change feed support in Azure Blob Storage works by listening to a GPv2 or Blob storage account for any blob level creation, modification, or deletion events. 
It then outputs an ordered log of events for the blobs stored in the $blobchangefeed container within the storage account. 
The serialized changes are persisted as an Apache Avro file and can be processed asynchronously and incrementally.
If not specify ChangeFeedRetentionInDays, will get null value in service properties, indicates an infinite retention of the change feed.

### Example 3: Enable Versioning on Blob service of a Storage account
```powershell
Update-AzStorageBlobServiceProperty -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -IsVersioningEnabled $true
```

```output
StorageAccountName            : mystorageaccount
ResourceGroupName             : myresourcegroup
DefaultServiceVersion         : 
DeleteRetentionPolicy.Enabled : False
DeleteRetentionPolicy.Days    : 
RestorePolicy.Enabled         : 
RestorePolicy.Days            : 
ChangeFeed                    : 
ChangeFeed.RetentionInDays    :
IsVersioningEnabled           : True
```

This command enables Versioning on Blob service of a Storage account

### Example 4: Update CORS rules
```powershell
$CorsRules = (@{
    AllowedHeaders=@("x-ms-blob-content-type","x-ms-blob-content-disposition");
    ExposedHeaders=@(); 
    AllowedOrigins=@("*");
    AllowedMethods=@("TRACE","CONNECT")},
    @{
    AllowedOrigins=@("http://www.fabrikam.com","http://www.contoso.com"); 
    ExposedHeaders=@("x-ms-meta-data*","x-ms-meta-customheader"); 
    AllowedHeaders=@("x-ms-meta-target*","x-ms-meta-customheader");
    MaxAgeInSeconds=30;
    AllowedMethods=@("PUT")})

$property = Update-AzStorageBlobServiceProperty -ResourceGroupName myresourcegroup -StorageAccountName mystorageaccount -CorsRule $CorsRules
$property.Cors.CorsRulesProperty
```

```output
AllowedOrigins  : {*}
AllowedMethods  : {TRACE, CONNECT}
MaxAgeInSeconds : 0
ExposedHeaders  : {}
AllowedHeaders  : {x-ms-blob-content-type, x-ms-blob-content-disposition}

AllowedOrigins  : {http://www.fabrikam.com, http://www.contoso.com}
AllowedMethods  : {PUT}
MaxAgeInSeconds : 30
ExposedHeaders  : {x-ms-meta-customheader, x-ms-meta-data*}
AllowedHeaders  : {x-ms-meta-customheader, x-ms-meta-target*}
```

The first command assigns an array of rules to the $CorsRules variable. This command uses standard extends over several lines in this code block.
The second command sets the rules in $CorsRules to the Blob service of a Storage account.

### Example 5: Clean up CORS rules
```powershell
Update-AzStorageBlobServiceProperty -ResourceGroupName myresourcegroup -StorageAccountName mystorageaccount -CorsRule @()
```

This command cleans up the CORS rules of a Storage account by inputting @() to parameter CorsRule

## PARAMETERS

### -ChangeFeedRetentionInDays
Indicates the duration of changeFeed retention in days. Minimum value is 1 day and maximum value is 146000 days (400 years). 
Never specify it when enabled changeFeed will get null value in service properties, indicates an infinite retention of the change feed.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CorsRule
Specifies CORS rules for the Blob service.

```yaml
Type: Microsoft.Azure.Commands.Management.Storage.Models.PSCorsRule[]
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

### -DefaultServiceVersion
Default Service Version to Set

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

### -EnableChangeFeed
Enable Change Feed logging for the storage account by set to $true, disable Change Feed logging by set to $false.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsVersioningEnabled
Gets or sets versioning is enabled if set to true.

```yaml
Type: System.Boolean
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

### -ResourceGroupName
Resource Group Name.

```yaml
Type: System.String
Parameter Sets: AccountName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Input a Storage account Resource Id, or a Blob service properties Resource Id.

```yaml
Type: System.String
Parameter Sets: BlobServicePropertiesResourceId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageAccount
Storage account object

```yaml
Type: Microsoft.Azure.Commands.Management.Storage.Models.PSStorageAccount
Parameter Sets: AccountObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StorageAccountName
Storage Account Name.

```yaml
Type: System.String
Parameter Sets: AccountName
Aliases: AccountName, Name

Required: True
Position: 1
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

### Microsoft.Azure.Commands.Management.Storage.Models.PSStorageAccount

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSBlobServiceProperties

## NOTES

## RELATED LINKS
