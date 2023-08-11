---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/Az.SecurityInsights/new-azsentinelanomalysecuritymlanalyticssettingsobject
schema: 2.0.0
---

# New-AzSentinelAnomalySecurityMlAnalyticsSettingsObject

## SYNOPSIS
Create an in-memory object for AnomalySecurityMlAnalyticsSettings.

## SYNTAX

```
New-AzSentinelAnomalySecurityMlAnalyticsSettingsObject [-AnomalySettingsVersion <Int32>]
 [-AnomalyVersion <String>]
 [-CustomizableObservation <IAnomalySecurityMlAnalyticsSettingsPropertiesCustomizableObservations>]
 [-Description <String>] [-DisplayName <String>] [-Enabled <Boolean>] [-Etag <String>] [-Frequency <TimeSpan>]
 [-IsDefaultSetting <Boolean>] [-RequiredDataConnector <ISecurityMlAnalyticsSettingsDataSource[]>]
 [-SettingsDefinitionId <String>] [-SettingsStatus <String>] [-Tactic <String[]>] [-Technique <String[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AnomalySecurityMlAnalyticsSettings.

## EXAMPLES

### Example 1: Create an Anomaly SecurityMlAnalyticsSettings Object
```powershell
$setting = New-AzSentinelAnomalySecurityMlAnalyticsSettingsObject -AnomalyVersion 1.0.5 -Enabled $false -DisplayName "Login from unusual region" -Frequency (New-TimeSpan -Hours 1) -SettingsStatus Production -IsDefaultSetting $true -SettingsDefinitionId "f209187f-1d17-4431-94af-c141bf5f23db"
```

```output
AnomalySettingsVersion       : 
AnomalyVersion               : 1.0.5
CustomizableObservation      : {
                               }
Description                  : 
DisplayName                  : Login from unusual region
Enabled                      : False
Etag                         : 
Frequency                    : 01:00:00
Id                           : 
IsDefaultSetting             : True
Kind                         : Anomaly
LastModifiedUtc              : 
Name                         : 
RequiredDataConnector        : 
SettingsDefinitionId         : f209187f-1d17-4431-94af-c141bf5f23db
SettingsStatus               : Production
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tactic                       : 
Technique                    : 
Type                         : 
```

This command creates a Anomaly SecurityMlAnalyticsSettings Object

## PARAMETERS

### -AnomalySettingsVersion
The anomaly settings version of the Anomaly security ml analytics settings that dictates whether job version gets updated or not.

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

### -AnomalyVersion
The anomaly version of the AnomalySecurityMLAnalyticsSettings.

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

### -CustomizableObservation
The customizable observations of the AnomalySecurityMLAnalyticsSettings.
To construct, see NOTES section for CUSTOMIZABLEOBSERVATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IAnomalySecurityMlAnalyticsSettingsPropertiesCustomizableObservations
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
The description of the SecurityMLAnalyticsSettings.

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

### -DisplayName
The display name for settings created by this SecurityMLAnalyticsSettings.

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

### -Enabled
Determines whether this settings is enabled or disabled.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Etag
Etag of the azure resource.

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

### -Frequency
The frequency that this SecurityMLAnalyticsSettings will be run.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsDefaultSetting
Determines whether this anomaly security ml analytics settings is a default settings.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequiredDataConnector
The required data sources for this SecurityMLAnalyticsSettings.
To construct, see NOTES section for REQUIREDDATACONNECTOR properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityMlAnalyticsSettingsDataSource[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SettingsDefinitionId
The anomaly settings definition Id.

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

### -SettingsStatus
The anomaly SecurityMLAnalyticsSettings status.

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

### -Tactic
The tactics of the SecurityMLAnalyticsSettings.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Technique
The techniques of the SecurityMLAnalyticsSettings.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.AnomalySecurityMlAnalyticsSettings

## NOTES

## RELATED LINKS

