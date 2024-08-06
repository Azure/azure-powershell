---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll-Help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/set-azstorageblobinventorypolicy
schema: 2.0.0
---

# Set-AzStorageBlobInventoryPolicy

## SYNOPSIS
Creates or updates blob inventory policy in a Storage account.

## SYNTAX

### AccountNamePolicyRule (Default)
```
Set-AzStorageBlobInventoryPolicy [-ResourceGroupName] <String> [-StorageAccountName] <String>
 -Rule <PSBlobInventoryPolicyRule[]> [-Disabled] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AccountNamePolicyObject
```
Set-AzStorageBlobInventoryPolicy [-ResourceGroupName] <String> [-StorageAccountName] <String>
 -Policy <PSBlobInventoryPolicy> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AccountObjectPolicyRule
```
Set-AzStorageBlobInventoryPolicy -StorageAccount <PSStorageAccount> -Rule <PSBlobInventoryPolicyRule[]>
 [-Disabled] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### AccountObjectPolicyObject
```
Set-AzStorageBlobInventoryPolicy -StorageAccount <PSStorageAccount> -Policy <PSBlobInventoryPolicy>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### AccountResourceIdPolicyRule
```
Set-AzStorageBlobInventoryPolicy [-StorageAccountResourceId] <String> -Rule <PSBlobInventoryPolicyRule[]>
 [-Disabled] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### AccountResourceIdPolicyObject
```
Set-AzStorageBlobInventoryPolicy [-StorageAccountResourceId] <String> -Policy <PSBlobInventoryPolicy>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzStorageBlobInventoryPolicy** cmdlet creates or updates blob inventory policy in a Storage account.

## EXAMPLES

### Example 1: Create or update the blob inventory policy with BlobInventoryPolicy rule objects.
<!-- Skip: Output cannot be splitted from code -->


```
$rule1 = New-AzStorageBlobInventoryPolicyRule -Name Test1 -Destination $containerName -Disabled -Format Csv -Schedule Daily -ContainerSchemaField Name,Metadata,PublicAccess,Last-mOdified,LeaseStatus,LeaseState,LeaseDuration,HasImmutabilityPolicy,HasLegalHold -PrefixMatch con1,con2

$rule2 = New-AzStorageBlobInventoryPolicyRule -Name Test2 -Destination $containerName -Format Parquet -Schedule Weekly -IncludeBlobVersion -IncludeSnapshot -BlobType blockBlob,appendBlob -PrefixMatch aaa,bbb `
                -BlobSchemaField name,Creation-Time,Last-Modified,Content-Length,Content-MD5,BlobType,AccessTier,AccessTierChangeTime,Expiry-Time,hdi_isfolder,Owner,Group,Permissions,Acl,Metadata

$rule3 = New-AzStorageBlobInventoryPolicyRule -Name Test3 -Destination $containerName -Format Parquet -Schedule Weekly -IncludeBlobVersion -IncludeSnapshot -IncludeDeleted -BlobType blockBlob,appendBlob -PrefixMatch aaa,bbb `
                -ExcludePrefix ccc,ddd -BlobSchemaField name,Last-Modified,BlobType,AccessTier,AccessTierChangeTime,Content-Type,Content-CRC64,CopyId,x-ms-blob-sequence-number,TagCount

$policy = Set-AzStorageBlobInventoryPolicy -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -Disabled -Rule $rule1,$rule2,$rule3

$policy

StorageAccountName : mystorageaccount
ResourceGroupName  : myresourcegroup
Name               : DefaultInventoryPolicy
Id                 : /subscriptions/{subscription-Id}/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/mystorageaccount/inventoryPolicies/default
Type               : Microsoft.Storage/storageAccounts/inventoryPolicies
LastModifiedTime   : 5/12/2021 8:53:38 AM
Enabled            : False
Rules              : {Test1, Test2, Test3}

$policy.Rules

Name  Enabled Destination   ObjectType Format  Schedule IncludeSnapshots IncludeBlobVersions IncludeDeleted BlobTypes               PrefixMatch ExcludePrefix  SchemaFields                                           
----  ------- -----------   ---------- ------  -------- ---------------- ------------------- -------------- ---------               ----------- -------------  ------------                                           
Test1 False   containername Container  Csv     Daily                                                                                {con1, con2}               {Name, Metadata, PublicAccess, Last-Modified...}       
Test2 True    containername Blob       Parquet Weekly   True             True                               {blockBlob, appendBlob} {aaa, bbb}                 {Name, Creation-Time, Last-Modified, Content-Length...}
Test3 True    containername Blob       Parquet Weekly   True             True                True           {blockBlob, appendBlob} {aaa, bbb}  {ccc, ddd}     {Name, Content-Type, Content-CRC64, Last-Modified...}
```

This first 2 commands create 3 BlobInventoryPolicy rule objects: rule "Test1" for contaienr inventory; rule "Test2" and "Test3" for blob inventory.
The following command sets blob inventory policy to a Storage account with the 2 rule objects, then show the updated policy and rules properties.

### Example 2: Create or update the blob inventory policy of a Storage account with a Json format policy.
<!-- Skip: Output cannot be splitted from code -->


```
$policy = Set-AzStorageBlobInventoryPolicy -ResourceGroupName $resourceGroupName  -StorageAccountName $accountName -Policy (@{
                Enabled=$true;
                Rules=(@{
                    Enabled=$true;
                    Name="Test1";
                    Destination=$containerName;
                    Definition=(@{
                        ObjectType="Blob";
                        Format="Csv";
                        Schedule="Weekly";
                        SchemaFields=@("name","Content-Length","BlobType","Snapshot","VersionId","IsCurrentVersion");
                        Filters=(@{
                            BlobTypes=@("blockBlob","appendBlob");
                            PrefixMatch=@("prefix1","prefix2");
                            IncludeSnapshots=$true;
                            IncludeBlobVersions=$true;
                        })
                    })
                },
                @{
                    Enabled=$false;
                    Name="Test2";
                    Destination=$containerName;
                    Definition=(@{
                        ObjectType="Container";
                        Format="Parquet";
                        Schedule="Daily";
                        SchemaFields=@("name","Metadata","PublicAccess","DefaultEncryptionScope","DenyEncryptionScopeOverride");
                        Filters=(@{
                            PrefixMatch=@("conpre1","conpre2");
                        })
                    })
                },
                @{
                    Enabled=$false;
                    Name="Test3";
                    Destination=$containerName;
                    Definition=(@{
                        ObjectType="Blob";
                        Format="Csv";
                        Schedule="Weekly";
                        SchemaFields=@("name","Deleted","RemainingRetentionDays","Content-Type","Content-Language","Cache-Control","Content-Disposition");
                        Filters=(@{
                            BlobTypes=@("blockBlob","appendBlob");
                            PrefixMatch=@("conpre1","conpre2");
                            ExcludePrefix=@("expre1","expre2");
                            IncludeDeleted=$true
                        })
                    })
                })
            })


$policy

StorageAccountName : weiadlscanary1
ResourceGroupName  : weitry
Name               : DefaultInventoryPolicy
Id                 : /subscriptions/{subscription-Id}/resourceGroups/weitry/providers/Microsoft.Storage/storageAccounts/weiadlscanary1/inventoryPolicies/default
Type               : Microsoft.Storage/storageAccounts/inventoryPolicies
LastModifiedTime   : 5/12/2021 9:02:21 AM
Enabled            : True
Rules              : {Test1, Test2, Test3}

$policy.Rules 

Name  Enabled Destination   ObjectType Format  Schedule IncludeSnapshots IncludeBlobVersions IncludeDeleted BlobTypes               PrefixMatch        ExcludePrefix    SchemaFields                                           
----  ------- -----------   ---------- ------  -------- ---------------- ------------------- -------------- ---------               -----------        -------------    ------------                                           
Test1 True    containername Blob       Csv     Weekly   True             True                               {blockBlob, appendBlob} {prefix1, prefix2}                  {Name, Content-Length, BlobType, Snapshot...}     
Test2 False   containername Container  Parquet Daily                                                                                {conpre1, conpre2}                  {Name, Metadata, PublicAccess} 
Test3 False   containername Blob       Csv     Weekly                                        True           {blockBlob, appendBlob} {conpre1, conpre2} {expre1, expre2} {Name, Content-Type, Content-Cache, Content-Language...}                                                                                    {name, Metadata, PublicAccess}
```

This command creates or updates the blob inventory policy of a Storage account with a json format policy.

### Example 3: Get the blob inventory policy from a Storage account, then set it to another Storage account.
```powershell
$policy = Get-AzStorageBlobInventoryPolicy -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" | Set-AzStorageBlobInventoryPolicy -ResourceGroupName "myresourcegroup2" -AccountName "mystorageaccount2"
```

This command first gets the blob inventory policy from a Storage account, then set it to another Storage account.
The proeprties： Destination, Enabled, and Rules of the policy will be set to the destination account.

### Example 4: Get the blob inventory policy rules from a Storage account, then set it to another Storage account.
```powershell
$policy = ,((Get-AzStorageBlobInventoryPolicy -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount").Rules) | Set-AzStorageBlobInventoryPolicy -ResourceGroupName "myresourcegroup2" -AccountName "mystorageaccount2" -Disabled
```

This command first gets the blob inventory policy from a Storage account, then set it's rules to another Storage account.

## PARAMETERS

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

### -Disabled
The Blob Inventory Policy is enabled by default, specify this parameter to disable it.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AccountNamePolicyRule, AccountObjectPolicyRule, AccountResourceIdPolicyRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Policy
Blob Inventory Policy Object to Set

```yaml
Type: Microsoft.Azure.Commands.Management.Storage.Models.PSBlobInventoryPolicy
Parameter Sets: AccountNamePolicyObject, AccountObjectPolicyObject, AccountResourceIdPolicyObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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
Parameter Sets: AccountNamePolicyRule, AccountNamePolicyObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Rule
The Blob Inventory  Policy rules.
Get the object with New-AzStorageBlobInventoryPolicyRule cmdlet.

```yaml
Type: Microsoft.Azure.Commands.Management.Storage.Models.PSBlobInventoryPolicyRule[]
Parameter Sets: AccountNamePolicyRule, AccountObjectPolicyRule, AccountResourceIdPolicyRule
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StorageAccount
Storage account object

```yaml
Type: Microsoft.Azure.Commands.Management.Storage.Models.PSStorageAccount
Parameter Sets: AccountObjectPolicyRule, AccountObjectPolicyObject
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
Parameter Sets: AccountNamePolicyRule, AccountNamePolicyObject
Aliases: AccountName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountResourceId
Storage Account Resource Id.

```yaml
Type: System.String
Parameter Sets: AccountResourceIdPolicyRule, AccountResourceIdPolicyObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### Microsoft.Azure.Commands.Management.Storage.Models.PSBlobInventoryPolicyRule[]

### Microsoft.Azure.Commands.Management.Storage.Models.PSBlobInventoryPolicySchema

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSManagementPolicy

## NOTES

## RELATED LINKS
