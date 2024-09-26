---
external help file: Az.Autoscale.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/get-azautoscalesetting
schema: 2.0.0
---

# Get-AzAutoscaleSetting

## SYNOPSIS
Gets an autoscale setting

## SYNTAX

### List1 (Default)
```
Get-AzAutoscaleSetting [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzAutoscaleSetting -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzAutoscaleSetting -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAutoscaleSetting -InputObject <IAutoscaleIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an autoscale setting

## EXAMPLES

### Example 1: List autoscale setting under current subscription
```powershell
Get-AzAutoscaleSetting
```

List autoscale setting under current subscription

### Example 2: List autoscale setting under resource group
```powershell
Get-AzAutoscaleSetting -ResourceGroupName test-group
```

List autoscale setting under resource group

### Example 2: Get autoscale setting by name
```powershell
Get-AzAutoscaleSetting -ResourceGroupName test-group -Name test-autoscalesetting
```

Get autoscale setting by name

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.IAutoscaleIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The autoscale setting name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: AutoscaleSettingName

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

```yaml
Type: System.String[]
Parameter Sets: List1, Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.IAutoscaleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IAutoscaleSettingResource

## NOTES

## RELATED LINKS
