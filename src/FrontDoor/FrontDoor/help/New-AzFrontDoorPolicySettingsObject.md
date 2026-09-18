---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorpolicysettingsobject
schema: 2.0.0
---

# New-AzFrontDoorPolicySettingsObject

## SYNOPSIS
Create an in-memory object for PolicySettings.

## SYNTAX

```
New-AzFrontDoorPolicySettingsObject [-CaptchaExpirationInMinutes <Int32>] [-CustomBlockResponseBody <String>]
 [-CustomBlockResponseStatusCode <Int32>] [-EnabledState <String>]
 [-JavascriptChallengeExpirationInMinutes <Int32>] [-LogScrubbingSetting <IPolicySettingsLogScrubbing>]
 [-Mode <String>] [-RedirectUrl <String>] [-RequestBodyCheck <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PolicySettings.

## EXAMPLES

### Example 1: Create a WAF policy settings object with all parameters
```powershell
$logScrubbing = New-AzFrontDoorWafLogScrubbingSettingObject -State "Enabled" -ScrubbingRule @()
New-AzFrontDoorPolicySettingsObject -EnabledState "Enabled" -Mode "Prevention" -RequestBodyCheck "Enabled" -CustomBlockResponseStatusCode 403 -CustomBlockResponseBody "PGh0bWw+PGJvZHk+QmxvY2tlZDwvYm9keT48L2h0bWw+" -RedirectUrl "https://www.example.com/blocked" -JavascriptChallengeExpirationInMinutes 30 -LogScrubbingSetting $logScrubbing
```

```output
CaptchaExpirationInMinutes             :
CustomBlockResponseBody                : PGh0bWw+PGJvZHk+QmxvY2tlZDwvYm9keT48L2h0bWw+
CustomBlockResponseStatusCode          : 403
EnabledState                           : Enabled
JavascriptChallengeExpirationInMinutes : 30
LogScrubbingSetting                    : {
                                         }
Mode                                   : Prevention
RedirectUrl                            : https://www.example.com/blocked
RequestBodyCheck                       : Enabled
```

Create a comprehensive WAF policy settings object with prevention mode enabled, custom block response, redirect URL, and log scrubbing configuration.

## PARAMETERS

### -CaptchaExpirationInMinutes
Defines the Captcha cookie validity lifetime in minutes.
This setting is only applicable to Premium_AzureFrontDoor.
Value must be an integer between 5 and 1440 with the default value being 30.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomBlockResponseBody
If the action type is block, customer can override the response body.
The body must be specified in base64 encoding.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomBlockResponseStatusCode
If the action type is block, customer can override the response status code.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnabledState
Describes if the policy is in enabled or disabled state.
Defaults to Enabled if not specified.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JavascriptChallengeExpirationInMinutes
Defines the JavaScript challenge cookie validity lifetime in minutes.
This setting is only applicable to Premium_AzureFrontDoor.
Value must be an integer between 5 and 1440 with the default value being 30.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogScrubbingSetting
Defines rules that scrub sensitive fields in the Web Application Firewall logs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IPolicySettingsLogScrubbing
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Mode
Describes if it is in detection mode or prevention mode at policy level.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RedirectUrl
If action type is redirect, this field represents redirect URL for the client.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestBodyCheck
Describes if policy managed rules will inspect the request body content.

```yaml
Type: System.String
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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.PolicySettings

## NOTES

## RELATED LINKS
