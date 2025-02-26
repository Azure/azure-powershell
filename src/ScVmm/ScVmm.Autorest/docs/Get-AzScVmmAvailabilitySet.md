---
external help file:
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/get-azscvmmavailabilityset
schema: 2.0.0
---

# Get-AzScVmmAvailabilitySet

## SYNOPSIS
Implements AvailabilitySet GET method.

## SYNTAX

### List (Default)
```
Get-AzScVmmAvailabilitySet [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzScVmmAvailabilitySet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzScVmmAvailabilitySet -InputObject <IScVmmIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzScVmmAvailabilitySet -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Implements AvailabilitySet GET method.

## EXAMPLES

### Example 1: Get Availability Set By Subscription Id
```powershell
Get-AzScVmmAvailabilitySet -SubscriptionId "00000000-abcd-0000-abcd-000000000000"
```

```output
Name            ResourceGroupName ProvisioningState
----            ----------------- -----------------
test-avset      test-rg-01        Succeeded
test-avset-02   test-rg-01        Succeeded
test-avset-03   test-rg-01        Succeeded
test-avset-04   test-rg-02        Succeeded
test-avset-05   test-rg-02        Succeeded
test-avset-06   test-rg-03        Succeeded
```

This command list Availability Sets in provided subscription.

### Example 2: Get Availability Set By Resource Group
```powershell
Get-AzScVmmAvailabilitySet -ResourceGroupName "test-rg-01" -SubscriptionId "00000000-abcd-0000-abcd-000000000000"
```

```output
Name            ResourceGroupName ProvisioningState
----            ----------------- -----------------
test-avset      test-rg-01        Succeeded
test-avset-02   test-rg-01        Succeeded
test-avset-03   test-rg-01        Succeeded
```

This command list Availability Sets in provided Resource Group.

### Example 3: Get Availability Set
```powershell
Get-AzScVmmAvailabilitySet -Name "test-avset" -ResourceGroupName "test-rg-01" -SubscriptionId "00000000-abcd-0000-abcd-000000000000"
```

```output
AvailabilitySetName          : test-avset
ExtendedLocationName         : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ExtendedLocation/customLocations/test-cl
ExtendedLocationType         : customLocation
Id                           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/availabilitySets/test-avset
Location                     : eastus
Name                         : test-avset
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg-01
SystemDataCreatedAt          : 08-01-2024 15:05:41
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 08-01-2024 18:14:34
SystemDataLastModifiedBy     : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.scvmm/availabilitysets
VmmServerId                  : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01
```

This command gets the Availability Set named `test-avset` in the resource group named `test-rg-01`.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IScVmmIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the AvailabilitySet.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: AvailabilitySetResourceName

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

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IScVmmIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IAvailabilitySet

## NOTES

## RELATED LINKS

