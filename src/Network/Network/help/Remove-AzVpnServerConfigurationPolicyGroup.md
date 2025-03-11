---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/remove-azvpnserverconfigurationpolicygroup
schema: 2.0.0
---

# Remove-AzVpnServerConfigurationPolicyGroup

## SYNOPSIS
Removes an existing VpnServerConfigurationPolicyGroup.

## SYNTAX

### ByVpnServerConfigurationName (Default)
```
Remove-AzVpnServerConfigurationPolicyGroup -ResourceGroupName <String> -ServerConfigurationName <String>
 -Name <String> [-Force] [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByVpnServerConfigurationResourceId
```
Remove-AzVpnServerConfigurationPolicyGroup -ServerConfigurationResourceId <String> [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVpnServerConfigurationObject
```
Remove-AzVpnServerConfigurationPolicyGroup -ServerConfigurationObject <PSVpnServerConfiguration> [-Force]
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzVpnServerConfigurationPolicyGroup** cmdlet enables you to remove an existing VpnServerConfigurationPolicyGroup under VpnServerConfiguration.

## EXAMPLES

### Example 1
```powershell

# Get an existing VpnServerConfigurationPolicyGroup resource.
Get-AzVpnServerConfigurationPolicyGroup -ResourceGroupName TestRG -ServerConfigurationName VpnServerConfig2 -Name Group3

Provisioning State Name   IsDefault Priority P2SConnectionConfiguration ids
------------------ ----   --------- -------- ------------------------------
Succeeded          Group3 False     1        {/subscriptions/64c5a05b-0859-4e60-9634-d52db66832bd/resourceGroups/TestRG/providers/Microsoft.Network/p2sVpnGateways/d8c79d4be6fd47a497f8ac8f8eb545ad-eastus-gw/p2sConnectionConfigurations/P2SConConfig2

# Remove existing VpnServerConfigurationPolicyGroup resource.
Remove-AzVpnServerConfigurationPolicyGroup -ResourceGroupName TestRG -ServerConfigurationName VpnServerConfig2 -Name Group3 -Force -PassThru
True

# Try to get deleted resource to make sure its removed.
Get-AzVpnServerConfigurationPolicyGroup -ResourceGroupName TestRG -ServerConfigurationName VpnServerConfig2 -Name Group3
Get-AzVpnServerConfigurationPolicyGroup: Resource /subscriptions/64c5a05b-0859-4e60-9634-d52db66832bd/resourceGroups/TestRG/providers/Microsoft.Network/vpnServerConfigurations/VpnServerConfig2/configurationPolicyGroups/Group3 not found.
StatusCode: 404
ReasonPhrase: Not Found
ErrorCode: NotFound
ErrorMessage: Resource /subscriptions/64c5a05b-0859-4e60-9634-d52db66832bd/resourceGroups/TestRG/providers/Microsoft.Network/vpnServerConfigurations/VpnServerConfig2/configurationPolicyGroups/Group3 not found.

```

The **Remove-AzVpnServerConfigurationPolicyGroup** cmdlet enables you to remove an existing VpnServerConfigurationPolicyGroup under VpnServerConfiguration.

## PARAMETERS

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

### -Force
Do not ask for confirmation if you want to delete a resource

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

### -PassThru
Returns an object representing the item on which this operation is being performed.

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

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
