---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version:
schema: 2.0.0
---

# Remove-AzureRmDdosProtectionPlan

## SYNOPSIS
Removes a DDoS protection plan.

## SYNTAX

```
Remove-AzureRmDdosProtectionPlan -ResourceGroupName <String> -Name <String> [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Remove-AzureRmDdosProtectionPlan cmdlet removes a DDoS protection plan.

## EXAMPLES

### Example 1: Remove an empty DDoS protection plan
```
Remove-AzureRmDdosProtectionPlan -ResourceGroupName ResourceGroupName -Name DdosProtectionPlan
```

In this case, we remove a DDoS protection plan as specified. The user is prompted for confirmation, but they can avoid it by specifying the flag **Force**.

### Example 2: Remove a DDoS protection plan associated with a virtual network
```
$vnet = Get-AzureRmVirtualNetwork -Name VnetName -ResourceGroupName ResourceGroupName

$vnet.DdosProtectionPlan = $null
$vnet.EnableDdosProtection = $false

$vnet | Set-AzureRmVirtualNetwork

Remove-AzureRmDdosProtectionPlan -ResourceGroupName ResourceGroupName -Name DdosProtectionPlan
```

DDoS protection plans cannot be deleted if they are associated with a virtual network. So the first step is to disassociate both objects. Here, we get the most updated version of the virtual network associated with the plan, and we set the property **DdosProtectionPlan** to an empty value and the flag **EnableDdosProtection** (this flag cannot be true without a plan).

Then, we persist the new state by piping the local variable into **Set-AzureRmVirtualNetwork**. At this point, the plan is no longer associated with the virtual network.

If this is the last one associated with the plan, we can remove the DDoS protection plan by using the command Remove-AzureRmDdosProtectionPlan.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation if you want to delete resource.

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
Specifies the name of the DDoS protection plan to be removed.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
Returns an object representing the item with which you are working.
By default, this cmdlet does not generate any output.

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
Specifies the resource group of the DDoS protection plan to be removed.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[New-AzureRmDdosProtectionPlan](./New-AzureRmDdosProtectionPlan.md)

[Get-AzureRmDdosProtectionPlan](./Get-AzureRmDdosProtectionPlan.md)

[New-AzureRmVirtualNetwork](./New-AzureRmVirtualNetwork.md)

[Set-AzureRmVirtualNetwork](./Set-AzureRmVirtualNetwork.md)

[Get-AzureRmVirtualNetwork](./Get-AzureRmVirtualNetwork.md)