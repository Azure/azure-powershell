---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Cdn.dll-Help.xml
Module Name: Az.Cdn
online version: https://docs.microsoft.com/powershell/module/az.cdn/new-azfrontdoorcdnruleaction
schema: 2.0.0
---

# New-AzFrontDoorCdnRuleAction

## SYNOPSIS
Creates the rule action.

## SYNTAX

### AfdRuleCacheExpirationAction (Default)
```
New-AzFrontDoorCdnRuleAction -CacheBehavior <String> [-CacheDuration <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AfdRuleHeaderTypeAction
```
New-AzFrontDoorCdnRuleAction -HeaderType <String> -HeaderAction <String> -HeaderName <String>
 [-HeaderValue <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AfdRuleCacheKeyQueryStringAction
```
New-AzFrontDoorCdnRuleAction -QueryStringBehavior <String> -QueryParameters <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AfdRuleUrlRedirectAction
```
New-AzFrontDoorCdnRuleAction -RedirectType <String> [-DestinationProtocol <String>] [-CustomPath <String>]
 [-CustomHostname <String>] [-CustomQueryString <String>] [-CustomFragment <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AfdRuleUrlRewriteAction
```
New-AzFrontDoorCdnRuleAction -SourcePattern <String> -Destination <String> [-PreservePath]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AfdRuleOriginGroupOverrideAction
```
New-AzFrontDoorCdnRuleAction -OriginGroupOverride <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Creates the rule action.

## EXAMPLES

### Example 1
```powershell
New-AzFrontDoorCdnRuleAction -CacheBehavior BypassCache
```

Creates the rule action.

## PARAMETERS

### -CacheBehavior
Caching behavior for the action.

```yaml
Type: String
Parameter Sets: AfdRuleCacheExpirationAction
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
Type: String
Parameter Sets: AfdRuleCacheExpirationAction
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomFragment
Fragment to add to the redirect URL.
Fragment is the part of the URL that comes after #.
Do not include the #.

```yaml
Type: String
Parameter Sets: AfdRuleUrlRedirectAction
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomHostname
Host to redirect.
Leave empty to use the incoming host as the destination host.

```yaml
Type: String
Parameter Sets: AfdRuleUrlRedirectAction
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomPath
The full path to redirect.
Path cannot be empty and must start with /.
Leave empty to use the incoming path as destination path.

```yaml
Type: String
Parameter Sets: AfdRuleUrlRedirectAction
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomQueryString
The set of query strings to be placed in the redirect URL.
Setting this value would replace any existing query string; leave empty to preserve the incoming query string.
Query string must be in \<key\>=\<value\> format.
? and & will be added automatically so do not include them.

```yaml
Type: String
Parameter Sets: AfdRuleUrlRedirectAction
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Destination
Define the relative URL to which the above requests will be rewritten by.

```yaml
Type: String
Parameter Sets: AfdRuleUrlRewriteAction
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationProtocol
Protocol to use for the redirect.
The default value is MatchRequest.

```yaml
Type: String
Parameter Sets: AfdRuleUrlRedirectAction
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HeaderAction
Action to perform.

```yaml
Type: String
Parameter Sets: AfdRuleHeaderTypeAction
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HeaderName
Name of the header to modify.

```yaml
Type: String
Parameter Sets: AfdRuleHeaderTypeAction
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HeaderType
Whether to modify request header or response header.

```yaml
Type: String
Parameter Sets: AfdRuleHeaderTypeAction
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HeaderValue
Value for the specified action.

```yaml
Type: String
Parameter Sets: AfdRuleHeaderTypeAction
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OriginGroupOverride
Defines the origin group override action for the delivery rule.

```yaml
Type: String
Parameter Sets: AfdRuleOriginGroupOverrideAction
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreservePath
Whether to preserve unmatched path.

```yaml
Type: SwitchParameter
Parameter Sets: AfdRuleUrlRewriteAction
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueryParameters
Query parameters to include or exclude (comma separated).

```yaml
Type: String
Parameter Sets: AfdRuleCacheKeyQueryStringAction
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueryStringBehavior
Defines the parameters for the cache-key query string action.
Accepted values : Include, IncludeAll, Exclude, ExcludeAll

```yaml
Type: String
Parameter Sets: AfdRuleCacheKeyQueryStringAction
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RedirectType
The redirect type the rule will use when redirecting traffic.

```yaml
Type: String
Parameter Sets: AfdRuleUrlRedirectAction
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourcePattern
Define a request URI pattern that identifies the type of requests that may be rewritten.
If value is blank, all strings are matched.

```yaml
Type: String
Parameter Sets: AfdRuleUrlRewriteAction
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

### Microsoft.Azure.Commands.Cdn.AfdModels.PSAfdRuleAction

## NOTES

## RELATED LINKS
