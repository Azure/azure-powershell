---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azapplicationgatewayfirewallcondition
schema: 2.0.0
---

# New-AzApplicationGatewayFirewallPolicySettings

## SYNOPSIS
Creates a policy setting for the firewall policy

## SYNTAX

```
New-AzApplicationGatewayFirewallPolicySettings -State <String> -Mode <String>  
[-RequestBodyCheck] -FileUploadLimitInMb <Integer> -MaxRequestBodySizeInKb <Integer>
[-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzApplicationGatewayFirewallPolicySettings** creates a policy settings for a firewall policy.

## EXAMPLES

### Example 1
```powershell
PS C:\> $condition = New-AzApplicationGatewayFirewallPolicySettings -State $enabledState -Mode $enabledMode -RequestBodyCheck -FileUploadLimitInMb $fileUploadLimitInMb -MaxRequestBodySizeInKb $maxRequestBodySizeInKb
```

The command creates a policy setting with state as $enabledState, mode as $enabledMode, RequestBodyCheck as true, FileUploadLimitInMb as $fileUploadLimitInMb and MaxRequestBodySizeInKb as $$maxRequestBodySizeInKb.
The new policySettings is stored to $condition.

## PARAMETERS

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

### -State
State variable in policy settings of the firewall policy.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: Enabled
Accept pipeline input: False
Accept wildcard characters: False
```

### -Mode
Firewall Mode in policy settings of the firewall policy.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: Detection
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestBodyCheck
RequestBodyCheck in policy settings of the firewall policy.

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

### -FileUploadLimitInMb
FileUploadLimitInMb in policy settings of the firewall policy.

```yaml
Type: System.Integer
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 750
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxRequestBodySizeInKb
MaxRequestBodySizeInKb in policy settings of the firewall policy.

```yaml
Type: System.Integer
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 128
Accept pipeline input: False
Accept wildcard characters: False
```
### CommonParameters

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayFirewallCondition

## NOTES

## RELATED LINKS
