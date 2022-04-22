---
external help file:
Module Name: Az.DataBoxEdge
online version: https://docs.microsoft.com/en-us/powershell/module/az.databoxedge/start-azdataboxedgesupportpackage
schema: 2.0.0
---

# Start-AzDataBoxEdgeSupportPackage

## SYNOPSIS
Triggers support package on the device

## SYNTAX

### TriggerExpanded (Default)
```
Start-AzDataBoxEdgeSupportPackage -DeviceName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Include <String>] [-MaximumTimeStamp <DateTime>] [-MinimumTimeStamp <DateTime>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Trigger
```
Start-AzDataBoxEdgeSupportPackage -DeviceName <String> -ResourceGroupName <String>
 -TriggerSupportPackageRequest <ITriggerSupportPackageRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TriggerViaIdentity
```
Start-AzDataBoxEdgeSupportPackage -InputObject <IDataBoxEdgeIdentity>
 -TriggerSupportPackageRequest <ITriggerSupportPackageRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TriggerViaIdentityExpanded
```
Start-AzDataBoxEdgeSupportPackage -InputObject <IDataBoxEdgeIdentity> [-Include <String>]
 [-MaximumTimeStamp <DateTime>] [-MinimumTimeStamp <DateTime>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Triggers support package on the device

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

### -DeviceName
The device name.

```yaml
Type: System.String
Parameter Sets: Trigger, TriggerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Include
Type of files, which need to be included in the logsThis will contain the type of logs (Default/DefaultWithDumps/None/All/DefaultWithArchived)or a comma separated list of log types that are required

```yaml
Type: System.String
Parameter Sets: TriggerExpanded, TriggerViaIdentityExpanded
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.IDataBoxEdgeIdentity
Parameter Sets: TriggerViaIdentity, TriggerViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MaximumTimeStamp
Start of the timespan of the log collection

```yaml
Type: System.DateTime
Parameter Sets: TriggerExpanded, TriggerViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinimumTimeStamp
MinimumTimeStamp from where logs need to be collected

```yaml
Type: System.DateTime
Parameter Sets: TriggerExpanded, TriggerViaIdentityExpanded
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
The resource group name.

```yaml
Type: System.String
Parameter Sets: Trigger, TriggerExpanded
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
Parameter Sets: Trigger, TriggerExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggerSupportPackageRequest
The request object for trigger support package.
To construct, see NOTES section for TRIGGERSUPPORTPACKAGEREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.Api20220301.ITriggerSupportPackageRequest
Parameter Sets: Trigger, TriggerViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.Api20220301.ITriggerSupportPackageRequest

### Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.IDataBoxEdgeIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


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

TRIGGERSUPPORTPACKAGEREQUEST <ITriggerSupportPackageRequest>: The request object for trigger support package.
  - `[Include <String>]`: Type of files, which need to be included in the logs         This will contain the type of logs (Default/DefaultWithDumps/None/All/DefaultWithArchived)         or a comma separated list of log types that are required
  - `[MaximumTimeStamp <DateTime?>]`: Start of the timespan of the log collection
  - `[MinimumTimeStamp <DateTime?>]`: MinimumTimeStamp from where logs need to be collected

## RELATED LINKS

