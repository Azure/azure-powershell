---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/set-azstackhcivmlogicalnetwork
schema: 2.0.0
---

# Set-AzStackHciVMLogicalNetwork

## SYNOPSIS
The operation to create or update a logical network.
Please note some properties can be set only during logical network creation.

## SYNTAX

```
Set-AzStackHciVMLogicalNetwork -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-DhcpOptionDnsServer <String[]>] [-ExtendedLocationName <String>]
 [-ExtendedLocationType <ExtendedLocationTypes>] [-Subnet <ISubnet[]>] [-SystemDataCreatedAt <DateTime>]
 [-SystemDataCreatedBy <String>] [-SystemDataCreatedByType <CreatedByType>]
 [-SystemDataLastModifiedAt <DateTime>] [-SystemDataLastModifiedBy <String>]
 [-SystemDataLastModifiedByType <CreatedByType>] [-Tag <Hashtable>] [-VMSwitchName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to create or update a logical network.
Please note some properties can be set only during logical network creation.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

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
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -DhcpOptionDnsServer
The list of DNS servers IP addresses.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationName
The name of the extended location.

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

### -ExtendedLocationType
The type of the extended location.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes
Parameter Sets: (All)
Aliases:

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
Name of the logical network

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: LogicalNetworkName

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Subnet
Subnet - list of subnets under the logical network
To construct, see NOTES section for SUBNET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.ISubnet[]
Parameter Sets: (All)
Aliases:

Required: False
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

### -SystemDataCreatedAt
The timestamp of resource creation (UTC).

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemDataCreatedBy
The identity that created the resource.

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

### -SystemDataCreatedByType
The type of identity that created the resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemDataLastModifiedAt
The timestamp of resource last modification (UTC)

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemDataLastModifiedBy
The identity that last modified the resource.

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

### -SystemDataLastModifiedByType
The type of identity that last modified the resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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

### -VMSwitchName
name of the network switch to be used for VMs

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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.ILogicalNetworks

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


SUBNET <ISubnet[]>: Subnet - list of subnets under the logical network
  - `[AddressPrefix <String>]`: The address prefix for the subnet: Cidr for this subnet - IPv4, IPv6.
  - `[IPAllocationMethod <IPAllocationMethodEnum?>]`: IPAllocationMethod - The IP address allocation method. Possible values include: 'Static', 'Dynamic'
  - `[IPConfigurationReference <ISubnetPropertiesFormatIPConfigurationReferencesItem[]>]`: IPConfigurationReferences - list of IPConfigurationReferences
    - `[Id <String>]`: IPConfigurationID
  - `[IPPool <IIPPool[]>]`: network associated pool of IP Addresses
    - `[End <String>]`: End of the IP address pool
    - `[Name <String>]`: Name of the IP-Pool
    - `[Start <String>]`: Start of the IP address pool
    - `[Type <IPPoolTypeEnum?>]`: Type of the IP Pool [vm, vippool]
  - `[Name <String>]`: Name - The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[PropertiesAddressPrefixes <String[]>]`: List of address prefixes for the subnet.
  - `[Route <IRoute[]>]`: Collection of routes contained within a route table.
    - `[AddressPrefix <String>]`: The destination CIDR to which the route applies.
    - `[Name <String>]`: Name - name of the subnet
    - `[NextHopIPAddress <String>]`: The IP address packets should be forwarded to. Next hop values are only allowed in routes where the next hop type is VirtualAppliance.
  - `[Vlan <Int32?>]`: Vlan to use for the subnet

## RELATED LINKS

