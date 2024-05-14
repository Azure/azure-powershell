---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azvirtualnetworkgatewaypolicygroupmember
schema: 2.0.0
---

# New-AzVirtualNetworkGatewayPolicyGroupMember

## SYNOPSIS
Create a Virtual Network Gateway Policy Group Member

## SYNTAX

```
New-AzVirtualNetworkGatewayPolicyGroupMember -Name <String> -AttributeType <String> -AttributeValue <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Virtual Network Gateway Policy Group Member is a used for setting up one policy based on their identity or authentication credentials

## EXAMPLES

### Example 1
```powershell
#create the policy group and connection client configuration
$member1=New-AzVirtualNetworkGatewayPolicyGroupMember -Name "member1" -AttributeType "CertificateGroupId" -AttributeValue "ab"
$member2=New-AzVirtualNetworkGatewayPolicyGroupMember -Name "member2" -AttributeType "CertificateGroupId" -AttributeValue "cd"
$policyGroup1=New-AzVirtualNetworkGatewayPolicyGroup -Name "policyGroup1" -Priority 0 -DefaultPolicyGroup  -PolicyMember $member1
$policyGroup2=New-AzVirtualNetworkGatewayPolicyGroup -Name "policyGroup2" -Priority 10 -PolicyMember $member2
```

create policy group member

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

### -AttributeType
The Attribute Type of the policy group member.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AttributeValue
The Attribute Value

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
The name of the Virtual Network Gateway Policy Group Member

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVpnClientRootCertificate

## NOTES

## RELATED LINKS
