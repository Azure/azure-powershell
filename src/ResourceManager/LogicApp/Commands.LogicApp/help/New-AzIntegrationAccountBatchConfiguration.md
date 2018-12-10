---
external help file: Microsoft.Azure.Commands.LogicApp.dll-Help.xml
Module Name: Az.LogicApp
online version:
schema: 2.0.0
---

# New-AzIntegrationAccountBatchConfiguration

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### ByIntegrationAccount (Default)
```
New-AzIntegrationAccountBatchConfiguration [-ResourceGroupName <String>] [-ParentName <String>]
 [-Name <String>] [-BatchGroupName <String>] [-MessageCount <Int32>] [-BatchSize <Int32>]
 [-ScheduleInterval <Int32>] [-ScheduleFrequency <String>] [-ScheduleTimeZone <String>]
 [-ScheduleStartTime <String>] [-Metadata <JObject>] [-InputObject <BatchConfiguration>] [-ResourceId <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByFilePath
```
New-AzIntegrationAccountBatchConfiguration [-ResourceGroupName <String>] [-ParentName <String>]
 [-Name <String>] -BatchConfigurationFilePath <String> [-BatchGroupName <String>] [-MessageCount <Int32>]
 [-BatchSize <Int32>] [-ScheduleInterval <Int32>] [-ScheduleFrequency <String>] [-ScheduleTimeZone <String>]
 [-ScheduleStartTime <String>] [-Metadata <JObject>] [-InputObject <BatchConfiguration>] [-ResourceId <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByJson
```
New-AzIntegrationAccountBatchConfiguration [-ResourceGroupName <String>] [-ParentName <String>]
 [-Name <String>] -BatchConfigurationDefinition <String> [-BatchGroupName <String>] [-MessageCount <Int32>]
 [-BatchSize <Int32>] [-ScheduleInterval <Int32>] [-ScheduleFrequency <String>] [-ScheduleTimeZone <String>]
 [-ScheduleStartTime <String>] [-Metadata <JObject>] [-InputObject <BatchConfiguration>] [-ResourceId <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -BatchConfigurationDefinition
The integration account batch configuration definition.

```yaml
Type: System.String
Parameter Sets: ByJson
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BatchConfigurationFilePath
The integration account batch configuration file path.

```yaml
Type: System.String
Parameter Sets: ByFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BatchGroupName
The integration account batch configuration group name.

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

### -BatchSize
The integration account batch configuration batch size.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
An integration account batch configuration.

```yaml
Type: Microsoft.Azure.Management.Logic.Models.BatchConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MessageCount
The integration account batch configuration message count.

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

### -Metadata
The integration account batch configuration metadata.

```yaml
Type: Newtonsoft.Json.Linq.JObject
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The integration account batch configuration name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: BatchConfigurationName, ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ParentName
The integration account name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: IntegrationAccountName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The integration account resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The integration account batch configuration resource id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ScheduleFrequency
The integration account batch configuration schedule frequency.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Month, Week, Day, Hour, Minute, Second

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleInterval
The integration account batch configuration schedule interval.

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

### -ScheduleStartTime
The integration account batch configuration schedule start time.

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

### -ScheduleTimeZone
The integration account batch configuration schedule time zone.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Management.Logic.Models.BatchConfiguration

## OUTPUTS

### Microsoft.Azure.Management.Logic.Models.BatchConfiguration

## NOTES

## RELATED LINKS
