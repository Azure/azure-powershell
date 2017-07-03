---
external help file: Microsoft.Azure.Commands.ApiManagement.ServiceManagement.dll-Help.xml
ms.assetid: 894297BF-2771-4871-9E4C-8684364DAC4B
online version:
schema: 2.0.0
---

# Get-AzureRmApiManagementProperty

## SYNOPSIS

## SYNTAX

### Get all properties (Default)
```
Get-AzureRmApiManagementProperty -Context <PsApiManagementContext> [<CommonParameters>]
```

### Get by property ID
```
Get-AzureRmApiManagementProperty -Context <PsApiManagementContext> [-PropertyId <String>] [<CommonParameters>]
```

### Find properties containing Name
```
Get-AzureRmApiManagementProperty -Context <PsApiManagementContext> [-Name <String>] [<CommonParameters>]
```

### Find properties by Tag
```
Get-AzureRmApiManagementProperty -Context <PsApiManagementContext> [-Tag <String>] [<CommonParameters>]
```

## DESCRIPTION

## EXAMPLES

### 1:
```
PS C:\> Get-AzureRmApiManagementProperty -Context $Context -Name $PropertyName
```

## PARAMETERS

### -Context
```yaml
Type: PsApiManagementContext
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
```yaml
Type: String
Parameter Sets: Find properties containing Name
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PropertyId
```yaml
Type: String
Parameter Sets: Get by property ID
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Key-value pairs in the form of a hash table. For example:

@{key0="value0";key1=$null;key2="value2"}

```yaml
Type: String
Parameter Sets: Find properties by Tag
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS