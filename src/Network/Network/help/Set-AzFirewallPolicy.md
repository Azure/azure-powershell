---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/set-azfirewallpolicy
schema: 2.0.0
---

# Set-AzFirewallPolicy

## SYNOPSIS
Saves a modified azure firewall policy

## SYNTAX

### SetByNameParameterSet (Default)
```
Set-AzFirewallPolicy -Name <String> -ResourceGroupName <String> [-AsJob] [-ThreatIntelMode <String>]
 [-ThreatIntelWhitelist <PSAzureFirewallPolicyThreatIntelWhitelist>] [-BasePolicy <String>]
 [-DnsSetting <PSAzureFirewallPolicyDnsSettings>] [-SqlSetting <PSAzureFirewallPolicySqlSetting>]
 -Location <String> [-Tag <Hashtable>] [-IntrusionDetection <PSAzureFirewallPolicyIntrusionDetection>]
 [-TransportSecurityName <String>] [-TransportSecurityKeyVaultSecretId <String>] [-SkuTier <String>]
 [-UserAssignedIdentityId <String>] [-Identity <PSManagedServiceIdentity>] [-PrivateRange <String[]>]
 [-ExplicitProxy <PSAzureFirewallPolicyExplicitProxy>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### SetByInputObjectParameterSet
```
Set-AzFirewallPolicy [-Name <String>] -InputObject <PSAzureFirewallPolicy> [-AsJob] [-ThreatIntelMode <String>]
 [-ThreatIntelWhitelist <PSAzureFirewallPolicyThreatIntelWhitelist>] [-BasePolicy <String>]
 [-DnsSetting <PSAzureFirewallPolicyDnsSettings>] [-SqlSetting <PSAzureFirewallPolicySqlSetting>]
 [-Location <String>] [-Tag <Hashtable>] [-IntrusionDetection <PSAzureFirewallPolicyIntrusionDetection>]
 [-TransportSecurityName <String>] [-TransportSecurityKeyVaultSecretId <String>] [-SkuTier <String>]
 [-UserAssignedIdentityId <String>] [-Identity <PSManagedServiceIdentity>] [-PrivateRange <String[]>]
 [-ExplicitProxy <PSAzureFirewallPolicyExplicitProxy>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### SetByResourceIdParameterSet
```
Set-AzFirewallPolicy [-AsJob] -ResourceId <String> [-ThreatIntelMode <String>]
 [-ThreatIntelWhitelist <PSAzureFirewallPolicyThreatIntelWhitelist>] [-BasePolicy <String>]
 [-DnsSetting <PSAzureFirewallPolicyDnsSettings>] [-SqlSetting <PSAzureFirewallPolicySqlSetting>]
 -Location <String> [-Tag <Hashtable>] [-IntrusionDetection <PSAzureFirewallPolicyIntrusionDetection>]
 [-TransportSecurityName <String>] [-TransportSecurityKeyVaultSecretId <String>] [-SkuTier <String>]
 [-UserAssignedIdentityId <String>] [-Identity <PSManagedServiceIdentity>] [-PrivateRange <String[]>]
 [-ExplicitProxy <PSAzureFirewallPolicyExplicitProxy>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzFirewallPolicy** cmdlet updates an Azure Firewall Policy.

## EXAMPLES

### Example 1
```powershell
Set-AzFirewallPolicy -InputObject $fp
```

This example sets the firewall policy with the new firewall policy value

### Example 2
```powershell
Set-AzFirewallPolicy -Name firewallPolicy1 -ResourceGroupName TestRg -Location westcentralus -ThreatIntelMode "Alert"
```

This example sets the firewall policy with the new threat intel mode

### Example 3
```powershell
$threatIntelWhitelist = New-AzFirewallPolicyThreatIntelWhitelist -IpAddress 23.46.72.91,192.79.236.79 -FQDN microsoft.com
Set-AzFirewallPolicy -Name firewallPolicy1 -ResourceGroupName TestRg -Location westcentralus -ThreatIntelWhitelist $threatIntelWhitelist
```

This example sets the firewall policy with the new threat intel whitelist

### Example 4
```powershell
$exProxy = New-AzFirewallPolicyExplicitProxy -EnableExplicitProxy  -HttpPort 100 -HttpsPort 101 -EnablePacFile  -PacFilePort 130 -PacFile "sampleurlfortesting.blob.core.windowsnet/nothing"
Set-AzFirewallPolicy -Name firewallPolicy1 -ResourceGroupName TestRg -Location westcentralus -ExplicitProxy $exProxy
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
		Identity	                : null	
		IntrusionDetection	        : null	
		Location	                : "westcentralus"	
		Name	                    : "firewallPolicy1"	
		PrivateRange	            : null
		PrivateRangeText	        : "[]"
		ProvisioningState	        : null	
		ResourceGroupName	        : "TestRg"	
		ResourceGuid	            : null	
		RuleCollectionGroups	    : null	
		Sku	
			Tier	                : "Standard"	
		Snat	
			AutoLearnPrivateRanges	: null	
			PrivateRanges	        : null	
		SqlSetting	                : null	
		Tag	                        : null	
		TagsTable	                : null	
		ThreatIntelMode	            : "Alert"	
		ThreatIntelWhitelist	    : null	
		TransportSecurity	        : null	
		Type	                    : null	
```
This example sets the firewall policy with the explicit proxy settings

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

### -Identity
Firewall Policy Identity to be assigned to Firewall Policy.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSManagedServiceIdentity
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The AzureFirewall Policy

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPolicy
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

### -Location
location.

```yaml
Type: System.String
Parameter Sets: SetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: SetByInputObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: SetByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
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

### -SkuTier
Firewall policy sku tier

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Standard, Premium, Basic

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
The whitelist for Threat Intelligence

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

### -TransportSecurityKeyVaultSecretId
Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault

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

### -TransportSecurityName
Transport security name

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

### -UserAssignedIdentityId
ResourceId of the user assigned identity to be assigned to Firewall Policy.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: UserAssignedIdentity

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