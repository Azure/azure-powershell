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

