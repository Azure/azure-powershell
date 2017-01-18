---
external help file: Microsoft.Azure.Commands.DataLakeAnalytics.dll-Help.xml
ms.assetid: A0293D80-5935-4D2C-AF11-2837FEC95760
online version: 
schema: 2.0.0
---

# Get-AzureRmDataLakeAnalyticsJob

## SYNOPSIS
Gets a Data Lake Analytics job.

## SYNTAX

### All In Resource Group and Account (Default)
```
Get-AzureRmDataLakeAnalyticsJob [-Account] <String> [[-Name] <String>] [[-Submitter] <String>]
 [[-SubmittedAfter] <DateTimeOffset>] [[-SubmittedBefore] <DateTimeOffset>] [[-State] <JobState[]>]
 [[-Result] <JobResult[]>] [-Top <Int32>] [<CommonParameters>]
```

### Specific JobInformation
```
Get-AzureRmDataLakeAnalyticsJob [-Account] <String> [-JobId] <Guid> [[-Include] <ExtendedJobData>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmDataLakeAnalyticsJob** cmdlet gets an Azure Data Lake Analytics job.
If you do not specify a job, this cmdlet gets all jobs.

## EXAMPLES

### Example 1: Get a specified job
```
PS C:\>Get-AzureRmDataLakeAnalyticsJob -Account "contosoadla" -JobId $JobID01
```

This command gets the job with the specified ID.

### Example 2: Get jobs submitted in the past week
```
PS C:\>Get-AzureRmDataLakeAnalyticsJob -Account "contosoadla" -SubmittedAfter (Get-Date).AddDays(-7)
```

This command gets jobs submitted in the past week.

## PARAMETERS

### -Account
Specifies the name of a Data Lake Analytics account.

```yaml
Type: String
Parameter Sets: (All)
Aliases: AccountName

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Include
Specifies options that indicate the type of additional information to retrieve about the job.
The acceptable values for this parameter are:

- None
- DebugInfo
- Statistics
- All

```yaml
Type: ExtendedJobData
Parameter Sets: Specific JobInformation
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -JobId
Specifies the ID of the job to get.

```yaml
Type: Guid
Parameter Sets: Specific JobInformation
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Name
Specifies a name to use to filter the job list results.
The acceptable values for this parameter are:

- None
- DebugInfo
- Statistics
- All

```yaml
Type: String
Parameter Sets: All In Resource Group and Account
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Result
Specifies a result filter for the job results.
The acceptable values for this parameter are:

- None
- Cancelled
- Failed
- Succeeded

```yaml
Type: JobResult[]
Parameter Sets: All In Resource Group and Account
Aliases: 

Required: False
Position: 6
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -State
Specifies a state filter for the job results.
The acceptable values for this parameter are:

- Accepted
- New
- Compiling
- Scheduling
- Queued
- Starting
- Paused
- Running
- Ended

```yaml
Type: JobState[]
Parameter Sets: All In Resource Group and Account
Aliases: 

Required: False
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubmittedAfter
Specifies a date filter.
Use this parameter to filter the job list result to jobs submitted after the specified date.

```yaml
Type: DateTimeOffset
Parameter Sets: All In Resource Group and Account
Aliases: 

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubmittedBefore
Specifies a date filter.
Use this parameter to filter the job list result to jobs submitted before the specified date.

```yaml
Type: DateTimeOffset
Parameter Sets: All In Resource Group and Account
Aliases: 

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Submitter
Specifies the email address of a user.
Use this parameter to filter the job list results to jobs submitted by a specified user.

```yaml
Type: String
Parameter Sets: All In Resource Group and Account
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Top
An optional value which indicates the number of jobs to return. Default value is 500```yaml
Type: Int32
Parameter Sets: All In Resource Group and Account
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### JobInformation
The specified job information details

### List<JobInformation>
The list of jobs in the specified Data Lake Analytics account.

## NOTES

## RELATED LINKS

[Stop-AzureRmDataLakeAnalyticsJob](./Stop-AzureRmDataLakeAnalyticsJob.md)

[Submit-AzureRmDataLakeAnalyticsJob](./Submit-AzureRmDataLakeAnalyticsJob.md)

[Wait-AzureRmDataLakeAnalyticsJob](./Wait-AzureRmDataLakeAnalyticsJob.md)


