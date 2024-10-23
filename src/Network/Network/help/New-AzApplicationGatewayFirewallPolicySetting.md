---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azapplicationgatewayfirewallpolicysetting
schema: 2.0.0
---

# New-AzApplicationGatewayFirewallPolicySetting

## SYNOPSIS
Creates a policy setting for the firewall policy

## SYNTAX

```
New-AzApplicationGatewayFirewallPolicySetting [-Mode <String>] [-State <String>]
 [-DisableRequestBodyEnforcement <Boolean>] [-RequestBodyInspectLimitInKB <Int32>] [-DisableRequestBodyCheck]
 [-MaxRequestBodySizeInKb <Int32>] [-DisableFileUploadEnforcement <Boolean>] [-MaxFileUploadInMb <Int32>]
 [-CustomBlockResponseStatusCode <Int32>] [-CustomBlockResponseBody <String>]
 [-LogScrubbing <PSApplicationGatewayFirewallPolicyLogScrubbingConfiguration>]
 [-JSChallengeCookieExpirationInMins <Int32>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayFirewallPolicySetting** creates a policy settings for a firewall policy.

## EXAMPLES

### Example 1
```powershell
$condition = New-AzApplicationGatewayFirewallPolicySetting -State $enabledState -Mode $enabledMode -DisableRequestBodyCheck -MaxFileUploadInMb $fileUploadLimitInMb -MaxRequestBodySizeInKb $maxRequestBodySizeInKb
```

The command creates a policy setting with state as $enabledState, mode as $enabledMode, RequestBodyCheck as false, FileUploadLimitInMb as $fileUploadLimitInMb and MaxRequestBodySizeInKb as $maxRequestBodySizeInKb.
The new policySettings is stored to $condition.

### Example 2
```powershell
$condition = New-AzApplicationGatewayFirewallPolicySetting -State $enabledState -Mode $enabledMode -DisableRequestBodyCheck -MaxFileUploadInMb $fileUploadLimitInMb -MaxRequestBodySizeInKb $maxRequestBodySizeInKb -LogScrubbing $logScrubbingRuleConfig
```

The command creates a policy setting with state as $enabledState, mode as $enabledMode, RequestBodyCheck as false, FileUploadLimitInMb as $fileUploadLimitInMb and MaxRequestBodySizeInKb as $maxRequestBodySizeInKb with a scrubbing rule as $logScrubbingRuleConfig.
The new policySettings is stored to $condition.

### Example 3
```powershell
$condition = New-AzApplicationGatewayFirewallPolicySetting -State $enabledState -Mode $enabledMode -DisableRequestBodyEnforcement true -RequestBodyInspectLimitInKB 2000 -DisableRequestBodyCheck -MaxFileUploadInMb $fileUploadLimitInMb -DisableFileUploadEnforcement true -MaxRequestBodySizeInKb $maxRequestBodySizeInKb
```

The command creates a policy setting with state as $enabledState, mode as $enabledMode, RequestBodyEnforcement as false, RequestBodyInspectLimitInKB as 2000, RequestBodyCheck as false, FileUploadLimitInMb as $fileUploadLimitInMb, FileUploadEnforcement as false and MaxRequestBodySizeInKb as $maxRequestBodySizeInKb.
The new policySettings is stored to $condition.

### Example 4
```powershell
$condition = New-AzApplicationGatewayFirewallPolicySetting -State $enabledState -Mode $enabledMode -DisableRequestBodyCheck -MaxFileUploadInMb $fileUploadLimitInMb -MaxRequestBodySizeInKb $maxRequestBodySizeInKb -JSChallengeCookieExpirationInMins $jsChallengeCookieExpirationInMins
```

The command creates a policy setting with state as $enabledState, mode as $enabledMode, RequestBodyCheck as false, FileUploadLimitInMb as $fileUploadLimitInMb and MaxRequestBodySizeInKb as $maxRequestBodySizeInKb, JSChallengeCookieExpirationInMins as $jsChallengeCookieExpirationInMins.
The new policySettings is stored to $condition.

## PARAMETERS

### -CustomBlockResponseBody
Custom Block Response Body in policy settings of the firewall policy.

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
Custom block response status code in policy settings of the firewall policy.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableFileUploadEnforcement
Disable file upload enforcement limits for WAF.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableRequestBodyCheck
Diables the requestBodyCheck in policy settings of the firewall policy.

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

### -DisableRequestBodyEnforcement
Disable request body enforcement limits for WAF.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JSChallengeCookieExpirationInMins
Web Application Firewall JavaScript Challenge Cookie Expiration time in minutes.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogScrubbing
To scrub sensitive log fields

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallPolicyLogScrubbingConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxFileUploadInMb
Maximum fileUpload size in MB.

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

### -MaxRequestBodySizeInKb
MaxRequestBodySizeInKb in policy settings of the firewall policy.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 128
Accept pipeline input: False
Accept wildcard characters: False
```

### -Mode
Firewall Mode in policy settings of the firewall policy.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Prevention, Detection

Required: False
Position: Named
Default value: Detection
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestBodyInspectLimitInKB
Max inspection limit in KB for request body inspection.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
State variable in policy settings of the firewall policy.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Disabled, Enabled

Required: False
Position: Named
Default value: Enabled
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallPolicySettings

## NOTES

## RELATED LINKS
