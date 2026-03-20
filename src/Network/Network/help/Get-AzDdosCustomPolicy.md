---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azddoscustompolicy
schema: 2.0.0
---

# Get-AzDdosCustomPolicy

## SYNOPSIS
Gets a DDoS custom policy.

## SYNTAX

```
Get-AzDdosCustomPolicy [-ResourceGroupName <String>] [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzDdosCustomPolicy cmdlet gets a DDoS custom policy.

## EXAMPLES

### Example 1: Get a specific DDoS custom policy
```powershell
Get-AzDdosCustomPolicy -ResourceGroupName ResourceGroupName -Name DdosCustomPolicyName
```

```output
Name              : DdosCustomPolicyName
Id                : /subscriptions/d1dbd366-9871-45ac-84b7-fb318152a9e0/resourceGroups/ResourceGroupName/providers/Microsoft.Network/ddosCustomPolicies/DdosCustomPolicyName
Etag              : W/"a20e5592-9b51-423b-9758-b00cd322f744"
ProvisioningState : Succeeded
ResourceGuid      : 12345678-1234-1234-1234-123456789012
DetectionRules    : []
FrontEndIPConfiguration : []
```

In this case, we need to specify both **ResourceGroupName** and **Name** attributes, which correspond to the resource group and the name of the DDoS custom policy, respectively.

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
Specifies the name of the DDoS custom policy.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that contains the DDoS custom policy.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy

## NOTES

## RELATED LINKS

[New-AzDdosCustomPolicy](./New-AzDdosCustomPolicy.md)

[Remove-AzDdosCustomPolicy](./Remove-AzDdosCustomPolicy.md)
