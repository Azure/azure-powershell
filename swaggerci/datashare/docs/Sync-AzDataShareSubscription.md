---
external help file:
Module Name: Az.DataShare
online version: https://docs.microsoft.com/en-us/powershell/module/az.datashare/sync-azdatasharesubscription
schema: 2.0.0
---

# Sync-AzDataShareSubscription

## SYNOPSIS
Initiate a copy

## SYNTAX

### SynchronizeExpanded (Default)
```
Sync-AzDataShareSubscription -AccountName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-SynchronizationMode <SynchronizationMode>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Synchronize
```
Sync-AzDataShareSubscription -AccountName <String> -Name <String> -ResourceGroupName <String>
 -Synchronize <ISynchronize> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SynchronizeViaIdentity
```
Sync-AzDataShareSubscription -InputObject <IDataShareIdentity> -Synchronize <ISynchronize>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SynchronizeViaIdentityExpanded
```
Sync-AzDataShareSubscription -InputObject <IDataShareIdentity> [-SynchronizationMode <SynchronizationMode>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Initiate a copy

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

### -AccountName
The name of the share account.

```yaml
Type: System.String
Parameter Sets: Synchronize, SynchronizeExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models.IDataShareIdentity
Parameter Sets: SynchronizeViaIdentity, SynchronizeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of share subscription

```yaml
Type: System.String
Parameter Sets: Synchronize, SynchronizeExpanded
Aliases: ShareSubscriptionName

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
The resource group name.

```yaml
Type: System.String
Parameter Sets: Synchronize, SynchronizeExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription identifier

```yaml
Type: System.String
Parameter Sets: Synchronize, SynchronizeExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SynchronizationMode
Mode of synchronization used in triggers and snapshot sync.
Incremental by default

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataShare.Support.SynchronizationMode
Parameter Sets: SynchronizeExpanded, SynchronizeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Synchronize
Payload for the synchronizing the data.
To construct, see NOTES section for SYNCHRONIZE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models.Api20200901.ISynchronize
Parameter Sets: Synchronize, SynchronizeViaIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models.Api20200901.ISynchronize

### Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models.IDataShareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models.Api20200901.IShareSubscriptionSynchronization

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDataShareIdentity>: Identity Parameter
  - `[AccountName <String>]`: The name of the share account.
  - `[DataSetMappingName <String>]`: The name of the dataSetMapping.
  - `[DataSetName <String>]`: The name of the dataSet.
  - `[Id <String>]`: Resource identity path
  - `[InvitationId <String>]`: An invitation id
  - `[InvitationName <String>]`: The name of the invitation.
  - `[Location <String>]`: Location of the invitation
  - `[ProviderShareSubscriptionId <String>]`: To locate shareSubscription
  - `[ResourceGroupName <String>]`: The resource group name.
  - `[ShareName <String>]`: The name of the share.
  - `[ShareSubscriptionName <String>]`: The name of the shareSubscription.
  - `[SubscriptionId <String>]`: The subscription identifier
  - `[SynchronizationSettingName <String>]`: The name of the synchronizationSetting.
  - `[TriggerName <String>]`: The name of the trigger.

SYNCHRONIZE <ISynchronize>: Payload for the synchronizing the data.
  - `[SynchronizationMode <SynchronizationMode?>]`: Mode of synchronization used in triggers and snapshot sync. Incremental by default

## RELATED LINKS

