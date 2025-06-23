---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azvpnserverconfigurationpolicygroup
schema: 2.0.0
---

# Get-AzVpnServerConfigurationPolicyGroup

## SYNOPSIS
Gets VpnServerConfigurationPolicyGroup that can be attached to P2SVpnGateway.

## SYNTAX

### ByVpnServerConfigurationName (Default)
```
Get-AzVpnServerConfigurationPolicyGroup -ResourceGroupName <String> -ServerConfigurationName <String>
 [-Name <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByVpnServerConfigurationObject
```
Get-AzVpnServerConfigurationPolicyGroup [-Name <String>] -ServerConfigurationObject <PSVpnServerConfiguration>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByVpnServerConfigurationResourceId
```
Get-AzVpnServerConfigurationPolicyGroup [-Name <String>] -ServerConfigurationResourceId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzVpnServerConfigurationPolicyGroup** cmdlet enables you to get an existing VpnServerConfigurationPolicyGroup under VpnServerConfiguration 

## EXAMPLES

### Example 1
```powershell
Get-AzVpnServerConfigurationPolicyGroup -ResourceGroupName TestRG -ServerConfigurationName VpnServerConfig2 -Name Group2 | Format-List
```

```output
ProvisioningState               : Succeeded
IsDefault                       : False
Priority                        : 1
PolicyMembers                   : {policy2}
P2SConnectionConfigurations     : {/subscriptions/64c5a05b-0859-4e60-9634-d52db66832bd/resourceGroups/TestRG/providers/Microsoft.Network/p2sVpnGateways/d8c79d4be6fd47a497f8ac8f8eb545ad-eastus-gw/p2sConnectionConfigurations/P2SConConfig2}
PolicyMembersText               : [
                                    {
                                      "Name": "policy2",
                                      "AttributeType": "CertificateGroupId",
                                      "AttributeValue": "cd"
                                    }
                                  ]
P2SConnectionConfigurationsText : [
                                    {
                                      "Id": "/subscriptions/64c5a05b-0859-4e60-9634-d52db66832bd/resourceGroups/TestRG/providers/Microsoft.Network/p2sVpnGateways/d8c79d4be6fd47a497f8ac8f8eb545ad-eastus-gw/p2sConnectionConfigurations/P2SConConfig2"
                                    }
                                  ]
Name                            : Group2
Etag                            : W/"d3d91ed6-11a9-471f-880e-6459e78aeef9"
Id                              : /subscriptions/64c5a05b-0859-4e60-9634-d52db66832bd/resourceGroups/TestRG/providers/Microsoft.Network/vpnServerConfigurations/VpnServerConfig2/configurationPolicyGroups/Group2
```

The **Get-AzVpnServerConfigurationPolicyGroup** cmdlet enables you to get an existing VpnServerConfigurationPolicyGroup under VpnServerConfiguration which can be attached to P2SVpnGateway for Point to site connectivity from Point to site clients to Azure VirtualWan.

## PARAMETERS

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
Parameter Sets: (All)
Aliases: ResourceName, VpnServerConfigurationPolicyGroupName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
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
The parent resource name.

```yaml
Type: System.String
Parameter Sets: ByVpnServerConfigurationName
Aliases: ParentVpnServerConfigurationName, VpnServerConfigurationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerConfigurationObject
The parent VpnServerConfiguration for this VpnServerConfigurationPolicyGroup.

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
The resource id of the parent VpnServerConfiguration for this VpnServerConfigurationPolicyGroup.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSVpnServerConfiguration

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVpnServerConfigurationPolicyGroup

## NOTES

## RELATED LINKS

[New-AzRoutingConfiguration](New-AzRoutingConfiguration.md)
