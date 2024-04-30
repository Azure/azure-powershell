---
external help file: Az.ConnectedNetwork-help.xml
Module Name: Az.ConnectedNetwork
online version: https://learn.microsoft.com/powershell/module/az.connectednetwork/new-azconnectednetworkdevice
schema: 2.0.0
---

# New-AzConnectedNetworkDevice

## SYNOPSIS
Creates or updates a device.

## SYNTAX

```
New-AzConnectedNetworkDevice -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-Property <IDevicePropertiesFormat>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a device.

## EXAMPLES

### Example 1: New-AzConnectedNetworkDevice
```powershell
$ase = New-AzConnectedNetworkAzureStackEdgeObject -AzureStackEdgeId "/subscriptions/xxxxx-00000-xxxxx-00000/resourcegroups/myResources/providers/Microsoft.DataBoxEdge/dataBoxEdgeDevices/myAse"
New-AzConnectedNetworkDevice -Name "myMecDevice" -ResourceGroupName "myResources" -Location "eastus" -Property $ase
```

```output
DeviceType                   : AzureStackEdge
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/resourceGroups/myResources/providers/Microsoft.HybridNetwork/devices/myMecDevice
Location                     : eastus
Name                         : myMecDevice
NetworkFunction              :
ProvisioningState            : Succeeded
ResourceGroupName            : myResources
Status                       : NotRegistered
SystemDataCreatedAt          : 11/25/2021 4:47:45 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : myVendor
SystemDataLastModifiedAt     : 11/25/2021 4:47:47 AM
SystemDataLastModifiedBy     : xxxxx-11111-xxxxx-11111
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20.TrackedResourceTags
Type                         : microsoft.hybridnetwork/devices
```

Create a device with Device Name with resource myMecDevice name in Resource Group myResources, Location eastus with Ase Device Id /subscriptions/xxxxx-00000-xxxxx-00000/resourcegroups/myResources/providers/Microsoft.DataBoxEdge/dataBoxEdgeDevices/myAse.

### Example 2:  New-AzConnectedNetworkDevice
```powershell
$ase = New-AzConnectedNetworkAzureStackEdgeObject -AzureStackEdgeId "/subscriptions/xxxxx-00000-xxxxx-00000/resourcegroups/myResources/providers/Microsoft.DataBoxEdge/dataBoxEdgeDevices/myAse1"
New-AzConnectedNetworkDevice -Name "myMecDevice1" -ResourceGroupName "myResources" -Location "eastus2euap" -Property $ase -SubscriptionId xxxxx-00000-xxxxx-00000
```

```output
DeviceType                   : AzureStackEdge
Id                           : /subscriptions/xxxxx-00000-xxxxx-00000/resourceGroups/myResources/providers/Microsoft.HybridNetwork/devices/myMecDevice1
Location                     : eastus
Name                         : myMecDevice1
NetworkFunction              :
ProvisioningState            : Succeeded
ResourceGroupName            : myResources
Status                       : Registered
SystemDataCreatedAt          : 11/25/2021 4:49:34 AM
SystemDataCreatedBy          : user@microsoft.com
SystemDataCreatedByType      : myVendor
SystemDataLastModifiedAt     : 11/25/2021 4:57:47 AM
SystemDataLastModifiedBy     : xxxxx-11111-xxxxx-11111
SystemDataLastModifiedByType : Application
Tag                          : Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20.TrackedResourceTags
Type                         : microsoft.hybridnetwork/devices
```

Create a device with Device Name myMecDevice1 in Resource Group myResources, Location eastus2euap, SubscriptionId and Ase Device Id /subscriptions/xxxxx-00000-xxxxx-00000/resourcegroups/myResources/providers/Microsoft.DataBoxEdge/dataBoxEdgeDevices/myAse1.

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

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Resource name for the device resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DeviceName

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

### -Property
Device properties.
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.IDevicePropertiesFormat
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
Parameter Sets: (All)
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.IDevice

## NOTES

## RELATED LINKS
