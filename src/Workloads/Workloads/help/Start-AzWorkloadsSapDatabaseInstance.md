---
external help file: Az.Workloads-help.xml
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/start-azworkloadssapdatabaseinstance
schema: 2.0.0
---

# Start-AzWorkloadsSapDatabaseInstance

## SYNOPSIS
Starts the database instance of the SAP system.

## SYNTAX

### StartExpanded (Default)
```
Start-AzWorkloadsSapDatabaseInstance -Name <String> -ResourceGroupName <String>
 -SapVirtualInstanceName <String> [-SubscriptionId <String>] [-StartVM] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Start
```
Start-AzWorkloadsSapDatabaseInstance -Name <String> -ResourceGroupName <String>
 -SapVirtualInstanceName <String> [-SubscriptionId <String>] -Body <IStartRequest> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### StartViaIdentityExpanded
```
Start-AzWorkloadsSapDatabaseInstance -InputObject <IWorkloadsIdentity> [-StartVM] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### StartViaIdentity
```
Start-AzWorkloadsSapDatabaseInstance -InputObject <IWorkloadsIdentity> -Body <IStartRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Starts the database instance of the SAP system.

## EXAMPLES

### Example 1: Start Database instance of the SAP system
```powershell
Start-AzWorkloadsSapDatabaseInstance -Name db0 -ResourceGroupName db0-vis-rg -SapVirtualInstanceName DB0
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

Start-AzWorkloadsSapDatabaseInstance cmdlet starts the Database instance of the SAP system represented by the VIS.
Currently start action is supported for SAP HANA Database only.
In this example, you can see that database can be started by passing the DB instance resource name, ResourceGroupName and VIS name as inputs.

### Example 2: Start Database instance of the SAP system
```powershell
Start-AzWorkloadsSapDatabaseInstance -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/db0-vis-rg/providers/Microsoft.Workloads/sapVirtualInstances/DB0/databaseInstances/db0
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

Start-AzWorkloadsSapDatabaseInstance cmdlet starts the Database instance of the SAP system represented by the VIS.
Currently start action is supported for SAP HANA Database only.
In this example, you can see that database can be started by providing the DB instance Azure resource ID as InputObject to the cmdlet.

### Example 3: Start Database instance of the SAP system and its underlying Virtual Machine
```powershell
Start-AzWorkloadsSapDatabaseInstance -Name db0 -ResourceGroupName db0-vis-rg -SapVirtualInstanceName DB0 -StartVM
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

Start-AzWorkloadsSapDatabaseInstance cmdlet starts the Database instance of the SAP system and its underlying Virtual Machine represented by the VIS.
Currently start action is supported for SAP HANA Database only.
In this example, you can see that the VMs and database can be started by passing the DB instance resource name, ResourceGroupName, VIS name and StartVM parameter as inputs.

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

### -Body
Start SAP instance(s) request body.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20231001Preview.IStartRequest
Parameter Sets: Start, StartViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Parameter Sets: StartViaIdentityExpanded, StartViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Database resource name string modeled as parameter for auto generation to work correctly.

```yaml
Type: System.String
Parameter Sets: StartExpanded, Start
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
Parameter Sets: StartExpanded, Start
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
Parameter Sets: StartExpanded, Start
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartVM
The boolean value indicates whether to start the virtual machines before starting the SAP instances.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: StartExpanded, StartViaIdentityExpanded
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
Parameter Sets: StartExpanded, Start
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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20231001Preview.IStartRequest

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.IWorkloadsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api30.IOperationStatusResult

## NOTES

## RELATED LINKS
