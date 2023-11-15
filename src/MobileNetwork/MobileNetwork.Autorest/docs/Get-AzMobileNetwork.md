---
external help file:
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.mobilenetwork/get-azmobilenetwork
schema: 2.0.0
---

# Get-AzMobileNetwork

## SYNOPSIS
Gets information about the specified mobile network.

## SYNTAX

### List (Default)
```
Get-AzMobileNetwork [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMobileNetwork -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMobileNetwork -InputObject <IMobileNetworkIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzMobileNetwork -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets information about the specified mobile network.

## EXAMPLES

### Example 1: List information about the specified mobile network by Sub.
```powershell
Get-AzMobileNetwork
```

```output
Location Name     ResourceGroupName PublicLandMobileNetworkIdentifierMcc PublicLandMobileNetworkIdentifierMnc
-------- ----     ----------------- ------------------------------------ ------------------------------------
eastus   azps-mn  azps_test_group   001                                  01
eastus   azps-mn2 azps_test_group   001                                  01
```

List information about the specified mobile network by Sub.

### Example 2: List information about the specified mobile network by ResourceGroup.
```powershell
Get-AzMobileNetwork -ResourceGroupName azps_test_group
```

```output
Location Name     ResourceGroupName PublicLandMobileNetworkIdentifierMcc PublicLandMobileNetworkIdentifierMnc
-------- ----     ----------------- ------------------------------------ ------------------------------------
eastus   azps-mn  azps_test_group   001                                  01
eastus   azps-mn2 azps_test_group   001                                  01
```

List information about the specified mobile network by ResourceGroup.

### Example 3: Get information about the specified mobile network.
```powershell
Get-AzMobileNetwork -ResourceGroupName azps_test_group -Name azps-mn
```

```output
Location Name    ResourceGroupName PublicLandMobileNetworkIdentifierMcc PublicLandMobileNetworkIdentifierMnc
-------- ----    ----------------- ------------------------------------ ------------------------------------
eastus   azps-mn azps_test_group   001                                  01
```

Get information about the specified mobile network.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the mobile network.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: MobileNetworkName

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

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.IMobileNetwork

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IMobileNetworkIdentity>`: Identity Parameter
  - `[AttachedDataNetworkName <String>]`: The name of the attached data network.
  - `[DataNetworkName <String>]`: The name of the data network.
  - `[Id <String>]`: Resource identity path
  - `[MobileNetworkName <String>]`: The name of the mobile network.
  - `[PacketCoreControlPlaneName <String>]`: The name of the packet core control plane.
  - `[PacketCoreDataPlaneName <String>]`: The name of the packet core data plane.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ServiceName <String>]`: The name of the service. You must not use any of the following reserved strings - 'default', 'requested' or 'service'
  - `[SimGroupName <String>]`: The name of the SIM Group.
  - `[SimName <String>]`: The name of the SIM.
  - `[SimPolicyName <String>]`: The name of the SIM policy.
  - `[SiteName <String>]`: The name of the mobile network site.
  - `[SliceName <String>]`: The name of the network slice.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VersionName <String>]`: The name of the packet core control plane version.

## RELATED LINKS

