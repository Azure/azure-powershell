---
external help file:
Module Name: Az.Functions
online version: https://docs.microsoft.com/en-us/powershell/module/az.functions/get-azfunctionappplan
schema: 2.0.0
---

# Get-AzFunctionAppPlan

## SYNOPSIS
Get function apps plans in a subscription.

## SYNTAX

### GetAll (Default)
```
Get-AzFunctionAppPlan [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ByLocation
```
Get-AzFunctionAppPlan -Location <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ByName
```
Get-AzFunctionAppPlan -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ByResourceGroupName
```
Get-AzFunctionAppPlan [-ResourceGroupName <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### BySubscriptionId
```
Get-AzFunctionAppPlan [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get function apps plans in a subscription.

## EXAMPLES

### Example 1: Get all function apps plans.
```powershell
PS C:\> Get-AzFunctionAppPlan

```

### Example 2: Get function apps plans by resource group name.
```powershell
PS C:\> Get-AzFunctionAppPlan -ResourceGroupName MyResourceGroupName

```

### Example 3: Get function apps plans for the given subscriptions.
```powershell
PS C:\> Get-AzFunctionAppPlan -SubscriptionId 52d8cf1b-bcac-493a-bbae-f234b5ff3889, 07308f04-ea00-494b-b320-690df74b1c07

```

### Example 4: Get function apps plans by location.
```powershell
PS C:\> Get-AzFunctionAppPlan -Location "Central US"

```

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
Dynamic: False
```

### -Location
The location of the function app plan.

```yaml
Type: System.String
Parameter Sets: ByLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The service plan name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: ByName, ByResourceGroupName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String[]
Parameter Sets: ByName, BySubscriptionId
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20180201.IAppServicePlan

## ALIASES

## NOTES

## RELATED LINKS

