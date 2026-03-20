---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azddoscustompolicy
schema: 2.0.0
---

# New-AzDdosCustomPolicy

## SYNOPSIS
Creates a DDoS custom policy.

## SYNTAX

```
New-AzDdosCustomPolicy -ResourceGroupName <String> -Name <String> -Location <String> -TrafficType <String>
 -PacketsPerSecond <Int32> [-Tag <Hashtable>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The New-AzDdosCustomPolicy cmdlet creates a DDoS custom policy resource.

## EXAMPLES

### Example 1: Create a DDoS custom policy
```powershell
$ddosCustomPolicy = New-AzDdosCustomPolicy -ResourceGroupName ResourceGroupName -Name DdosCustomPolicyName -Location "West US" -TrafficType Tcp -PacketsPerSecond 1000000
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

This command creates a new DDoS custom policy resource in the specified resource group and location.

### Example 2: Create a DDoS custom policy with tags
```powershell
$ddosCustomPolicy = New-AzDdosCustomPolicy -ResourceGroupName ResourceGroupName -Name DdosCustomPolicyName -Location "West US" -TrafficType Tcp -PacketsPerSecond 1000000 -Tag @{"Environment"="Test"; "Project"="Demo"}
```

This command creates a DDoS custom policy with tags for better resource organization and cost tracking.

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

### -Location
Specifies the location of the DDoS custom policy.

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

### -Name
Specifies the name of the DDoS custom policy.

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

### -PacketsPerSecond
Specifies the customized packets per second threshold for the DDoS detection rule.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group in which to create the DDoS custom policy.

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

### -Tag
A hash table which represents resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TrafficType
Specifies the traffic type for the DDoS detection rule. Allowed values are Tcp, Udp, and TcpSyn.

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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy

## NOTES

## RELATED LINKS

[Get-AzDdosCustomPolicy](./Get-AzDdosCustomPolicy.md)

[Remove-AzDdosCustomPolicy](./Remove-AzDdosCustomPolicy.md)
