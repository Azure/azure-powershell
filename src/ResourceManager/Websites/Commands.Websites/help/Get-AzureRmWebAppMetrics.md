---
external help file: Microsoft.Azure.Commands.Websites.dll-Help.xml
ms.assetid: 513BE097-EB4A-4C49-9F7F-42A2BED09022
online version: 
schema: 2.0.0
---

# Get-AzureRmWebAppMetrics

## SYNOPSIS
Gets Azure Web App metrics.

## SYNTAX

### S1
```
Get-AzureRmWebAppMetrics [-Metrics] <String[]> [-StartTime] <DateTime> [[-EndTime] <DateTime>]
 [-Granularity] <String> [-InstanceDetails] [-ResourceGroupName] <String> [-Name] <String>
```

### S2
```
Get-AzureRmWebAppMetrics [-Metrics] <String[]> [-StartTime] <DateTime> [[-EndTime] <DateTime>]
 [-Granularity] <String> [-InstanceDetails] [-WebApp] <Site>
```

## DESCRIPTION
The **Get-AzureRmWebAppMetrics** gets Web App metrics.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmAppServicePlanMetrics -ResourceGroupName "Default-Web-WestUS" -Name "ContosoWebApp" -StartTime 2016-11-30T22:00:00Z -EndTime 2016-11-30T22:30:00Z -Granularity PT1M -Metrics ["Requests"]
```

This command gets Requests of the Web App ContosoWebApp 
    per minute(PT1M - Poll Time 1 minute) between StartTime and EndTime

## PARAMETERS

### -EndTime
End Time in UTC

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases: 

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Granularity
Granularity

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceDetails
Instance Details

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metrics
Metrics as a string array

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
WebApp Name

```yaml
Type: String
Parameter Sets: S1
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: String
Parameter Sets: S1
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTime
Start Time in UTC

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebApp
WebApp object

```yaml
Type: Site
Parameter Sets: S2
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmWebAppCertificate](./Get-AzureRmWebAppCertificate.md)

