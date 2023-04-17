---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/update-azfrontdoorcdnorigin
schema: 2.0.0
---

# Update-AzFrontDoorCdnOrigin

## SYNOPSIS
Updates an existing origin within an origin group.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzFrontDoorCdnOrigin -OriginGroupName <String> -OriginName <String> -ProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-AzureOriginId <String>]
 [-EnabledState <EnabledState>] [-EnforceCertificateNameCheck] [-HostName <String>] [-HttpPort <Int32>]
 [-HttpsPort <Int32>] [-OriginHostHeader <String>] [-Priority <Int32>] [-PrivateLinkId <String>]
 [-SharedPrivateLinkResourceGroupId <String>] [-SharedPrivateLinkResourcePrivateLinkLocation <String>]
 [-SharedPrivateLinkResourceRequestMessage <String>]
 [-SharedPrivateLinkResourceStatus <SharedPrivateLinkResourceStatus>] [-Weight <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzFrontDoorCdnOrigin -InputObject <ICdnIdentity> [-AzureOriginId <String>]
 [-EnabledState <EnabledState>] [-EnforceCertificateNameCheck] [-HostName <String>] [-HttpPort <Int32>]
 [-HttpsPort <Int32>] [-OriginHostHeader <String>] [-Priority <Int32>] [-PrivateLinkId <String>]
 [-SharedPrivateLinkResourceGroupId <String>] [-SharedPrivateLinkResourcePrivateLinkLocation <String>]
 [-SharedPrivateLinkResourceRequestMessage <String>]
 [-SharedPrivateLinkResourceStatus <SharedPrivateLinkResourceStatus>] [-Weight <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates an existing origin within an origin group.

## EXAMPLES

### Example 1: Update an AzureFrontDoor origin group under the profile
```powershell
Update-AzFrontDoorCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001 -OriginName ori001 -Weight 999
```

```output
Name   ResourceGroupName
----   -----------------
ori001 testps-rg-da16jm
```

Update an AzureFrontDoor origin group under the profile

### Example 2: Update an AzureFrontDoor origin group under the profile via identity
```powershell
Get-AzFrontDoorCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001 -OriginName ori001 | Update-AzFrontDoorCdnOrigin -Weight 999
```

```output
Name   ResourceGroupName
----   -----------------
ori001 testps-rg-da16jm
```

Update an AzureFrontDoor origin group under the profile via identity

## PARAMETERS

### -AsJob
Run the command as a job

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

### -AzureOriginId
Resource ID.

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

### -EnabledState
Whether to enable health probes to be made against backends defined under backendPools.
Health probes can only be disabled if there is a single enabled backend in single enabled backend pool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.EnabledState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnforceCertificateNameCheck
Whether to enable certificate name check at origin level

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

### -HostName
The address of the origin.
Domain names, IPv4 addresses, and IPv6 addresses are supported.This should be unique across all origins in an endpoint.

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

### -HttpPort
The value of the HTTP port.
Must be between 1 and 65535.

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

### -HttpsPort
The value of the HTTPS port.
Must be between 1 and 65535.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -OriginGroupName
Name of the origin group which is unique within the profile.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OriginHostHeader
The host header value sent to the origin with each request.
If you leave this blank, the request hostname determines this value.
Azure Front Door origins, such as Web Apps, Blob Storage, and Cloud Services require this host header value to match the origin hostname by default.
This overrides the host header defined at Endpoint

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

### -OriginName
Name of the origin which is unique within the profile.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Priority
Priority of origin in given origin group for load balancing.
Higher priorities will not be used for load balancing if any lower priority origin is healthy.Must be between 1 and 5

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

### -PrivateLinkId
Resource ID.

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

### -ProfileName
Name of the Azure Front Door Standard or Azure Front Door Premium profile which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedPrivateLinkResourceGroupId
The group id from the provider of resource the shared private link resource is for.

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

### -SharedPrivateLinkResourcePrivateLinkLocation
The location of the shared private link resource

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

### -SharedPrivateLinkResourceRequestMessage
The request message for requesting approval of the shared private link resource.

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

### -SharedPrivateLinkResourceStatus
Status of the shared private link resource.
Can be Pending, Approved, Rejected, Disconnected, or Timeout.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.SharedPrivateLinkResourceStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Weight
Weight of the origin in given origin group for load balancing.
Must be between 1 and 1000

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IAfdOrigin

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

