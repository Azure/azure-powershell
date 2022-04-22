---
external help file:
Module Name: Az.Chaos
online version: https://docs.microsoft.com/en-us/powershell/module/az.chaos/get-azchaosexperimentexecutiondetail
schema: 2.0.0
---

# Get-AzChaosExperimentExecutionDetail

## SYNOPSIS
Get an execution detail of a Experiment resource.

## SYNTAX

### List (Default)
```
Get-AzChaosExperimentExecutionDetail -ExperimentName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzChaosExperimentExecutionDetail -ExecutionDetailsId <String> -ExperimentName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzChaosExperimentExecutionDetail -InputObject <IChaosIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get an execution detail of a Experiment resource.

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

### -ExecutionDetailsId
GUID that represents a Experiment execution detail.

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

### -ExperimentName
String that represents a Experiment resource name.

```yaml
Type: System.String
Parameter Sets: Get, List
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
String that represents an Azure resource group.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
GUID that represents an Azure subscription ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.Api20210915Preview.IExperimentExecutionDetails

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IChaosIdentity>: Identity Parameter
  - `[CapabilityName <String>]`: String that represents a Capability resource name.
  - `[CapabilityTypeName <String>]`: String that represents a Capability Type resource name.
  - `[ExecutionDetailsId <String>]`: GUID that represents a Experiment execution detail.
  - `[ExperimentName <String>]`: String that represents a Experiment resource name.
  - `[Id <String>]`: Resource identity path
  - `[LocationName <String>]`: String that represents a Location resource name.
  - `[ParentProviderNamespace <String>]`: String that represents a resource provider namespace.
  - `[ParentResourceName <String>]`: String that represents a resource name.
  - `[ParentResourceType <String>]`: String that represents a resource type.
  - `[ResourceGroupName <String>]`: String that represents an Azure resource group.
  - `[StatusId <String>]`: GUID that represents a Experiment status.
  - `[SubscriptionId <String>]`: GUID that represents an Azure subscription ID.
  - `[TargetName <String>]`: String that represents a Target resource name.
  - `[TargetTypeName <String>]`: String that represents a Target Type resource name.

## RELATED LINKS

