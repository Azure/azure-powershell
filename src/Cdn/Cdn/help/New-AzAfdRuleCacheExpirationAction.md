---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Cdn.dll-Help.xml
Module Name: Az.Cdn
online version:
schema: 2.0.0
---

# New-AzAfdRuleCacheExpirationAction

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### AfdRuleBypassCache
```
New-AzAfdRuleCacheExpirationAction [-BypassCache] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### AfdRuleOverride
```
New-AzAfdRuleCacheExpirationAction [-Override] -CacheDuration <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AfdRuleSetIfMissing
```
New-AzAfdRuleCacheExpirationAction [-SetIfMissing] -CacheDuration <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -BypassCache
Sets the caching behavior to Bypass caching.
This prevents requests that contain query strings from being cached.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AfdRuleBypassCache
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CacheDuration
The duration for which the content needs to be cached.
Allowed format is \[d.\]hh:mm:ss

```yaml
Type: System.String
Parameter Sets: AfdRuleOverride, AfdRuleSetIfMissing
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Override
Sets the caching behavior to Override.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AfdRuleOverride
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SetIfMissing
Sets the caching behavior to SetIfMissing.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AfdRuleSetIfMissing
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Cdn.AfdModels.PSAfdRuleCacheExpirationAction

## NOTES

## RELATED LINKS
