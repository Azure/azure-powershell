---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/az.frontdoor/get-azfrontdoorfrontendendpoint
schema: 2.0.0
---

# Get-AzFrontDoorFrontendEndpoint

## SYNOPSIS
Gets a Frontend endpoint with the specified name within the specified Front Door.

## SYNTAX

### ByFieldsParameterSet (Default)
```
Get-AzFrontDoorFrontendEndpoint -FrontDoorName <String> -ResourceGroupName <String> [-Name <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ByObjectParameterSet
```
Get-AzFrontDoorFrontendEndpoint -FrontDoorInputObject <IFrontDoorIdentity> [-Name <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzFrontDoorFrontendEndpoint -FrontDoorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzFrontDoorFrontendEndpoint -InputObject <IFrontDoorIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityFrontDoor
```
Get-AzFrontDoorFrontendEndpoint -FrontDoorInputObject <IFrontDoorIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzFrontDoorFrontendEndpoint -FrontDoorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a Frontend endpoint with the specified name within the specified Front Door.

## EXAMPLES

### Example 1: Get a specific frontend endpoint by name
```powershell
Get-AzFrontDoorFrontendEndpoint -ResourceGroupName "myResourceGroup" -FrontDoorName "myFrontDoor" -Name "myFrontDoor-azurefd-net"
```

```output
HostName                         : myFrontDoor-azurefd.net
SessionAffinityEnabledState      : Disabled
SessionAffinityTtlSeconds        : 0
WebApplicationFirewallPolicyLink : 
CustomHttpsProvisioningState     : Enabled
CustomHttpsProvisioningSubstate  : CertificateProvisioned
CertificateSource                : FrontDoor
MinimumTlsVersion                : 1.2
ResourceState                    : Enabled
Id                               : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/myResourceGroup/providers/Microsoft.Network/frontDoors/myFrontDoor/frontendEndpoints/myFrontDoor-azurefd-net
Name                             : myFrontDoor-azurefd-net
Type                             : Microsoft.Network/frontDoors/frontendEndpoints
```

Get details of a specific frontend endpoint from the Front Door configuration.

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

### -FrontDoorInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoorIdentity
Parameter Sets: ByObjectParameterSet, GetViaIdentityFrontDoor
Aliases: FrontDoorObject

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FrontDoorName
Name of the Front Door which is globally unique.

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet, Get, List
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
Name of the Frontend endpoint which is unique within the Front Door.

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet, ByObjectParameterSet, Get, GetViaIdentityFrontDoor
Aliases: FrontendEndpointName

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
Parameter Sets: ByFieldsParameterSet, Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoorIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontendEndpoint

## NOTES

## RELATED LINKS

