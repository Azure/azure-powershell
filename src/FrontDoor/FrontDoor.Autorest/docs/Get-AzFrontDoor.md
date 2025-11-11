---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/az.frontdoor/get-azfrontdoor
schema: 2.0.0
---

# Get-AzFrontDoor

## SYNOPSIS
Gets a Front Door with the specified Front Door name under the specified subscription and resource group.

## SYNTAX

### List (Default)
```
Get-AzFrontDoor [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzFrontDoor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzFrontDoor -InputObject <IFrontDoorIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzFrontDoor -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a Front Door with the specified Front Door name under the specified subscription and resource group.

## EXAMPLES

### Example 1: Get all FrontDoors in the current subscription.
```powershell
Get-AzFrontDoor
```

```output
Location  Name                                                          ResourceGroupName
--------  ----                                                          -----------------
Global    {Name0}                                                       {rg0}
CentralUs {Name1}                                                       {rg1}
```

Get all FrontDoors in the current subscription.

### Example 2: Get all FrontDoors in resource group "rg1" in the current subscription.
```powershell
Get-AzFrontDoor -ResourceGroupName "rg1"
```

```output
Global   name1         rg1
Global   name2         rg1
```

Get all FrontDoors in resource group "rg1" in the current subscription.

### Example 3: Get the FrontDoors in resource group "rg1" with name "frontDoor1" in the current subscription.
```powershell
Get-AzFrontDoor -ResourceGroupName "rg1" -Name "frontDoor1"
```

```output
BackendPool          : {BackendPool0}
BackendPoolsSetting  : {
                         "enforceCertificateNameCheck": "Enabled",
                         "sendRecvTimeoutSeconds": 30
                       }
Cname                :
EnabledState         : Disabled
ExtendedProperty     : {
                         "MigratedTo": {link0}
                       }
FriendlyName         : frontDoor1
FrontdoorId          : {guid0}
FrontendEndpoint     : {Endpoint0}
HealthProbeSetting   : {HealthProbeSetting0}
Id                   : /subscriptions/{guid}/resourcegroups/rg1/providers/M
                        icrosoft.Network/frontdoors/frontdoor1
LoadBalancingSetting : {LoadBalancingSetting0}
Location             : Global
Name                 : frontDoor1
ProvisioningState    : Succeeded
ResourceGroupName    : {rg1}
ResourceState        : Migrated
RoutingRule          : {RoutingRule0,RoutingRule1}
RulesEngine          : {RulesEngine0,RulesEngine1}
Tag                  : {
                       }
Type                 : Microsoft.Network/frontdoors
```

Get the FrontDoors in resource group "rg1" with name "frontDoor1" in the current subscription.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoorIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Front Door which is globally unique.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: FrontDoorName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

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
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoorIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoor

## NOTES

## RELATED LINKS

