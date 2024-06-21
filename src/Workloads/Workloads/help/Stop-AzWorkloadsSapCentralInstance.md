---
external help file: Az.Workloads-help.xml
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/stop-azworkloadssapcentralinstance
schema: 2.0.0
---

# Stop-AzWorkloadsSapCentralInstance

## SYNOPSIS
Stops the SAP Central Services Instance.

## SYNTAX

### StopExpanded (Default)
```
Stop-AzWorkloadsSapCentralInstance -Name <String> -ResourceGroupName <String> -SapVirtualInstanceName <String>
 [-SubscriptionId <String>] [-DeallocateVM] [-SoftStopTimeoutSecond <Int64>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### StopViaIdentityExpanded
```
Stop-AzWorkloadsSapCentralInstance -InputObject <IWorkloadsIdentity> [-DeallocateVM]
 [-SoftStopTimeoutSecond <Int64>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Stops the SAP Central Services Instance.

## EXAMPLES

### Example 1: Stop Central services instance of the SAP system
```powershell
Stop-AzWorkloadsSapCentralInstance -Name cs0 -ResourceGroupName db0-vis-rg -SapVirtualInstanceName DB0
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 15-03-2023 08:45:40
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/CENTRALUSEUAP/operationStatuses/881d4ff9-1d38-4596-b215-28e
                    77dbfe176*DF20ACAC495F17B1D0D9182C3A4C44BC6EDFF718387348FAE17F19BCB5DE687C
Message           :
Name              : 881d4ff9-1d38-4596-b215-28e77dbfe176*DF20ACAC495F17B1D0D9182C3A4C44BC6EDFF718387348FAE17F19BCB5DE687C
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 08:43:32
Status            : Succeeded
Target            :
```

Stop-AzWorkloadsSapCentralInstance cmdlet stops the Central services instance of the SAP system represented by the VIS.
Currently, stop action is supported for ABAP central services stack.
In this example, you can see that instance can be stopped by passing the Central services instance resource name, Resource Group name and VIS name as inputs.

### Example 2: Stop Central services instance of the SAP system
```powershell
Stop-AzWorkloadsSapCentralInstance -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/db0-vis-rg/providers/Microsoft.Workloads/sapVirtualInstances/DB0/centralInstances/cs0
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 15-03-2023 08:45:40
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/CENTRALUSEUAP/operationStatuses/881d4ff9-1d38-4596-b215-28e
                    77dbfe176*DF20ACAC495F17B1D0D9182C3A4C44BC6EDFF718387348FAE17F19BCB5DE687C
Message           :
Name              : 881d4ff9-1d38-4596-b215-28e77dbfe176*DF20ACAC495F17B1D0D9182C3A4C44BC6EDFF718387348FAE17F19BCB5DE687C
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 08:43:32
Status            : Succeeded
Target            :
```

Stop-AzWorkloadsSapCentralInstance cmdlet stops the Central services instance of the SAP system represented by the VIS.
Currently, stop action is supported for ABAP central services stack.
In this example, you can see that instance can be stopped by passing the Central services instance Azure resource ID as InputObject to the cmdlet.

### Example 3: Stop Central services instance of the SAP system and its underlying Virtual Machine
```powershell
Stop-AzWorkloadsSapCentralInstance -Name cs0 -ResourceGroupName db0-vis-rg -SapVirtualInstanceName DB0 -DeallocateVM
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 15-03-2023 08:45:40
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/CENTRALUSEUAP/operationStatuses/881d4ff9-1d38-4596-b215-28e
                    77dbfe176*DF20ACAC495F17B1D0D9182C3A4C44BC6EDFF718387348FAE17F19BCB5DE687C
Message           :
Name              : 881d4ff9-1d38-4596-b215-28e77dbfe176*DF20ACAC495F17B1D0D9182C3A4C44BC6EDFF718387348FAE17F19BCB5DE687C
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 08:43:32
Status            : Succeeded
Target            :
```

Stop-AzWorkloadsSapCentralInstance cmdlet stops the Central services instance of the SAP system represented by the VIS.
Currently, stop action is supported for ABAP central services stack.
In this example, you can see that instance and its VMs can be stopped by passing the Central services instance resource name, Resource Group name, VIS name and DeallocateVM parameter as inputs.

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

### -DeallocateVM
The boolean value indicates whether to Stop and deallocate the virtual machines along with the SAP instances.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.IWorkloadsIdentity
Parameter Sets: StopViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Central Services Instance resource name string modeled as parameter for auto generation to work correctly.

```yaml
Type: System.String
Parameter Sets: StopExpanded
Aliases:

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
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: StopExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SapVirtualInstanceName
The name of the Virtual Instances for SAP solutions resource

```yaml
Type: System.String
Parameter Sets: StopExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoftStopTimeoutSecond
This parameter defines how long (in seconds) the soft shutdown waits until the RFC/HTTP clients no longer consider the server for calls with load balancing.
Value 0 means that the kernel does not wait, but goes directly into the next shutdown state, i.e.
hard stop.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: StopExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.IWorkloadsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.IOperationStatusResult

## NOTES

## RELATED LINKS
