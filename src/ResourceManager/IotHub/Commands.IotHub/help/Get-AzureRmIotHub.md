---
external help file: Microsoft.Azure.Commands.IotHub.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmIotHub

## SYNOPSIS
Gets information about the IotHubs in a subscription. 

## SYNTAX

### ListIotHubsByResourceGroup (Default)
```
Get-AzureRmIotHub [[-ResourceGroupName] <String>] [<CommonParameters>]
```

### GetIotHubByName
```
Get-AzureRmIotHub [-ResourceGroupName] <String> [-Name] <String> [<CommonParameters>]
```

## DESCRIPTION
Gets information about the IotHubs in a subscription. You can view all IotHub instances in a subscription, or filter your results by a resource group or a particular IotHub Name.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmIotHub
```

Gets all the IotHubs in the subscription.

### Example 2
```
PS C:\> Get-AzureRmIotHub -ResourceGroupName "myresourcegroup"
```

Gets all the IotHubs in the subscription belonging to the resourcegroup named "myresourcegroup".

### Example 3
```
PS C:\> Get-AzureRmIotHub -ResourceGroupName "myresourcegroup" -Name "myiothub"
```

Gets information about the IotHub named "myiothub".

## PARAMETERS

### -Name
Name of the IoT hub.

```yaml
Type: String
Parameter Sets: GetIotHubByName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group.

```yaml
Type: String
Parameter Sets: ListIotHubsByResourceGroup
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: GetIotHubByName
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Management.IotHub.Models.PSIotHub
System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Management.IotHub.Models.PSIotHub, Microsoft.Azure.Commands.IotHub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

