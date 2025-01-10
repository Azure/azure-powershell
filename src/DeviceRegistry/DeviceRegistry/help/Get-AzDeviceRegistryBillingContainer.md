---
external help file: Az.DeviceRegistry-help.xml
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/get-azdeviceregistrybillingcontainer
schema: 2.0.0
---

# Get-AzDeviceRegistryBillingContainer

## SYNOPSIS
Get a BillingContainer

## SYNTAX

### List (Default)
```
Get-AzDeviceRegistryBillingContainer [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzDeviceRegistryBillingContainer -Name <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDeviceRegistryBillingContainer -InputObject <IDeviceRegistryIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get a BillingContainer

## EXAMPLES

### Example 1: list all billing containers from a specified subscription
```powershell
Get-AzDeviceRegistryBillingContainer -SubscriptionId xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
```

```output
Name                   SystemDataCreatedAt   SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType
--------------------   -------------------   ------------------- ----------------------- ------------------------ ------------------------             ----------------------------
my-billingContainer1   12/18/2024 7:36:44 PM user@outlook.com    User                    12/18/2024 7:43:58 PM    319f651f-7ddb-4fc6-9857-7aef9250bd05 Application
my-billingContainer2   12/19/2024 8:52:54 PM user@outlook.com    User                    12/19/2024 8:53:02 PM    319f651f-7ddb-4fc6-9857-7aef9250bd05 Application
```

This command lists all the Device Registry billing containers from subscription `xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx`

### Example 2: get a billing container by name
```powershell
Get-AzDeviceRegistryBillingContainer -SubscriptionId xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -Name my-billingContainer1
```

```output
Etag                         : "1f00ec86-0000-0500-0000-66e9d6ab0000"
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.DeviceRegistry/billingContainers/adr-billing
Name                         : adr-billing
ProvisioningState            : Succeeded
ResourceGroupName            :
SystemDataCreatedAt          : 9/6/2024 12:31:24 AM
SystemDataCreatedBy          : 6ce3f5ab-5f16-4633-a660-21ceb8d74c01
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 9/17/2024 7:21:14 PM
SystemDataLastModifiedBy     : 6ce3f5ab-5f16-4633-a660-21ceb8d74c01
SystemDataLastModifiedByType : Application
Type                         : microsoft.deviceregistry/billingcontainers
```

This command gets the Device Registry billing container `my-billingContainer1` from subscription `xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx`

### Example 3: GetViaIdentity for billing container
```powershell
$billingContainer = @{
  SubscriptionId = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
  BillingContainerName = "my-billingContainer1"
}
Get-AzDeviceRegistryBillingContainer -InputObject $billingContainer
```

```output
Etag                         : "1f00ec86-0000-0500-0000-66e9d6ab0000"
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.DeviceRegistry/billingContainers/adr-billing
Name                         : adr-billing
ProvisioningState            : Succeeded
ResourceGroupName            :
SystemDataCreatedAt          : 9/6/2024 12:31:24 AM
SystemDataCreatedBy          : 6ce3f5ab-5f16-4633-a660-21ceb8d74c01
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 9/17/2024 7:21:14 PM
SystemDataLastModifiedBy     : 6ce3f5ab-5f16-4633-a660-21ceb8d74c01
SystemDataLastModifiedByType : Application
Type                         : microsoft.deviceregistry/billingcontainers
```

This command gets the Device Registry billing container `my-billingContainer1` from subscription `xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx` via the Identity input object.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the billing container.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: BillingContainerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IBillingContainer

## NOTES

## RELATED LINKS
