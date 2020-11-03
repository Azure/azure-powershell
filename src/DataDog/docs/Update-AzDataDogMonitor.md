---
external help file:
Module Name: Az.DataDog
online version: https://docs.microsoft.com/en-us/powershell/module/az.datadog/update-azdatadogmonitor
schema: 2.0.0
---

# Update-AzDataDogMonitor

## SYNOPSIS
Update a monitor resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDataDogMonitor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-MonitoringStatus <MonitoringStatus>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Update-AzDataDogMonitor -Name <String> -ResourceGroupName <String>
 -Body <IDatadogMonitorResourceUpdateParameters> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzDataDogMonitor -InputObject <IDataDogIdentity> -Body <IDatadogMonitorResourceUpdateParameters>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDataDogMonitor -InputObject <IDataDogIdentity> [-MonitoringStatus <MonitoringStatus>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a monitor resource.

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

### -Body
The parameters for a PATCH request to a monitor resource.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20200201Preview.IDatadogMonitorResourceUpdateParameters
Parameter Sets: Update, UpdateViaIdentity
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.IDataDogIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitoringStatus
Flag specifying if the resource monitoring is enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataDog.Support.MonitoringStatus
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Monitor resource name

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: MonitorName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group to which the Datadog resource belongs.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Microsoft Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The new tags of the monitor resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20200201Preview.IDatadogMonitorResourceUpdateParameters

### Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.IDataDogIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20200201Preview.IDatadogMonitorResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <IDatadogMonitorResourceUpdateParameters>: The parameters for a PATCH request to a monitor resource.
  - `[MonitoringStatus <MonitoringStatus?>]`: Flag specifying if the resource monitoring is enabled or disabled.
  - `[Tag <IDatadogMonitorResourceUpdateParametersTags>]`: The new tags of the monitor resource.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

INPUTOBJECT <IDataDogIdentity>: Identity Parameter
  - `[ConfigurationName <String>]`: 
  - `[Id <String>]`: Resource identity path
  - `[MonitorName <String>]`: Monitor resource name
  - `[ResourceGroupName <String>]`: The name of the resource group to which the Datadog resource belongs.
  - `[RuleSetName <String>]`: 
  - `[SubscriptionId <String>]`: The Microsoft Azure subscription ID.

## RELATED LINKS

