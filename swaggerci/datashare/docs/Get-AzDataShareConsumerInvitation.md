---
external help file:
Module Name: Az.DataShare
online version: https://docs.microsoft.com/en-us/powershell/module/az.datashare/get-azdatashareconsumerinvitation
schema: 2.0.0
---

# Get-AzDataShareConsumerInvitation

## SYNOPSIS
Get an invitation

## SYNTAX

### List (Default)
```
Get-AzDataShareConsumerInvitation [-SkipToken <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDataShareConsumerInvitation -InvitationId <String> -Location <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataShareConsumerInvitation -InputObject <IDataShareIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get an invitation

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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InvitationId
An invitation id

```yaml
Type: System.String
Parameter Sets: Get
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
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipToken
The continuation token

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

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

## RELATED LINKS

