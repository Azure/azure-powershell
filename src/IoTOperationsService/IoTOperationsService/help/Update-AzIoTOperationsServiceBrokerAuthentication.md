---
external help file: Az.IoTOperationsService-help.xml
Module Name: Az.IoTOperationsService
online version: https://learn.microsoft.com/powershell/module/az.iotoperationsservice/update-aziotoperationsservicebrokerauthentication
schema: 2.0.0
---

# Update-AzIoTOperationsServiceBrokerAuthentication

## SYNOPSIS
update a BrokerAuthenticationResource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzIoTOperationsServiceBrokerAuthentication -AuthenticationName <String> -BrokerName <String>
 -InstanceName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AuthenticationMethod <IBrokerAuthenticatorMethods[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityInstanceExpanded
```
Update-AzIoTOperationsServiceBrokerAuthentication -AuthenticationName <String> -BrokerName <String>
 -InstanceInputObject <IIoTOperationsServiceIdentity> [-AuthenticationMethod <IBrokerAuthenticatorMethods[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityBrokerExpanded
```
Update-AzIoTOperationsServiceBrokerAuthentication -AuthenticationName <String>
 -BrokerInputObject <IIoTOperationsServiceIdentity> [-AuthenticationMethod <IBrokerAuthenticatorMethods[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzIoTOperationsServiceBrokerAuthentication -InputObject <IIoTOperationsServiceIdentity>
 [-AuthenticationMethod <IBrokerAuthenticatorMethods[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
update a BrokerAuthenticationResource

## EXAMPLES

### Example 1: Update a broker authentication
```powershell
Update-AzIoTOperationsServiceBrokerAuthentication `
  -AuthenticationName "my-authn" `
  -BrokerName "default" `
  -InstanceName "aio-117832708" `
  -ResourceGroupName "aio-validation-117832708" `
  -AuthenticationMethod @(
      @{
          method = "X509"
          x509Settings = @{
              trustedClientCaCert = "client-ca"
          }
      }
  )
```

```output
AuthenticationMethod         : {{
                                 "x509Settings": {
                                   "trustedClientCaCert": "client-ca"
                                 },
                                 "method": "X509"
                               }}
ExtendedLocationName         : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117832708/providers/Microsoft.ExtendedLocation/customLocations/location-11783270
                               8
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117832708/providers/Microsoft.IoTOperations/instances/aio-117832708/brokers/defa
                               ult/authentications/test-authentication
Name                         : test-authentication
ProvisioningState            : Succeeded
ResourceGroupName            : aio-validation-117832708
SystemDataCreatedAt          : 3/13/2025 4:24:46 PM
SystemDataCreatedBy          : henrymorales@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/13/2025 4:24:54 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Type                         : microsoft.iotoperations/instances/brokers/authentications
```

Update a broker auth

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthenticationMethod
Defines a set of Broker authentication methods to be used on `BrokerListeners`.
For each array element one authenticator type supported.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IBrokerAuthenticatorMethods[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthenticationName
Name of Instance broker authentication resource

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityInstanceExpanded, UpdateViaIdentityBrokerExpanded
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
Parameter Sets: UpdateViaIdentityBrokerExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityInstanceExpanded
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
Parameter Sets: UpdateViaIdentityExpanded
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
Parameter Sets: UpdateViaIdentityInstanceExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IBrokerAuthenticationResource

## NOTES

## RELATED LINKS
