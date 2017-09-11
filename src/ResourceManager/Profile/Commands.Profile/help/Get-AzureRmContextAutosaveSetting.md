---
external help file: Microsoft.Azure.Commands.Profile.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmContextAutosaveSetting

## SYNOPSIS
Display metadata about the context autosave feature, including whterh the context is 
automaticallys aved, and where saved context and credential information cna be found.


## SYNTAX

```
Get-AzureRmContextAutosaveSetting [-Scope <ContextModificationScope>]
```

## DESCRIPTION
Display metadata about the context autosave feature, including whterh the context is 
automaticallys aved, and where saved context and credential information cna be found.


## EXAMPLES

### Get context save metadata for the current session
```
PS C:\> Get-AzureRmContextAutosaveSetting

Mode             : Process
ContextDirectory : None
ContextFile      : None
CacheDirectory   : None
CacheFile        : None
Settings         : {}
```

Get details about whether and wehere the context is saved.  In the above example, the autosave feature has been disabled.

### Get context save metadata for the current user
```
PS C:\> Get-AzureRmContextAutosaveSetting -Scope CurrentUser

Mode             : CurrentUser
ContextDirectory : C:\Users\contoso\AppData\Roaming\Windows Azure Powershell
ContextFile      : AzureRmContext.json
CacheDirectory   : C:\Users\contoso\AppData\Roaming\Windows Azure Powershell
CacheFile        : TokenCache.dat
Settings         : {}
```

Get details about whether and wehere the context is saved by default for the current user.  Note that this may be different than 
the settings that are active in the current session. In the above example, the autosave feature has been enabled, and data is saved 
to the default location.

## PARAMETERS

### -DefaultProfile
The credeetnails, tenant and subscription used for communication with azure

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
Determines the scope of context changes, for example, wheher changes apply only to the cusrrent process, or to all sessions started by this user

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

## INPUTS

### None


## OUTPUTS

### Microsoft.Azure.Commands.Common.Authentication.ContextAutosaveSettings


## NOTES

## RELATED LINKS

