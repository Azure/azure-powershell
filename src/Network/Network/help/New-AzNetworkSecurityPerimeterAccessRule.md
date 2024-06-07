---
external help file: Az.NetworkSecurityPerimeter.psm1-help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworksecurityperimeteraccessrule
schema: 2.0.0
---

# New-AzNetworkSecurityPerimeterAccessRule

## SYNOPSIS
Create a network access rule.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkSecurityPerimeterAccessRule -Name <String> -ProfileName <String> -ResourceGroupName <String>
 -SecurityPerimeterName <String> [-SubscriptionId <String>] [-AccessRuleId <String>]
 [-AddressPrefix <String[]>] [-Direction <String>] [-EmailAddress <String[]>]
 [-FullyQualifiedDomainName <String[]>] [-Location <String>] [-PhoneNumber <String[]>] [-ServiceTag <String[]>]
 [-Subscription <ISubscriptionId[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkSecurityPerimeterAccessRule -Name <String> -ProfileName <String> -ResourceGroupName <String>
 -SecurityPerimeterName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkSecurityPerimeterAccessRule -Name <String> -ProfileName <String> -ResourceGroupName <String>
 -SecurityPerimeterName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityProfileExpanded
```
New-AzNetworkSecurityPerimeterAccessRule -Name <String> -ProfileInputObject <INetworkSecurityPerimeterIdentity>
 [-AccessRuleId <String>] [-AddressPrefix <String[]>] [-Direction <String>] [-EmailAddress <String[]>]
 [-FullyQualifiedDomainName <String[]>] [-Location <String>] [-PhoneNumber <String[]>] [-ServiceTag <String[]>]
 [-Subscription <ISubscriptionId[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityProfile
```
New-AzNetworkSecurityPerimeterAccessRule -Name <String> -ProfileInputObject <INetworkSecurityPerimeterIdentity>
 -Parameter <INspAccessRule> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityNetworkSecurityPerimeterExpanded
```
New-AzNetworkSecurityPerimeterAccessRule -Name <String> -ProfileName <String>
 -NetworkSecurityPerimeterInputObject <INetworkSecurityPerimeterIdentity> [-AccessRuleId <String>]
 [-AddressPrefix <String[]>] [-Direction <String>] [-EmailAddress <String[]>]
 [-FullyQualifiedDomainName <String[]>] [-Location <String>] [-PhoneNumber <String[]>] [-ServiceTag <String[]>]
 [-Subscription <ISubscriptionId[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityNetworkSecurityPerimeter
```
New-AzNetworkSecurityPerimeterAccessRule -Name <String> -ProfileName <String>
 -NetworkSecurityPerimeterInputObject <INetworkSecurityPerimeterIdentity> -Parameter <INspAccessRule>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Create
```
New-AzNetworkSecurityPerimeterAccessRule -Name <String> -ProfileName <String> -ResourceGroupName <String>
 -SecurityPerimeterName <String> [-SubscriptionId <String>] -Parameter <INspAccessRule>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzNetworkSecurityPerimeterAccessRule -InputObject <INetworkSecurityPerimeterIdentity>
 [-AccessRuleId <String>] [-AddressPrefix <String[]>] [-Direction <String>] [-EmailAddress <String[]>]
 [-FullyQualifiedDomainName <String[]>] [-Location <String>] [-PhoneNumber <String[]>] [-ServiceTag <String[]>]
 [-Subscription <ISubscriptionId[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a network access rule.

## EXAMPLES

### Example 1: Creates a NetworkSecurityPerimeterAccessRule
```powershell
New-AzNetworkSecurityPerimeterAccessRule -Name accessRule1 -ProfileName profile2 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3 -AddressPrefix '10.10.0.0/16' -Direction 'Inbound' -Location eastus2euap
```

```output
Location Name
-------- ----
         accessRule1
```

Creates a NetworkSecurityPerimeterAccessRule

### Example 2: Creates a NetworkSecurityPerimeterAccessRule
```powershell
$emails = @("test123@microsoft.com", "test321@microsoft.com")
New-AzNetworkSecurityPerimeterAccessRule -Name accessRule2 -ProfileName profile2 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3 -EmailAddress $emails -Direction 'Outbound' -Location eastus2euap
```

```output
Location Name
-------- ----
         accessRule2
```

Creates a NetworkSecurityPerimeterAccessRule

## PARAMETERS

### -AccessRuleId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityExpanded
Aliases: Id

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddressPrefix
Inbound address prefixes (IPv4/IPv6)

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Direction
Direction that specifies whether the access rules is inbound/outbound.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmailAddress
Outbound rules email address format.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FullyQualifiedDomainName
Outbound rules fully qualified domain name format.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the NSP access rule.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityProfileExpanded, CreateViaIdentityProfile, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityNetworkSecurityPerimeter, Create
Aliases: AccessRuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkSecurityPerimeterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity
Parameter Sets: CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityNetworkSecurityPerimeter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Parameter
The NSP access rule resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspAccessRule
Parameter Sets: CreateViaIdentityProfile, CreateViaIdentityNetworkSecurityPerimeter, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PhoneNumber
Outbound rules phone number format.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity
Parameter Sets: CreateViaIdentityProfileExpanded, CreateViaIdentityProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProfileName
The name of the NSP profile.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityNetworkSecurityPerimeter, Create
Aliases: SecurityPerimeterProfileName, NSPProfileName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityPerimeterName
The name of the network security perimeter.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, Create
Aliases: NetworkSecurityPerimeterName, NSPName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceTag
Inbound rules service tag names.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Subscription
List of subscription ids

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.ISubscriptionId[]
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, Create
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspAccessRule

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspAccessRule

## NOTES

## RELATED LINKS
