---
external help file: Az.IoTOperationsService-help.xml
Module Name: Az.IoTOperationsService
online version: https://learn.microsoft.com/powershell/module/az.iotoperationsservice/get-aziotoperationsserviceinstance
schema: 2.0.0
---

# Get-AzIoTOperationsServiceInstance

## SYNOPSIS
Get a InstanceResource

## SYNTAX

### List (Default)
```
Get-AzIoTOperationsServiceInstance [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzIoTOperationsServiceInstance -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzIoTOperationsServiceInstance -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzIoTOperationsServiceInstance -InputObject <IIoTOperationsServiceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a InstanceResource

## EXAMPLES

### Example 1: Get Instance
```powershell
Get-AzIoTOperationsServiceInstance -Name "aio-3lrx4"  -ResourceGroupName  "aio-validation-117026523"
```

```output
Description                  : An AIO instance.
ExtendedLocationName         : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117026523/providers/Microsoft.ExtendedLo
                               cation/customLocations/location-3lrx4
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117026523/providers/Microsoft.IoTOperati
                               ons/instances/aio-3lrx4
IdentityPrincipalId          :
IdentityTenantId             :
IdentityType                 : None
IdentityUserAssignedIdentity : {
                               }
Location                     : eastus2
Name                         : aio-3lrx4
ProvisioningState            : Succeeded
ResourceGroupName            : aio-validation-117026523
SchemaRegistryRefResourceId  : /subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117026523/providers/Microsoft.DeviceRegi
                               stry/schemaRegistries/aio-sr-c7fa257132
SystemDataCreatedAt          : 3/5/2025 5:04:40 PM
SystemDataCreatedBy          : 739f5293-922a-4616-b106-3662530ef99f
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 3/5/2025 5:07:18 PM
SystemDataLastModifiedBy     : 319f651f-7ddb-4fc6-9857-7aef9250bd05
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.iotoperations/instances
Version                      : 1.1.0-main.20250227.13
```

This command gets an instance

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
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of instance.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: InstanceName

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
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IInstanceResource

## NOTES

## RELATED LINKS
