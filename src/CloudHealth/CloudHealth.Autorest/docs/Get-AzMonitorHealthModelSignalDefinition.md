---
external help file:
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/az.cloudhealth/get-azmonitorhealthmodelsignaldefinition
schema: 2.0.0
---

# Get-AzMonitorHealthModelSignalDefinition

## SYNOPSIS
Get a SignalDefinition

## SYNTAX

### List (Default)
```
Get-AzMonitorHealthModelSignalDefinition -HealthModelName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Timestamp <DateTime>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMonitorHealthModelSignalDefinition -HealthModelName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMonitorHealthModelSignalDefinition -InputObject <ICloudHealthIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityHealthmodel
```
Get-AzMonitorHealthModelSignalDefinition -HealthmodelInputObject <ICloudHealthIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a SignalDefinition

## EXAMPLES

### Example 1: Get a signal definition by name
```powershell
# Get the signal definition cpu-signal
Get-AzMonitorHealthModelSignalDefinition -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name cpu-signal
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azpwsh-test-rg/providers/Microsoft.CloudHealth/healthmodels/azpwsh-healthmodel1/signaldefinitions/cpu-signal
Name                         : cpu-signal
ProvisioningState            : Succeeded
ResourceGroupName            : azpwsh-test-rg
SystemDataCreatedAt          : 5/1/2026 12:00:35 AM
SystemDataCreatedBy          : contoso@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 5/1/2026 12:00:35 AM
SystemDataLastModifiedBy     : contoso@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.cloudhealth/healthmodels/signaldefinitions
```

Gets a single signal definition under a health model by name.

### Example 2: List every signal definition in a health model
```powershell
# List all signal definitions in the health model
Get-AzMonitorHealthModelSignalDefinition -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg
```

```output
Name          ProvisioningState ResourceGroupName
----          ----------------- -----------------
cpu-signal Succeeded         azpwsh-test-rg
cpu-signal-2         Succeeded         azpwsh-test-rg
```

Lists all signal definition resources defined on the specified health model.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -HealthmodelInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity
Parameter Sets: GetViaIdentityHealthmodel
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -HealthModelName
Name of health model resource

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the signal definition.
Must be unique within a health model.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityHealthmodel
Aliases: SignalDefinitionName

Required: True
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### -Timestamp
Timestamp to use for the operation.
When specified, the version of the resource at this point in time is retrieved.
If not specified, the latest version is used.

```yaml
Type: System.DateTime
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

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalDefinition

## NOTES

## RELATED LINKS

