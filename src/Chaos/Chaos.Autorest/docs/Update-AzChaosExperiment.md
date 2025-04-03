---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/update-azchaosexperiment
schema: 2.0.0
---

# Update-AzChaosExperiment

## SYNOPSIS
Update a Experiment resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzChaosExperiment -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-EnableSystemAssignedIdentity <Boolean?>] [-Location <String>] [-Selector <ISelector[]>] [-Step <IStep[]>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzChaosExperiment -InputObject <IChaosIdentity> [-EnableSystemAssignedIdentity <Boolean?>]
 [-Location <String>] [-Selector <ISelector[]>] [-Step <IStep[]>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update a Experiment resource.

## EXAMPLES

### Example 1: Update a Experiment resource Tag.
```powershell
Update-AzChaosExperiment -Name experiment-test -ResourceGroupName azps_test_group_chaos -Location eastus -Tag @{"a"="1"}
```

```output
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/EXPERIMENT-TEST
IdentityPrincipalId          : 72f14040-8265-4f10-b5ea-377c6fc2671c
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus
Name                         : EXPERIMENT-TEST
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_chaos
Selector                     : {{
                                 "type": "List",
                                 "id": "selector1",
                                 "targets": [
                                   {
                                     "type": "ChaosTarget",
                                     "id": "/subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Compute/virtualMachines/exampleVM/providers/Microso
                               ft.Chaos/targets/Microsoft-VirtualMachine"
                                   }
                                 ]
                               }}
Step                         : {{
                                 "name": "step1",
                                 "branches": [
                                   {
                                     "name": "branch1",
                                     "actions": [
                                       {
                                         "type": "continuous",
                                         "name": "urn:csci:microsoft:virtualMachine:shutdown/1.0",
                                         "duration": "PT10M",
                                         "parameters": [
                                           {
                                             "key": "abruptShutdown",
                                             "value": "false"
                                           }
                                         ],
                                         "selectorId": "selector1"
                                       }
                                     ]
                                   }
                                 ]
                               }}
SystemDataCreatedAt          : 2024-04-10 10:28:10 AM
SystemDataCreatedBy          :
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-04-10 10:50:21 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.Chaos/experiments
```

Update a Experiment resource Tag.

### Example 1: Update a Experiment resource IdentityType.
```powershell
Update-AzChaosExperiment -Name experiment-test -ResourceGroupName azps_test_group_chaos -Location eastus -UserAssignedIdentity "/subscriptions/{subId}/resourcegroups/azps_test_group_chaos/providers/Microsoft.ManagedIdentity/userAssignedIdentities/uami" -EnableSystemAssignedIdentity:$false
```

```output
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/EXPERIMENT-TEST
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : UserAssigned
IdentityUserAssignedIdentity : {
                                 "/subscriptions/{subId}/resourcegroups/azps_test_group_chaos/providers/Microsoft.ManagedIdentity/userAssignedIdentities/uami": {
                                 }
                               }
Location                     : eastus
Name                         : EXPERIMENT-TEST
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_chaos
Selector                     : {{
                                 "type": "List",
                                 "id": "selector1",
                                 "targets": [
                                   {
                                     "type": "ChaosTarget",
                                     "id": "/subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Compute/virtualMachines/exampleVM/providers/Microso
                               ft.Chaos/targets/microsoft-virtualmachine"
                                   }
                                 ]
                               }}
Step                         : {{
                                 "name": "step1",
                                 "branches": [
                                   {
                                     "name": "branch1",
                                     "actions": [
                                       {
                                         "type": "continuous",
                                         "name": "urn:csci:microsoft:virtualMachine:shutdown/1.0",
                                         "duration": "PT5M",
                                         "parameters": [
                                           {
                                             "key": "abruptShutdown",
                                             "value": "false"
                                           }
                                         ],
                                         "selectorId": "selector1"
                                       }
                                     ]
                                   }
                                 ]
                               }}
SystemDataCreatedAt          : 2024-04-17 03:14:43 AM
SystemDataCreatedBy          :
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-04-17 03:20:23 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.Chaos/experiments
```

Update a Experiment resource IdentityType.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -EnableSystemAssignedIdentity
Decides if enable a system assigned identity for the resource.

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

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

### -Name
String that represents a Experiment resource name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: ExperimentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ResourceGroupName
String that represents an Azure resource group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Selector
List of selectors.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ISelector[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Step
List of steps.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
GUID that represents an Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IExperiment

## NOTES

## RELATED LINKS

