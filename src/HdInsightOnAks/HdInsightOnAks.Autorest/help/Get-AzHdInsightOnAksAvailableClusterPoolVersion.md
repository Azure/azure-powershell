---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/get-azhdinsightonaksavailableclusterpoolversion
schema: 2.0.0
---

# Get-AzHdInsightOnAksAvailableClusterPoolVersion

## SYNOPSIS
Returns a list of available cluster pool versions.

## SYNTAX

```
Get-AzHdInsightOnAksAvailableClusterPoolVersion -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns a list of available cluster pool versions.

## EXAMPLES

### Example 1: Returns all cluster pool versions in a region.
```powershell
$location = "west us 2"
Get-AzHdInsightOnAksAvailableClusterPoolVersion -Location $location
```

```output
AksVersion                   : 1.26
ClusterPoolVersionValue      : 1.0
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.HDInsight/locations/west us 2/
                               availableclusterpoolversions/1.0
IsPreview                    : False
Name                         : 1.0
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.SystemData
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         :
```

Get all available cluster pool versions in West US 2

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

### -Location
The name of the Azure region.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPoolVersion

## NOTES

## RELATED LINKS

