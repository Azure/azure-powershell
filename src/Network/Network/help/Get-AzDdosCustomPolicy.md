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
Get-AzDdosCustomPolicy -ResourceGroupName <String> -Name <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzDdosCustomPolicy** cmdlet retrieves a DDoS custom policy by its resource group name and policy name.

## EXAMPLES

### Example 1: Get a DDoS custom policy
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
```

This example gets the DDoS custom policy named "myPolicy" from the resource group "myRG".

### Example 2: Get a DDoS custom policy and display its detection rules
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$policy.DetectionRules | Format-Table TrafficType, PacketsPerSecond
```

This example gets the DDoS custom policy and displays its detection rules in a table format.

### Example 3: Get a DDoS custom policy and display all properties
```powershell
Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy" | Format-List
```

This example gets the DDoS custom policy and displays all its properties.

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
Specifies the name of the DDoS custom policy to retrieve.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the resource group name of the DDoS custom policy.

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

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy

## NOTES

## RELATED LINKS

[New-AzDdosCustomPolicy](./New-AzDdosCustomPolicy.md)

[Remove-AzDdosCustomPolicy](./Remove-AzDdosCustomPolicy.md)

[New-AzDdosCustomPolicyDetectionRule](./New-AzDdosCustomPolicyDetectionRule.md)
