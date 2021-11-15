---
external help file:
Module Name: Az.Functions
online version: https://docs.microsoft.com/powershell/module/az.functions/remove-azfunctionappplan
schema: 2.0.0
---

# Remove-AzFunctionAppPlan

## SYNOPSIS
Deletes a function app plan.

## SYNTAX

### ByName (Default)
```
Remove-AzFunctionAppPlan -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-Force]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ByObjectInput
```
Remove-AzFunctionAppPlan -InputObject <IAppServicePlan> [-Force] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Deletes a function app plan.

## EXAMPLES

### Example 1: Get a function app plan by name and delete it.
```powershell
PS C:\> Get-AzFunctionAppPlan -Name MyAppName -ResourceGroupName MyResourceGroupName | Remove-AzFunctionAppPlan -Force
```

This command gets a function app plan by name and deletes it.

### Example 2: Delete a function app plan by name.
```powershell
PS C:\> Remove-AzFunctionAppPlan -Name MyAppName -ResourceGroupName MyResourceGroupName -Force
```

This command deletes a function app plan by name.

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

### -Force
Forces the cmdlet to remove the function app plan without prompting for confirmation.

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

### -InputObject
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan
Parameter Sets: ByObjectInput
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of function app.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds.

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


```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: ByName
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

### Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IAppServicePlan>: 
  - `Location <String>`: Resource Location.
  - `[Kind <String>]`: Kind of resource.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Capacity <Int32?>]`: Current number of instances assigned to the resource.
  - `[FreeOfferExpirationTime <DateTime?>]`: The time when the server farm free offer expires.
  - `[HostingEnvironmentProfileId <String>]`: Resource ID of the App Service Environment.
  - `[HyperV <Boolean?>]`: If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.
  - `[IsSpot <Boolean?>]`: If <code>true</code>, this App Service Plan owns spot instances.
  - `[IsXenon <Boolean?>]`: Obsolete: If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.
  - `[MaximumElasticWorkerCount <Int32?>]`: Maximum number of total workers allowed for this ElasticScaleEnabled App Service Plan
  - `[PerSiteScaling <Boolean?>]`: If <code>true</code>, apps assigned to this App Service plan can be scaled independently.         If <code>false</code>, apps assigned to this App Service plan will scale to all instances of the plan.
  - `[Reserved <Boolean?>]`: If Linux app service plan <code>true</code>, <code>false</code> otherwise.
  - `[SkuCapability <ICapability[]>]`: Capabilities of the SKU, e.g., is traffic manager enabled?
    - `[Name <String>]`: Name of the SKU capability.
    - `[Reason <String>]`: Reason of the SKU capability.
    - `[Value <String>]`: Value of the SKU capability.
  - `[SkuCapacityDefault <Int32?>]`: Default number of workers for this App Service plan SKU.
  - `[SkuCapacityMaximum <Int32?>]`: Maximum number of workers for this App Service plan SKU.
  - `[SkuCapacityMinimum <Int32?>]`: Minimum number of workers for this App Service plan SKU.
  - `[SkuCapacityScaleType <String>]`: Available scale configurations for an App Service plan.
  - `[SkuFamily <String>]`: Family code of the resource SKU.
  - `[SkuLocation <String[]>]`: Locations of the SKU.
  - `[SkuName <String>]`: Name of the resource SKU.
  - `[SkuSize <String>]`: Size specifier of the resource SKU.
  - `[SkuTier <String>]`: Service tier of the resource SKU.
  - `[SpotExpirationTime <DateTime?>]`: The time when the server farm expires. Valid only if it is a spot server farm.
  - `[TargetWorkerCount <Int32?>]`: Scaling worker count.
  - `[TargetWorkerSizeId <Int32?>]`: Scaling worker size ID.
  - `[WorkerTierName <String>]`: Target worker tier assigned to the App Service plan.

## RELATED LINKS

