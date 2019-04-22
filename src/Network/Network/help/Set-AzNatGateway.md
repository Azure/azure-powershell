---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-aznatgateway.md
schema: 2.0.0
---

# Set-AzNatGateway

## SYNOPSIS
Update Nat Gateway Resource with Public Ip Address, Public Ip Prefix and IdleTimeoutInMinutes.

## SYNTAX

### SetByNameParameterSet (Default)
```
Set-AzNatGateway -ResourceGroupName <String> -Name <String> [-PublicIpAddress <PSResourceId[]>]
 [-PublicIpPrefix <PSResourceId[]>] [-AsJob] [-IdleTimeoutInMinutes <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByResourceIdParameterSet
```
Set-AzNatGateway -NatGatewayId <String> [-PublicIpAddress <PSResourceId[]>] [-PublicIpPrefix <PSResourceId[]>]
 [-AsJob] [-IdleTimeoutInMinutes <Int32>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetByInputObjectParameterSet
```
Set-AzNatGateway -NatGateway <PSNatGateway> [-PublicIpAddress <PSResourceId[]>]
 [-PublicIpPrefix <PSResourceId[]>] [-AsJob] [-IdleTimeoutInMinutes <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update Nat Gateway Resource with Public Ip Address, Public Ip Prefix and IdleTimeoutInMinutes.

## EXAMPLES

### Example 1
```powershell
PS C:\> $pip = Get-AzPublicIpAddress -Name "test_pip" -ResourceGroupName "natgateway_test"
PS C:\> $natUpdate = Set-AzNatGateway -NatGateway $ngw -IdleTimeoutInMinutes 5 -PublicIpAddress $pip
PS C:\> $natUpdate


IdleTimeoutInMinutes  : 5
ProvisioningState     : Succeeded
Sku                   : Microsoft.Azure.Commands.Network.Models.PSNatGatewaySku
PublicIpAddresses     : {/subscriptions/3dc13b6d-6896-40ac-98f7-f18cbce2a405/resourceGroups/natgateway_test/providers/Microsoft.Network/publicIPAddresses/Test_Pip}
PublicIpPrefixes      : {}
SkuText               : {
                          "Name": "Standard"
                        }
PublicIpAddressesText : [
                          {
                            "Id": "/subscriptions/3dc13b6d-6896-40ac-98f7-f18cbce2a405/resourceGroups/natgateway_test/providers/Microsoft.Network/publicIPAddresses/Test_Pip"
                          }
                        ]
PublicIpPrefixesText  : []
ResourceGroupName     : natgateway_test
Location              : eastus2
ResourceGuid          :
Type                  : Microsoft.Network/natGateways
Tag                   :
TagsTable             :
Name                  : natgateway
Etag                  : W/"7e0e8579-ef38-42a5-a854-f66c0effa9f8"
Id                    : /subscriptions/3dc13b6d-6896-40ac-98f7-f18cbce2a405/resourceGroups/natgateway_test/providers/Microsoft.Network/natGateways/natgateway




PS C:\> $prefix = Get-AzPublicIpPrefix -ResourceGroupName "natgateway_test"
PS C:\> $natUpdate = Set-AzNatGateway -NatGateway $ngw -IdleTimeoutInMinutes 5 -PublicIpPrefix $prefix
PS C:\> $natUpdate


IdleTimeoutInMinutes  : 5
ProvisioningState     : Succeeded
Sku                   : Microsoft.Azure.Commands.Network.Models.PSNatGatewaySku
PublicIpAddresses     : {/subscriptions/3dc13b6d-6896-40ac-98f7-f18cbce2a405/resourceGroups/natgateway_test/providers/Microsoft.Network/publicIPAddresses/Test_Pip}
PublicIpPrefixes      : {/subscriptions/3dc13b6d-6896-40ac-98f7-f18cbce2a405/resourceGroups/natgateway_test/providers/Microsoft.Network/publicIPPrefixes/prefix2}
SkuText               : {
                          "Name": "Standard"
                        }
PublicIpAddressesText : [
                          {
                            "Id": "/subscriptions/3dc13b6d-6896-40ac-98f7-f18cbce2a405/resourceGroups/natgateway_test/providers/Microsoft.Network/publicIPAddresses/Test_Pip"
                          }
                        ]
PublicIpPrefixesText  : [
                          {
                            "Id": "/subscriptions/3dc13b6d-6896-40ac-98f7-f18cbce2a405/resourceGroups/natgateway_test/providers/Microsoft.Network/publicIPPrefixes/prefix2"
                          }
                        ]
ResourceGroupName     : natgateway_test
Location              : eastus2
ResourceGuid          :
Type                  : Microsoft.Network/natGateways
Tag                   :
TagsTable             :
Name                  : natgateway
Etag                  : W/"52f33a5c-6ba4-4b55-afb3-4b5be96e3b18"
Id                    : /subscriptions/3dc13b6d-6896-40ac-98f7-f18cbce2a405/resourceGroups/natgateway_test/providers/Microsoft.Network/natGateways/natgateway
```

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

### -IdleTimeoutInMinutes
The idle timeout of the nat gateway.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
{{ Fill Name Description }}

```yaml
Type: String
Parameter Sets: SetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NatGateway
The nat gateway

```yaml
Type: PSNatGateway
Parameter Sets: SetByInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NatGatewayId
Nat Gateway Id

```yaml
Type: String
Parameter Sets: SetByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PublicIpAddress
An array of public ip addresses associated with the nat gateway resource.

```yaml
Type: PSResourceId[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicIpPrefix
An array of public ip prefixes associated with the nat gateway resource.

```yaml
Type: PSResourceId[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
{{ Fill ResourceGroupName Description }}

```yaml
Type: String
Parameter Sets: SetByNameParameterSet
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Network.Models.PSNatGateway

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNatGateway

## NOTES

## RELATED LINKS
