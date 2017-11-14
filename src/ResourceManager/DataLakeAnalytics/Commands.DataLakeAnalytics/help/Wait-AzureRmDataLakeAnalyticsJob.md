---
external help file: Microsoft.Azure.Commands.DataLakeAnalytics.dll-Help.xml
Module Name: AzureRM.DataLakeAnalytics
ms.assetid: CE7B54BC-C493-49CE-93BD-346ED0B966A1
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.datalakeanalytics/wait-azurermdatalakeanalyticsjob
schema: 2.0.0
---

# Wait-AzureRmDataLakeAnalyticsJob

## SYNOPSIS
Waits for a job to complete.

## SYNTAX

```
Wait-AzureRmDataLakeAnalyticsJob [-Account] <String> [-JobId] <Guid> [[-WaitIntervalInSeconds] <Int32>]
 [[-TimeoutInSeconds] <Int32>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Wait-AzureRmDataLakeAnalyticsJob** cmdlet waits for an Azure Data Lake Analytics job to complete.

## EXAMPLES

### Example 1: Wait for a job to complete
```
PS C:\>Wait-AzureRmDataLakeAnalyticsJob -Account "ContosoAdlAccount" -JobId "a0a78d72-3fa8-4564-9b18-6becb3fda48a"
```

The following command waits for the job with the specified ID to complete.

## PARAMETERS

### -Account
Specifies the Data Lake Analytics account name.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobId
Specifies the ID of the job for which to wait.

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -TimeoutInSeconds
Specifies the number of seconds to wait before exiting the wait operation.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WaitIntervalInSeconds
Specify the number of seconds that elapse between each check of the job state.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Guid
Parameter 'JobId' accepts value of type 'Guid' from the pipeline

## OUTPUTS

### JobInformation
The final job details for the completed job.

## NOTES

## RELATED LINKS

[Get-AzureRmDataLakeAnalyticsJob](./Get-AzureRmDataLakeAnalyticsJob.md)

[Stop-AzureRmDataLakeAnalyticsJob](./Stop-AzureRmDataLakeAnalyticsJob.md)

[Submit-AzureRmDataLakeAnalyticsJob](./Submit-AzureRmDataLakeAnalyticsJob.md)


