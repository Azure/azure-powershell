---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/powershell/module/az.resources/get-azmgapplication
schema: 2.0.0
---

# Get-AzMgApplication

## SYNOPSIS
Represents an Azure Active Directory object.
The directoryObject type is the base type for many other directory entity types.

## SYNTAX

### EmptyParameterSet (Default)
```
Get-AzMgApplication [-Count] [-Filter <String>] [-Orderby <String[]>] [-Search <String>] [-Select <String[]>]
 [-ConsistencyLevel <String>] [-First <UInt64>] [-Skip <UInt64>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ApplicationIdentifierUriParameterSet
```
Get-AzMgApplication -IdentifierUri <String> [-Select <String[]>] [-First <UInt64>] [-Skip <UInt64>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ApplicationIdParameterSet
```
Get-AzMgApplication -ApplicationId <Guid> [-Select <String[]>] [-First <UInt64>] [-Skip <UInt64>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ApplicationObjectIdParameterSet
```
Get-AzMgApplication -ObjectId <String> [-Select <String[]>] [-First <UInt64>] [-Skip <UInt64>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### DisplayNameParameterSet
```
Get-AzMgApplication -DisplayName <String> [-Select <String[]>] [-First <UInt64>] [-Skip <UInt64>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### SearchStringParameterSet
```
Get-AzMgApplication -DisplayNameStartWith <String> [-Select <String[]>] [-First <UInt64>] [-Skip <UInt64>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Represents an Azure Active Directory object.
The directoryObject type is the base type for many other directory entity types.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -ApplicationId
application id

```yaml
Type: System.Guid
Parameter Sets: ApplicationIdParameterSet
Aliases: AppId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConsistencyLevel
Indicates the requested consistency level.
Documentation URL: https://developer.microsoft.com/en-us/office/blogs/microsoft-graph-advanced-queries-for-directory-objects-are-now-generally-available/

```yaml
Type: System.String
Parameter Sets: EmptyParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Count
Include count of items

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: EmptyParameterSet
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
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
application display name

```yaml
Type: System.String
Parameter Sets: DisplayNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayNameStartWith
application display name starts with

```yaml
Type: System.String
Parameter Sets: SearchStringParameterSet
Aliases: DisplayNameStartsWith

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
Filter items by property values

```yaml
Type: System.String
Parameter Sets: EmptyParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -First
Gets only the first 'n' objects.

```yaml
Type: System.UInt64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentifierUri
application identifier uri

```yaml
Type: System.String
Parameter Sets: ApplicationIdentifierUriParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectId
key: id of application

```yaml
Type: System.String
Parameter Sets: ApplicationObjectIdParameterSet
Aliases: Id

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Orderby
Order items by property values

```yaml
Type: System.String[]
Parameter Sets: EmptyParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Search
Search items by search phrases

```yaml
Type: System.String
Parameter Sets: EmptyParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Select
Select properties to be returned

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Ignores the first 'n' objects and then gets the remaining objects.

```yaml
Type: System.UInt64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphApplication

## NOTES

ALIASES

## RELATED LINKS

