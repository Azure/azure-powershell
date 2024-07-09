---
external help file: Az.Storage-help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/update-azstoragetaskassignment
schema: 2.0.0
---

# Update-AzStorageTaskAssignment

## SYNOPSIS
Update storage task assignment properties

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStorageTaskAssignment -AccountName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Description <String>] [-Enabled] [-EndBy <DateTime>] [-Interval <Int32>]
 [-IntervalUnit <String>] [-ReportPrefix <String>] [-StartFrom <DateTime>] [-StartOn <DateTime>]
 [-TargetExcludePrefix <String[]>] [-TargetPrefix <String[]>] [-TriggerType <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityStorageAccountExpanded
```
Update-AzStorageTaskAssignment -Name <String> -StorageAccountInputObject <IStorageIdentity>
 [-Description <String>] [-Enabled] [-EndBy <DateTime>] [-Interval <Int32>] [-IntervalUnit <String>]
 [-ReportPrefix <String>] [-StartFrom <DateTime>] [-StartOn <DateTime>] [-TargetExcludePrefix <String[]>]
 [-TargetPrefix <String[]>] [-TriggerType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStorageTaskAssignment -InputObject <IStorageIdentity> [-Description <String>] [-Enabled]
 [-EndBy <DateTime>] [-Interval <Int32>] [-IntervalUnit <String>] [-ReportPrefix <String>]
 [-StartFrom <DateTime>] [-StartOn <DateTime>] [-TargetExcludePrefix <String[]>] [-TargetPrefix <String[]>]
 [-TriggerType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update storage task assignment properties

## EXAMPLES

### EXAMPLE 1
```
$start = Get-Date -Year 2024 -Month 8 -Day 7 -Hour 1 -Minute 30
$end = Get-Date -Year 2024 -Month 12 -Day 25 -Hour 2 -Minute 45
Update-AzStorageTaskAssignment -accountname myaccount -name mytaskassignment -resourcegroupname myresourcegroup -StartFrom $start.ToUniversalTime() -EndBy $end.ToUniversalTime() -Interval 7 -Description "update task assignment" -Enabled
```

## PARAMETERS

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
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

### -Description
Text that describes the purpose of the storage task assignment

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

### -Enabled
Whether the storage task assignment is enabled or not

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndBy
When to end task execution.
This is a mutable field when ExecutionTrigger.properties.type is 'OnSchedule'; this property should not be present when ExecutionTrigger.properties.type is 'RunOnce'

```yaml
Type: DateTime
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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Interval
Run interval of task execution.
This is a mutable field when ExecutionTrigger.properties.type is 'OnSchedule'; this property should not be present when ExecutionTrigger.properties.type is 'RunOnce'

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

### -IntervalUnit
Run interval unit of task execution.
This is a mutable field when ExecutionTrigger.properties.type is 'OnSchedule'; this property should not be present when ExecutionTrigger.properties.type is 'RunOnce'

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

### -Name
The name of the storage task assignment within the specified resource group.
Storage task assignment names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: String
Parameter Sets: UpdateExpanded, UpdateViaIdentityStorageAccountExpanded
Aliases: StorageTaskAssignmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
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

### -ReportPrefix
The prefix of the storage task assignment report

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartFrom
When to start task execution.
This is a mutable field when ExecutionTrigger.properties.type is 'OnSchedule'; this property should not be present when ExecutionTrigger.properties.type is 'RunOnce'

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartOn
When to start task execution.
This is a mutable field when ExecutionTrigger.properties.type is 'RunOnce'; this property should not be present when ExecutionTrigger.properties.type is 'OnSchedule'

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountInputObject
Identity Parameter

```yaml
Type: IStorageIdentity
Parameter Sets: UpdateViaIdentityStorageAccountExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetExcludePrefix
List of object prefixes to be excluded from task execution.
If there is a conflict between include and exclude prefixes, the exclude prefix will be the determining factor

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetPrefix
Required list of object prefixes to be included for task execution

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggerType
The trigger type of the storage task assignment execution

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageTaskAssignment
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

[https://learn.microsoft.com/powershell/module/az.storage/update-azstoragetaskassignment](https://learn.microsoft.com/powershell/module/az.storage/update-azstoragetaskassignment)

