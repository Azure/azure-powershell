---
external help file: Az.StreamAnalytics-help.xml
Module Name: Az.StreamAnalytics
online version: https://learn.microsoft.com/powershell/module/az.streamanalytics/get-azstreamanalyticstransformation
schema: 2.0.0
---

# Get-AzStreamAnalyticsTransformation

## SYNOPSIS
Gets details about the specified transformation.

## SYNTAX

### Get (Default)
```
Get-AzStreamAnalyticsTransformation -JobName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStreamAnalyticsTransformation -InputObject <IStreamAnalyticsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets details about the specified transformation.

## EXAMPLES

### Example 1: Get information about a Stream Analytics transformation
```powershell
Get-AzStreamAnalyticsTransformation -ResourceGroupName azure-rg-test -JobName sajob-01-pwsh -Name tranf-01
```

```output
Name     Type                                                    ETag
----     ----                                                    ----
tranf-01 Microsoft.StreamAnalytics/streamingjobs/transformations ec0c7238-6bb2-4dad-b2cf-04c6a9285f4d
```

This command returns information about the transformation on the job.

### Example 2: Get information about a Stream Analytics transformation by pipeline
```powershell
New-AzStreamAnalyticsTransformation -ResourceGroupName azure-rg-test -JobName sajob-01-portal -Name tranf-01 -StreamingUnit 6 -Query "Select Id, Name from input-01" | Get-AzStreamAnalyticsTransformation
```

```output
Name     Type                                                    ETag
----     ----                                                    ----
tranf-01 Microsoft.StreamAnalytics/streamingjobs/transformations ec0c7238-6bb2-4dad-b2cf-04c6a9285f4d
```

This command returns information about the transformation on the job.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JobName
The name of the streaming job.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the transformation.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: TransformationName

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
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformation

## NOTES

## RELATED LINKS
