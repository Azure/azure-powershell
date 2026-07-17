---
external help file:
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/get-azscvmmcloud
schema: 2.0.0
---

# Get-AzScVmmCloud

## SYNOPSIS
Implements Cloud GET method.

## SYNTAX

### List (Default)
```
Get-AzScVmmCloud [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzScVmmCloud -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzScVmmCloud -InputObject <IScVmmIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzScVmmCloud -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Implements Cloud GET method.

## EXAMPLES

### Example 1: Get Cloud By Subscription Id
```powershell
Get-AzScVmmCloud -SubscriptionId "00000000-abcd-0000-abcd-000000000000"
```

```output
Name            ResourceGroupName Uuid                                 ProvisioningState
----            ----------------- ----                                 -----------------
test-cloud      test-rg-01        00000000-1111-0000-0002-000000000000 Succeeded
test-cloud-02   test-rg-01        00000000-1111-0000-0011-000000000000 Succeeded
test-cloud-03   test-rg-01        00000000-1111-0000-0012-000000000000 Succeeded
test-cloud-04   test-rg-02        00000000-1111-0000-0013-000000000000 Succeeded
test-cloud-05   test-rg-02        00000000-1111-0000-0014-000000000000 Succeeded
test-cloud-06   test-rg-03        00000000-1111-0000-0015-000000000000 Succeeded
```

This command lists Cloud in provided subscription.

### Example 2: Get Cloud By ResourceGroup
```powershell
Get-AzScVmmCloud -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -ResourceGroupName "test-rg-01"
```

```output
Name            ResourceGroupName Uuid                                 ProvisioningState
----            ----------------- ----                                 -----------------
test-cloud      test-rg-01        00000000-1111-0000-0002-000000000000 Succeeded
test-cloud-02   test-rg-01        00000000-1111-0000-0011-000000000000 Succeeded
test-cloud-03   test-rg-01        00000000-1111-0000-0012-000000000000 Succeeded
```

This command lists Cloud in provided Resource Group.

### Example 3: Get Cloud
```powershell
Get-AzScVmmCloud -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -ResourceGroupName "test-rg-01" -Name "test-cloud"
```

```output
CapacityCpuCount             : 10
CapacityMemoryMb             : 10240
CapacityVMCount              : 10
CloudName                    : test-cloud
ExtendedLocationName         : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ExtendedLocation/customLocations/test-cl
ExtendedLocationType         : customLocation
Id                           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/clouds/test-cloud
InventoryItemId              : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01/InventoryItems/00000000-1111-0000-0002-000000000000
Location                     : eastus
Name                         : test-cloud
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg-01
StorageQoSPolicy             : {}
SystemDataCreatedAt          : 08-01-2024 15:05:41
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 08-01-2024 18:14:34
SystemDataLastModifiedBy     : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "key-1": "value-1"
                               }
Type                         : microsoft.scvmm/clouds
Uuid                         : 00000000-1111-0000-0002-000000000000
VmmServerId                  : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01
```

This command gets the Cloud named `test-cloud` in the resource group named `test-rg-01`.

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
Name of the Cloud.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: CloudResourceName

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

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.ICloud

## NOTES

## RELATED LINKS

