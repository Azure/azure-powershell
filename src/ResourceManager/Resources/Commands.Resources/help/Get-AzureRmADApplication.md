---
external help file: Microsoft.Azure.Commands.Resources.dll-Help.xml
ms.assetid: 66AC5120-80B1-46F2-AA51-132BF361602E
online version: 
schema: 2.0.0
---

# Get-AzureRmADApplication

## SYNOPSIS
Lists existing azure active directory applications.

## SYNTAX

### EmptyParameterSet (Default)
```
Get-AzureRmADApplication [-InformationAction <ActionPreference>] [-InformationVariable <String>]
```

### ApplicationObjectIdParameterSet
```
Get-AzureRmADApplication -ObjectId <Guid> [-InformationAction <ActionPreference>]
 [-InformationVariable <String>]
```

### ApplicationIdParameterSet
```
Get-AzureRmADApplication -ApplicationId <Guid> [-InformationAction <ActionPreference>]
 [-InformationVariable <String>]
```

### ApplicationDisplayNameParameterSet
```
Get-AzureRmADApplication -DisplayNameStartWith <String> [-InformationAction <ActionPreference>]
 [-InformationVariable <String>]
```

### ApplicationIdentifierUriParameterSet
```
Get-AzureRmADApplication -IdentifierUri <String> [-InformationAction <ActionPreference>]
 [-InformationVariable <String>]
```

## DESCRIPTION
Lists existing azure active directory applications.
Application lookup can be done by ObjectId, ApplicationId, IdentifierUri or DisplayName.
If no parameter is provided, it fetches all applications under the tenant.

## EXAMPLES

### --------------------------  Example 1  --------------------------
@{paragraph=PS C:\\\>}

```
PS E:\> Get-AzureRmADApplication
```

Lists all the applications under a tenant.

### --------------------------  Example 2  --------------------------
@{paragraph=PS C:\\\>}

```
PS E:\> Get-AzureRmADApplication -IdentifierUri http://mySecretApp1
```

Gets the application with identifier uri as "http://mySecretApp1".

## PARAMETERS

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

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Remove-AzureRmADAppCredential]()

[New-AzureRmADAppCredential]()

[Get-AzureRmADAppCredential]()

[Remove-AzureRmADApplication]()

[Set-AzureRmADApplication]()

[New-AzureRmADApplication]()

