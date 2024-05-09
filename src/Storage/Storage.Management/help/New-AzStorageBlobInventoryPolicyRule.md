---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll-Help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/new-azstorageblobinventorypolicyrule
schema: 2.0.0
---

# New-AzStorageBlobInventoryPolicyRule

## SYNOPSIS
Creates a blob inventory policy rule object, which can be used in Set-AzStorageBlobInventoryPolicy.

## SYNTAX

### BlobRuleParameterSet (Default)
```
New-AzStorageBlobInventoryPolicyRule [-Name] <String> [-Disabled] -Destination <String> -Format <String>
 -Schedule <String> -BlobSchemaField <String[]> -BlobType <String[]> [-PrefixMatch <String[]>]
 [-ExcludePrefix <String[]>] [-IncludeSnapshot] [-IncludeBlobVersion] [-IncludeDeleted]
 [-CreationTimeLastNDay <Int32>] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ContainerRuleParameterSet
```
New-AzStorageBlobInventoryPolicyRule [-Name] <String> [-Disabled] -Destination <String> -Format <String>
 -Schedule <String> -ContainerSchemaField <String[]> [-PrefixMatch <String[]>] [-ExcludePrefix <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzStorageBlobInventoryPolicyRule** cmdlet creates a blob inventory policy rule object, which can be used in Set-AzStorageBlobInventoryPolicy.

## EXAMPLES

### Example 1: Create blob inventory policy rule objects, then sets blob inventory policy with the rule objects.
<!-- Skip: Output cannot be splitted from code -->

```
$rule1 = New-AzStorageBlobInventoryPolicyRule -Name Test1 -Destination $containerName -Disabled -Format Csv -Schedule Daily -ContainerSchemaField Name,Metadata,PublicAccess,Last-mOdified,LeaseStatus,LeaseState,LeaseDuration,HasImmutabilityPolicy,HasLegalHold -PrefixMatch con1,con2

$rule2 = New-AzStorageBlobInventoryPolicyRule -Name Test2 -Destination $containerName -Format Parquet -Schedule Weekly  -IncludeSnapshot -BlobType blockBlob,appendBlob -PrefixMatch aaa,bbb `
                -BlobSchemaField name,Creation-Time,Last-Modified,Content-Length,Content-MD5,BlobType,AccessTier,AccessTierChangeTime,Expiry-Time,hdi_isfolder,Owner,Group,Permissions,Acl,Metadata -CreationTimeLastNDay 30
$rule3 = New-AzStorageBlobInventoryPolicyRule -Name Test3 -Destination $containerName -Format Parquet -Schedule Weekly  -IncludeSnapshot -IncludeDeleted -BlobType blockBlob,appendBlob -PrefixMatch aaa,bbb `
                 -ExcludePrefix ccc,ddd -BlobSchemaField name,Last-Modified,BlobType,AccessTier,AccessTierChangeTime,Content-Type,Content-CRC64,CopyId,DeletionId,Deleted,DeletedTime,RemainingRetentionDays

$policy = Set-AzStorageBlobInventoryPolicy -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -Disabled -Rule $rule1,$rule2

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

Name  Enabled Destination   ObjectType Format  Schedule IncludeSnapshots IncludeBlobVersions IncludeDeleted BlobTypes               PrefixMatch  ExcludePrefix SchemaFields                                            CreationTime
----  ------- -----------   ---------- ------  -------- ---------------- ------------------- -------------- ---------               -----------  ------------- ------------                                            ------------
Test1 False   containername Container  Csv     Daily                                                                                {con1, con2}               {Name, Metadata, PublicAccess, Last-Modified...}                    
Test2 True    containername Blob       Parquet Weekly   True                                                {blockBlob, appendBlob} {aaa, bbb}                 {Name, Creation-Time, Last-Modified, Content-Length...} LastNDays=30
Test3 True    containername Blob       Parquet Weekly   True                                 True           {blockBlob, appendBlob} {aaa, bbb}   {ccc, ddd}    {Name, Last-Modified, BlobType, AccessTier...}
```

This first 3 commands create 3 BlobInventoryPolicy rule objects: rule "Test1" for contaienr inventory; rule "Test2" for blob inventory; rule "Test3" for blob inventory with more schema fields, excludePrefix specified, and IncludeDeleted enabled.
The following command sets blob inventory policy to a Storage account with the 3 rule objects, then show the updated policy and rules properties.

## PARAMETERS

### -BlobSchemaField
Specifies the fields and properties of the Blob object to be included in the inventory. Valid values include: Name, Creation-Time, Last-Modified, Content-Length, Content-MD5, BlobType, AccessTier, AccessTierChangeTime, Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl, Metadata, LastAccessTime, AccessTierInferred, Tags. 
'Name' is a required schemafield. Schema field values 'Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl' are valid only for HierarchicalNamespace enabled accounts.'Tags' field is only valid for non HierarchicalNamespace accounts.
If specify '-IncludeSnapshot', will include 'Snapshot'  in the inventory.  If specify '-IncludeBlobVersion', will include 'VersionId, 'IsCurrentVersion' in the inventory.

```yaml
Type: System.String[]
Parameter Sets: BlobRuleParameterSet
Aliases:
Accepted values: Name, Creation-Time, Last-Modified, Content-Length, Content-MD5, BlobType, AccessTier, AccessTierChangeTime, Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl, Metadata, LastAccessTime, AccessTierInferred, Tags, Etag, Content-Type, Content-Encoding, Content-Language, Content-CRC64, Cache-Control, Content-Disposition, LeaseStatus, LeaseState, LeaseDuration, ServerEncrypted, Deleted, RemainingRetentionDays, ImmutabilityPolicyUntilDate, ImmutabilityPolicyMode, LegalHold, CopyId, CopyStatus, CopySource, CopyProgress, CopyCompletionTime, CopyStatusDescription, CustomerProvidedKeySha256, RehydratePriority, ArchiveStatus, x-ms-blob-sequence-number, EncryptionScope, IncrementalCopy, DeletionId, DeletedTime, TagCount

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlobType
Sets the blob types for the blob inventory policy rule.
Valid values include blockBlob, appendBlob, pageBlob.
Hns accounts does not support pageBlobs.

```yaml
Type: System.String[]
Parameter Sets: BlobRuleParameterSet
Aliases:
Accepted values: blockBlob, pageBlob, appendBlob

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerSchemaField
Specifies the fields and properties of the container object to be included in the inventory. Valid values include: Name, Last-Modified, Metadata, LeaseStatus, LeaseState, LeaseDuration, PublicAccess, HasImmutabilityPolicy, HasLegalHold. 'Name' is a required schemafield.

```yaml
Type: System.String[]
Parameter Sets: ContainerRuleParameterSet
Aliases:
Accepted values: Name, Last-Modified, Metadata, LeaseStatus, LeaseState, LeaseDuration, PublicAccess, HasImmutabilityPolicy, HasLegalHold, Etag, DefaultEncryptionScope, DenyEncryptionScopeOverride, ImmutableStorageWithVersioningEnabled, Deleted, Version, DeletedTime, RemainingRetentionDays

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreationTimeLastNDay
Filter the objects which has creation time in last N days. The valid value is between 1 to 36500. Inventory schema 'Creation-Time' is mandatory with this filter.

```yaml
Type: System.Int32
Parameter Sets: BlobRuleParameterSet
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

### -Destination
The container name where blob inventory files are stored. Must be pre-created.

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

### -Disabled
The rule is disabled if set it.

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

### -ExcludePrefix
Sets an array of strings with maximum 10 blob prefixes to be excluded from the inventory.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Format
Specifies the format for the inventory files. Possible values include: 'Csv', 'Parquet'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Csv, Parquet

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeBlobVersion
The rule is disabled if set it.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: BlobRuleParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeDeleted
Includes deleted blob in blob inventory. When include delete blob, for ContainerSchemaFields, must include 'Deleted, Version, DeletedTime and RemainingRetentionDays'. For BlobSchemaFields, on HNS enabled storage accounts, must include 'DeletionId, Deleted, DeletedTime and RemainingRetentionDays', and on Hns disabled accounts must include 'Deleted and RemainingRetentionDays', else they must be excluded.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: BlobRuleParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeSnapshot
The rule is disabled if set it.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: BlobRuleParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
A rule name can contain any combination of alpha numeric characters.
Rule name is case-sensitive.
It must be unique within a policy.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrefixMatch
Sets an array of strings for blob prefixes to be matched..

```yaml
Type: System.String[]
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

### -Schedule
This field is used to schedule an inventory formation. Possible values include: 'Daily', 'Weekly'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Daily, Weekly

Required: True
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

### Microsoft.Azure.Commands.Management.Storage.Models.PSBlobInventoryPolicyRule

## NOTES

## RELATED LINKS
