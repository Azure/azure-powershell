---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/new-azcdnorigin
schema: 2.0.0
---

# New-AzCdnOrigin

## SYNOPSIS
Create a new origin within the specified endpoint.

## SYNTAX

### CreateExpanded (Default)
```
New-AzCdnOrigin -EndpointName <String> -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Enabled] [-HostName <String>] [-HttpPort <Int32>] [-HttpsPort <Int32>]
 [-OriginHostHeader <String>] [-Priority <Int32>] [-PrivateLinkAlias <String>]
 [-PrivateLinkApprovalMessage <String>] [-PrivateLinkLocation <String>] [-PrivateLinkResourceId <String>]
 [-Weight <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityEndpoint
```
New-AzCdnOrigin -EndpointInputObject <ICdnIdentity> -Name <String> -Origin <IOrigin>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityEndpointExpanded
```
New-AzCdnOrigin -EndpointInputObject <ICdnIdentity> -Name <String> [-Enabled] [-HostName <String>]
 [-HttpPort <Int32>] [-HttpsPort <Int32>] [-OriginHostHeader <String>] [-Priority <Int32>]
 [-PrivateLinkAlias <String>] [-PrivateLinkApprovalMessage <String>] [-PrivateLinkLocation <String>]
 [-PrivateLinkResourceId <String>] [-Weight <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityProfile
```
New-AzCdnOrigin -EndpointName <String> -Name <String> -ProfileInputObject <ICdnIdentity> -Origin <IOrigin>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityProfileExpanded
```
New-AzCdnOrigin -EndpointName <String> -Name <String> -ProfileInputObject <ICdnIdentity> [-Enabled]
 [-HostName <String>] [-HttpPort <Int32>] [-HttpsPort <Int32>] [-OriginHostHeader <String>]
 [-Priority <Int32>] [-PrivateLinkAlias <String>] [-PrivateLinkApprovalMessage <String>]
 [-PrivateLinkLocation <String>] [-PrivateLinkResourceId <String>] [-Weight <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzCdnOrigin -EndpointName <String> -Name <String> -ProfileName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzCdnOrigin -EndpointName <String> -Name <String> -ProfileName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new origin within the specified endpoint.

## EXAMPLES

### Example 1: Create an AzureCDN origin under the AzureCDN endpoint
```powershell
New-AzCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name origin1 -HostName "host1.hello.com" 
```

```output
Name    ResourceGroupName
----    -----------------
origin1 testps-rg-da16jm
```

Create an AzureCDN origin under the AzureCDN endpoint

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

### -Enabled
Origin is enabled for load balancing or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityEndpointExpanded, CreateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: CreateViaIdentityEndpoint, CreateViaIdentityEndpointExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EndpointName
Name of the endpoint under the profile which is unique globally.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProfile, CreateViaIdentityProfileExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
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
Parameter Sets: CreateExpanded, CreateViaIdentityEndpointExpanded, CreateViaIdentityProfileExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityEndpointExpanded, CreateViaIdentityProfileExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityEndpointExpanded, CreateViaIdentityProfileExpanded
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

### -Name
Name of the origin that is unique within the endpoint.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: OriginName

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
CDN origin is the source of the content being delivered via CDN.
When the edge nodes represented by an endpoint do not have the requested content cached, they attempt to fetch it from one or more of the configured origins.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IOrigin
Parameter Sets: CreateViaIdentityEndpoint, CreateViaIdentityProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OriginHostHeader
The host header value sent to the origin with each request.
If you leave this blank, the request hostname determines this value.
Azure CDN origins, such as Web Apps, Blob Storage, and Cloud Services require this host header value to match the origin hostname by default.
This overrides the host header defined at Endpoint

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEndpointExpanded, CreateViaIdentityProfileExpanded
Aliases:

Required: False
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
Parameter Sets: CreateExpanded, CreateViaIdentityEndpointExpanded, CreateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkAlias
The Alias of the Private Link resource.
Populating this optional field indicates that this origin is 'Private'

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEndpointExpanded, CreateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkApprovalMessage
A custom message to be included in the approval request to connect to the Private Link.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEndpointExpanded, CreateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkLocation
The location of the Private Link resource.
Required only if 'privateLinkResourceId' is populated

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEndpointExpanded, CreateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkResourceId
The Resource Id of the Private Link resource.
Populating this optional field indicates that this backend is 'Private'

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEndpointExpanded, CreateViaIdentityProfileExpanded
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
Parameter Sets: CreateViaIdentityProfile, CreateViaIdentityProfileExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProfileName
Name of the CDN profile which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaIdentityEndpointExpanded, CreateViaIdentityProfileExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IOrigin

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IOrigin

## NOTES

## RELATED LINKS

