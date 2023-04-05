---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/remove-azworkloadssapvirtualinstance
schema: 2.0.0
---

# Remove-AzWorkloadsSapVirtualInstance

## SYNOPSIS
Deletes a Virtual Instance for SAP solutions resource and its child resources, that is the associated Central Services Instance, Application Server Instances and Database Instance.

## SYNTAX

### Delete (Default)
```
Remove-AzWorkloadsSapVirtualInstance -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzWorkloadsSapVirtualInstance -InputObject <IWorkloadsIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Deletes a Virtual Instance for SAP solutions resource and its child resources, that is the associated Central Services Instance, Application Server Instances and Database Instance.

## EXAMPLES

### Example 1: Remove a Virtual Instance for SAP solutions (VIS)
```powershell
Remove-AzWorkloadsSapVirtualInstance -Name X51 -ResourceGroupName X51Test
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           :
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/EASTUS/operationStatuses/1433bd12-7bb0-403d-a11c-31194d7bd4
                    f2*619F4904A0186D89AC80F440FBACD91E1EBCEBE959C0A31F7160ABF29816CAF8
Message           :
Name              : 1433bd12-7bb0-403d-a11c-31194d7bd4f2*619F4904A0186D89AC80F440FBACD91E1EBCEBE959C0A31F7160ABF29816CAF8
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 14:50:32
Status            : Succeeded
Target            :
```

Remove-AzWorkloadsSapVirtualInstance cmdlet deletes the VIS, associated child instances (ASCS, Application Instance and Database Instance) and Managed Resource Group.
This action doesnt delete the underlying physical Infrastructure resources such as Application resource group and underlying components such as Virtual Machines, Disks, etc.
Its required that customer deletes physical resources themselves.
Delete of a VIS  is permanent action and cannot be reverted.
In this example, you can see that VIS can be deleted by passing the VIS name and Resource Group as inputs.

### Example 2: Remove a Virtual Instance for SAP solutions (VIS)
```powershell
Remove-AzWorkloadsSapVirtualInstance -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/X51Test/providers/Microsoft.Workloads/sapVirtualInstances/X51
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           :
Id                : /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/providers/Microsoft.Workloads/locations/EASTUS/operationStatuses/1433bd12-7bb0-403d-a11c-31194d7bd4
                    f2*619F4904A0186D89AC80F440FBACD91E1EBCEBE959C0A31F7160ABF29816CAF8
Message           :
Name              : 1433bd12-7bb0-403d-a11c-31194d7bd4f2*619F4904A0186D89AC80F440FBACD91E1EBCEBE959C0A31F7160ABF29816CAF8
Operation         :
PercentComplete   :
ResourceGroupName :
StartTime         : 15-03-2023 14:50:32
Status            : Succeeded
Target            :
```

Remove-AzWorkloadsSapVirtualInstance cmdlet deletes the VIS, associated child instances (ASCS, Application Instance and Database Instance) and Managed Resource Group.
This action doesnt delete the underlying physical Infrastructure resources such as Application resource group and underlying components such as Virtual Machines, Disks, etc.
Its required that customer deletes physical resources themselves.
Delete of a VIS  is permanent action and cannot be reverted.
In this example, you can see that VIS can be deleted by passing the Virtual Instance for SAP solutions (VIS) Azure resource ID as InputObject to the cmdlet.

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
Parameter Sets: DeleteViaIdentity
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
Parameter Sets: Delete
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

### -PassThru
Returns true when the command succeeds

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
Parameter Sets: Delete
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
Parameter Sets: Delete
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

