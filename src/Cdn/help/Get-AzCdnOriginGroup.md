---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/get-azcdnorigingroup
schema: 2.0.0
---

# Get-AzCdnOriginGroup

## SYNOPSIS
Gets an existing origin group within an endpoint.

## SYNTAX

### List1 (Default)
```
Get-AzCdnOriginGroup -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzCdnOriginGroup -EndpointName <String> -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzCdnOriginGroup -InputObject <ICdnIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets an existing origin group within an endpoint.

## EXAMPLES

### Example 1: List AzureCDN origin groups under the AzureCDN endpoint
```powershell
Get-AzCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
org002 testps-rg-da16jm
```

List AzureCDN origin groups under the AzureCDN endpoint

### Example 2: Get an AzureCDN origin group under the AzureCDN endpoint
```powershell
Get-AzCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name org001
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
```

Get an AzureCDN origin group under the AzureCDN endpoint

### Example 3: Get an AzureCDN origin group under the AzureCDN endpoint via identity
```powershell
$healthProbeParameters = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 120 -ProbePath "/check-health.aspx" -ProbeProtocol "Http" -ProbeRequestType "HEAD"
$origin = Get-AzCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest010 -Name origin1
New-AzCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest010 -Name org001 -HealthProbeSetting $healthProbeParameters -Origin @(@{ Id = $origin.Id }) | Get-AzCdnOriginGroup
```

```output
Name   Location ResourceGroupName
----   -------- -----------------
org001          testps-rg-da16jm
```

Get an AzureCDN origin group under the AzureCDN endpoint via identity

## PARAMETERS

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

### -EndpointName
Name of the endpoint under the profile which is unique globally.

```yaml
Type: System.String
Parameter Sets: Get1, List1
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: GetViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the origin group which is unique within the endpoint.

```yaml
Type: System.String
Parameter Sets: Get1
Aliases: OriginGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
Name of the CDN profile which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: Get1, List1
Aliases:

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
Parameter Sets: Get1, List1
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
Parameter Sets: Get1, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IOriginGroup

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
  - `[ProfileName <String>]`: Name of the Azure Front Door Standard or Azure Front Door Premium profile which is unique within the resource group.
  - `[ResourceGroupName <String>]`: Name of the Resource group within the Azure subscription.
  - `[RouteName <String>]`: Name of the routing rule.
  - `[RuleName <String>]`: Name of the delivery rule which is unique within the endpoint.
  - `[RuleSetName <String>]`: Name of the rule set under the profile which is unique globally.
  - `[SecretName <String>]`: Name of the Secret under the profile.
  - `[SecurityPolicyName <String>]`: Name of the security policy under the profile.
  - `[SubscriptionId <String>]`: Azure Subscription ID.

## RELATED LINKS

