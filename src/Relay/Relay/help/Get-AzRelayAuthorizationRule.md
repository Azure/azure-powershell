---
external help file: Az.Relay-help.xml
Module Name: Az.Relay
online version: https://learn.microsoft.com/powershell/module/az.relay/get-azrelayauthorizationrule
schema: 2.0.0
---

# Get-AzRelayAuthorizationRule

## SYNOPSIS
Authorization rule for a namespace by name.

## SYNTAX

### List (Default)
```
Get-AzRelayAuthorizationRule -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzRelayAuthorizationRule -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -HybridConnection <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### List2
```
Get-AzRelayAuthorizationRule -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WcfRelay <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzRelayAuthorizationRule -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -Name <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get1
```
Get-AzRelayAuthorizationRule -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -Name <String> -HybridConnection <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Get2
```
Get-AzRelayAuthorizationRule -Namespace <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -Name <String> -WcfRelay <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzRelayAuthorizationRule -InputObject <IRelayIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Authorization rule for a namespace by name.

## EXAMPLES

### Example 1: List all Authorization Rules of the Relay namespace
```powershell
Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01
```

```output
Location Name                      ResourceGroupName
-------- ----                      -----------------
eastus   RootManageSharedAccessKey lucas-relay-rg
eastus   authRule-03               lucas-relay-rg
```

This cmdlet lists all Authorization Rules of the Relay namespace.

### Example 2: Get the specified authorization rule description for a given Relay namespace
```powershell
Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -Name authRule-03 | Format-List
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespa
                               ce-pwsh01/authorizationrules/authRule-03
Location                     : eastus
Name                         : authRule-03
ResourceGroupName            : lucas-relay-rg
Rights                       : {Listen, Send}
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/Namespaces/AuthorizationRules
```

This cmdlet gets the specified authorization rule description for a given Relay namespace.

### Example 3: List all Authorization Rules of the Hybrid Connection
```powershell
Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -HybridConnection connection-01
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
eastus   authRule-01 lucas-relay-rg
```

This cmdlet lists all Authorization Rules of the Hybrid Connection.

### Example 4: Get the specified authorization rule description for a given Hybrid Connection
```powershell
Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -HybridConnection connection-01 -Name authRule-01 | Format-List
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespa
                               ce-pwsh01/hybridconnections/connection-01/authorizationrules/authRule-01
Location                     : eastus
Name                         : authRule-01
ResourceGroupName            : lucas-relay-rg
Rights                       : {Listen, Send}
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/hybridconnections/authorizationrules
```

This cmdlet gets the specified authorization rule description for a given Hybrid Connection.

### Example 5: List all Authorization Rules of the Wcf Relay
```powershell
Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -WcfRelay wcf-01
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
eastus   authRule-01 lucas-relay-rg
```

This cmdlet lists all Authorization Rules of the Wcf Relay.

### Example 6: Get the specified authorization rule description for a given Wcf Relay
```powershell
Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 -WcfRelay connection-01 -Name authRule-01 | Format-List
```

```output
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespa
                               ce-pwsh01/wcfrelays/connection-01/authorizationrules/authRule-01
Location                     : eastus
Name                         : authRule-01
ResourceGroupName            : lucas-relay-rg
Rights                       : {Listen, Send}
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.Relay/namespaces/wcfrelays/authorizationrules
```

This cmdlet gets the specified authorization rule description for a given Wcf Relay.

### Example 7: Get the specified authorization rule description by pipeline
```powershell
Get-AzRelayAuthorizationRule -ResourceGroupName lucas-relay-rg -Namespace namespace-pwsh01 | Get-AzRelayAuthorizationRule
```

```output
Location Name                      ResourceGroupName
-------- ----                      -----------------
eastus   RootManageSharedAccessKey lucas-relay-rg
eastus   authRule-03               lucas-relay-rg
```

This cmdlet gets the specified authorization rule description by pipeline.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -HybridConnection
The hybrid connection name.

```yaml
Type: System.String
Parameter Sets: List1, Get1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.IRelayIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The authorization rule name.

```yaml
Type: System.String
Parameter Sets: Get, Get1, Get2
Aliases: AuthorizationRuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Namespace
The namespace name

```yaml
Type: System.String
Parameter Sets: List, List1, List2, Get, Get1, Get2
Aliases:

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
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: List, List1, List2, Get, Get1, Get2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: List, List1, List2, Get, Get1, Get2
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WcfRelay
The relay name.

```yaml
Type: System.String
Parameter Sets: List2, Get2
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

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.IRelayIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.IAuthorizationRule

## NOTES

## RELATED LINKS
