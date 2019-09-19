---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-azvnetsubnetnetworkpolicy
schema: 2.0.0
---

# Set-AzVnetSubnetNetworkPolicy

## SYNOPSIS
Prepares a subnet by applying network intent policies.

## SYNTAX

### PrepareExpanded (Default)
```
Set-AzVnetSubnetNetworkPolicy -ResourceGroupName <String> -SubnetName <String> -VnetName <String>
 [-SubscriptionId <String>] [-IntentPolicyResourceGroupName <String>]
 [-NetworkIntentPolicyConfiguration <INetworkIntentPolicyConfiguration[]>] [-ServiceName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Prepare
```
Set-AzVnetSubnetNetworkPolicy -ResourceGroupName <String> -SubnetName <String> -VnetName <String>
 -NetworkPolicyRequest <IPrepareNetworkPoliciesRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Prepares a subnet by applying network intent policies.

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

### -IntentPolicyResourceGroupName
The name of the resource group where the Network Intent Policy will be stored.

```yaml
Type: System.String
Parameter Sets: PrepareExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkIntentPolicyConfiguration
A list of NetworkIntentPolicyConfiguration.
To construct, see NOTES section for NETWORKINTENTPOLICYCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfiguration[]
Parameter Sets: PrepareExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkPolicyRequest
Details of PrepareNetworkPolicies for Subnet.
To construct, see NOTES section for NETWORKPOLICYREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPrepareNetworkPoliciesRequest
Parameter Sets: Prepare
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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

### -ServiceName
The name of the service for which subnet is being prepared for.

```yaml
Type: System.String
Parameter Sets: PrepareExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubnetName
The name of the subnet.

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

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VnetName
The name of the virtual network.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: VirtualNetworkName

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPrepareNetworkPoliciesRequest

## OUTPUTS

### System.Boolean

## ALIASES

### Set-AzVirtualNetworkSubnetNetworkPolicy

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### NETWORKINTENTPOLICYCONFIGURATION <INetworkIntentPolicyConfiguration[]>: A list of NetworkIntentPolicyConfiguration.
  - `[NetworkIntentPolicyName <String>]`: The name of the Network Intent Policy for storing in target subscription.
  - `[SourceNetworkIntentPolicyEtag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
  - `[SourceNetworkIntentPolicyId <String>]`: Resource ID.
  - `[SourceNetworkIntentPolicyLocation <String>]`: Resource location.
  - `[SourceNetworkIntentPolicyTag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

#### NETWORKPOLICYREQUEST <IPrepareNetworkPoliciesRequest>: Details of PrepareNetworkPolicies for Subnet.
  - `[NetworkIntentPolicyConfiguration <INetworkIntentPolicyConfiguration[]>]`: A list of NetworkIntentPolicyConfiguration.
    - `[NetworkIntentPolicyName <String>]`: The name of the Network Intent Policy for storing in target subscription.
    - `[SourceNetworkIntentPolicyEtag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
    - `[SourceNetworkIntentPolicyId <String>]`: Resource ID.
    - `[SourceNetworkIntentPolicyLocation <String>]`: Resource location.
    - `[SourceNetworkIntentPolicyTag <IResourceTags>]`: Resource tags.
      - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[ResourceGroupName <String>]`: The name of the resource group where the Network Intent Policy will be stored.
  - `[ServiceName <String>]`: The name of the service for which subnet is being prepared for.

## RELATED LINKS

