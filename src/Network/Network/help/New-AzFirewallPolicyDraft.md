---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/New-AzFirewallPolicyDraft
schema: 2.0.0
---

# New-AzFirewallPolicyDraft

## SYNOPSIS
Creates a new Azure Firewall Policy draft.

## SYNTAX

### SetByNameParameterSet (Default)
```
New-AzFirewallPolicyDraft -AzureFirewallPolicyName <String> -ResourceGroupName <String> -Location <String> [-ThreatIntelMode <String>]
 [-ThreatIntelWhitelist <PSAzureFirewallPolicyThreatIntelWhitelist>] [-BasePolicy <String>]
 [-DnsSetting <PSAzureFirewallPolicyDnsSettings>] [-SqlSetting <PSAzureFirewallPolicySqlSetting>]
 [-Tag <Hashtable>] [-Force] [-AsJob] [-IntrusionDetection <PSAzureFirewallPolicyIntrusionDetection>]
 [-PrivateRange <String[]>] [-ExplicitProxy <PSAzureFirewallPolicyExplicitProxy>] [-Snat <PSAzureFirewallPolicySNAT>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByParentInputObjectParameterSet
```
Set-AzFirewallPolicyDraft [-AzureFirewallPolicyName <String>] -FirewallPolicyObject <PSAzureFirewallPolicy> [-AsJob] [-ThreatIntelMode <String>]
 [-ThreatIntelWhitelist <PSAzureFirewallPolicyThreatIntelWhitelist>] [-BasePolicy <String>]
 [-DnsSetting <PSAzureFirewallPolicyDnsSettings>] [-SqlSetting <PSAzureFirewallPolicySqlSetting>]
 [-Tag <Hashtable>] [-IntrusionDetection <PSAzureFirewallPolicyIntrusionDetection>] [-TransportSecurityName <String>]
 [-PrivateRange <String[]>] [-ExplicitProxy <PSAzureFirewallPolicyExplicitProxy>] [-Snat <PSAzureFirewallPolicySNAT>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzFirewallPolicyDraft** cmdlet creates an Azure Firewall Policy draft with the same properties as the parent policy.

## EXAMPLES

### Example 1: Create a policy draft
```powershell
New-AzFirewallPolicyDraft -AzureFirewallPolicyName fp1 -ResourceGroupName TestRg
```

This example creates an azure firewall policy draft

### Example 2: Create a policy draft with ThreatIntel Mode
```powershell
New-AzFirewallPolicyDraft -AzureFirewallPolicyName fp1 -ResourceGroupName TestRg -ThreatIntelMode "Deny"
```

This example creates an azure firewall policy draft with the same properties as the parent policy except for a specified threat intel mode

### Example 3: Create a policy draft with ThreatIntelWhitelist
```powershell
$threatIntelWhitelist = New-AzFirewallPolicyThreatIntelWhitelist -IpAddress 23.46.72.91,192.79.236.79 -FQDN microsoft.com
New-AzFirewallPolicyDraft -AzureFirewallPolicyName fp1 -ResourceGroupName TestRg -ThreatIntelWhitelist $threatIntelWhitelist
```

This example creates an azure firewall policy draft with the same properties as the parent policy except for a specified ThreatIntelWhitelist

### Example 4: Create policy with intrusion detection
```powershell
$bypass = New-AzFirewallPolicyIntrusionDetectionBypassTraffic -Name "bypass-setting" -Protocol "TCP" -DestinationPort "80" -SourceAddress "10.0.0.0" -DestinationAddress "*"
$signatureOverride = New-AzFirewallPolicyIntrusionDetectionSignatureOverride -Id "123456798" -Mode "Deny"
$intrusionDetection = New-AzFirewallPolicyIntrusionDetection -Mode "Alert" -SignatureOverride $signatureOverride -BypassTraffic $bypass
New-AzFirewallPolicyDraft -AzureFirewallPolicyName fp1 -ResourceGroupName TestRg -IntrusionDetection $intrusionDetection 
```

This example creates an azure firewall policy draft with the same properties as the parent policy except that the intrusion detection in mode is set to alert

### Example 5: Create an empty Firewall Policy with customized private range setup
```powershell
New-AzFirewallPolicyDraft -AzureFirewallPolicyName fp1 -ResourceGroupName TestRg -PrivateRange @("99.99.99.0/24", "66.66.0.0/16")
```

This example creates a Firewall that treats "99.99.99.0/24" and "66.66.0.0/16" as private ip ranges and won't snat traffic to those addresses. Other properties are set by the parent policy.

### Example 6: Create an empty Firewall Policy with Explicit Proxy Settings
```powershell
$exProxy = New-AzFirewallPolicyExplicitProxy -EnableExplicitProxy  -HttpPort 100 -HttpsPort 101 -EnablePacFile  -PacFilePort 130 -PacFile "sampleurlfortesting.blob.core.windowsnet/nothing"
New-AzFirewallPolicyDraft -AzureFirewallPolicyName fp1 -ResourceGroupName TestRg -ExplicitProxy $exProxy
```

```output
		BasePolicy	                : null	
		DnsSettings  	            : null	
		Etag	                    : null	
		ExplicitProxy	
			EnableExplicitProxy	    : true	
			EnablePacFile	        : true	
			HttpPort	            : 100	
			HttpsPort	            : 101	
			PacFile                 : "sampleurlfortesting.blob.core.windowsnet/nothing"
			PacFilePort	            : 130	
		Id	                        : null	
		IntrusionDetection	        : null	
		Location	                : "westus2"	
		Name	                    : "fp1"	
		PrivateRange	            : null
		PrivateRangeText	        : "[]"
		ProvisioningState	        : null	
		ResourceGroupName	        : "TestRg"	
		ResourceGuid	            : null	
		RuleCollectionGroups	    : null	
		Snat	
			AutoLearnPrivateRanges	: null	
			PrivateRanges	        : null	
		SqlSetting	                : null	
		Tag	                        : null	
		TagsTable	                : null	
		ThreatIntelMode	            : "Alert"	
		ThreatIntelWhitelist	    : null	
```

This example creates a firewall policy with explicit proxy settings

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -BasePolicy
The base policy to inherit from

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -DnsSetting
The DNS Setting

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPolicyDnsSettings
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExplicitProxy
The Explicit Proxy Settings

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPolicyExplicitProxy
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation if you want to overwrite a resource

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

### -IntrusionDetection
The Intrusion Detection Setting

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPolicyIntrusionDetection
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureFirewallPolicyName
The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -FirewallPolicyObject
The AzureFirewall Policy associated with the draft

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPolicy
Parameter Sets: SetByParentInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateRange
The private IP ranges to which traffic won't be SNAT'ed

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Snat
The private IP addresses/IP ranges to which traffic will not be SNAT in Firewall Policy.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPolicySNAT
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlSetting
The SQL related setting

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPolicySqlSetting
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
A hashtable which represents resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ThreatIntelMode
The operation mode for Threat Intelligence.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Alert, Deny, Off

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ThreatIntelWhitelist
The allowlist for Threat Intelligence

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPolicyThreatIntelWhitelist
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewall

## NOTES

## RELATED LINKS

[New-AzFirewallPolicyDraftExplicitProxy](./New-AzFirewallPolicyDraftExplicitProxy.md)
[New-AzFirewallPolicyDraftSnat](./New-AzFirewallPolicyDraftSnat.md)