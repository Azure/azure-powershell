---
external help file:
Module Name: Az.HybridNetwork
online version: https://docs.microsoft.com/powershell/module/az.hybridnetwork/set-azhybridnetworkfunction
schema: 2.0.0
---

# Set-AzHybridNetworkFunction

## SYNOPSIS
Creates or updates a network function resource.
This operation can take up to 6 hours to complete.
This is expected service behavior.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzHybridNetworkFunction -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-DeviceId <String>] [-Etag <String>] [-ManagedApplicationParameter <IAny>]
 [-NetworkFunctionContainerConfiguration <IAny>]
 [-NetworkFunctionUserConfiguration <INetworkFunctionUserConfiguration[]>] [-SkuName <String>]
 [-Tag <Hashtable>] [-VendorName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzHybridNetworkFunction -Name <String> -ResourceGroupName <String> -Parameter <INetworkFunction>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a network function resource.
This operation can take up to 6 hours to complete.
This is expected service behavior.

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

### -DeviceId
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
```

### -Etag
A unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedApplicationParameter
The parameters for the managed application.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HybridNetwork.Models.IAny
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Resource name for the network function resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: NetworkFunctionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkFunctionContainerConfiguration
The network function container configurations from the user.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HybridNetwork.Models.IAny
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkFunctionUserConfiguration
The network function configurations from the user.
To construct, see NOTES section for NETWORKFUNCTIONUSERCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HybridNetwork.Models.Api20210501.INetworkFunctionUserConfiguration[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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

### -Parameter
Network function resource response.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HybridNetwork.Models.Api20210501.INetworkFunction
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -SkuName
The sku name for the network function.
Once set, it cannot be updated.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
```

### -VendorName
The vendor name for the network function.
Once set, it cannot be updated.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.HybridNetwork.Models.Api20210501.INetworkFunction

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HybridNetwork.Models.Api20210501.INetworkFunction

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


NETWORKFUNCTIONUSERCONFIGURATION <INetworkFunctionUserConfiguration[]>: The network function configurations from the user.
  - `[NetworkInterface <INetworkInterface[]>]`: The network interface configuration.
    - `[IPConfiguration <INetworkInterfaceIPConfiguration[]>]`: A list of IP configurations of the network interface.
      - `[DnsServer <String[]>]`: The list of DNS servers IP addresses.
      - `[Gateway <String>]`: The value of the gateway.
      - `[IPAddress <String>]`: The value of the IP address.
      - `[IPAllocationMethod <IPAllocationMethod?>]`: IP address allocation method.
      - `[IPVersion <IPVersion?>]`: IP address version.
      - `[Subnet <String>]`: The value of the subnet.
    - `[MacAddress <String>]`: The MAC address of the network interface.
    - `[Name <String>]`: The name of the network interface.
    - `[VMSwitchType <VMSwitchType?>]`: The type of the VM switch.
  - `[OSProfileCustomData <String>]`: Specifies a base-64 encoded string of custom data. The base-64 encoded string is decoded to a binary array that is saved as a file on the virtual machine. The maximum length of the binary array is 65535 bytes.    **Note: Do not pass any secrets or passwords in customData property**    This property cannot be updated after the VM is created.    customData is passed to the VM to be saved as a file. For more information see [Custom Data on Azure VMs](https://azure.microsoft.com/en-us/blog/custom-data-and-cloud-init-on-windows-azure/)    For using cloud-init for your Linux VM, see [Using cloud-init to customize a Linux VM during creation](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-using-cloud-init?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json)
  - `[RoleName <String>]`: The name of the network function role.
  - `[UserDataParameter <IAny>]`: The user data parameters from the customer.

PARAMETER <INetworkFunction>: Network function resource response.
  - `Location <String>`: The geo-location where the resource lives
  - `[Tag <ITrackedResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[ContainerConfiguration <IAny>]`: The network function container configurations from the user.
  - `[DeviceId <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[ManagedApplicationId <String>]`: Resource ID.
  - `[ManagedApplicationParameter <IAny>]`: The parameters for the managed application.
  - `[SkuName <String>]`: The sku name for the network function. Once set, it cannot be updated.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[UserConfiguration <INetworkFunctionUserConfiguration[]>]`: The network function configurations from the user.
    - `[NetworkInterface <INetworkInterface[]>]`: The network interface configuration.
      - `[IPConfiguration <INetworkInterfaceIPConfiguration[]>]`: A list of IP configurations of the network interface.
        - `[DnsServer <String[]>]`: The list of DNS servers IP addresses.
        - `[Gateway <String>]`: The value of the gateway.
        - `[IPAddress <String>]`: The value of the IP address.
        - `[IPAllocationMethod <IPAllocationMethod?>]`: IP address allocation method.
        - `[IPVersion <IPVersion?>]`: IP address version.
        - `[Subnet <String>]`: The value of the subnet.
      - `[MacAddress <String>]`: The MAC address of the network interface.
      - `[Name <String>]`: The name of the network interface.
      - `[VMSwitchType <VMSwitchType?>]`: The type of the VM switch.
    - `[OSProfileCustomData <String>]`: Specifies a base-64 encoded string of custom data. The base-64 encoded string is decoded to a binary array that is saved as a file on the virtual machine. The maximum length of the binary array is 65535 bytes.    **Note: Do not pass any secrets or passwords in customData property**    This property cannot be updated after the VM is created.    customData is passed to the VM to be saved as a file. For more information see [Custom Data on Azure VMs](https://azure.microsoft.com/en-us/blog/custom-data-and-cloud-init-on-windows-azure/)    For using cloud-init for your Linux VM, see [Using cloud-init to customize a Linux VM during creation](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-using-cloud-init?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json)
    - `[RoleName <String>]`: The name of the network function role.
    - `[UserDataParameter <IAny>]`: The user data parameters from the customer.
  - `[VendorName <String>]`: The vendor name for the network function. Once set, it cannot be updated.

## RELATED LINKS

