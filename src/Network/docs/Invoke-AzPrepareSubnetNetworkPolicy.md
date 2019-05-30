---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/invoke-azpreparesubnetnetworkpolicy
schema: 2.0.0
---

# Invoke-AzPrepareSubnetNetworkPolicy

## SYNOPSIS
Prepares a subnet by applying network intent policies.

## SYNTAX

### Prepare (Default)
```
Invoke-AzPrepareSubnetNetworkPolicy -ResourceGroupName <String> -SubnetName <String> -SubscriptionId <String>
 -VirtualNetworkName <String> [-PassThru]
 [-PrepareNetworkPoliciesRequestParameter <IPrepareNetworkPoliciesRequest>] [-DefaultProfile <PSObject>]
 [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PrepareViaIdentityExpanded
```
Invoke-AzPrepareSubnetNetworkPolicy [-ResourceGroupName <String>] -InputObject <INetworkIdentity> [-PassThru]
 [-NetworkIntentPolicyConfiguration <INetworkIntentPolicyConfiguration[]>] [-ServiceName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PrepareExpanded
```
Invoke-AzPrepareSubnetNetworkPolicy -ResourceGroupName <String> -SubnetName <String> -SubscriptionId <String>
 -VirtualNetworkName <String> [-PassThru]
 [-NetworkIntentPolicyConfiguration <INetworkIntentPolicyConfiguration[]>] [-ResourceGroupName1 <String>]
 [-ServiceName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PrepareViaIdentity
```
Invoke-AzPrepareSubnetNetworkPolicy -InputObject <INetworkIdentity> [-PassThru]
 [-PrepareNetworkPoliciesRequestParameter <IPrepareNetworkPoliciesRequest>] [-DefaultProfile <PSObject>]
 [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Prepares a subnet by applying network intent policies.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: PrepareViaIdentityExpanded, PrepareViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NetworkIntentPolicyConfiguration
A list of NetworkIntentPolicyConfiguration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfiguration[]
Parameter Sets: PrepareViaIdentityExpanded, PrepareExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrepareNetworkPoliciesRequestParameter
Details of PrepareNetworkPolicies for Subnet.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPrepareNetworkPoliciesRequest
Parameter Sets: Prepare, PrepareViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Prepare, PrepareExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: PrepareViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName1
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
```

### -ServiceName
The name of the service for which subnet is being prepared for.

```yaml
Type: System.String
Parameter Sets: PrepareViaIdentityExpanded, PrepareExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetName
The name of the subnet.

```yaml
Type: System.String
Parameter Sets: Prepare, PrepareExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Prepare, PrepareExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkName
The name of the virtual network.

```yaml
Type: System.String
Parameter Sets: Prepare, PrepareExpanded
Aliases:

Required: True
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

### System.Boolean
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/invoke-azpreparesubnetnetworkpolicy](https://docs.microsoft.com/en-us/powershell/module/az.network/invoke-azpreparesubnetnetworkpolicy)

