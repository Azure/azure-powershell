---
external help file:
Module Name: Az.DataShare
online version: https://docs.microsoft.com/en-us/powershell/module/az.datashare/invoke-azdatasharerejectconsumerinvitation
schema: 2.0.0
---

# Invoke-AzDataShareRejectConsumerInvitation

## SYNOPSIS
Reject an invitation

## SYNTAX

### RejectExpanded (Default)
```
Invoke-AzDataShareRejectConsumerInvitation -Location <String> -InvitationId <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Reject
```
Invoke-AzDataShareRejectConsumerInvitation -Location <String> -Invitation <IConsumerInvitation>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RejectViaIdentity
```
Invoke-AzDataShareRejectConsumerInvitation -InputObject <IDataShareIdentity> -Invitation <IConsumerInvitation>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RejectViaIdentityExpanded
```
Invoke-AzDataShareRejectConsumerInvitation -InputObject <IDataShareIdentity> -InvitationId <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Reject an invitation

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
Parameter Sets: RejectViaIdentity, RejectViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Invitation
A consumer Invitation data transfer object.
To construct, see NOTES section for INVITATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models.Api20200901.IConsumerInvitation
Parameter Sets: Reject, RejectViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InvitationId
Unique id of the invitation.

```yaml
Type: System.String
Parameter Sets: RejectExpanded, RejectViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location of the invitation

```yaml
Type: System.String
Parameter Sets: Reject, RejectExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models.Api20200901.IConsumerInvitation

### Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models.IDataShareIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models.Api20200901.IConsumerInvitation

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

INVITATION <IConsumerInvitation>: A consumer Invitation data transfer object.
  - `InvitationId <String>`: Unique id of the invitation.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The type of identity that last modified the resource.
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <LastModifiedByType?>]`: The type of identity that last modified the resource.

## RELATED LINKS

