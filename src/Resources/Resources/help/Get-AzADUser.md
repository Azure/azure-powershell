---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/powershell/module/az.resources/get-azaduser
schema: 2.0.0
---

# Get-AzADUser

## SYNOPSIS
Lists entities from users or get entity from users by key

## SYNTAX

### List (Default)
```
Get-AzADUser [-Expand <String[]>] [-Select <String[]>] [-First <UInt64>] [-Skip <UInt64>] [-AppendSelected]
 [-Filter <String>] [-Orderby <String[]>] [-Search <String>] [-ConsistencyLevel <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### MailParameterSet
```
Get-AzADUser [-Expand <String[]>] [-Select <String[]>] [-First <UInt64>] [-Skip <UInt64>] [-AppendSelected]
 [-DefaultProfile <PSObject>] -Mail <String> [<CommonParameters>]
```

### DisplayNameParameterSet
```
Get-AzADUser [-Expand <String[]>] [-Select <String[]>] [-First <UInt64>] [-Skip <UInt64>] [-AppendSelected]
 [-DefaultProfile <PSObject>] -DisplayName <String> [<CommonParameters>]
```

### StartsWithParameterSet
```
Get-AzADUser [-Expand <String[]>] [-Select <String[]>] [-First <UInt64>] [-Skip <UInt64>] [-AppendSelected]
 [-DefaultProfile <PSObject>] -StartsWith <String> [<CommonParameters>]
```

### ObjectIdParameterSet
```
Get-AzADUser [-Expand <String[]>] [-Select <String[]>] [-AppendSelected] [-DefaultProfile <PSObject>]
 -ObjectId <String> [<CommonParameters>]
```

### UPNParameterSet
```
Get-AzADUser [-Expand <String[]>] [-Select <String[]>] [-AppendSelected] [-DefaultProfile <PSObject>]
 -UserPrincipalName <String> [<CommonParameters>]
```

### SignedInUser
```
Get-AzADUser [-Expand <String[]>] [-Select <String[]>] [-AppendSelected] [-DefaultProfile <PSObject>]
 [-SignedIn] [<CommonParameters>]
```

## DESCRIPTION
Lists entities from users or get entity from users by key

## EXAMPLES

### Example 1: Get signin user
```powershell
PS C:\> Get-AzADUser -SignedIn
```

Get signin user

### Example 2: List users
```powershell
PS C:\> Get-AzADUser -First 10 -Select 'City' -AppendSelected
```

List first 10 users and append property 'City' after default properties: 'DisplayName', 'Id', 'DeletedDateTime', 'UserPrincipalName', 'UsageLocation', 'GivenName', 'SurName', 'AccountEnabled', 'MailNickName', 'Mail'

### Example 3: Get user by display name
```powershell
PS C:\> Get-AzADUser -DisplayName $name
```

Get user by display name

## PARAMETERS

### -AppendSelected
Append properties selected with default properties when this switch is on, only works with parameter '-Select'.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: List
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
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
user display name

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

### -Expand
Expand related entities

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

### -Filter
Filter items by property values

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Mail
user mail address

```yaml
Type: System.String
Parameter Sets: MailParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectId
key: id of user

```yaml
Type: System.String
Parameter Sets: ObjectIdParameterSet
Aliases:

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
Parameter Sets: List
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
Parameter Sets: List
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

### -SignedIn
user mail address

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SignedInUser
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartsWith
user display name starts with

```yaml
Type: System.String
Parameter Sets: StartsWithParameterSet
Aliases: SearchString

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserPrincipalName
user principal name

```yaml
Type: System.String
Parameter Sets: UPNParameterSet
Aliases: UPN

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Ignores the first 'n' objects and then gets the remaining objects.

```yaml
Type: System.UInt64
Parameter Sets: List, MailParameterSet, DisplayNameParameterSet, StartsWithParameterSet
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
Parameter Sets: List, MailParameterSet, DisplayNameParameterSet, StartsWithParameterSet
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphUser

## NOTES

ALIASES

## RELATED LINKS
