---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azvirtualnetworkappliancecapability
schema: 2.0.0
---

# Get-AzVirtualNetworkApplianceCapability

## SYNOPSIS
Gets a capability of a Virtual Network Appliance (VNA), or lists all capabilities on an appliance.

## SYNTAX

### ResourceNameParameterSet (Default)
```
Get-AzVirtualNetworkApplianceCapability [-Name <String>] -VirtualNetworkApplianceName <String>
 -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzVirtualNetworkApplianceCapability -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The Get-AzVirtualNetworkApplianceCapability cmdlet gets a single capability of a Virtual Network Appliance by name, or lists all capabilities on the appliance when -Name is omitted. A capability can also be retrieved by its full resource ID.

## EXAMPLES

### Example 1: Get a capability by name
```powershell
Get-AzVirtualNetworkApplianceCapability -ResourceGroupName "myResourceGroup" -VirtualNetworkApplianceName "myVNA" -Name "pl-gateway"
```

Gets the capability named "pl-gateway" on the appliance "myVNA".

### Example 2: List all capabilities on an appliance
```powershell
Get-AzVirtualNetworkApplianceCapability -ResourceGroupName "myResourceGroup" -VirtualNetworkApplianceName "myVNA"
```

Lists every capability on the appliance "myVNA".

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The capability name.

```yaml
Type: System.String
Parameter Sets: ResourceNameParameterSet
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ResourceNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource Id of the capability.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualNetworkApplianceName
The name of the parent Virtual Network Appliance.

```yaml
Type: System.String
Parameter Sets: ResourceNameParameterSet
Aliases: ApplianceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkApplianceCapability

## NOTES

## RELATED LINKS
