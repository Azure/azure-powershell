---
external help file:
Module Name: Az.DigitalTwins
online version: https://learn.microsoft.com/powershell/module/az.digitaltwins/get-azdigitaltwinsendpoint
schema: 2.0.0
---

# Get-AzDigitalTwinsEndpoint

## SYNOPSIS
Get DigitalTwinsInstances Endpoint.

## SYNTAX

### List (Default)
```
Get-AzDigitalTwinsEndpoint -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDigitalTwinsEndpoint -EndpointName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDigitalTwinsEndpoint -InputObject <IDigitalTwinsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityDigitalTwinsInstance
```
Get-AzDigitalTwinsEndpoint -DigitalTwinsInstanceInputObject <IDigitalTwinsIdentity> -EndpointName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get DigitalTwinsInstances Endpoint.

## EXAMPLES

### Example 1: List AzDigitalTwinsEndpoint in ResourceGroup
```powershell
Get-AzDigitalTwinsEndpoint -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance
```

```output
Name       EndpointType AuthenticationType ResourceGroupName
----       ------------ ------------------ -----------------
azps-dt-sb ServiceBus   KeyBased           azps_test_group
azps-dt-eh EventHub     KeyBased           azps_test_group
azps-dt-eg EventGrid    KeyBased           azps_test_group
```

List all AzDigitalTwinsEndpoints by ResourceGroupName

### Example 2: Get AzDigitalTwinsEndpoint by EndpointName
```powershell
Get-AzDigitalTwinsEndpoint -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -EndpointName azps-dt-eh
```

```output
AuthenticationType           : KeyBased
CreatedTime                  : 2025-06-06 11:16:50 AM
DeadLetterSecret             :
DeadLetterUri                :
EndpointType                 : EventHub
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.DigitalTwins/digitalTwinsInstances/azps-digitaltwins-instance/endpoints/az
                               ps-dt-eh
Name                         : azps-dt-eh
Property                     : {
                                 "endpointType": "EventHub",
                                 "provisioningState": "Succeeded",
                                 "createdTime": "2025-06-06T11:16:50.9480318Z",
                                 "authenticationType": "KeyBased",
                                 "connectionStringPrimaryKey": "Endpoint=sb://(PLACEHOLDER)/;SharedAccessKeyName=(PLACEHOLDER);SharedAccessKey=(PLACEHOLDER);EntityPath=(PLACEHOLDER)"
                               }
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group
SystemDataCreatedAt          : 2025-06-06 11:16:50 AM
SystemDataCreatedBy          : xxxxx.xxxxx@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2025-06-06 11:18:27 AM
SystemDataLastModifiedBy     : xxxxx.xxxxx@microsoft.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.DigitalTwins/digitalTwinsInstances/endpoints
```

Get AzDigitalTwinsEndpoint by EndpointName in ResourceGroup

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

### -DigitalTwinsInstanceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsIdentity
Parameter Sets: GetViaIdentityDigitalTwinsInstance
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EndpointName
Name of Endpoint Resource.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityDigitalTwinsInstance
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsEndpointResource

## NOTES

## RELATED LINKS

