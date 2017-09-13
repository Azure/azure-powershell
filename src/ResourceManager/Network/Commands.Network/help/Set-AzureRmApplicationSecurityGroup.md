---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: 
schema: 2.0.0
---

# Set-AzureRmApplicationSecurityGroup

## SYNOPSIS
Sets the goal state for an application security group.

## SYNTAX

```
Set-AzureRmApplicationSecurityGroup -ApplicationSecurityGroup <PSApplicationSecurityGroup> [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmApplicationSecurityGroup** cmdlet sets the goal state for an application security group.

## EXAMPLES

### Example 1
```
PS C:\> $asg = Get-AzureRmApplicationSecurityGroup -Name $applicationSecurityGroupName -ResourceGroupName $rgName
    
PS C:\> Set-AzureRmApplicationSecurityGroup -ApplicationSecurityGroup $asg
```

This example shows how an application security object can be obtained for setting the state of an application security group with **Set-AzureRmApplicationSecurityGroup**. In this case, no changes were made.

## PARAMETERS

### -ApplicationSecurityGroup
The application security group

```yaml
Type: PSApplicationSecurityGroup
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationSecurityGroup

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationSecurityGroup

## NOTES

## RELATED LINKS

