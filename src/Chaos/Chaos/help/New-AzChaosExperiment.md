---
external help file: Az.Chaos-help.xml
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/new-azchaosexperiment
schema: 2.0.0
---

# New-AzChaosExperiment

## SYNOPSIS
Create a Experiment resource.

## SYNTAX

### CreateViaJsonFilePath (Default)
```
New-AzChaosExperiment -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzChaosExperiment -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a Experiment resource.

## EXAMPLES

### Example 1: Create Or Update a Experiment resource for Json File Path.
```powershell
New-AzChaosExperiment -Name experiment-test -ResourceGroupName azps_test_group_chaos -JsonFilePath "C:\Users\abc\Desktop\jsonStr.json"
```

```output
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/EXPERIMENT-TEST
IdentityPrincipalId          : 00001111-aaaa-2222-bbbb-3333cccc4444
IdentityTenantId             : 00001111-aaaa-2222-bbbb-3333cccc4444
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
SystemDataLastModifiedAt     : 2024-04-10 10:32:47 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.Chaos/experiments
```

Create Or Update a Experiment resource for Json File Path.

### Example 2: Create Or Update a Experiment resource for Json String.
```powershell
$jsonStr = '
{
  "location": "eastus",
  "identity": {
    "type": "SystemAssigned"
  },
  "properties": {
    "steps": [
      {
        "name": "step1",
        "branches": [
          {
            "name": "branch1",
            "actions": [
              {
                "type": "continuous",
                "name": "urn:csci:microsoft:virtualMachine:shutdown/1.0",
                "selectorId": "selector1",
                "duration": "PT10M",
                "parameters": [
                  {
                    "key": "abruptShutdown",
                    "value": "false"
                  }
                ]
              }
            ]
          }
        ]
      }
    ],
    "selectors": [
      {
        "type": "List",
        "id": "selector1",
        "targets": [
          {
            "type": "ChaosTarget",
            "id": "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_chaos/providers/Microsoft.Compute/virtualMachines/azpstest1/providers/Microsoft.Chaos/targets/microsoft-virtualmachine"
          }
        ]
      }
    ]
  }
}'

New-AzChaosExperiment -Name experiment-test -ResourceGroupName azps_test_group_chaos -JsonString $jsonStr
```

```output
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Chaos/experiments/EXPERIMENT-TEST
IdentityPrincipalId          : 00001111-aaaa-2222-bbbb-3333cccc4444
IdentityTenantId             : 00001111-aaaa-2222-bbbb-3333cccc4444
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
SystemDataLastModifiedAt     : 2024-04-10 10:32:47 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.Chaos/experiments
```

Create Or Update a Experiment resource for Json String.

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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
String that represents a Experiment resource name.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
GUID that represents an Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IExperiment

## NOTES

## RELATED LINKS
