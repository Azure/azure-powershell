---
external help file: Az.Storage-help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/get-azstoragefileserviceusage
schema: 2.0.0
---

# Get-AzStorageFileServiceUsage

## SYNOPSIS
Gets the usage of file service in storage account including account limits, file share limits and constants used in recommendations and bursting formula.

## SYNTAX

### Get (Default)
```
Get-AzStorageFileServiceUsage -AccountName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List
```
Get-AzStorageFileServiceUsage -AccountName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Maxpagesize <Int32>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorageFileServiceUsage -InputObject <IStorageIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets the usage of file service in storage account including account limits, file share limits and constants used in recommendations and bursting formula.

## EXAMPLES

### EXAMPLE 1
```
{{ Add code here }}
```

### EXAMPLE 2
```
{{ Add code here }}
```

## PARAMETERS

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: Get, List
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
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Maxpagesize
Optional, specifies the maximum number of file service usages to be included in the list response.

```yaml
Type: System.Int32
Parameter Sets: List
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
The name of the resource group within the user's subscription.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceUsage
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
  \[FileServiceUsagesName \<String\>\]: The name of the file service usage.
File Service Usage Name must be "default"
  \[FileServicesName \<String\>\]: The name of the file Service within the specified storage account.
File Service Name must be "default"
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
  \[ShareName \<String\>\]: The name of the file share within the specified storage account.
File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only.
Every dash (-) character must be immediately preceded and followed by a letter or number.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
  \[Username \<String\>\]: The name of local user.
The username must contain lowercase letters and numbers only.
It must be unique only within the storage account.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.storage/get-azstoragefileserviceusage](https://learn.microsoft.com/powershell/module/az.storage/get-azstoragefileserviceusage)

