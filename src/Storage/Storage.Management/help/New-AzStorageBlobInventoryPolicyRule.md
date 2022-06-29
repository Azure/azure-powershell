---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/powershell/module/az.storage/new-azstorageblobinventorypolicyrule
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
 [-IncludeSnapshot] [-IncludeBlobVersion] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ContainerRuleParameterSet
```
New-AzStorageBlobInventoryPolicyRule [-Name] <String> [-Disabled] -Destination <String> -Format <String>
 -Schedule <String> -ContainerSchemaField <String[]> [-PrefixMatch <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzStorageBlobInventoryPolicyRule** cmdlet creates a blob inventory policy rule object, which can be used in Set-AzStorageBlobInventoryPolicy.

## EXAMPLES

### Example 1: Create blob inventory policy rule objects, then sets blob inventory policy with the rule objects.
```
PS C:\> $rule1 = New-AzStorageBlobInventoryPolicyRule -Name Test1 -Destination $containerName -Disabled -Format Csv -Schedule Daily -ContainerSchemaField Name,Metadata,PublicAccess,Last-mOdified,LeaseStatus,LeaseState,LeaseDuration,HasImmutabilityPolicy,HasLegalHold -PrefixMatch con1,con2

PS C:\> $rule2 = New-AzStorageBlobInventoryPolicyRule -Name Test2 -Destination $containerName -Format Parquet -Schedule Weekly -IncludeBlobVersion -IncludeSnapshot -BlobType blockBlob,appendBlob -PrefixMatch aaa,bbb `
                -BlobSchemaField name,Creation-Time,Last-Modified,Content-Length,Content-MD5,BlobType,AccessTier,AccessTierChangeTime,Expiry-Time,hdi_isfolder,Owner,Group,Permissions,Acl,Metadata

PS C:\> $policy = Set-AzStorageBlobInventoryPolicy -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -Disabled -Rule $rule1,$rule2

PS C:\> $policy

StorageAccountName : mystorageaccount
ResourceGroupName  : myresourcegroup
Name               : DefaultInventoryPolicy
Id                 : /subscriptions/{subscription-Id}/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/mystorageaccount/inventoryPolicies/default
Type               : Microsoft.Storage/storageAccounts/inventoryPolicies
LastModifiedTime   : 5/12/2021 8:53:38 AM
Enabled            : False
Rules              : {Test1, Test2}

PS C:\> $policy.Rules

Name  Enabled Destination   ObjectType Format  Schedule IncludeSnapshots IncludeBlobVersions BlobTypes               PrefixMatch  SchemaFields                                           
----  ------- -----------   ---------- ------  -------- ---------------- ------------------- ---------               -----------  ------------                                           
Test1 False   containername Container  Csv     Daily                                                                 {con1, con2} {Name, Metadata, PublicAccess, Last-Modified...}       
Test2 True    containername Blob       Parquet Weekly   True             True                {blockBlob, appendBlob} {aaa, bbb}   {Name, Creation-Time, Last-Modified, Content-Length...}
```

This first 2 commands create 2 BlobInventoryPolicy rule objects: rule "Test1" for contaienr inventory; rule "Test2" for blob inventory.
The following command sets blob inventory policy to a Storage account with the 2 rule objects, then show the updated policy and rules properties.

## PARAMETERS

### -BlobSchemaField
Specifies the fields and properties of the Blob object to be included in the inventory. Valid values include: Name, Creation-Time, Last-Modified, Content-Length, Content-MD5, BlobType, AccessTier, AccessTierChangeTime, Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl, Metadata, LastAccessTime, AccessTierInferred, Tags. 
'Name' is a required schemafield. Schema field values 'Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl' are valid only for HierarchicalNamespace enabled accounts.'Tags' field is only valid for non HierarchicalNamespace accounts.
If specify '-IncludeSnapshot', will include 'Snapshot'  in the inventory.  If specify '-IncludeBlobVersion', will include 'VersionId, 'IsCurrentVersion' in the inventory.

```yaml
Type: System.String[]
Parameter Sets: BlobRuleParameterSet
Aliases:
Accepted values: Name, Creation-Time, Last-Modified, Content-Length, Content-MD5, BlobType, AccessTier, AccessTierChangeTime, Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl, Metadata, LastAccessTime, AccessTierInferred, Tags

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
Accepted values: Name, Last-Modified, Metadata, LeaseStatus, LeaseState, LeaseDuration, PublicAccess, HasImmutabilityPolicy, HasLegalHold

Required: True
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSBlobInventoryPolicyRule

## NOTES

## RELATED LINKS
