---
external help file: Az.Peering-help.xml
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/get-azpeeringserviceprovider
schema: 2.0.0
---

# Get-AzPeeringServiceProvider

## SYNOPSIS
Lists all of the available peering service locations for the specified kind of peering.

## SYNTAX

```
Get-AzPeeringServiceProvider [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists all of the available peering service locations for the specified kind of peering.

## EXAMPLES

### Example 1: List all peering service providers
```powershell
Get-AzPeeringServiceProvider
```

```output
Name                                        PeeringLocation                            ServiceProviderName
----                                        ---------------                            -------------------
IIJ                                         {Osaka, Tokyo}                             IIJ
NTTCom                                      {Osaka, Tokyo}                             NTTCom
Kordia Limited                              {Auckland, Sydney}                         Kordia Limited
Liquid Telecommunications Ltd               {Cape Town, Johannesburg, Nairobi}         Liquid Telecommunications Ltd
InterCloud                                  {london, Paris, Zurich, Geneva}            InterCloud
Computer Concepts Limited                   {Auckland}                                 Computer Concepts Limited
Singnet                                     {singapore}                                Singnet
NTT Communications - Flexible InterConnect  {Osaka, Tokyo}                             NTT Communications - Flexible InterConnect
NAPAfrica                                   {Johannesburg, Cape Town}                  NAPAfrica
Vocusgroup NZ                               {Sydney, Auckland}                         Vocusgroup NZ
CMC NETWORKS                                {Johannesburg, Nairobi, cape Town}         CMC NETWORKS
MainOne                                     {Lisbon, Lagos}                            MainOne
Swisscom Switzerland Ltd                    {Geneva, Zurich}                           Swisscom Switzerland Ltd
DE-CIX                                      {Frankfurt, Marseille, Newark, Madrid…}    DE-CIX
Lumen Technologies                          {denver, los Angeles}                      Lumen Technologies
Colt Technology Services                    {Amsterdam, Barcelona, Berlin, Frankfurt…} Colt Technology Services
```

Lists all peering service providers

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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IPeeringServiceProvider

## NOTES

## RELATED LINKS
