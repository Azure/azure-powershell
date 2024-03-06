---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azvpnserverconfigurationpolicygroup
schema: 2.0.0
---

# New-AzVpnServerConfigurationPolicyGroup

## SYNOPSIS
Creates a new VpnServerConfigurationPolicyGroup that can be attached to P2SVpnGateway.

## SYNTAX

### ByVpnServerConfigurationName (Default)
```
New-AzVpnServerConfigurationPolicyGroup -ResourceGroupName <String> -ServerConfigurationName <String>
 -Name <String> -Priority <Int32> [-DefaultPolicyGroup]
 [-PolicyMember <PSVpnServerConfigurationPolicyGroupMember[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVpnServerConfigurationObject
```
New-AzVpnServerConfigurationPolicyGroup -ServerConfigurationObject <PSVpnServerConfiguration> -Priority <Int32>
 [-DefaultPolicyGroup] [-PolicyMember <PSVpnServerConfigurationPolicyGroupMember[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVpnServerConfigurationResourceId
```
New-AzVpnServerConfigurationPolicyGroup -ServerConfigurationResourceId <String> -Priority <Int32>
 [-DefaultPolicyGroup] [-PolicyMember <PSVpnServerConfigurationPolicyGroupMember[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzVpnServerConfigurationPolicyGroup** cmdlet enables you to create a new VpnServerConfigurationPolicyGroup under VpnServerConfiguration which can be attached to P2SVpnGateway for Point to site connectivity from Point to site clients to Azure VirtualWan.

## EXAMPLES

### Example 1
```powershell

# Create a PolicyMember1 Object
$policyGroupMember1 = New-Object -TypeName Microsoft.Azure.Commands.Network.Models.PSVpnServerConfigurationPolicyGroupMember
$policyGroupMember1.Name = "policyGroupMember1"
$policyGroupMember1.AttributeType = "AADGroupId"
$policyGroupMember1.AttributeValue = "41b23e61-6c1e-4545-b367-cd054e0ed4b5"

# Create a PolicyGroup1
New-AzVpnServerConfigurationPolicyGroup -ResourceGroupName TestRG -ServerConfigurationName VpnServerConfig2 -Name Group3 -Priority 3 -PolicyMember $policyGroupMember1
Provisioning State Name   IsDefault Priority P2SConnectionConfiguration ids
------------------ ----   --------- -------- ------------------------------
Succeeded          Group3 False     3        {}

```

Creates a new VpnServerConfiguration PolicyGroup.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultPolicyGroup
Flag to set this as Default Policy Group on this VpnServerConfiguration.

```yaml
Type: SwitchParameter
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
Type: IAzureContextContainer
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
Type: String
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
Type: PSVpnServerConfigurationPolicyGroupMember[]
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
Type: Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
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
Type: String
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
Type: PSVpnServerConfiguration
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
Type: String
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
Type: SwitchParameter
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
Type: SwitchParameter
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
