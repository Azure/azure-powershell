---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version:
schema: 2.0.0
---

# New-AzureRmDdosProtectionPlan

## SYNOPSIS
Creates a DDoS protection plan.

## SYNTAX

```
New-AzureRmDdosProtectionPlan -ResourceGroupName <String> -Name <String> -Location <String> [-Tag <Hashtable>]
 [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzureRmDdosProtectionPlan cmdlet creates a DDoS protection plan.

## EXAMPLES

### Example 1: Create and associate a DDoS protection plan with a new virtual network
```
$ddosProtectionPlan = New-AzureRmDdosProtectionPlan -ResourceGroupName ResourceGroupName -Name DdosProtectionPlanName -Location "West US"

$subnet = New-AzureRmVirtualNetworkSubnetConfig -Name SubnetName -AddressPrefix 10.0.1.0/24

$vnet = New-AzureRmvirtualNetwork -Name VnetName -ResourceGroupName ResourceGroupName -Location "West US" -AddressPrefix 10.0.0.0/16 -DnsServer 8.8.8.8 -Subnet $subnet -EnableDdoSProtection -DdosProtectionPlanId $ddosProtectionPlan.Id
```

First, we create a new DDoS Protection plan with the **New-AzureRmDdosProtectionPlan** command.

Then, we create a new virtual network with **New-AzureRmvirtualNetwork** and we specify the ID of the newly created plan in the parameter **DdosProtectionPlanId**. In this case, since we are associating the virtual network with a plan, we can also specify the parameter **EnableDdoSProtection**.

### Example 2: Create and associate a DDoS protection plan with an existing virtual network
```
$ddosProtectionPlan = New-AzureRmDdosProtectionPlan -ResourceGroupName ResourceGroupName -Name DdosProtectionPlanName -Location "West US"

$vnet = Get-AzureRmVirtualNetwork -Name VnetName -ResourceGroupName ResourceGroupName

$vnet.DdosProtectionPlan = New-Object Microsoft.Azure.Commands.Network.Models.PSResourceId
$vnet.DdosProtectionPlan.Id = $ddosProtectionPlan.Id

$vnet.EnableDdosProtection = $true

$vnet | Set-AzureRmVirtualNetwork
```

First, we create a new DDoS Protection plan with the **New-AzureRmDdosProtectionPlan** command.

Second, we get the most updated version of the virtual network we want to associate with the plan. We update the property **DdosProtectionPlan** with a **PSResourceId** object containing a reference to the ID of the newly created plan. In this case, if we associate the virtual network with a DDoS protection plan, we can also set the flag **EnableDdosProtection** to true.

Finally, we persist the new state by piping the local variable into **Set-AzureRmVirtualNetwork**.

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
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation if you want to overwrite a resource

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

### -Location
The location.

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

### -Name
Specifies the name of the DDoS protection plan to be created.

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

### -ResourceGroupName
Specifies the resource group of the DDoS protection plan to be created.

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

### -Tag
A hashtable which represents resource tags.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
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
System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosProtectionPlan

## NOTES

## RELATED LINKS

[Get-AzureRmDdosProtectionPlan](./Get-AzureRmDdosProtectionPlan.md)

[Remove-AzureRmDdosProtectionPlan](./Remove-AzureRmDdosProtectionPlan.md)

[New-AzureRmVirtualNetwork](./New-AzureRmVirtualNetwork.md)

[Set-AzureRmVirtualNetwork](./Set-AzureRmVirtualNetwork.md)

[Get-AzureRmVirtualNetwork](./Get-AzureRmVirtualNetwork.md)