---
external help file: Az.IoTOperationsService-help.xml
Module Name: Az.IoTOperationsService
online version: https://learn.microsoft.com/powershell/module/az.iotoperationsservice/get-aziotoperationsservicebrokerauthorization
schema: 2.0.0
---

# Get-AzIoTOperationsServiceBrokerAuthorization

## SYNOPSIS
Get a BrokerAuthorizationResource

## SYNTAX

### List (Default)
```
Get-AzIoTOperationsServiceBrokerAuthorization -BrokerName <String> -InstanceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityInstance
```
Get-AzIoTOperationsServiceBrokerAuthorization -AuthorizationName <String> -BrokerName <String>
 -InstanceInputObject <IIoTOperationsServiceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityBroker
```
Get-AzIoTOperationsServiceBrokerAuthorization -AuthorizationName <String>
 -BrokerInputObject <IIoTOperationsServiceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzIoTOperationsServiceBrokerAuthorization -AuthorizationName <String> -BrokerName <String>
 -InstanceName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzIoTOperationsServiceBrokerAuthorization -InputObject <IIoTOperationsServiceIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a BrokerAuthorizationResource

## EXAMPLES

### Example 1: Lists Broker Authorizations
```powershell
Get-AzIoTOperationsServiceBrokerAuthorization -BrokerName "default" -InstanceName "aio-117832708" -ResourceGroupName "aio-validation-117832708"
```

```output
AuthorizationPolicyCache     : Enabled
AuthorizationPolicyRule      :
ExtendedLocationName         : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117832708/providers/Microsoft.ExtendedLocation/customLocations/locati
                               on-117832708
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117832708/providers/Microsoft.IoTOperations/instances/aio-117832708/b
                               rokers/default/authorizations/test-authorization
Name                         : test-authorization
ProvisioningState            : Succeeded
ResourceGroupName            : aio-validation-117832708
SystemDataCreatedAt          : 3/13/2025 4:24:20 PM
SystemDataCreatedBy          : henrymorales@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/13/2025 4:24:26 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Type                         : microsoft.iotoperations/instances/brokers/authorizations
```

Lists broker authorizations

## PARAMETERS

### -AuthorizationName
Name of Instance broker authorization resource

```yaml
Type: System.String
Parameter Sets: GetViaIdentityInstance, GetViaIdentityBroker, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BrokerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: GetViaIdentityBroker
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -BrokerName
Name of broker.

```yaml
Type: System.String
Parameter Sets: List, GetViaIdentityInstance, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: GetViaIdentityInstance
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceName
Name of instance.

```yaml
Type: System.String
Parameter Sets: List, Get
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
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IBrokerAuthorizationResource

## NOTES

## RELATED LINKS
