---
external help file:
Module Name: Az.DevTestLabs
online version: https://docs.microsoft.com/en-us/powershell/module/az.devtestlabs/new-azdevtestlabsvirtualnetwork
schema: 2.0.0
---

# New-AzDevTestLabsVirtualNetwork

## SYNOPSIS
Create or replace an existing virtual network.
This operation can take a while to complete.

## SYNTAX

```
New-AzDevTestLabsVirtualNetwork -LabName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AllowedSubnet <ISubnet[]>] [-Description <String>]
 [-ExternalProviderResourceId <String>] [-Location <String>] [-SubnetOverride <ISubnetOverride[]>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or replace an existing virtual network.
This operation can take a while to complete.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AllowedSubnet
The allowed subnets of the virtual network.
To construct, see NOTES section for ALLOWEDSUBNET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.Api20180915.ISubnet[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Description
The description of the virtual network.

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

### -ExternalProviderResourceId
The Microsoft.Network resource identifier of the virtual network.

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

### -LabName
The name of the lab.

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

### -Location
The location of the resource.

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

### -Name
The name of the virtual network.

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

### -SubnetOverride
The subnet overrides of the virtual network.
To construct, see NOTES section for SUBNETOVERRIDE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.Api20180915.ISubnetOverride[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID.

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
The tags of the resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.Api20180915.IVirtualNetwork

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


ALLOWEDSUBNET <ISubnet[]>: The allowed subnets of the virtual network.
  - `[AllowPublicIP <UsagePermissionType?>]`: The permission policy of the subnet for allowing public IP addresses (i.e. Allow, Deny)).
  - `[LabSubnetName <String>]`: The name of the subnet as seen in the lab.
  - `[ResourceId <String>]`: The resource ID of the subnet.

SUBNETOVERRIDE <ISubnetOverride[]>: The subnet overrides of the virtual network.
  - `[LabSubnetName <String>]`: The name given to the subnet within the lab.
  - `[ResourceId <String>]`: The resource ID of the subnet.
  - `[SharedPublicIPAddressConfigurationAllowedPort <IPort[]>]`: Backend ports that virtual machines on this subnet are allowed to expose
    - `[BackendPort <Int32?>]`: Backend port of the target virtual machine.
    - `[TransportProtocol <TransportProtocol?>]`: Protocol type of the port.
  - `[UseInVMCreationPermission <UsagePermissionType?>]`: Indicates whether this subnet can be used during virtual machine creation (i.e. Allow, Deny).
  - `[UsePublicIPAddressPermission <UsagePermissionType?>]`: Indicates whether public IP addresses can be assigned to virtual machines on this subnet (i.e. Allow, Deny).
  - `[VirtualNetworkPoolName <String>]`: The virtual network pool associated with this subnet.

## RELATED LINKS

