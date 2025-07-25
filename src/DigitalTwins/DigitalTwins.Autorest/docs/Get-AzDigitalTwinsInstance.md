---
external help file:
Module Name: Az.DigitalTwins
online version: https://learn.microsoft.com/powershell/module/az.digitaltwins/get-azdigitaltwinsinstance
schema: 2.0.0
---

# Get-AzDigitalTwinsInstance

## SYNOPSIS
Get DigitalTwinsInstances resource.

## SYNTAX

### List (Default)
```
Get-AzDigitalTwinsInstance [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDigitalTwinsInstance -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDigitalTwinsInstance -InputObject <IDigitalTwinsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzDigitalTwinsInstance -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get DigitalTwinsInstances resource.

## EXAMPLES

### Example 1: List DigitalTwinsInstances resource.
```powershell
Get-AzDigitalTwinsInstance
```

```output
Name                         Location ResourceGroupName
----                         -------- -----------------
azps-digitaltwins-instance   eastus   azps_test_group
azps-digitaltwins-instance-2 eastus   azps_test_group
```

List DigitalTwinsInstances resource.

### Example 2: Get DigitalTwinsInstances resource by ResourceGroup.
```powershell
Get-AzDigitalTwinsInstance -ResourceGroupName azps_test_group
```

```output
Name                         Location ResourceGroupName
----                         -------- -----------------
azps-digitaltwins-instance   eastus   azps_test_group
azps-digitaltwins-instance-2 eastus   azps_test_group
```

Get DigitalTwinsInstances resource by ResourceGroup.

### Example 3: Get DigitalTwinsInstances resource by Instance Name.
```powershell
Get-AzDigitalTwinsInstance -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance
```

```output
CreatedTime                  : 2025-06-06 09:44:17 AM
HostName                     : azps-digitaltwins-instance.api.eus.digitaltwins.azure.net
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.DigitalTwins/digitalTwinsInstances/azps-digitaltwins-instance
IdentityPrincipalId          : 6463ae74-a748-4f95-acf9-7d76e1d343b3
IdentityTenantId             : 213e87ed-8e08-4eb4-a63c-c073058f7b00
IdentityType                 : SystemAssigned
LastUpdatedTime              : 2025-06-06 09:45:03 AM
Location                     : eastus
Name                         : azps-digitaltwins-instance
PrivateEndpointConnection    : {}
ProvisioningState            : Succeeded
PublicNetworkAccess          : Enabled
ResourceGroupName            : azps_test_group
SystemDataCreatedAt          : 2025-06-06 09:44:15 AM
SystemDataCreatedBy          : xxxxx.xxxxx@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2025-06-06 09:44:15 AM
SystemDataLastModifiedBy     : xxxxx.xxxxx@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.DigitalTwins/digitalTwinsInstances
```

Get DigitalTwinsInstances resource by Instance Name.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the DigitalTwinsInstance.

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

### -ResourceName
The name of the DigitalTwinsInstance.

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
The subscription identifier.

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

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsDescription

## NOTES

## RELATED LINKS

