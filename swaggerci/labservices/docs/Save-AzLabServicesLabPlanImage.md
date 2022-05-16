---
external help file:
Module Name: Az.LabServices
online version: https://docs.microsoft.com/en-us/powershell/module/az.labservices/save-azlabserviceslabplanimage
schema: 2.0.0
---

# Save-AzLabServicesLabPlanImage

## SYNOPSIS
Saves an image from a lab VM to the attached shared image gallery.

## SYNTAX

### SaveExpanded (Default)
```
Save-AzLabServicesLabPlanImage -LabPlanName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-LabVirtualMachineId <String>] [-Name <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Save
```
Save-AzLabServicesLabPlanImage -LabPlanName <String> -ResourceGroupName <String> -Body <ISaveImageBody>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SaveViaIdentity
```
Save-AzLabServicesLabPlanImage -InputObject <ILabServicesIdentity> -Body <ISaveImageBody>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SaveViaIdentityExpanded
```
Save-AzLabServicesLabPlanImage -InputObject <ILabServicesIdentity> [-LabVirtualMachineId <String>]
 [-Name <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Saves an image from a lab VM to the attached shared image gallery.

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

### -Body
Body for the save image POST
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211115Preview.ISaveImageBody
Parameter Sets: Save, SaveViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILabServicesIdentity
Parameter Sets: SaveViaIdentity, SaveViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LabPlanName
The name of the lab plan that uniquely identifies it within containing resource group.
Used in resource URIs and in UI.

```yaml
Type: System.String
Parameter Sets: Save, SaveExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LabVirtualMachineId
The ID of the lab virtual machine you want to save an image from.

```yaml
Type: System.String
Parameter Sets: SaveExpanded, SaveViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name for the image we create.

```yaml
Type: System.String
Parameter Sets: SaveExpanded, SaveViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: Save, SaveExpanded
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
Parameter Sets: Save, SaveExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211115Preview.ISaveImageBody

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILabServicesIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <ISaveImageBody>: Body for the save image POST
  - `[LabVirtualMachineId <String>]`: The ID of the lab virtual machine you want to save an image from.
  - `[Name <String>]`: The name for the image we create.

INPUTOBJECT <ILabServicesIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ImageName <String>]`: The image name.
  - `[LabName <String>]`: The name of the lab that uniquely identifies it within containing lab account. Used in resource URIs.
  - `[LabPlanName <String>]`: The name of the lab plan that uniquely identifies it within containing resource group. Used in resource URIs and in UI.
  - `[Location <String>]`: The location name.
  - `[OperationResultId <String>]`: The operation result ID / name.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ScheduleName <String>]`: The name of the schedule that uniquely identifies it within containing lab. Used in resource URIs.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[UserName <String>]`: The name of the user that uniquely identifies it within containing lab. Used in resource URIs.
  - `[VirtualMachineName <String>]`: The ID of the virtual machine that uniquely identifies it within the containing lab. Used in resource URIs.

## RELATED LINKS

