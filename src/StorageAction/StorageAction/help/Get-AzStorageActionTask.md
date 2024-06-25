---
external help file: Az.StorageAction-help.xml
Module Name: Az.StorageAction
online version: https://learn.microsoft.com/powershell/module/az.storageaction/get-azstorageactiontask
schema: 2.0.0
---

# Get-AzStorageActionTask

## SYNOPSIS
Get the storage task properties

## SYNTAX

### List (Default)
```
Get-AzStorageActionTask [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzStorageActionTask -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzStorageActionTask -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorageActionTask -InputObject <IStorageActionIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the storage task properties

## EXAMPLES

### Example 1: Get specific storage action task with specified resource group
```powershell
Get-AzStorageActionTask -Name mytask1 -ResourceGroupName group001
```

```output
CreationTimeInUtc            : 1/23/2024 6:47:43 AM
Description                  : my storage task
ElseOperation                : 
Enabled                      : True
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group001/providers/Microsoft.StorageActions/storageTasks/mytask1
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : None
IdentityUserAssignedIdentity : {
                               }
IfCondition                  : [[equals(AccessTier, 'Cool')]]
IfOperation                  : {{
                                 "name": "SetBlobTier",
                                 "parameters": {
                                   "tier": "Hot"
                                 },
                                 "onSuccess": "continue",
                                 "onFailure": "break"
                               }}
Location                     : eastus2euap
Name                         : mytask1
ProvisioningState            : Succeeded
ResourceGroupName            : group001
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : {
                               }
TaskVersion                  : 1
Type                         : Microsoft.StorageActions/storageTasks
```

This command gets specific storage action task with specified resource group

### Example 2: List storage action task by subscription
```powershell
Get-AzStorageActionTask
```

```output
Location      Name    SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Resour 
                                                                                                                                                                     ceGrou 
                                                                                                                                                                     pName  
--------      ----    ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- ------ 
canadacentral task1                                                                                                                                                  test-… 
eastus2euap   mytask1                                                                                                                                                ps1-t…
```

This command gets list of storage action task by subscription.

## PARAMETERS

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
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageActionIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the storage task within the specified resource group.
Storage task names must be between 3 and 18 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: StorageTaskName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List, Get, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageActionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTask

## NOTES

## RELATED LINKS
