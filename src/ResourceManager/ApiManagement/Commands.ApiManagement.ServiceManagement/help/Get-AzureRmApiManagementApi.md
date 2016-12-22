---
external help file: Microsoft.Azure.Commands.ApiManagement.ServiceManagement.dll-Help.xml
online version: 
schema: 2.0.0
ms.assetid: B80389B9-E143-4E24-A222-E95F691DA2E9
---

# Get-AzureRmApiManagementApi

## SYNOPSIS
Gets an API.

## SYNTAX

### All APIs (Default)
```
Get-AzureRmApiManagementApi -Context <PsApiManagementContext> [-InformationAction <ActionPreference>]
 [-InformationVariable <String>] [<CommonParameters>]
```

### Find by ID
```
Get-AzureRmApiManagementApi -Context <PsApiManagementContext> -ApiId <String>
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
```

### Find by Name
```
Get-AzureRmApiManagementApi -Context <PsApiManagementContext> -Name <String>
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
```

### Find by product ID
```
Get-AzureRmApiManagementApi -Context <PsApiManagementContext> -ProductId <String>
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmApiManagementApi** cmdlet gets one or more Azure API Management APIs.

## EXAMPLES

### Example 1: Get all management APIs
```
PS C:\>Get-AzureRmApiManagementApi -Context $ApiMgmtContext
```

This command gets all of the APIs for the specified context.

### Example 2: Get a management API by ID
```
PS C:\>Get-AzureRmApiManagementApi -Context $ApiMgmtContext -ApiId $ApiId
```

This command gets the API with the specified ID.

### Example 3: Get a management API by name
```
PS C:\>Get-AzureRmApiManagementApi -Context $ApiMgmtContext -Name "EchoApi"
```

This command gets the API with the specified name.

## PARAMETERS

### -Context
Specifies a **PsApiManagementContext** object.

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

### -ApiId
Specifies the ID of the API to get.

```yaml
Type: String
Parameter Sets: Find by ID
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the API to get.

```yaml
Type: String
Parameter Sets: Find by Name
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ProductId
Specifies the ID of the product for which to get the API.

```yaml
Type: String
Parameter Sets: Find by product ID
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InformationAction
Specifies how this cmdlet responds to an information event.

The acceptable values for this parameter are:

- Continue
- Ignore
- Inquire
- SilentlyContinue
- Stop
- Suspend

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: infa

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationVariable
Specifies an information variable.

```yaml
Type: String
Parameter Sets: (All)
Aliases: iv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### IList<Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementApi>

## NOTES

## RELATED LINKS

[Export-AzureRmApiManagementApi](./Export-AzureRmApiManagementApi.md)

[Import-AzureRmApiManagementApi](./Import-AzureRmApiManagementApi.md)

[New-AzureRmApiManagementApi](./New-AzureRmApiManagementApi.md)

[Remove-AzureRmApiManagementApi](./Remove-AzureRmApiManagementApi.md)

[Set-AzureRmApiManagementApi](./Set-AzureRmApiManagementApi.md)


