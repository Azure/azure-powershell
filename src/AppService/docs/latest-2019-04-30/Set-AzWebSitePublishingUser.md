---
external help file:
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/set-azwebsitepublishinguser
schema: 2.0.0
---

# Set-AzWebSitePublishingUser

## SYNOPSIS
Updates publishing user

## SYNTAX

### UpdateExpanded1 (Default)
```
Set-AzWebSitePublishingUser [-Kind <String>] [-PublishingPassword <String>] [-PublishingPasswordHash <String>]
 [-PublishingPasswordHashSalt <String>] [-PublishingUserName <String>] [-ScmUri <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update1
```
Set-AzWebSitePublishingUser -UserDetail <IUser> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Updates publishing user

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

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PublishingPassword
Password used for publishing.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PublishingPasswordHash
Password hash used for publishing.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PublishingPasswordHashSalt
Password hash salt used for publishing.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PublishingUserName
Username used for publishing.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ScmUri
Url of SCM site.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -UserDetail
User credentials used for publishing activity.
To construct, see NOTES section for USERDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IUser
Parameter Sets: Update1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IUser

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IUser

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### USERDETAIL <IUser>: User credentials used for publishing activity.
  - `PublishingUserName <String>`: Username used for publishing.
  - `[Kind <String>]`: Kind of resource.
  - `[PublishingPassword <String>]`: Password used for publishing.
  - `[PublishingPasswordHash <String>]`: Password hash used for publishing.
  - `[PublishingPasswordHashSalt <String>]`: Password hash salt used for publishing.
  - `[ScmUri <String>]`: Url of SCM site.

## RELATED LINKS

