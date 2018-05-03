---
external help file: Microsoft.Azure.Commands.Profile.dll-Help.xml
Module Name: AzureRM.Profile
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.profile/enable-azurermcontextautosave
schema: 2.0.0
---

# Enable-AzureRmContextAutosave

## SYNOPSIS
Allow the azure credential, account and subscription information to be saved and automatically loaded when you open a PowerShell window. 

## SYNTAX

```
Enable-AzureRmContextAutosave [-Scope <ContextModificationScope>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Allow the azure credential, account and subscription information to be saved and automatically loaded when you open a PowerShell window. 

## EXAMPLES

### Enable autosaving credentials for the current user
```
PS C:\> Enable-AzureRmContextAutosave
```

Turn on credential autosave for the current user.  Whenever a powershell window is opened, your current context will be remembered without logging in.

## PARAMETERS

### -DefaultProfile
The credentials, tenant and subscription used for communication with azure

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

### -Scope
Determines the scope of context changes, for example, whether changes apply only to the current process, or to all sessions started by this user

```yaml
Type: ContextModificationScope
Parameter Sets: (All)
Aliases: 
Accepted values: Process, CurrentUser

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Common.Authentication.ContextAutosaveSettings
Information about the current Autosave settings, including whether Autosave is enabled for the current user, and where context and credential files are saved.

## NOTES

## RELATED LINKS

