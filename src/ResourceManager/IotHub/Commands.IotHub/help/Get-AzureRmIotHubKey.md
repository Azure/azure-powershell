---
external help file: Microsoft.Azure.Commands.IotHub.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmIotHubKey

## SYNOPSIS
Gets an IotHub Key.

## SYNTAX

```
Get-AzureRmIotHubKey [-ResourceGroupName] <String> [-Name] <String> [[-KeyName] <String>]
```

## DESCRIPTION
Gets an IotHub Key.
You can either list all Keys or filter the list by a specific Key Name.

## EXAMPLES

### Example 1 Get all Keys
```
PS C:\> Get-AzureRmIotHubKey -ResourceGroupName "myresourcegroup" -Name "myiothub"
```

Gets all the Keys for the IotHub named "myiothub"

### Example 2 Get information for a specific Key
```
PS C:\> Get-AzureRmIotHubKey -ResourceGroupName "myresourcegroup" -Name "myiothub" -KeyName "iothubowner"
```

Gets the information for a key named "iothubowner" for the IotHub named "myiothub"

## PARAMETERS

### -KeyName
Name

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Management.IotHub.Models.PSSharedAccessSignatureAuthorizationRule
System.Collections.Generic.List\`1\[\[Microsoft.Azure.Commands.Management.IotHub.Models.PSSharedAccessSignatureAuthorizationRule, Microsoft.Azure.Commands.IotHub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\]\]

## NOTES

## RELATED LINKS

