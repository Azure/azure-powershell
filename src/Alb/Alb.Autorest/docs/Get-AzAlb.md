---
external help file:
Module Name: Az.Alb
online version: https://learn.microsoft.com/powershell/module/az.alb/get-azalb
schema: 2.0.0
---

# Get-AzAlb

## SYNOPSIS
Get a TrafficController

## SYNTAX

### List (Default)
```
Get-AzAlb [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAlb -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAlb -InputObject <IAlbIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzAlb -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a TrafficController

## EXAMPLES

### Example 1: Get a specified Application Gateway for Containers resource
```powershell
Get-AzAlb -Name test-alb -ResourceGroupName test-rg
```

```output
Name                       ResourceGroupName Location       ProvisioningState
----                       ----------------- --------       -----------------
test-alb                   1bcdr             NorthCentralUS Succeeded
```

This command shows a specific Application Gateway for Containers resource.

### Example 2: List Application Gateway for Containers resources for a resource group
```powershell
Get-AzAlb -ResourceGroupName test-rg
```

```output
Name                         ResourceGroupName Location       ProvisioningState
----                         ----------------- --------       -----------------
AGfC                         test-rg           northcentralus Succeeded
```

This command lists all Application Gateway for Containers resources belonging to a specific resource group.

### Example 3: List Application Gateway for Containers resources for a subscription
```powershell
Get-AzAlb
```

```output
Name                         ResourceGroupName Location       ProvisioningState
----                         ----------------- --------       -----------------
AGfC                         agfc-aks          northcentralus Succeeded
test-alb                     00                westeurope     Succeeded
```

This command lists all Application Gateway for Containers resources belonging to the current subscription context.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.IAlbIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
traffic controller name for path

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.IAlbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.ITrafficController

## NOTES

## RELATED LINKS

