---
external help file: Az.Chaos-help.xml
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/get-azchaosexperiment
schema: 2.0.0
---

# Get-AzChaosExperiment

## SYNOPSIS
Get a Experiment resource.

## SYNTAX

### List (Default)
```
Get-AzChaosExperiment [-SubscriptionId <String[]>] [-ContinuationToken <String>] [-Running]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzChaosExperiment -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzChaosExperiment -ResourceGroupName <String> [-SubscriptionId <String[]>] [-ContinuationToken <String>]
 [-Running] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzChaosExperiment -InputObject <IChaosIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Experiment resource.

## EXAMPLES

### Example 1: List Experiment resource.
```powershell
Get-AzChaosExperiment
```

```output
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/experiment-test
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 :
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus
Name                         : experiment-test
ProvisioningState            :
ResourceGroupName            : azps_test_group_chaos
Selector                     : {{
                                 "type": "List",
                                 "id": "84f2321b-b84c-4f61-ae0d-f18521c86477",
                                 "targets": [
                                   {
                                     "type": "ChaosTarget",
                                     "id": "/subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/microsoft.compute/virtualmachines/exampleVM/providers/Microsoft.C
                               haos/targets/microsoft-virtualmachine"
                                   }
                                 ]
                               }}
Step                         : {{
                                 "name": "Step 1",
                                 "branches": [
                                   {
                                     "name": "Branch 1",
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
                                         "selectorId": "84f2321b-b84c-4f61-ae0d-f18521c86477"
                                       }
                                     ]
                                   }
                                 ]
                               }}
SystemDataCreatedAt          : 2024-03-18 10:35:30 AM
SystemDataCreatedBy          :
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-03-18 10:35:30 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.Chaos/experiments
```

List Experiment resource.

### Example 2: List Experiment resource.
```powershell
Get-AzChaosExperiment -ResourceGroupName azps_test_group_chaos
```

```output
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/experiment-test
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 :
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus
Name                         : experiment-test
ProvisioningState            :
ResourceGroupName            : azps_test_group_chaos
Selector                     : {{
                                 "type": "List",
                                 "id": "84f2321b-b84c-4f61-ae0d-f18521c86477",
                                 "targets": [
                                   {
                                     "type": "ChaosTarget",
                                     "id": "/subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/microsoft.compute/virtualmachines/exampleVM/providers/Microsoft.C
                               haos/targets/microsoft-virtualmachine"
                                   }
                                 ]
                               }}
Step                         : {{
                                 "name": "Step 1",
                                 "branches": [
                                   {
                                     "name": "Branch 1",
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
                                         "selectorId": "84f2321b-b84c-4f61-ae0d-f18521c86477"
                                       }
                                     ]
                                   }
                                 ]
                               }}
SystemDataCreatedAt          : 2024-03-18 10:35:30 AM
SystemDataCreatedBy          :
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-03-18 10:35:30 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.Chaos/experiments
```

List Experiment resource.

### Example 3: Get a Experiment resource.
```powershell
Get-AzChaosExperiment -ResourceGroupName azps_test_group_chaos -Name experiment-test
```

```output
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/experiment-test
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 :
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus
Name                         : experiment-test
ProvisioningState            :
ResourceGroupName            : azps_test_group_chaos
Selector                     : {{
                                 "type": "List",
                                 "id": "84f2321b-b84c-4f61-ae0d-f18521c86477",
                                 "targets": [
                                   {
                                     "type": "ChaosTarget",
                                     "id": "/subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/microsoft.compute/virtualmachines/exampleVM/providers/Microsoft.C
                               haos/targets/microsoft-virtualmachine"
                                   }
                                 ]
                               }}
Step                         : {{
                                 "name": "Step 1",
                                 "branches": [
                                   {
                                     "name": "Branch 1",
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
                                         "selectorId": "84f2321b-b84c-4f61-ae0d-f18521c86477"
                                       }
                                     ]
                                   }
                                 ]
                               }}
SystemDataCreatedAt          : 2024-03-18 10:35:30 AM
SystemDataCreatedBy          :
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-03-18 10:35:30 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.Chaos/experiments
```

Get a Experiment resource.

## PARAMETERS

### -ContinuationToken
String that sets the continuation token.

```yaml
Type: System.String
Parameter Sets: List, List1
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
String that represents a Experiment resource name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ExperimentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
String that represents an Azure resource group.

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

### -Running
Optional value that indicates whether to filter results based on if the Experiment is currently running.
If null, then the results will not be filtered.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IExperiment

## NOTES

## RELATED LINKS
