---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: 
schema: 2.0.0
---

# Get-AzureRmApplicationSecurityGroup

## SYNOPSIS
Gets an application security group.

## SYNTAX

### NoExpand
```
Get-AzureRmApplicationSecurityGroup [-Name <String>] [-ResourceGroupName <String>]
```

### Expand
```
Get-AzureRmApplicationSecurityGroup -Name <String> -ResourceGroupName <String>
```

## DESCRIPTION
The **Get-AzureRmApplicationSecurityGroup** cmdlet gets an application security group.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmApplicationSecurityGroup -Name "MyApplicationSecurityGroup" -ResourceGroup "MyResourceGroup"
```

The command above returns the application security group named as `MyApplicationSecurityGroup` that belongs to the resource group `MyResourceGroup`.

## PARAMETERS

### -Name
The resource name.

```yaml
Type: String
Parameter Sets: NoExpand
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: Expand
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: NoExpand
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: Expand
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String


## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationSecurityGroup


## NOTES

## RELATED LINKS

