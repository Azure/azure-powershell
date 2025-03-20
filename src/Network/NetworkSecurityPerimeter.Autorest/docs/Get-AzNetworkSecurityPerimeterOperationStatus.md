---
external help file:
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworksecurityperimeteroperationstatus
schema: 2.0.0
---

# Get-AzNetworkSecurityPerimeterOperationStatus

## SYNOPSIS
Gets the operation status for the given operation id.

## SYNTAX

### Get (Default)
```
Get-AzNetworkSecurityPerimeterOperationStatus -Location <String> -OperationId <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkSecurityPerimeterOperationStatus -InputObject <INetworkSecurityPerimeterIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzNetworkSecurityPerimeterOperationStatus -LocationInputObject <INetworkSecurityPerimeterIdentity>
 -OperationId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the operation status for the given operation id.

## EXAMPLES

### Example 1: Get the Network security perimeter operation status
```powershell
Get-AzNetworkSecurityPerimeterOperationStatus -Location eastus2euap -OperationId 1e368a97-a861-480f-81bf-bbefba34c4b1 -SubscriptionId e82485c6-11f7-4775-8266-0e2c4e78ee25
```

```output
AdditionalInfo    :
Code              :
Detail            :
EndTime           : 3/12/2025 8:42:00 AM
Id                : /subscriptions/e82485c6-11f7-4775-8266-0e2c4e78ee25/providers/Microsoft.Network/locations/eastus2euap/networkSecurityPerimeterOperationStatuses/e368a97-a861-480f-81bf-bbefba34c4b1
Message           :
Name              : e368a97-a861-480f-81bf-bbefba34c4b1
Operation         :
PercentComplete   :
ResourceGroupName :
ResourceId        :
StartTime         : 3/12/2025 8:41:56 AM
Status            : Succeeded
Target            :
```

Get the Network security perimeter operation status


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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The location of network security perimeter.

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

### -LocationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity
Parameter Sets: GetViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OperationId
The operation id of the async operation.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation
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
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IOperationStatusResult

## NOTES

## RELATED LINKS

