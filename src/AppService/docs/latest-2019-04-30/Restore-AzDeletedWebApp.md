---
external help file:
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/restore-azdeletedwebapp
schema: 2.0.0
---

# Restore-AzDeletedWebApp

## SYNOPSIS
Restores a deleted web app to this web app.

## SYNTAX

### Restore (Default)
```
Restore-AzDeletedWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-PassThru]
 [-RestoreRequest <IDeletedAppRestoreRequest>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### RestoreSlot
```
Restore-AzDeletedWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Slot <String>
 [-PassThru] [-RestoreRequest <IDeletedAppRestoreRequest>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreExpandedSlot
```
Restore-AzDeletedWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Slot <String>
 [-PassThru] [-DeletedSiteId <String>] [-Kind <String>] [-RecoverConfiguration] [-SnapshotTime <String>]
 [-UseDrSecondary] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreExpanded
```
Restore-AzDeletedWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-PassThru]
 [-DeletedSiteId <String>] [-Kind <String>] [-RecoverConfiguration] [-SnapshotTime <String>] [-UseDrSecondary]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreViaIdentityExpandedSlot
```
Restore-AzDeletedWebApp -InputObject <IWebSiteIdentity> [-PassThru] [-DeletedSiteId <String>] [-Kind <String>]
 [-RecoverConfiguration] [-SnapshotTime <String>] [-UseDrSecondary] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreViaIdentityExpanded
```
Restore-AzDeletedWebApp -InputObject <IWebSiteIdentity> [-PassThru] [-DeletedSiteId <String>] [-Kind <String>]
 [-RecoverConfiguration] [-SnapshotTime <String>] [-UseDrSecondary] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreViaIdentity
```
Restore-AzDeletedWebApp -InputObject <IWebSiteIdentity> [-PassThru]
 [-RestoreRequest <IDeletedAppRestoreRequest>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Restores a deleted web app to this web app.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -DeletedSiteId
ARM resource ID of the deleted app.
Example:/subscriptions/{subId}/providers/Microsoft.Web/deletedSites/{deletedSiteId}

```yaml
Type: System.String
Parameter Sets: RestoreExpandedSlot, RestoreExpanded, RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity
Parameter Sets: RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded, RestoreViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: RestoreExpandedSlot, RestoreExpanded, RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of web app.

```yaml
Type: System.String
Parameter Sets: Restore, RestoreSlot, RestoreExpandedSlot, RestoreExpanded
Aliases: TargetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PassThru
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RecoverConfiguration
If true, deleted site configuration, in addition to content, will be restored.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RestoreExpandedSlot, RestoreExpanded, RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded
Aliases: RestoreContentOnly

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: Restore, RestoreSlot, RestoreExpandedSlot, RestoreExpanded
Aliases: TargetResourceGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RestoreRequest
Details about restoring a deleted app.
To construct, see NOTES section for RESTOREREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IDeletedAppRestoreRequest
Parameter Sets: Restore, RestoreSlot, RestoreViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Slot
Name of web app slot.
If not specified then will default to production slot.

```yaml
Type: System.String
Parameter Sets: RestoreSlot, RestoreExpandedSlot
Aliases: TargetSlot

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SnapshotTime
Point in time to restore the deleted app from, formatted as a DateTime string.
If unspecified, default value is the time that the app was deleted.

```yaml
Type: System.String
Parameter Sets: RestoreExpandedSlot, RestoreExpanded, RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: Restore, RestoreSlot, RestoreExpandedSlot, RestoreExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -UseDrSecondary
If true, the snapshot is retrieved from DRSecondary endpoint.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RestoreExpandedSlot, RestoreExpanded, RestoreViaIdentityExpandedSlot, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IDeletedAppRestoreRequest

## OUTPUTS

### System.Boolean

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### RESTOREREQUEST <IDeletedAppRestoreRequest>: Details about restoring a deleted app.
  - `[Kind <String>]`: Kind of resource.
  - `[DeletedSiteId <String>]`: ARM resource ID of the deleted app. Example:         /subscriptions/{subId}/providers/Microsoft.Web/deletedSites/{deletedSiteId}
  - `[RecoverConfiguration <Boolean?>]`: If true, deleted site configuration, in addition to content, will be restored.
  - `[SnapshotTime <String>]`: Point in time to restore the deleted app from, formatted as a DateTime string.         If unspecified, default value is the time that the app was deleted.
  - `[UseDrSecondary <Boolean?>]`: If true, the snapshot is retrieved from DRSecondary endpoint.

## RELATED LINKS

