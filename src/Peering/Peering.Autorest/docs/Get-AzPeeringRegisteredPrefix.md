---
external help file:
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/get-azpeeringregisteredprefix
schema: 2.0.0
---

# Get-AzPeeringRegisteredPrefix

## SYNOPSIS
Gets an existing registered prefix with the specified name under the given subscription, resource group and peering.

## SYNTAX

### List (Default)
```
Get-AzPeeringRegisteredPrefix -PeeringName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPeeringRegisteredPrefix -Name <String> -PeeringName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPeeringRegisteredPrefix -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an existing registered prefix with the specified name under the given subscription, resource group and peering.

## EXAMPLES

### Example 1: List all registered prefixes for a peering
```powershell
Get-AzPeeringRegisteredPrefix -PeeringName DemoPeering -ResourceGroupName DemoRG
```

```output
Name                  Prefix       PeeringServicePrefixKey              PrefixValidationState ProvisioningState
----                  ------       -----------------------              --------------------- -----------------
accessibilityTesting1 240.0.0.0/24 f5947454-80e3-4ce5-bcb3-2501537b6952 Failed                Succeeded
accessibilityTesting2 240.0.1.0/24 249aa0dd-6177-4105-94fe-dfefcbf5ab48 Failed                Succeeded
accessibilityTesting3 240.0.2.0/24 4fb59e9e-d4eb-4847-b2ad-9939edda750b Failed                Succeeded
accessibilityTesting4 240.0.4.0/24 b725f16c-759b-4144-93ed-ed4eb89cb8f7 Failed                Succeeded
accessibilityTesting5 240.0.3.0/24 bb1262ca-0b31-45f3-a301-105b0615b21c Failed                Succeeded
```

List all registered prefixes

### Example 2: Get specific registered prefix for a peering
```powershell
Get-AzPeeringRegisteredPrefix -PeeringName DemoPeering -ResourceGroupName DemoRG -Name accessibilityTesting1
```

```output
Name                  Prefix       PeeringServicePrefixKey              PrefixValidationState ProvisioningState
----                  ------       -----------------------              --------------------- -----------------
accessibilityTesting1 240.0.0.0/24 f5947454-80e3-4ce5-bcb3-2501537b6952 Failed                Succeeded
```

Get a specific registered prefix by name

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the registered prefix.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: RegisteredPrefixName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringName
The name of the peering.

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

### -ResourceGroupName
The name of the resource group.

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
The Azure subscription ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IPeeringRegisteredPrefix

## NOTES

## RELATED LINKS

