---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabricinterface
schema: 2.0.0
---

# Get-AzNetworkFabricInterface

## SYNOPSIS
Get the Network Interface resource details.

## SYNTAX

### List (Default)
```
Get-AzNetworkFabricInterface -NetworkDeviceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentityNetworkDevice
```
Get-AzNetworkFabricInterface -Name <String> -NetworkDeviceInputObject <IManagedNetworkFabricIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkFabricInterface -Name <String> -NetworkDeviceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFabricInterface -InputObject <IManagedNetworkFabricIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get the Network Interface resource details.

## EXAMPLES

### Example 1: List Network Interfaces
```powershell
Get-AzNetworkFabricInterface -NetworkDeviceName $deviceName -ResourceGroupName $resourceGroupName
```

```output
Name        SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy           SystemDataLastModifiedByType ResourceGroupName
----        ------------------- -------------------       ----------------------- ------------------------ ------------------------           ---------------------------- -----
Ethernet1   09/22/2023 06:53:47 <identity>                Application             09/22/2023 06:53:47      <identity>                         Application                  nfa-…
Ethernet2   09/22/2023 06:53:47 <identity>                Application             09/22/2023 06:53:47      <identity>                         Application                  nfa-…
Ethernet9   09/22/2023 06:53:47 <identity>                Application             09/22/2023 06:53:47      <identity>                         Application                  nfa-…
Ethernet10  09/22/2023 06:53:47 <identity>                Application             09/22/2023 06:53:47      <identity>                         Application                  nfa-…
Ethernet11  09/22/2023 06:53:47 <identity>                Application             09/22/2023 06:53:47      <identity>                         Application                  nfa-…
Ethernet12  09/22/2023 06:53:47 <identity>                Application             09/22/2023 06:53:47      <identity>                         Application                  nfa-…
Ethernet17  09/22/2023 06:53:47 <identity>                Application             09/22/2023 06:53:47      <identity>                         Application                  nfa-…
Ethernet47  09/22/2023 06:53:48 <identity>                Application             09/22/2023 06:53:48      <identity>                         Application                  nfa-…
Ethernet48  09/22/2023 06:53:48 <identity>                Application             09/22/2023 06:53:48      <identity>                         Application                  nfa-…
Ethernet49  09/22/2023 06:53:48 <identity>                Application             09/22/2023 06:53:48      <identity>                         Application                  nfa-…
Ethernet50  09/22/2023 06:53:48 <identity>                Application             09/22/2023 06:53:48      <identity>                         Application                  nfa-…
Management1 09/22/2023 06:53:48 <identity>                Application             09/22/2023 06:53:48      <identity>                         Application                  nfa-…
```

This command gets details of the given Network Interfaces.

### Example 2: Get Network Interface
```powershell
Get-AzNetworkFabricInterface -Name $name -NetworkDeviceName $deviceName -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConnectedTo Id
------------------- ---------- ----------- --
Enabled                        AR-CE1-MA1  /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/netwo…
```

This command gets details of the given Network Interface.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Network Interface.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityNetworkDevice, Get
Aliases: NetworkInterfaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkDeviceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: GetViaIdentityNetworkDevice
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NetworkDeviceName
Name of the Network Device.

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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkInterface

## NOTES

## RELATED LINKS
