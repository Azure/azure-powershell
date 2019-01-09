---
external help file: Microsoft.Azure.PowerShell.Cmdlets.LogicApp.dll-Help.xml
Module Name: Az.LogicApp
online version:
schema: 2.0.0
---

# Set-AzIntegrationAccountBatchConfiguration

## SYNOPSIS
Modifies an integration account batch configuration.

## SYNTAX

### ByIntegrationAccountAndParameters (Default)
```
Set-AzIntegrationAccountBatchConfiguration -ResourceGroupName <String> -ParentName <String> -Name <String>
 [-BatchGroupName <String>] [-MessageCount <Int32>] [-BatchSize <Int32>] [-ScheduleInterval <Int32>]
 [-ScheduleFrequency <String>] [-ScheduleTimeZone <String>] [-ScheduleStartTime <DateTime>]
 [-Metadata <Hashtable>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByIntegrationAccountAndJson
```
Set-AzIntegrationAccountBatchConfiguration -ResourceGroupName <String> -ParentName <String> -Name <String>
 -BatchConfigurationDefinition <String> [-Metadata <Hashtable>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByIntegrationAccountAndFilePath
```
Set-AzIntegrationAccountBatchConfiguration -ResourceGroupName <String> -ParentName <String> -Name <String>
 -BatchConfigurationFilePath <String> [-Metadata <Hashtable>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByInputObjectAndFilePath
```
Set-AzIntegrationAccountBatchConfiguration -BatchConfigurationFilePath <String> [-Metadata <Hashtable>]
 -InputObject <BatchConfiguration> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceIdAndFilePath
```
Set-AzIntegrationAccountBatchConfiguration -BatchConfigurationFilePath <String> [-Metadata <Hashtable>]
 -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByInputObjectAndJson
```
Set-AzIntegrationAccountBatchConfiguration -BatchConfigurationDefinition <String> [-Metadata <Hashtable>]
 -InputObject <BatchConfiguration> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceIdAndJson
```
Set-AzIntegrationAccountBatchConfiguration -BatchConfigurationDefinition <String> [-Metadata <Hashtable>]
 -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByInputObjectAndParameters
```
Set-AzIntegrationAccountBatchConfiguration [-BatchGroupName <String>] [-MessageCount <Int32>]
 [-BatchSize <Int32>] [-ScheduleInterval <Int32>] [-ScheduleFrequency <String>] [-ScheduleTimeZone <String>]
 [-ScheduleStartTime <DateTime>] [-Metadata <Hashtable>] -InputObject <BatchConfiguration>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceIdAndParameters
```
Set-AzIntegrationAccountBatchConfiguration [-BatchGroupName <String>] [-MessageCount <Int32>]
 [-BatchSize <Int32>] [-ScheduleInterval <Int32>] [-ScheduleFrequency <String>] [-ScheduleTimeZone <String>]
 [-ScheduleStartTime <DateTime>] [-Metadata <Hashtable>] -ResourceId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzIntegrationAccountBatchConfiguration** cmdlet modifies an integration account batch configuration.

## EXAMPLES

### Example 1: Modify a batch configuration using local file
```powershell
PS C:\> Set-AzIntegrationAccountBatchConfiguration -ResourceGroupName "sampleResourceGroup" -IntegrationAccountName "sampleIntegrationAccount" -BatchConfigurationName "sampleBatchConfiguration" -BatchConfigurationFilePath $batchConfigurationFilePath
```

Modify a batch configuration named "sampleBatchConfiguration" using the local file located at the file path contained in "$batchConfigurationFilePath".

### Example 2: Modify a batch configuration using a JSON string
```powershell
PS C:\> Set-AzIntegrationAccountBatchConfiguration -ResourceGroupName "sampleResourceGroup" -IntegrationAccountName "sampleIntegrationAccount" -BatchConfigurationName "sampleBatchConfiguration" -BatchConfigurationDefinition $batchConfigurationContent
```

Modify a batch configuration named "sampleBatchConfiguration" using the a JSON string contained in "$batchConfigurationContent".

### Example 3: Modify a batch configuration using parameters
```powershell
PS C:\> Set-AzIntegrationAccountBatchConfiguration -ResourceGroupName "sampleResourceGroup" -IntegrationAccountName "sampleIntegrationAccount" -BatchConfigurationName "sampleBatchConfiguration" -MessageCount 199 -BatchSize 5 -ScheduleInterval 1 -ScheduleFrequency "Month"
```

Modify a batch configuration named "sampleBatchConfiguration" by manually providing all of the nessecary parameters.

## PARAMETERS

### -BatchConfigurationDefinition
The integration account batch configuration definition.

```yaml
Type: System.String
Parameter Sets: ByIntegrationAccountAndJson, ByInputObjectAndJson, ByResourceIdAndJson
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
Parameter Sets: ByIntegrationAccountAndFilePath, ByInputObjectAndFilePath, ByResourceIdAndFilePath
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
Parameter Sets: ByIntegrationAccountAndParameters, ByInputObjectAndParameters, ByResourceIdAndParameters
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
Parameter Sets: ByIntegrationAccountAndParameters, ByInputObjectAndParameters, ByResourceIdAndParameters
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
Aliases: AzContext, AzureRmContext, AzureCredential

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
Parameter Sets: ByInputObjectAndFilePath, ByInputObjectAndJson, ByInputObjectAndParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MessageCount
The integration account batch configuration message count.

```yaml
Type: System.Int32
Parameter Sets: ByIntegrationAccountAndParameters, ByInputObjectAndParameters, ByResourceIdAndParameters
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
Type: System.Collections.Hashtable
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
Parameter Sets: ByIntegrationAccountAndParameters, ByIntegrationAccountAndJson, ByIntegrationAccountAndFilePath
Aliases: BatchConfigurationName, ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentName
The integration account name.

```yaml
Type: System.String
Parameter Sets: ByIntegrationAccountAndParameters, ByIntegrationAccountAndJson, ByIntegrationAccountAndFilePath
Aliases: IntegrationAccountName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ByIntegrationAccountAndParameters, ByIntegrationAccountAndJson, ByIntegrationAccountAndFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The integration account batch configuration resource id.

```yaml
Type: System.String
Parameter Sets: ByResourceIdAndFilePath, ByResourceIdAndJson, ByResourceIdAndParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ScheduleFrequency
The integration account batch configuration schedule frequency.

```yaml
Type: System.String
Parameter Sets: ByIntegrationAccountAndParameters, ByInputObjectAndParameters, ByResourceIdAndParameters
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
Parameter Sets: ByIntegrationAccountAndParameters, ByInputObjectAndParameters, ByResourceIdAndParameters
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
Type: System.Nullable`1[System.DateTime]
Parameter Sets: ByIntegrationAccountAndParameters, ByInputObjectAndParameters, ByResourceIdAndParameters
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
Parameter Sets: ByIntegrationAccountAndParameters, ByInputObjectAndParameters, ByResourceIdAndParameters
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

### Microsoft.Azure.Management.Logic.Models.BatchConfiguration

### System.String

## OUTPUTS

### Microsoft.Azure.Management.Logic.Models.BatchConfiguration

## NOTES

## RELATED LINKS
