---
external help file: Az.HorizonDB-help.xml
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/get-azhorizondbcapability
schema: 2.0.0
---

# Get-AzHorizonDbCapability

## SYNOPSIS
Gets the singleton HorizonDB capability catalog entry available to a subscription in a specific region.

## SYNTAX

### Get (Default)
```
Get-AzHorizonDbCapability -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzHorizonDbCapability -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzHorizonDbCapability -InputObject <IHorizonDbIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the singleton HorizonDB capability catalog entry available to a subscription in a specific region.

## EXAMPLES

### Example 1: Get the capability catalog for a region
```powershell
Get-AzHorizonDbCapability -Location 'eastus2' | Format-List -Property Name, ClusterCapabilityRecommendedPostgreSqlVersion, ClusterCapabilitySupportedPostgreSqlVersion, ProvisioningState
```

```output
Name                                          : default
ClusterCapabilityRecommendedPostgreSqlVersion : 17
ClusterCapabilitySupportedPostgreSqlVersion   : {{
                                                  "name": "17",
                                                  "supportedVersionsToUpgrade": [ ]
                                                }, {
                                                  "name": "18",
                                                  "supportedVersionsToUpgrade": [ ]
                                                }}
ProvisioningState                             : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

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

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.ICapability

## NOTES

## RELATED LINKS
