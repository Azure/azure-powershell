---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/powershell/module/az.resources/get-azaduser
schema: 2.0.0
---

# Get-AzAdUser

## SYNOPSIS
Represents an Azure Active Directory user object.

## SYNTAX

### List (Default)
```
Get-AzAdUser [-AppendSelected] [-ConsistencyLevel <String>] [-DefaultProfile <PSObject>] [-Expand <String[]>]
 [-Filter <String>] [-First <UInt64>] [-IncludeTotalCount] [-Orderby <String[]>] [-Search <String>]
 [-Select <String[]>] [-Skip <UInt64>] [<CommonParameters>]
```

### DisplayNameParameterSet
```
Get-AzAdUser -DisplayName <String> [-AppendSelected] [-DefaultProfile <PSObject>] [-Expand <String[]>]
 [-First <UInt64>] [-IncludeTotalCount] [-Select <String[]>] [-Skip <UInt64>] [<CommonParameters>]
```

### MailParameterSet
```
Get-AzAdUser -Mail <String> [-AppendSelected] [-DefaultProfile <PSObject>] [-Expand <String[]>]
 [-First <UInt64>] [-IncludeTotalCount] [-Select <String[]>] [-Skip <UInt64>] [<CommonParameters>]
```

### ObjectIdParameterSet
```
Get-AzAdUser -ObjectId <String> [-AppendSelected] [-DefaultProfile <PSObject>] [-Expand <String[]>]
 [-Select <String[]>] [<CommonParameters>]
```

### SignedInUser
```
Get-AzAdUser -SignedIn [-AppendSelected] [-DefaultProfile <PSObject>] [-Expand <String[]>]
 [-Select <String[]>] [<CommonParameters>]
```

### StartsWithParameterSet
```
Get-AzAdUser -StartsWith <String> [-AppendSelected] [-DefaultProfile <PSObject>] [-Expand <String[]>]
 [-First <UInt64>] [-IncludeTotalCount] [-Select <String[]>] [-Skip <UInt64>] [<CommonParameters>]
```

### UPNParameterSet
```
Get-AzAdUser -UserPrincipalName <String> [-AppendSelected] [-DefaultProfile <PSObject>] [-Expand <String[]>]
 [-Select <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Represents an Azure Active Directory user object.

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

### -AppendSelected


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
Aliases: AzureRMContext, AzureCredential

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

### -First
Gets only the first 'n' objects.

```yaml
Type: System.UInt64
Parameter Sets: DisplayNameParameterSet, List, MailParameterSet, StartsWithParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeTotalCount
Reports the number of objects in the data set.
Currently, this parameter does nothing.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: DisplayNameParameterSet, List, MailParameterSet, StartsWithParameterSet
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

### -Skip
Ignores the first 'n' objects and then gets the remaining objects.

```yaml
Type: System.UInt64
Parameter Sets: DisplayNameParameterSet, List, MailParameterSet, StartsWithParameterSet
Aliases:

Required: False
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphUser

## NOTES

ALIASES

## RELATED LINKS

