---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/get-azfrontdoorcdnprofile
schema: 2.0.0
---

# Get-AzFrontDoorCdnProfile

## SYNOPSIS
Gets an Azure Front Door Standard or Azure Front Door Premium or CDN profile with the specified profile name under the specified subscription and resource group.

## SYNTAX

### List (Default)
```
Get-AzFrontDoorCdnProfile [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzFrontDoorCdnProfile -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzFrontDoorCdnProfile -InputObject <ICdnIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzFrontDoorCdnProfile -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets an Azure Front Door Standard or Azure Front Door Premium or CDN profile with the specified profile name under the specified subscription and resource group.

## EXAMPLES

### Example 1: List AzureFrontDoor profiles under the subscription
```powershell
Get-AzFrontDoorCdnProfile
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
Global   fdp-a345e9 frontdoor testps-rg-da16jm
Global   fdp-t0jfb9 frontdoor testps-rg-zvt8sy
```

List AzureFrontDoor profiles under the subscription

### Example 2: List AzureFrontDoor profiles under the resource group
```powershell
Get-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
Global   fdp-a345e9 frontdoor testps-rg-da16jm
```

List AzureFrontDoor profiles under the resource group

### Example 3: Get an AzureFrontDoor profile under the resource group
```powershell
Get-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q6 frontdoor testps-rg-da16jm
```

Get an AzureFrontDoor profile under the resource group

### Example 4: Get an AzureFrontDoor profile under the resource group via identity
```powershell
New-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q7 -SkuName Standard_AzureFrontDoor -Location Global | Get-AzFrontDoorCdnProfile
```

```output
Location Name       Kind      ResourceGroupName
-------- ----       ----      -----------------
Global   fdp-v542q7 frontdoor testps-rg-da16jm
```

Get an AzureFrontDoor profile under the resource group via identity

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Azure Front Door Standard or Azure Front Door Premium or CDN profile which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ProfileName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IProfile

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <ICdnIdentity>`: Identity Parameter
  - `[CustomDomainName <String>]`: Name of the domain under the profile which is unique globally.
  - `[EndpointName <String>]`: Name of the endpoint under the profile which is unique globally.
  - `[Id <String>]`: Resource identity path
  - `[OriginGroupName <String>]`: Name of the origin group which is unique within the endpoint.
  - `[OriginName <String>]`: Name of the origin which is unique within the profile.
  - `[ProfileName <String>]`: Name of the Azure Front Door Standard or Azure Front Door Premium which is unique within the resource group.
  - `[ResourceGroupName <String>]`: Name of the Resource group within the Azure subscription.
  - `[RouteName <String>]`: Name of the routing rule.
  - `[RuleName <String>]`: Name of the delivery rule which is unique within the endpoint.
  - `[RuleSetName <String>]`: Name of the rule set under the profile which is unique globally.
  - `[SecretName <String>]`: Name of the Secret under the profile.
  - `[SecurityPolicyName <String>]`: Name of the security policy under the profile.
  - `[SubscriptionId <String>]`: Azure Subscription ID.

## RELATED LINKS

