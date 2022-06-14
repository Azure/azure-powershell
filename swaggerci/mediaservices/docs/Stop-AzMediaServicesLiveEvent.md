---
external help file:
Module Name: Az.MediaServices
online version: https://docs.microsoft.com/en-us/powershell/module/az.mediaservices/stop-azmediaservicesliveevent
schema: 2.0.0
---

# Stop-AzMediaServicesLiveEvent

## SYNOPSIS
Stops a running live event.

## SYNTAX

### StopExpanded (Default)
```
Stop-AzMediaServicesLiveEvent -AccountName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-RemoveOutputsOnStop] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Stop
```
Stop-AzMediaServicesLiveEvent -AccountName <String> -Name <String> -ResourceGroupName <String>
 -Parameter <ILiveEventActionInput> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaIdentity
```
Stop-AzMediaServicesLiveEvent -InputObject <IMediaServicesIdentity> -Parameter <ILiveEventActionInput>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaIdentityExpanded
```
Stop-AzMediaServicesLiveEvent -InputObject <IMediaServicesIdentity> [-RemoveOutputsOnStop]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Stops a running live event.

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
The Media Services account name.

```yaml
Type: System.String
Parameter Sets: Stop, StopExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.IMediaServicesIdentity
Parameter Sets: StopViaIdentity, StopViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the live event, maximum length is 32.

```yaml
Type: System.String
Parameter Sets: Stop, StopExpanded
Aliases: LiveEventName

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

### -Parameter
The LiveEvent action input parameter definition.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.ILiveEventActionInput
Parameter Sets: Stop, StopViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -RemoveOutputsOnStop
The flag indicates whether live outputs are automatically deleted when live event is being stopped.
Deleting live outputs do not delete the underlying assets.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: StopExpanded, StopViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: Stop, StopExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The unique identifier for a Microsoft Azure subscription.

```yaml
Type: System.String
Parameter Sets: Stop, StopExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.ILiveEventActionInput

### Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.IMediaServicesIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IMediaServicesIdentity>: Identity Parameter
  - `[AccountName <String>]`: The Media Services account name.
  - `[AssetName <String>]`: The Asset name.
  - `[ContentKeyPolicyName <String>]`: The Content Key Policy name.
  - `[FilterName <String>]`: The Account Filter name
  - `[Id <String>]`: Resource identity path
  - `[JobName <String>]`: The Job name.
  - `[LiveEventName <String>]`: The name of the live event, maximum length is 32.
  - `[LiveOutputName <String>]`: The name of the live output.
  - `[LocationName <String>]`: The name of the location
  - `[Name <String>]`: 
  - `[OperationId <String>]`: Operation Id.
  - `[ResourceGroupName <String>]`: The name of the resource group within the Azure subscription.
  - `[StreamingEndpointName <String>]`: The name of the streaming endpoint, maximum length is 24.
  - `[StreamingLocatorName <String>]`: The Streaming Locator name.
  - `[StreamingPolicyName <String>]`: The Streaming Policy name.
  - `[SubscriptionId <String>]`: The unique identifier for a Microsoft Azure subscription.
  - `[TrackName <String>]`: The Asset Track name.
  - `[TransformName <String>]`: The Transform name.

PARAMETER <ILiveEventActionInput>: The LiveEvent action input parameter definition.
  - `[RemoveOutputsOnStop <Boolean?>]`: The flag indicates whether live outputs are automatically deleted when live event is being stopped. Deleting live outputs do not delete the underlying assets.

## RELATED LINKS

