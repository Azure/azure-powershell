---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/remove-azworkloadsproviderinstance
schema: 2.0.0
---

# Remove-AzWorkloadsProviderInstance

## SYNOPSIS
Deletes a provider instance for the specified subscription, resource group, SAP monitor name, and resource name.

## SYNTAX

### Delete (Default)
```
Remove-AzWorkloadsProviderInstance -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzWorkloadsProviderInstance -InputObject <IWorkloadsIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Deletes a provider instance for the specified subscription, resource group, SAP monitor name, and resource name.

## EXAMPLES

### Example 1: Delete a specific provider from AMS instance
```powershell
Remove-AzWorkloadsProviderInstance -MonitorName suha-160323-ams7 -Name suha-os-1 -ResourceGroupName suha-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c
```

```output
EndTime             Name                                                                                                  PercentComplete ResourceGroupName StartTime           Status
-------             ----                                                                                                  --------------- ----------------- ---------           ------
16-03-2023 11:48:08 034ff381-73dc-4273-8ed2-1ccd852a64a2*6E77053B6B98265D96E60B59AE83132A76A7B1EA2C160941AD1C81EFE679D721                                   16-03-2023 11:48:05 Succeeded
```

Delete a provider from specific AMS Instance

### Example 2: Delete a specific provider from AMS instance by Id
```powershell
Remove-AzWorkloadsProviderInstance -InputObject "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/suha-0802-rg1/providers/Microsoft.Workloads/monitors/suha-160323-ams7/providerInstances/suha-os-1"
```

```output
EndTime             Name                                                                                                  PercentComplete ResourceGroupName StartTime           Status
-------             ----                                                                                                  --------------- ----------------- ---------           ------
16-03-2023 11:48:08 034ff381-73dc-4273-8ed2-1ccd852a64a2*6E77053B6B98265D96E60B59AE83132A76A7B1EA2C160941AD1C81EFE679D721                                   16-03-2023 11:48:05 Succeeded
```

Delete a provider from specific AMS Instance by Arm Id

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

### -MonitorName
Name of the SAP monitor resource.

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

### -Name
Name of the provider instance.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases: ProviderInstanceName

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

