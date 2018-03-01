---
external help file: Microsoft.Azure.Commands.Resources.dll-Help.xml
Module Name: AzureRM.Resources
ms.assetid: 66AC5120-80B1-46F2-AA51-132BF361602E
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.resources/get-azurermadapplication
schema: 2.0.0
---

# Get-AzureRmADApplication

## SYNOPSIS
Lists existing azure active directory applications.

## SYNTAX

### EmptyParameterSet (Default)
```
Get-AzureRmADApplication [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ApplicationObjectIdParameterSet
```
Get-AzureRmADApplication -ObjectId <Guid> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ApplicationIdParameterSet
```
Get-AzureRmADApplication -ApplicationId <Guid> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ApplicationDisplayNameParameterSet
```
Get-AzureRmADApplication -DisplayNameStartWith <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ApplicationIdentifierUriParameterSet
```
Get-AzureRmADApplication -IdentifierUri <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists existing azure active directory applications.
Application lookup can be done by ObjectId, ApplicationId, IdentifierUri or DisplayName.
If no parameter is provided, it fetches all applications under the tenant.

## EXAMPLES

### Example 1
```
PS E:\> Get-AzureRmADApplication
```

Lists all the applications under a tenant.

### Example 2
```
PS E:\> Get-AzureRmADApplication -IdentifierUri http://mySecretApp1
```

Gets the application with identifier uri as "http://mySecretApp1".

## PARAMETERS

### -ApplicationId
The application id of the application to fetch.

```yaml
Type: Guid
Parameter Sets: ApplicationIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

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

### -DisplayNameStartWith
Fetch all applications starting with the display name.

```yaml
Type: String
Parameter Sets: ApplicationDisplayNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IdentifierUri
Unique identifier Uri of the application to fetch.

```yaml
Type: String
Parameter Sets: ApplicationIdentifierUriParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ObjectId
The object id of the application to fetch.

```yaml
Type: Guid
Parameter Sets: ApplicationObjectIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
This cmdlet does not accept any input.

## OUTPUTS

### System.Collections.Generic.List`1[Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory.PSADApplication]

## NOTES

## RELATED LINKS

[Remove-AzureRmADAppCredential](./Remove-AzureRmADAppCredential.md)

[New-AzureRmADAppCredential](./New-AzureRmADAppCredential.md)

[Get-AzureRmADAppCredential](./Get-AzureRmADAppCredential.md)

[Remove-AzureRmADApplication](./Remove-AzureRmADApplication.md)

[Set-AzureRmADApplication](./Set-AzureRmADApplication.md)

[New-AzureRmADApplication](./New-AzureRmADApplication.md)

