---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/update-azvpnserverconfigurationpolicygroup
schema: 2.0.0
---

# Update-AzVpnServerConfigurationPolicyGroup

## SYNOPSIS
Update an existing VpnServerConfigurationPolicyGroup under VpnServerConfiguration for point to site connectivity.

## SYNTAX

### ByVpnServerConfigurationName (Default)
```
Update-AzVpnServerConfigurationPolicyGroup -ResourceGroupName <String> -ServerConfigurationName <String>
 -Name <String> [-Priority <Int32>] [-DefaultPolicyGroup <Boolean>]
 [-PolicyMember <PSVpnServerConfigurationPolicyGroupMember[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByVpnServerConfigurationObject
```
Update-AzVpnServerConfigurationPolicyGroup -ServerConfigurationObject <PSVpnServerConfiguration>
 [-Priority <Int32>] [-DefaultPolicyGroup <Boolean>]
 [-PolicyMember <PSVpnServerConfigurationPolicyGroupMember[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByVpnServerConfigurationResourceId
```
Update-AzVpnServerConfigurationPolicyGroup -ServerConfigurationResourceId <String> [-Priority <Int32>]
 [-DefaultPolicyGroup <Boolean>] [-PolicyMember <PSVpnServerConfigurationPolicyGroupMember[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzVpnServerConfigurationPolicyGroup** cmdlet enables you to update an existing VpnServerConfigurationPolicyGroup under VpnServerConfiguration with new policyGroupMember and/or Priority.

## EXAMPLES

### Example 1
```powershell
# Update existing VpnServerConfigurationPolicyGroup with new PolicyGroupMember2 & Priority to 2.
Update-AzVpnServerConfigurationPolicyGroup -ResourceGroupName TestRG -ServerConfigurationName VpnServerConfig2 -Name Group2 -PolicyMember $policyGroupMember2 -Priority 2
```

```output
ProvisioningState               : Succeeded
IsDefault                       : False
Priority                        : 2
PolicyMembers                   : {policyGroupMember2}
P2SConnectionConfigurations     : {/subscriptions/64c5a05b-0859-4e60-9634-d52db66832bd/resourceGroups/TestRG/providers/Microsoft.Network/p2sVpnGateways/d8c79d4be6fd47a497f8ac8f8eb545ad-eastus-gw/p2sConnectionConfigurations/P2SConConfig2}
PolicyMembersText               : [
                                    {
                                      "Name": "policyGroupMember2",
                                      "AttributeType": "AADGroupId",
                                      "AttributeValue": "41b23e61-6c1e-4545-b367-cd054e0ed4b5"
                                    }
                                  ]
P2SConnectionConfigurationsText : [
                                    {
                                      "Id": "/subscriptions/64c5a05b-0859-4e60-9634-d52db66832bd/resourceGroups/TestRG/providers/Microsoft.Network/p2sVpnGateways/d8c79d4be6fd47a497f8ac8f8eb545ad-eastus-gw/p2sConnectionConfigurations/P2SConConfig2"
                                    }
                                  ]
Name                            : Group2
Etag                            : W/"44998fce-7fde-43f9-bafb-4599452d672c"
Id                              : /subscriptions/64c5a05b-0859-4e60-9634-d52db66832bd/resourceGroups/TestRG/providers/Microsoft.Network/vpnServerConfigurations/VpnServerConfig2/configurationPolicyGroups/Group2
```

The **Update-AzVpnServerConfigurationPolicyGroup** cmdlet enables you to update an existing VpnServerConfigurationPolicyGroup under VpnServerConfiguration with new policyGroupMember and/or Priority.

## PARAMETERS

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

### -DefaultPolicyGroup
Set this as Default Policy Group on this VpnServerConfiguration.

```yaml
Type: System.Nullable`1[System.Boolean]
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

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: ByVpnServerConfigurationName
Aliases: ResourceName, VpnServerConfigurationPolicyGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyMember
The list of Policy members.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVpnServerConfigurationPolicyGroupMember[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Priority
The Priority of the policy group.
Priority should be in consecutive orders.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

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
Parameter Sets: ByVpnServerConfigurationName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerConfigurationName
The VpnServerConfiguration name this PolicyGroup is linked to.

```yaml
Type: System.String
Parameter Sets: ByVpnServerConfigurationName
Aliases: ParentVpnServerConfigurationName, VpnServerConfigurationName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServerConfigurationObject
The VpnServerConfiguration object this PolicyGroup is linked to.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVpnServerConfiguration
Parameter Sets: ByVpnServerConfigurationObject
Aliases: ParentVpnServerConfiguration, VpnServerConfiguration

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServerConfigurationResourceId
The id of VpnServerConfiguration object this PolicyGroup is linked to.

```yaml
Type: System.String
Parameter Sets: ByVpnServerConfigurationResourceId
Aliases: ParentVpnServerConfigurationId, VpnServerConfigurationId

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

### Microsoft.Azure.Commands.Network.Models.PSVpnServerConfiguration

### System.Int32

### Microsoft.Azure.Commands.Network.Models.PSVpnServerConfigurationPolicyGroupMember[]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVpnServerConfigurationPolicyGroup

## NOTES

## RELATED LINKS

[New-AzRoutingConfiguration](New-AzRoutingConfiguration.md)
