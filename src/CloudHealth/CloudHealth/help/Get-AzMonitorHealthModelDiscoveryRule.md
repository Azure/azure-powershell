---
external help file: Az.CloudHealth-help.xml
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/az.cloudhealth/get-azmonitorhealthmodeldiscoveryrule
schema: 2.0.0
---

# Get-AzMonitorHealthModelDiscoveryRule

## SYNOPSIS
Get a DiscoveryRule

## SYNTAX

### List (Default)
```
Get-AzMonitorHealthModelDiscoveryRule -HealthModelName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Timestamp <DateTime>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzMonitorHealthModelDiscoveryRule -HealthModelName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityHealthmodel
```
Get-AzMonitorHealthModelDiscoveryRule -Name <String> -HealthmodelInputObject <ICloudHealthIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMonitorHealthModelDiscoveryRule -InputObject <ICloudHealthIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a DiscoveryRule

## EXAMPLES

### Example 1: Get a discovery rule by name
```powershell
# Get the discovery rule vmss-discovery
Get-AzMonitorHealthModelDiscoveryRule -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name vmss-discovery
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azpwsh-test-rg/providers/Microsoft.CloudHealth/healthmodels/azpwsh-healthmodel1/discoveryrules/vmss-discovery
Name                         : vmss-discovery
ProvisioningState            : Succeeded
ResourceGroupName            : azpwsh-test-rg
SystemDataCreatedAt          : 5/1/2026 12:00:35 AM
SystemDataCreatedBy          : contoso@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 5/1/2026 12:00:35 AM
SystemDataLastModifiedBy     : contoso@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.cloudhealth/healthmodels/discoveryrules
```

Gets a single discovery rule under a health model by name.

### Example 2: List every discovery rule in a health model
```powershell
# List all discovery rules in the health model
Get-AzMonitorHealthModelDiscoveryRule -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg
```

```output
Name          ProvisioningState ResourceGroupName
----          ----------------- -----------------
vmss-discovery Succeeded         azpwsh-test-rg
vmss-discovery-2         Succeeded         azpwsh-test-rg
```

Lists all discovery rule resources defined on the specified health model.

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
Parameter Sets: List, Get
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
Name of the discovery rule.
Must be unique within a health model.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityHealthmodel
Aliases: DiscoveryRuleName

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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IDiscoveryRule

## NOTES

## RELATED LINKS
