---
external help file:
Module Name: Az.DataBoxEdge
online version: https://docs.microsoft.com/en-us/powershell/module/az.databoxedge/test-azdataboxedgedevicecapacitycheckresourcecreationfeasibility
schema: 2.0.0
---

# Test-AzDataBoxEdgeDeviceCapacityCheckResourceCreationFeasibility

## SYNOPSIS
Posts the device capacity request info to check feasibility.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzDataBoxEdgeDeviceCapacityCheckResourceCreationFeasibility -DeviceName <String>
 -ResourceGroupName <String> -VMPlacementQuery <String[][]> [-SubscriptionId <String>]
 [-CapacityName <String>] [-VMPlacementResult <IVMPlacementRequestResult[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check
```
Test-AzDataBoxEdgeDeviceCapacityCheckResourceCreationFeasibility -DeviceName <String>
 -ResourceGroupName <String> -DeviceCapacityRequestInfo <IDeviceCapacityRequestInfo>
 [-SubscriptionId <String>] [-CapacityName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzDataBoxEdgeDeviceCapacityCheckResourceCreationFeasibility -InputObject <IDataBoxEdgeIdentity>
 -DeviceCapacityRequestInfo <IDeviceCapacityRequestInfo> [-CapacityName <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzDataBoxEdgeDeviceCapacityCheckResourceCreationFeasibility -InputObject <IDataBoxEdgeIdentity>
 -VMPlacementQuery <String[][]> [-CapacityName <String>] [-VMPlacementResult <IVMPlacementRequestResult[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Posts the device capacity request info to check feasibility.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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

### -CapacityName
The capacity name.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -DeviceCapacityRequestInfo
Object for Capturing DeviceCapacityRequestInfo
To construct, see NOTES section for DEVICECAPACITYREQUESTINFO properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.Api20220301.IDeviceCapacityRequestInfo
Parameter Sets: Check, CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DeviceName
The device name.

```yaml
Type: System.String
Parameter Sets: Check, CheckExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.IDataBoxEdgeIdentity
Parameter Sets: CheckViaIdentity, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
The resource group name.

```yaml
Type: System.String
Parameter Sets: Check, CheckExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID.

```yaml
Type: System.String
Parameter Sets: Check, CheckExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMPlacementQuery
Array containing the sizes of the VMs for checking if its feasible to create them on the appliance.

```yaml
Type: System.String[][]
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMPlacementResult
Array of the VMs of the sizes in VmSizes can be provisioned on the appliance.
To construct, see NOTES section for VMPLACEMENTRESULT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.Api20220301.IVMPlacementRequestResult[]
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.Api20220301.IDeviceCapacityRequestInfo

### Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.IDataBoxEdgeIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


DEVICECAPACITYREQUESTINFO <IDeviceCapacityRequestInfo>: Object for Capturing DeviceCapacityRequestInfo
  - `VMPlacementQuery <String[][]>`: Array containing the sizes of the VMs for checking if its feasible to create them on the appliance.
  - `[VMPlacementResult <IVMPlacementRequestResult[]>]`: Array of the VMs of the sizes in VmSizes can be provisioned on the appliance.
    - `[IsFeasible <Boolean?>]`: Boolean value indicating if the VM(s) in VmSize can be created.
    - `[Message <String>]`: Localized message to be displayed to the user to explain the check result.
    - `[MessageCode <String>]`: MessageCode indicating reason for success or failure.
    - `[VMSize <String[]>]`: List of VM sizes being checked.

INPUTOBJECT <IDataBoxEdgeIdentity>: Identity Parameter
  - `[AddonName <String>]`: The addon name.
  - `[ContainerName <String>]`: The container Name
  - `[DeviceName <String>]`: The device name.
  - `[Id <String>]`: Resource identity path
  - `[Name <String>]`: The alert name.
  - `[ResourceGroupName <String>]`: The resource group name.
  - `[RoleName <String>]`: The role name.
  - `[StorageAccountName <String>]`: The storage account name.
  - `[SubscriptionId <String>]`: The subscription ID.

VMPLACEMENTRESULT <IVMPlacementRequestResult[]>: Array of the VMs of the sizes in VmSizes can be provisioned on the appliance.
  - `[IsFeasible <Boolean?>]`: Boolean value indicating if the VM(s) in VmSize can be created.
  - `[Message <String>]`: Localized message to be displayed to the user to explain the check result.
  - `[MessageCode <String>]`: MessageCode indicating reason for success or failure.
  - `[VMSize <String[]>]`: List of VM sizes being checked.

## RELATED LINKS

