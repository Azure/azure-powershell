---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/stop-azworkloadssapapplicationinstance
schema: 2.0.0
---

# Stop-AzWorkloadsSapApplicationInstance

## SYNOPSIS
Stops the SAP Application Server Instance.

## SYNTAX

### StopExpanded (Default)
```
Stop-AzWorkloadsSapApplicationInstance -Name <String> -ResourceGroupName <String>
 -SapVirtualInstanceName <String> [-SubscriptionId <String>] [-SoftStopTimeoutSecond <Int64>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaIdentityExpanded
```
Stop-AzWorkloadsSapApplicationInstance -InputObject <IWorkloadsIdentity> [-SoftStopTimeoutSecond <Int64>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Stops the SAP Application Server Instance.

## EXAMPLES

### Example 1: Stop Application server instance of the SAP system
```powershell
Stop-AzWorkloadsSapApplicationInstance -Name app0 -ResourceGroupName db0-vis-rg -SapVirtualInstanceName DB0
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

Stop-AzWorkloadsSapApplicationInstance cmdlet stops the App server instance of the SAP system represented by the VIS.
Currently, stop action is supported for ABAP stack.
In this example, you can see that instance can be stopped by passing the App server instance resource name, Resource Group name and VIS name as inputs.

### Example 2: Stop Application server instance of the SAP system
```powershell
Stop-AzWorkloadsSapApplicationInstance -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/db0-vis-rg/providers/Microsoft.Workloads/sapVirtualInstances/DB0/applicationInstances/app0
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

Stop-AzWorkloadsSapApplicationInstance cmdlet stops the App server instance of the SAP system represented by the VIS.
Currently, stop action is supported for ABAP stack.
In this example, you can see that instance can be stopped by passing the App server instance Azure resource ID as InputObject to the cmdlet.

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
The name of SAP Application Server instance resource.

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

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IWorkloadsIdentity>`: Identity Parameter
  - `[ApplicationInstanceName <String>]`: The name of SAP Application Server instance resource.
  - `[CentralInstanceName <String>]`: Central Services Instance resource name string modeled as parameter for auto generation to work correctly.
  - `[DatabaseInstanceName <String>]`: Database resource name string modeled as parameter for auto generation to work correctly.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of Azure region.
  - `[MonitorName <String>]`: Name of the SAP monitor resource.
  - `[ProviderInstanceName <String>]`: Name of the provider instance.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SapVirtualInstanceName <String>]`: The name of the Virtual Instances for SAP solutions resource
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

