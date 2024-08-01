---
external help file: Az.Workloads-help.xml
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/stop-azworkloadssapvirtualinstance
schema: 2.0.0
---

# Stop-AzWorkloadsSapVirtualInstance

## SYNOPSIS
Stops the SAP Application, that is the Application server instances and Central Services instance.

## SYNTAX

### StopExpanded (Default)
```
Stop-AzWorkloadsSapVirtualInstance -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DeallocateVM] [-SoftStopTimeoutSecond <Int64>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### StopViaIdentityExpanded
```
Stop-AzWorkloadsSapVirtualInstance -InputObject <IWorkloadsIdentity> [-DeallocateVM]
 [-SoftStopTimeoutSecond <Int64>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Stops the SAP Application, that is the Application server instances and Central Services instance.

## EXAMPLES

### Example 1: Stop an SAP system
```powershell
Stop-AzWorkloadsSapVirtualInstance -Name DB0 -ResourceGroupName db0-vis-rg
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 15-03-2023 09:04:37
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/CENTRALUSEUAP/operationStatuses/7ff215e4-afb
                    8-41fa-b281-0111da9a0cce*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Message           :
Name              : 7ff215e4-afb8-41fa-b281-0111da9a0cce*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 09:01:24
Status            : Succeeded
Target            :
```

Stop-AzWorkloadsSapVirtualInstance cmdlet stops the SAP application tier, that is App servers and ASCS instances of the system.
In this example, you can see that system can be stopped by passing the VIS name and ResourceGroupName of the VIS as inputs.

### Example 2: Stop an SAP system
```powershell
Stop-AzWorkloadsSapVirtualInstance -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/db0-vis-rg/providers/Microsoft.Workloads/sapVirtualInstances/DB0
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 15-03-2023 09:04:37
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/CENTRALUSEUAP/operationStatuses/7ff215e4-afb
                    8-41fa-b281-0111da9a0cce*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Message           :
Name              : 7ff215e4-afb8-41fa-b281-0111da9a0cce*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 09:01:24
Status            : Succeeded
Target            :
```

Stop-AzWorkloadsSapVirtualInstance cmdlet stops the SAP application tier, that is App servers and ASCS instances of the system.
In this example, you can see that system can be stopped by providing the VIS Azure resource ID as InputObject to the cmdlet.

### Example 3: Stop an SAP system and its underlying Virtual Machine(s)
```powershell
Stop-AzWorkloadsSapVirtualInstance -Name DB0 -ResourceGroupName db0-vis-rg -DeallocateVM
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 15-03-2023 09:04:37
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/CENTRALUSEUAP/operationStatuses/7ff215e4-afb
                    8-41fa-b281-0111da9a0cce*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Message           :
Name              : 7ff215e4-afb8-41fa-b281-0111da9a0cce*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 09:01:24
Status            : Succeeded
Target            :
```

Stop-AzWorkloadsSapVirtualInstance cmdlet stops the SAP application tier and its underlying VIrtual Machine, that is App servers and ASCS instances of the system.
In this example, you can see that SAP application and the VMs can be stopped by passing the VIS name, ResourceGroupName of the VIS, and DeallocateVM parameter as inputs.

### Example 4: Soft Stop an SAP system
```powershell
Stop-AzWorkloadsSapVirtualInstance -Name DB0 -ResourceGroupName db0-vis-rg -SoftStopTimeoutSecond 300
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 15-03-2023 09:04:37
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/CENTRALUSEUAP/operationStatuses/7ff215e4-afb
                    8-41fa-b281-0111da9a0cce*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Message           :
Name              : 7ff215e4-afb8-41fa-b281-0111da9a0cce*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 09:01:24
Status            : Succeeded
Target            :
```

Stop-AzWorkloadsSapVirtualInstance cmdlet soft stops the SAP application tier, that is App servers and ASCS instances of the system.
In this example, you can see that system can be soft stopped by passing the VIS name, ResourceGroupName of the VIS and soft stop timeout seconds as inputs.

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
The name of the Virtual Instances for SAP solutions resource

```yaml
Type: System.String
Parameter Sets: StopExpanded
Aliases: SapVirtualInstanceName

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
