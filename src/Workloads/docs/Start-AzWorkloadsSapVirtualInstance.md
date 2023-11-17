---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/start-azworkloadssapvirtualinstance
schema: 2.0.0
---

# Start-AzWorkloadsSapVirtualInstance

## SYNOPSIS
Starts the SAP application, that is the Central Services instance and Application server instances.

## SYNTAX

### Start (Default)
```
Start-AzWorkloadsSapVirtualInstance -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StartViaIdentity
```
Start-AzWorkloadsSapVirtualInstance -InputObject <IWorkloadsIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Starts the SAP application, that is the Central Services instance and Application server instances.

## EXAMPLES

### Example 1: Start an SAP system
```powershell
Start-AzWorkloadsSapVirtualInstance -Name DB0 -ResourceGroupName db0-vis-rg
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 15-03-2023 09:11:00
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/CENTRALUSEUAP/operationStatuses/651c6f1b-db7
                    b-46b2-ba9a-fb5ee67ec372*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Message           :
Name              : 651c6f1b-db7b-46b2-ba9a-fb5ee67ec372*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 09:08:45
Status            : Succeeded
Target            :
```

Start-AzWorkloadsSapVirtualInstance cmdlet starts the SAP application tier, that is ASCS instance and App servers of the system.
In this example, you can see that system can be started by passing the VIS name and ResourceGroupName of the VIS as inputs.

### Example 2: Start an SAP system
```powershell
Start-AzWorkloadsSapVirtualInstance -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/db0-vis-rg/providers/Microsoft.Workloads/sapVirtualInstances/DB0
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 15-03-2023 09:11:00
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/CENTRALUSEUAP/operationStatuses/651c6f1b-db7
                    b-46b2-ba9a-fb5ee67ec372*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Message           :
Name              : 651c6f1b-db7b-46b2-ba9a-fb5ee67ec372*D9A8F8EF15D6E75CE64E8F442A39F1D7AF307793D262CE855530D335419055E3
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 09:08:45
Status            : Succeeded
Target            :
```

Start-AzWorkloadsSapVirtualInstance cmdlet starts the SAP application tier, that is ASCS instance and App servers of the system.
In this example, you can see that system can be started by providing the VIS Azure resource ID as InputObject to the cmdlet.

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
Parameter Sets: StartViaIdentity
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
Parameter Sets: Start
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Start
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
Type: System.String
Parameter Sets: Start
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

