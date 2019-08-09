---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-azinterfaceendpoint
schema: 2.0.0
---

# Set-AzInterfaceEndpoint

## SYNOPSIS
Creates or updates an interface endpoint in the specified resource group.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzInterfaceEndpoint -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-EndpointServiceId <String>] [-Etag <String>] [-Fqdn <String>] [-Id <String>] [-Location <String>]
 [-Subnet <ISubnet_Reference>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzInterfaceEndpoint -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -InterfaceEndpoint <IInterfaceEndpoint> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an interface endpoint in the specified resource group.

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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -EndpointServiceId
A unique identifier of the service being referenced by the interface endpoint.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Etag
Gets a unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Fqdn
A first-party service's FQDN that is mapped to the private IP allocated via this interface endpoint.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
Resource ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InterfaceEndpoint
Interface endpoint resource.
To construct, see NOTES section for INTERFACEENDPOINT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpoint
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the interface endpoint.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: InterfaceEndpointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Subnet
The ID of the subnet from which the private IP will be allocated.
To construct, see NOTES section for SUBNET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet_Reference
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpoint

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpoint

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### INTERFACEENDPOINT <IInterfaceEndpoint>: Interface endpoint resource.
  - `[Id <String>]`: Resource ID.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[EndpointServiceId <String>]`: A unique identifier of the service being referenced by the interface endpoint.
  - `[Etag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
  - `[Fqdn <String>]`: A first-party service's FQDN that is mapped to the private IP allocated via this interface endpoint.
  - `[Subnet <ISubnet>]`: The ID of the subnet from which the private IP will be allocated.

#### SUBNET <ISubnet_Reference>: The ID of the subnet from which the private IP will be allocated.
  - `[AddressPrefix <String[]>]`: List of  address prefixes for the subnet.
  - `[Delegation <IDelegation[]>]`: Gets an array of references to the delegations on the subnet.
    - `[Id <String>]`: Resource ID.
    - `[Action <String[]>]`: Describes the actions permitted to the service upon delegation
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a subnet. This name can be used to access the resource.
    - `[ServiceName <String>]`: The name of the service to whom the subnet should be delegated (e.g. Microsoft.Sql/servers)
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[NatGatewayId <String>]`: Resource ID.
  - `[Nsg <INetworkSecurityGroup>]`: The reference of the NetworkSecurityGroup resource.
  - `[PropertiesAddressPrefix <String>]`: The address prefix for the subnet.
  - `[ProvisioningState <String>]`: The provisioning state of the resource.
  - `[ResourceNavigationLink <IResourceNavigationLink[]>]`: Gets an array of references to the external resources using subnet.
  - `[RouteTable <IRouteTable>]`: The reference of the RouteTable resource.
  - `[ServiceAssociationLink <IServiceAssociationLink[]>]`: Gets an array of references to services injecting into this subnet.
  - `[ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]`: An array of service endpoints.
  - `[ServiceEndpointPolicy <IServiceEndpointPolicy[]>]`: An array of service endpoint policies.

## RELATED LINKS

