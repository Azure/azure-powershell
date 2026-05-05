---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/new-azfrontdoorcdnorigin
schema: 2.0.0
---

# New-AzFrontDoorCdnOrigin

## SYNOPSIS
Create a new origin within the specified origin group.

## SYNTAX

### CreateExpanded (Default)
```
New-AzFrontDoorCdnOrigin -OriginName <String> -OriginGroupName <String> -ProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-AzureOriginId <String>] [-EnabledState <String>]
 [-EnforceCertificateNameCheck] [-HostName <String>] [-HttpPort <Int32>] [-HttpsPort <Int32>]
 [-OriginHostHeader <String>] [-Priority <Int32>] [-PrivateLinkId <String>]
 [-SharedPrivateLinkResourceGroupId <String>] [-SharedPrivateLinkResourcePrivateLinkLocation <String>]
 [-SharedPrivateLinkResourceRequestMessage <String>] [-SharedPrivateLinkResourceStatus <String>]
 [-Weight <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzFrontDoorCdnOrigin -OriginName <String> -OriginGroupName <String> -ProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzFrontDoorCdnOrigin -OriginName <String> -OriginGroupName <String> -ProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityProfileExpanded
```
New-AzFrontDoorCdnOrigin -OriginName <String> -OriginGroupName <String> -ProfileInputObject <ICdnIdentity>
 [-AzureOriginId <String>] [-EnabledState <String>] [-EnforceCertificateNameCheck] [-HostName <String>]
 [-HttpPort <Int32>] [-HttpsPort <Int32>] [-OriginHostHeader <String>] [-Priority <Int32>]
 [-PrivateLinkId <String>] [-SharedPrivateLinkResourceGroupId <String>]
 [-SharedPrivateLinkResourcePrivateLinkLocation <String>] [-SharedPrivateLinkResourceRequestMessage <String>]
 [-SharedPrivateLinkResourceStatus <String>] [-Weight <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityProfile
```
New-AzFrontDoorCdnOrigin -OriginName <String> -OriginGroupName <String> -ProfileInputObject <ICdnIdentity>
 -Origin <IAfdOrigin> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityOriginGroupExpanded
```
New-AzFrontDoorCdnOrigin -OriginName <String> -OriginGroupInputObject <ICdnIdentity> [-AzureOriginId <String>]
 [-EnabledState <String>] [-EnforceCertificateNameCheck] [-HostName <String>] [-HttpPort <Int32>]
 [-HttpsPort <Int32>] [-OriginHostHeader <String>] [-Priority <Int32>] [-PrivateLinkId <String>]
 [-SharedPrivateLinkResourceGroupId <String>] [-SharedPrivateLinkResourcePrivateLinkLocation <String>]
 [-SharedPrivateLinkResourceRequestMessage <String>] [-SharedPrivateLinkResourceStatus <String>]
 [-Weight <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityOriginGroup
```
New-AzFrontDoorCdnOrigin -OriginName <String> -OriginGroupInputObject <ICdnIdentity> -Origin <IAfdOrigin>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a new origin within the specified origin group.

## EXAMPLES

### Example 1: Create an AzureFrontDoor origin under the AzureFrontDoor origin group
```powershell
New-AzFrontDoorCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001 -OriginName ori001 -OriginHostHeader en.wikipedia.org -HostName en.wikipedia.org -HttpPort 80 -HttpsPort 443 -Priority 1 -Weight 1000
```

```output
Name   ResourceGroupName
----   -----------------
ori001 testps-rg-da16jm
```

Create an AzureFrontDoor origin under the AzureFrontDoor origin group

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
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityOriginGroupExpanded
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityOriginGroupExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityOriginGroupExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityOriginGroupExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityOriginGroupExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityOriginGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -Origin
Azure Front Door origin is the source of the content being delivered via Azure Front Door.
When the edge nodes represented by an endpoint do not have the requested content cached, they attempt to fetch it from one or more of the configured origins.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IAfdOrigin
Parameter Sets: CreateViaIdentityProfile, CreateViaIdentityOriginGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OriginGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: CreateViaIdentityOriginGroupExpanded, CreateViaIdentityOriginGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OriginGroupName
Name of the origin group which is unique within the profile.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityProfileExpanded, CreateViaIdentityProfile
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
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityOriginGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OriginName
Name of the origin that is unique within the profile.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityOriginGroupExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityOriginGroupExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: CreateViaIdentityProfileExpanded, CreateViaIdentityProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProfileName
Name of the Azure Front Door Standard or Azure Front Door Premium which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityOriginGroupExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityOriginGroupExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityOriginGroupExpanded
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityOriginGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded, CreateViaIdentityOriginGroupExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IAfdOrigin

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IAfdOrigin

## NOTES

## RELATED LINKS
