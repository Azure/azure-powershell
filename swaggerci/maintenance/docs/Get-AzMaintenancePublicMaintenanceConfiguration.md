---
external help file:
Module Name: Az.Maintenance
online version: https://docs.microsoft.com/en-us/powershell/module/az.maintenance/get-azmaintenancepublicmaintenanceconfiguration
schema: 2.0.0
---

# Get-AzMaintenancePublicMaintenanceConfiguration

## SYNOPSIS
Get Public Maintenance Configuration record

## SYNTAX

### List (Default)
```
Get-AzMaintenancePublicMaintenanceConfiguration [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzMaintenancePublicMaintenanceConfiguration -ResourceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMaintenancePublicMaintenanceConfiguration -InputObject <IMaintenanceIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get Public Maintenance Configuration record

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Maintenance.Models.IMaintenanceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceName
Maintenance Configuration Name

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

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Maintenance.Models.IMaintenanceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Maintenance.Models.Api20210901Preview.IMaintenanceConfiguration

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IMaintenanceIdentity>: Identity Parameter
  - `[ApplyUpdateName <String>]`: applyUpdate Id
  - `[ConfigurationAssignmentName <String>]`: Configuration assignment name
  - `[Id <String>]`: Resource identity path
  - `[ProviderName <String>]`: Resource provider name
  - `[ResourceGroupName <String>]`: Resource group name
  - `[ResourceName <String>]`: Maintenance Configuration Name
  - `[ResourceParentName <String>]`: Resource parent identifier
  - `[ResourceParentType <String>]`: Resource parent type
  - `[ResourceType <String>]`: Resource type
  - `[SubscriptionId <String>]`: Subscription credentials that uniquely identify a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

