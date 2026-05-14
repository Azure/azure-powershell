---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/get-azcdnendpoint
schema: 2.0.0
---

# Get-AzCdnEndpoint

## SYNOPSIS
Gets an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.

## SYNTAX

### List (Default)
```
Get-AzCdnEndpoint -ProfileName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzCdnEndpoint -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzCdnEndpoint -InputObject <ICdnIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityProfile
```
Get-AzCdnEndpoint -Name <String> -ProfileInputObject <ICdnIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.

## EXAMPLES

### Example 1: List AzureCDN Endpoints under the AzureCDN profile
```powershell
Get-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
WestUs   endptest001 testps-rg-da16jm
WestUs   endptest002 testps-rg-da16jm
```

List AzureCDN Endpoints under the AzureCDN profile

### Example 2: Get an AzureCDN Endpoint under the AzureCDN profile
```powershell
Get-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -Name endptest001
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
WestUs   endptest001 testps-rg-da16jm
```

Get an AzureCDN Endpoint under the AzureCDN profile

### Example 3: Get an AzureCDN Endpoint under the AzureCDN profile via identity
```powershell
$origin = @{
    Name = "origin1"
    HostName = "host1.hello.com"
};

New-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -Name endptest010 -Location global -Origin $origin | Get-AzCdnEndpoint
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
Global   endptest010 testps-rg-da16jm
```

Get an AzureCDN Endpoint under the AzureCDN profile via identity

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

### -InputObject
Identity Parameter

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
Name of the endpoint under the profile which is unique globally.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityProfile
Aliases: EndpointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: GetViaIdentityProfile
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IEndpoint

## NOTES

## RELATED LINKS

