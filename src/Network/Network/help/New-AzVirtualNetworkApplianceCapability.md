---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azvirtualnetworkappliancecapability
schema: 2.0.0
---

# New-AzVirtualNetworkApplianceCapability

## SYNOPSIS
Creates a capability on a Virtual Network Appliance (VNA).

## SYNTAX

```
New-AzVirtualNetworkApplianceCapability -Name <String> -VirtualNetworkApplianceName <String>
 -ResourceGroupName <String> -Kind <String> [-IpVersion <String>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [-AcquirePolicyToken]
 [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The New-AzVirtualNetworkApplianceCapability cmdlet creates a capability child resource on an existing Virtual Network Appliance.
The capability kind is selected with the -Kind parameter. The three Private Link kinds (PLGatewayFastpath, PLGateway, PLIPForwarders) require an -IpVersion; NAT64 is property-less and does not accept -IpVersion. The parent appliance must be dual-stack.

## EXAMPLES

### Example 1: Create a Private Link Gateway FastPath capability
```powershell
New-AzVirtualNetworkApplianceCapability -ResourceGroupName "myResourceGroup" -VirtualNetworkApplianceName "myVNA" -Name "pl-fastpath" -Kind "PLGatewayFastpath" -IpVersion "DualStack"
```

Creates a PLGatewayFastpath capability. This kind requires the DualStack IP version.

### Example 2: Create a Private Link Gateway capability
```powershell
New-AzVirtualNetworkApplianceCapability -ResourceGroupName "myResourceGroup" -VirtualNetworkApplianceName "myVNA" -Name "pl-gateway" -Kind "PLGateway" -IpVersion "IPv6"
```

Creates a PLGateway capability. This kind requires the IPv6 IP version (as does PLIPForwarders).

### Example 3: Create a NAT64 capability
```powershell
New-AzVirtualNetworkApplianceCapability -ResourceGroupName "myResourceGroup" -VirtualNetworkApplianceName "myVNA" -Name "nat64" -Kind "NAT64"
```

Creates a NAT64 capability. NAT64 is property-less and must not be given an -IpVersion.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

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

### -AsJob
Run cmdlet in the background

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

### -ChangeReference
The change reference resource ID for this resource operation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Force
Do not ask for confirmation if you want to overwrite a resource

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

### -IpVersion
The IP version the capability applies to. Required for the Private Link kinds: PLGatewayFastpath requires DualStack; PLGateway and PLIPForwarders require IPv6. Must not be set for NAT64 (property-less). Possible values: IPv6, DualStack.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: IPv6, DualStack

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Kind
The capability kind. Possible values: PLGatewayFastpath, PLGateway, PLIPForwarders, NAT64.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: PLGatewayFastpath, PLGateway, PLIPForwarders, NAT64

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The capability name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases: ApplianceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkApplianceCapability

## NOTES

## RELATED LINKS
