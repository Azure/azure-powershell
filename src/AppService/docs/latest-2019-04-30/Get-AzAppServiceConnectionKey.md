---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/get-azappserviceconnectionkey
schema: 2.0.0
---

# Get-AzAppServiceConnectionKey

## SYNOPSIS
Lists connection keys.

## SYNTAX

### ListExpanded (Default)
```
Get-AzAppServiceConnectionKey -ConnectionName <String> -ResourceGroupName <String> -SubscriptionId <String[]>
 -Location <String> [-Id <String>] [-Kind <String>] [-Name <String>] [-Tag <Hashtable>] [-Type <String>]
 [-ValidityTimeSpan <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### List
```
Get-AzAppServiceConnectionKey -ConnectionName <String> -ResourceGroupName <String> -SubscriptionId <String[]>
 -Content <IListConnectionKeysInput> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Lists connection keys.

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

### -ConnectionName
The connection name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Content
List Connection Keys Input payload
To construct, see NOTES section for CONTENT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801Preview.IListConnectionKeysInput
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -Id
Resource Id

```yaml
Type: System.String
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource

```yaml
Type: System.String
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource Location

```yaml
Type: System.String
Parameter Sets: ListExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Resource Name

```yaml
Type: System.String
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Type
Resource type

```yaml
Type: System.String
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ValidityTimeSpan
time span for how long the keys will be valid

```yaml
Type: System.String
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801Preview.IListConnectionKeysInput

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801Preview.IConnectionSecrets

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### CONTENT <IListConnectionKeysInput>: List Connection Keys Input payload
  - `Location <String>`: Resource Location
  - `[Id <String>]`: Resource Id
  - `[Kind <String>]`: Kind of resource
  - `[Name <String>]`: Resource Name
  - `[Tag <IResourceTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Type <String>]`: Resource type
  - `[ValidityTimeSpan <String>]`: time span for how long the keys will be valid

## RELATED LINKS

