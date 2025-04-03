---
external help file:
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/get-azpeeringreceivedroute
schema: 2.0.0
---

# Get-AzPeeringReceivedRoute

## SYNOPSIS
Lists the prefixes received over the specified peering under the given subscription and resource group.

## SYNTAX

```
Get-AzPeeringReceivedRoute -PeeringName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-AsPath <String>] [-OriginAsValidationState <String>] [-Prefix <String>] [-RpkiValidationState <String>]
 [-SkipToken <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the prefixes received over the specified peering under the given subscription and resource group.

## EXAMPLES

### Example 1: Get all received routes for a specific peering
```powershell
Get-AzPeeringReceivedRoute -PeeringName DemoPeering -ResourceGroupName DemoRG
```

```output
AsPath               NextHop       OriginAsValidationState Prefix         ReceivedTimestamp            RpkiValidationState TrustAnchor
------               -------       ----------------------- ------         -----------------            ------------------- -----------
7018 13335           12.90.152.69  Valid                   1.0.0.0/24     2022-12-05T11:51:51.2062620Z Valid               None
7018 13335           12.90.152.69  Valid                   1.1.1.0/24     2022-12-05T11:51:51.2062620Z Valid               None
7018 4837 4808       12.90.152.69  Valid                   1.119.192.0/21 2021-12-07T05:21:11.7043790Z Unknown             None
7018 4837 4808       12.90.152.69  Valid                   1.119.200.0/22 2021-12-07T05:21:11.7043790Z Unknown             None
7018 4837 4808 59034 12.90.152.69  Valid                   1.119.204.0/24 2021-12-07T05:21:13.7045170Z Unknown             None
7018 9680 9680 3462  12.90.152.69  Valid                   1.160.0.0/12   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.160.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.161.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.162.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.163.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 15169 396982    12.90.152.69  Unknown                 1.179.112.0/20 2021-12-07T05:21:16.7056160Z Unknown             None
7018 9680 9680 3462  12.90.152.69  Valid                   1.164.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.165.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.166.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.167.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
...
```

Gets all the received routes for a specific peering

### Example 2: Filter received routes based on optional parameters
```powershell
Get-AzPeeringReceivedRoute -PeeringName DemoPeering -ResourceGroupName DemoRG -AsPath "7018 9680 9680 3462"
```

```output
AsPath                          NextHop       OriginAsValidationState Prefix           ReceivedTimestamp            RpkiValidationState TrustAnchor
------                          -------       ----------------------- ------           -----------------            ------------------- -----------
7018 9680 9680 3462             12.90.152.69  Valid                   1.160.0.0/12     2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462             12.90.152.69  Valid                   1.160.0.0/16     2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462             12.90.152.69  Valid                   1.161.0.0/16     2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462             12.90.152.69  Valid                   1.162.0.0/16     2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462             12.90.152.69  Valid                   1.163.0.0/16     2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462             12.90.152.69  Valid                   1.164.0.0/16     2022-11-29T07:46:45.2062680Z Valid               None
...
```

Gets all received routes of a peering with a specific AsPath

## PARAMETERS

### -AsPath
The optional AS path that can be used to filter the routes.

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

### -OriginAsValidationState
The optional origin AS validation state that can be used to filter the routes.

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

### -PeeringName
The name of the peering.

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

### -Prefix
The optional prefix that can be used to filter the routes.

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

### -ResourceGroupName
The name of the resource group.

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

### -RpkiValidationState
The optional RPKI validation state that can be used to filter the routes.

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

### -SkipToken
The optional page continuation token that is used in the event of paginated result.

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

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IPeeringReceivedRoute

## NOTES

## RELATED LINKS

