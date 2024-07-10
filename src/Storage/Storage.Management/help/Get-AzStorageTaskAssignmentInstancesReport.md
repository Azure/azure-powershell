---
external help file: Az.Storage-help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/get-azstoragetaskassignmentinstancesreport
schema: 2.0.0
---

# Get-AzStorageTaskAssignmentInstancesReport

## SYNOPSIS
Fetch the report summary of a single storage task assignment's instances

## SYNTAX

### List (Default)
```
Get-AzStorageTaskAssignmentInstancesReport -AccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Filter <String>] [-Maxpagesize <Int32>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzStorageTaskAssignmentInstancesReport -AccountName <String> -ResourceGroupName <String>
 -StorageTaskAssignmentName <String> [-SubscriptionId <String[]>] [-Filter <String>] [-Maxpagesize <Int32>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentityStorageAccount
```
Get-AzStorageTaskAssignmentInstancesReport -StorageTaskAssignmentName <String>
 -StorageAccountInputObject <IStorageIdentity> [-Filter <String>] [-Maxpagesize <Int32>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorageTaskAssignmentInstancesReport -InputObject <IStorageIdentity> [-Filter <String>]
 [-Maxpagesize <Int32>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Fetch the report summary of a single storage task assignment's instances

## EXAMPLES

### EXAMPLE 1
```
Get-AzStorageTaskAssignmentInstancesReport -AccountName myaccount -ResourceGroupName myresourcegroup -StorageTaskAssignmentName mytaskassignment
```

### EXAMPLE 2
```
Get-AzStorageTaskAssignmentInstancesReport -AccountName myaccount -ResourceGroupName myresourcegroup
```

## PARAMETERS

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
Optional.
When specified, it can be used to query using reporting properties.
See \[Constructing Filter Strings\](https://learn.microsoft.com/en-us/rest/api/storageservices/querying-tables-and-entities#constructing-filter-strings) for details.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: IStorageIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Maxpagesize
Optional, specifies the maximum number of storage task assignment instances to be included in the list response.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountInputObject
Identity Parameter

```yaml
Type: IStorageIdentity
Parameter Sets: GetViaIdentityStorageAccount
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StorageTaskAssignmentName
The name of the storage task assignment within the specified resource group.
Storage task assignment names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: String
Parameter Sets: Get, GetViaIdentityStorageAccount
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: String[]
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageTaskReportInstance
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IStorageIdentity\>: Identity Parameter
  \[AccountName \<String\>\]: The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
  \[BlobInventoryPolicyName \<String\>\]: The name of the storage account blob inventory policy.
It should always be 'default'
  \[DeletedAccountName \<String\>\]: Name of the deleted storage account.
  \[EncryptionScopeName \<String\>\]: The name of the encryption scope within the specified storage account.
Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only.
Every dash (-) character must be immediately preceded and followed by a letter or number.
  \[Id \<String\>\]: Resource identity path
  \[Location \<String\>\]: The location of the deleted storage account.
  \[ManagementPolicyName \<String\>\]: The name of the Storage Account Management Policy.
It should always be 'default'
  \[MigrationName \<String\>\]: The name of the Storage Account Migration.
It should always be 'default'
  \[ObjectReplicationPolicyId \<String\>\]: For the destination account, provide the value 'default'.
Configure the policy on the destination account first.
For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account.
The policy is downloaded as a JSON file.
  \[PrivateEndpointConnectionName \<String\>\]: The name of the private endpoint connection associated with the Azure resource
  \[ResourceGroupName \<String\>\]: The name of the resource group within the user's subscription.
The name is case insensitive.
  \[StorageTaskAssignmentName \<String\>\]: The name of the storage task assignment within the specified resource group.
Storage task assignment names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
  \[Username \<String\>\]: The name of local user.
The username must contain lowercase letters and numbers only.
It must be unique only within the storage account.

STORAGEACCOUNTINPUTOBJECT \<IStorageIdentity\>: Identity Parameter
  \[AccountName \<String\>\]: The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
  \[BlobInventoryPolicyName \<String\>\]: The name of the storage account blob inventory policy.
It should always be 'default'
  \[DeletedAccountName \<String\>\]: Name of the deleted storage account.
  \[EncryptionScopeName \<String\>\]: The name of the encryption scope within the specified storage account.
Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only.
Every dash (-) character must be immediately preceded and followed by a letter or number.
  \[Id \<String\>\]: Resource identity path
  \[Location \<String\>\]: The location of the deleted storage account.
  \[ManagementPolicyName \<String\>\]: The name of the Storage Account Management Policy.
It should always be 'default'
  \[MigrationName \<String\>\]: The name of the Storage Account Migration.
It should always be 'default'
  \[ObjectReplicationPolicyId \<String\>\]: For the destination account, provide the value 'default'.
Configure the policy on the destination account first.
For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account.
The policy is downloaded as a JSON file.
  \[PrivateEndpointConnectionName \<String\>\]: The name of the private endpoint connection associated with the Azure resource
  \[ResourceGroupName \<String\>\]: The name of the resource group within the user's subscription.
The name is case insensitive.
  \[StorageTaskAssignmentName \<String\>\]: The name of the storage task assignment within the specified resource group.
Storage task assignment names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
  \[Username \<String\>\]: The name of local user.
The username must contain lowercase letters and numbers only.
It must be unique only within the storage account.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.storage/get-azstoragetaskassignmentinstancesreport](https://learn.microsoft.com/powershell/module/az.storage/get-azstoragetaskassignmentinstancesreport)

