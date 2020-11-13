---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/set-azstorageblobinventorypolicy
schema: 2.0.0
---

# Set-AzStorageBlobInventoryPolicy

## SYNOPSIS
Creates or updates blob inventory policy in a Storage account.

## SYNTAX

### AccountNamePolicyRule (Default)
```
Set-AzStorageBlobInventoryPolicy [-ResourceGroupName] <String> [-StorageAccountName] <String>
 -Rule <PSBlobInventoryPolicyRule[]> [-Disabled] -Destination <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AccountNamePolicyObject
```
Set-AzStorageBlobInventoryPolicy [-ResourceGroupName] <String> [-StorageAccountName] <String>
 -Policy <PSBlobInventoryPolicy> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### AccountObjectPolicyRule
```
Set-AzStorageBlobInventoryPolicy -StorageAccount <PSStorageAccount> -Rule <PSBlobInventoryPolicyRule[]>
 [-Disabled] -Destination <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### AccountObjectPolicyObject
```
Set-AzStorageBlobInventoryPolicy -StorageAccount <PSStorageAccount> -Policy <PSBlobInventoryPolicy>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AccountResourceIdPolicyRule
```
Set-AzStorageBlobInventoryPolicy [-StorageAccountResourceId] <String> -Rule <PSBlobInventoryPolicyRule[]>
 [-Disabled] -Destination <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### AccountResourceIdPolicyObject
```
Set-AzStorageBlobInventoryPolicy [-StorageAccountResourceId] <String> -Policy <PSBlobInventoryPolicy>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzStorageBlobInventoryPolicy** cmdlet creates or updates blob inventory policy in a Storage account.

## EXAMPLES

### Example 1: Create or update the blob inventory policy with BlobInventoryPolicy rule objects.
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

### Example 2: Create or update the blob inventory policy of a Storage account with a Json format policy.
```
PS C:\> Set-AzStorageBlobInventoryPolicy -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -Policy (@{
            Enabled=$true;
            Destination=$containerName;
            Rules=(@{
                Enabled=$true;
                Name="Test1";
                Definition=(@{
                    Filters=(@{
                        BlobTypes=@("blockBlob");
                        PrefixMatch=@("prefix1","prefix2");
                        IncludeSnapshots=$true;
                        IncludeBlobVersions=$true;
                    })
                })
            },
            @{
                Enabled=$false;
                Name="Test2";
                Definition=(@{
                    Filters=(@{
                        BlobTypes=@("blockBlob","appendBlob","pageBlob");
                        PrefixMatch=@("prefix3","prefix4");
                        IncludeSnapshots=$true;
                        IncludeBlobVersions=$false;
                    })
                })
            })
        })


StorageAccountName : mystorageaccount
ResourceGroupName  : myresourcegroup
Name               : DefaultInventoryPolicy
Id                 : /subscriptions/45b60d85-fd72-427a-a708-f994d26e593e/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/mystorageaccount/inventoryPolicies/default
Type               : Microsoft.Storage/storageAccounts/inventoryPolicies
LastModifiedTime   : 11/4/2020 9:31:49 AM
Destination        : containername
Enabled            : True
Rules              : {Test1, Test2}
```

This command creates or updates the blob inventory policy of a Storage account with a json format policy.

### Example 3: Get the blob inventory policy from a Storage account, then set it to another Storage account.
```
PS C:\>$policy = Get-AzStorageBlobInventoryPolicy -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" | Set-AzStorageBlobInventoryPolicy -ResourceGroupName "myresourcegroup2" -AccountName "mystorageaccount2"
```

This command first gets the blob inventory policy from a Storage account, then set it to another Storage account.
The proeprties： Destination, Enabled, and Rules of the policy will be set to the destination account.

### Example 4: Get the blob inventory policy rules from a Storage account, then set it to another Storage account.
```
PS C:\>$policy = ,((Get-AzStorageBlobInventoryPolicy -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount").Rules) | Set-AzStorageBlobInventoryPolicy -ResourceGroupName "myresourcegroup2" -AccountName "mystorageaccount2" -Destination $containerName
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

### -Destination
The container name where blob inventory files are stored.
Must be pre-created.

```yaml
Type: System.String
Parameter Sets: AccountNamePolicyRule, AccountObjectPolicyRule, AccountResourceIdPolicyRule
Aliases:

Required: True
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSStorageAccount

### System.String

### Microsoft.Azure.Commands.Management.Storage.Models.PSBlobInventoryPolicyRule[]

### Microsoft.Azure.Commands.Management.Storage.Models.PSBlobInventoryPolicySchema

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSManagementPolicy

## NOTES

## RELATED LINKS
