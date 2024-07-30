---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/Set-AzFirewallPolicyDraft
schema: 2.0.0
---

# Set-AzFirewallPolicyDraft

## SYNOPSIS
Saves a modified azure firewall policy draft

## SYNTAX

### SetByNameParameterSet (Default)
```
Set-AzFirewallPolicyDraft -AzureFirewallPolicyName <String> -ResourceGroupName <String> [-AsJob] [-ThreatIntelMode <String>]
 [-ThreatIntelWhitelist <PSAzureFirewallPolicyThreatIntelWhitelist>] [-BasePolicy <String>]
 [-DnsSetting <PSAzureFirewallPolicyDnsSettings>] [-SqlSetting <PSAzureFirewallPolicySqlSetting>]
 [-IntrusionDetection <PSAzureFirewallPolicyIntrusionDetection>] [-PrivateRange <String[]>]
 [-ExplicitProxy <PSAzureFirewallPolicyExplicitProxy>] [-Snat <PSAzureFirewallPolicySNAT>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByParentInputObjectParameterSet
```
Set-AzFirewallPolicyDraft [-AzureFirewallPolicyName <String>] -FirewallPolicyObject <PSAzureFirewallPolicy> [-AsJob] [-ThreatIntelMode <String>]
 [-ThreatIntelWhitelist <PSAzureFirewallPolicyThreatIntelWhitelist>] [-BasePolicy <String>]
 [-DnsSetting <PSAzureFirewallPolicyDnsSettings>] [-SqlSetting <PSAzureFirewallPolicySqlSetting>]
 [-Tag <Hashtable>] [-IntrusionDetection <PSAzureFirewallPolicyIntrusionDetection>] [-PrivateRange <String[]>]
 [-ExplicitProxy <PSAzureFirewallPolicyExplicitProxy>] [-Snat <PSAzureFirewallPolicySNAT>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByInputObjectParameterSet
```
Set-AzFirewallPolicyDraft [-AzureFirewallPolicyName <String>] -InputObject <PSAzureFirewallPolicyDraft> [-AsJob] [-ThreatIntelMode <String>]
 [-ThreatIntelWhitelist <PSAzureFirewallPolicyThreatIntelWhitelist>] [-BasePolicy <String>]
 [-DnsSetting <PSAzureFirewallPolicyDnsSettings>] [-SqlSetting <PSAzureFirewallPolicySqlSetting>]
 [-Tag <Hashtable>] [-IntrusionDetection <PSAzureFirewallPolicyIntrusionDetection>] [-PrivateRange <String[]>]
 [-ExplicitProxy <PSAzureFirewallPolicyExplicitProxy>] [-Snat <PSAzureFirewallPolicySNAT>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByResourceIdParameterSet
```
Set-AzFirewallPolicyDraft [-AsJob] -ResourceId <String> [-ThreatIntelMode <String>]
 [-ThreatIntelWhitelist <PSAzureFirewallPolicyThreatIntelWhitelist>] [-BasePolicy <String>]
 [-DnsSetting <PSAzureFirewallPolicyDnsSettings>] [-SqlSetting <PSAzureFirewallPolicySqlSetting>]
 [-Tag <Hashtable>] [-IntrusionDetection <PSAzureFirewallPolicyIntrusionDetection>] [-PrivateRange <String[]>]
 [-ExplicitProxy <PSAzureFirewallPolicyExplicitProxy>] [-Snat <PSAzureFirewallPolicySNAT>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzFirewallPolicyDraft** cmdlet updates an Azure Firewall Policy draft.

## EXAMPLES

### Example 1
```powershell
Set-AzFirewallPolicyDraft -InputObject $fpDraft
```

This example sets the firewall policy draft with the new firewall policy draft value

### Example 2
```powershell
Set-AzFirewallPolicyDraft -AzureFirewallPolicyName firewallPolicy1 -ResourceGroupName TestRg -ThreatIntelMode "Alert"
```

This example sets the firewall policy draft with the new threat intel mode

### Example 3
```powershell
$threatIntelWhitelist = New-AzFirewallPolicyThreatIntelWhitelist -IpAddress 23.46.72.91,192.79.236.79 -FQDN microsoft.com
Set-AzFirewallPolicyDraft -AzureFirewallPolicyName firewallPolicy1 -ResourceGroupName TestRg -ThreatIntelWhitelist $threatIntelWhitelist
```

This example sets the firewall policy draft with the new threat intel allowlist

### Example 4
```powershell
$exProxy = New-AzFirewallPolicyExplicitProxy -EnableExplicitProxy  -HttpPort 100 -HttpsPort 101 -EnablePacFile  -PacFilePort 130 -PacFile "sampleurlfortesting.blob.core.windowsnet/nothing"
Set-AzFirewallPolicyDraft -AzureFirewallPolicyName firewallPolicy1 -ResourceGroupName TestRg -ExplicitProxy $exProxy
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
		Location	                : "westcentralus"	
		Name	                    : "firewallPolicy1"	
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
		Type	                    : null
```

This example sets the firewall policy draft with the explicit proxy settings

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

### -InputObject
The AzureFirewall Policy draft

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPolicyDraft
Parameter Sets: SetByInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Parameter Sets: SetByNameParameterSet
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

```yaml
Type: System.String
Parameter Sets: SetByInputObjectParameterSet
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -PrivateRange
The Private IP Range

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
Parameter Sets: SetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ResourceId
The resource Id.

```yaml
Type: System.String
Parameter Sets: SetByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
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

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPolicy

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewall

## NOTES

## RELATED LINKS

[New-AzFirewallPolicyExplicitProxy](./New-AzFirewallPolicyExplicitProxy.md)
[New-AzFirewallPolicySnat](./New-AzFirewallPolicySnat.md)