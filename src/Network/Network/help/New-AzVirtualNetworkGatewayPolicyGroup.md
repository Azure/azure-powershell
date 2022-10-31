---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-azvirtualnetworkgatewaynatrule
schema: 2.0.0
---

# New-AzVirtualNetworkGatewayPolicyGroup

## SYNOPSIS
Create a Virtual Network Gateway Policy Group

## SYNTAX

```
New-AzVirtualNetworkGatewayPolicyGroup -Name <String> -Priority <Int32> [-DefaultPolicyGroup]
 -PolicyMember <PSVirtualNetworkGatewayPolicyGroupMember[]> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Virtual Network Gateway Policy Group is a used for setting up different groups of users based on their identity or authentication credentials
## EXAMPLES

### Example 1
```powershell
 #create the policy group and connection client configuration
$member1=New-AzVirtualNetworkGatewayPolicyGroupMember -Name "member1" -AttributeType "CertificateGroupId" -AttributeValue "ab"
$member2=New-AzVirtualNetworkGatewayPolicyGroupMember -Name "member2" -AttributeType "CertificateGroupId" -AttributeValue "cd"
$policyGroup1=New-AzVirtualNetworkGatewayPolicyGroup -Name "policyGroup1" -Priority 0 -DefaultPolicyGroup  -PolicyMember $member1
$policyGroup2=New-AzVirtualNetworkGatewayPolicyGroup -Name "policyGroup2" -Priority 10 -PolicyMember $member2
```

create policy group  member

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
Flag to set this as Default Policy Group on this VpnServerConfiguration.

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
The name of the Virtual Network Gateway Policy Group

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

### -PolicyMember
The list of Policy members.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGatewayPolicyGroupMember[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Priority
The Priority of the policy group.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Int32

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGatewayPolicyGroupMember[]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVpnClientRootCertificate

## NOTES

## RELATED LINKS
