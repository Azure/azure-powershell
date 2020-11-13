---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/new-azstorageblobinventorypolicyrule
schema: 2.0.0
---

# New-AzStorageBlobInventoryPolicyRule

## SYNOPSIS
Creates a blob inventory policy rule object, which can be used in Set-AzStorageBlobInventoryPolicy.

## SYNTAX

```
New-AzStorageBlobInventoryPolicyRule [-Name] <String> [-Disabled] -BlobType <String[]>
 [-PrefixMatch <String[]>] [-IncludeSnapshot] [-IncludeBlobVersion] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzStorageBlobInventoryPolicyRule** cmdlet creates a blob inventory policy rule object, which can be used in Set-AzStorageBlobInventoryPolicy.

## EXAMPLES

### Example 1: Create blob inventory policy rule objects, then sets blob inventory policy with the rule objects.
```
PS C:\> $rule1 = New-AzStorageBlobInventoryPolicyRule -Name Test1 -BlobType blockBlob -PrefixMatch prefix1,prefix2 -IncludeSnapshot -IncludeBlobVersion

PS C:\> $rule2 = New-AzStorageBlobInventoryPolicyRule -Name Test2 -BlobType blockBlob,appendBlob,pageBlob -IncludeSnapshot -Disabled 

PS C:\> $policy = Set-AzStorageBlobInventoryPolicy "myresourcegroup" -AccountName "mystorageaccount"  -Disabled -Destination "containername" -Rule $rule1,$rule2

PS C:\> $policy

StorageAccountName : mystorageaccount
ResourceGroupName  : myresourcegroup
Name               : DefaultInventoryPolicy
Id                 : /subscriptions/45b60d85-fd72-427a-a708-f994d26e593e/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/mystorageaccount/inventoryPolicies/default
Type               : Microsoft.Storage/storageAccounts/inventoryPolicies
LastModifiedTime   : 11/4/2020 9:23:36 AM
Destination        : containername
Enabled            : False
Rules              : {Test1, Test2}

PS C:\> $policy.Rules

Name  Enabled IncludeSnapshots IncludeBlobVersions BlobTypes                         PrefixMatch       
----  ------- ---------------- ------------------- ---------                         -----------       
Test1 True    True             True                blockBlob                         {prefix1, prefix2}
Test2 False   True             False               {blockBlob, appendBlob, pageBlob}
```

This command first creates 2 BlobInventoryPolicy rule objects, then sets blob inventory policy of a Storage account with the 2 rule objects, finally show the updated policy and rules properties.

## PARAMETERS

### -BlobType
Sets the blob types for the blob inventory policy rule.
Valid values include blockBlob, appendBlob, pageBlob.
Hns accounts does not support pageBlobs.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:
Accepted values: blockBlob, pageBlob, appendBlob

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

### -IncludeBlobVersion
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

### -IncludeSnapshot
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSBlobInventoryPolicyRule

## NOTES

## RELATED LINKS
