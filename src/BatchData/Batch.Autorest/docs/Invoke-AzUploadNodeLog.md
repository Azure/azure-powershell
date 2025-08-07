---
external help file:
Module Name: Az.Batch
online version: https://learn.microsoft.com/powershell/module/az.batch/invoke-azuploadnodelog
schema: 2.0.0
---

# Invoke-AzUploadNodeLog

## SYNOPSIS
This is for gathering Azure Batch service log files in an automated fashion\nfrom Compute Nodes if you are experiencing an error and wish to escalate to\nAzure support.
The Azure Batch service log files should be shared with Azure\nsupport to aid in debugging issues with the Batch service.

## SYNTAX

### UploadExpanded (Default)
```
Invoke-AzUploadNodeLog -Endpoint <String> -NodeId <String> -PoolId <String> -ContainerUrl <String>
 -StartTime <DateTime> [-TimeOut <Int32>] [-ClientRequestId <String>] [-Ocpdate <String>]
 [-ReturnClientRequestId] [-EndTime <DateTime>] [-IdentityReferenceResourceId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Upload
```
Invoke-AzUploadNodeLog -Endpoint <String> -NodeId <String> -PoolId <String>
 -UploadOption <IUploadBatchServiceLogsOptions> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UploadViaIdentity
```
Invoke-AzUploadNodeLog -Endpoint <String> -InputObject <IBatchIdentity>
 -UploadOption <IUploadBatchServiceLogsOptions> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UploadViaIdentityExpanded
```
Invoke-AzUploadNodeLog -Endpoint <String> -InputObject <IBatchIdentity> -ContainerUrl <String>
 -StartTime <DateTime> [-TimeOut <Int32>] [-ClientRequestId <String>] [-Ocpdate <String>]
 [-ReturnClientRequestId] [-EndTime <DateTime>] [-IdentityReferenceResourceId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UploadViaIdentityPool
```
Invoke-AzUploadNodeLog -Endpoint <String> -NodeId <String> -PoolInputObject <IBatchIdentity>
 -UploadOption <IUploadBatchServiceLogsOptions> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UploadViaIdentityPoolExpanded
```
Invoke-AzUploadNodeLog -Endpoint <String> -NodeId <String> -PoolInputObject <IBatchIdentity>
 -ContainerUrl <String> -StartTime <DateTime> [-TimeOut <Int32>] [-ClientRequestId <String>]
 [-Ocpdate <String>] [-ReturnClientRequestId] [-EndTime <DateTime>] [-IdentityReferenceResourceId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UploadViaJsonFilePath
```
Invoke-AzUploadNodeLog -Endpoint <String> -NodeId <String> -PoolId <String> -JsonFilePath <String>
 [-TimeOut <Int32>] [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UploadViaJsonString
```
Invoke-AzUploadNodeLog -Endpoint <String> -NodeId <String> -PoolId <String> -JsonString <String>
 [-TimeOut <Int32>] [-ClientRequestId <String>] [-Ocpdate <String>] [-ReturnClientRequestId]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This is for gathering Azure Batch service log files in an automated fashion\nfrom Compute Nodes if you are experiencing an error and wish to escalate to\nAzure support.
The Azure Batch service log files should be shared with Azure\nsupport to aid in debugging issues with the Batch service.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -ClientRequestId
The caller-generated request identity, in the form of a GUID with no decoration
such as curly braces, e.g.
9C4D50EE-2D56-4CD3-8152-34347DC9F2B0.

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

### -ContainerUrl
The URL of the container within Azure Blob Storage to which to upload the Batch Service log file(s).
If a user assigned managed identity is not being used, the URL must include a Shared Access Signature (SAS) granting write permissions to the container.
The SAS duration must allow enough time for the upload to finish.
The start time for SAS is optional and recommended to not be specified.

```yaml
Type: System.String
Parameter Sets: UploadExpanded, UploadViaIdentityExpanded, UploadViaIdentityPoolExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Endpoint
Batch account endpoint (for example: https://batchaccount.eastus2.batch.azure.com).

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

### -EndTime
The end of the time range from which to upload Batch Service log file(s).
Any log file containing a log message in the time range will be uploaded.
This means that the operation might retrieve more logs than have been requested since the entire log file is always uploaded, but the operation should not retrieve fewer logs than have been requested.
If omitted, the default is to upload all logs available after the startTime.

```yaml
Type: System.DateTime
Parameter Sets: UploadExpanded, UploadViaIdentityExpanded, UploadViaIdentityPoolExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityReferenceResourceId
The ARM resource id of the user assigned identity.

```yaml
Type: System.String
Parameter Sets: UploadExpanded, UploadViaIdentityExpanded, UploadViaIdentityPoolExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity
Parameter Sets: UploadViaIdentity, UploadViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Upload operation

```yaml
Type: System.String
Parameter Sets: UploadViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Upload operation

```yaml
Type: System.String
Parameter Sets: UploadViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeId
The ID of the Compute Node for which you want to get the Remote Desktop
Protocol file.

```yaml
Type: System.String
Parameter Sets: Upload, UploadExpanded, UploadViaIdentityPool, UploadViaIdentityPoolExpanded, UploadViaJsonFilePath, UploadViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ocpdate
The time the request was issued.
Client libraries typically set this to the
current system clock time; set it explicitly if you are calling the REST API
directly.

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

### -PoolId
The ID of the Pool that contains the Compute Node.

```yaml
Type: System.String
Parameter Sets: Upload, UploadExpanded, UploadViaJsonFilePath, UploadViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity
Parameter Sets: UploadViaIdentityPool, UploadViaIdentityPoolExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ReturnClientRequestId
Whether the server should return the client-request-id in the response.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTime
The start of the time range from which to upload Batch Service log file(s).
Any log file containing a log message in the time range will be uploaded.
This means that the operation might retrieve more logs than have been requested since the entire log file is always uploaded, but the operation should not retrieve fewer logs than have been requested.

```yaml
Type: System.DateTime
Parameter Sets: UploadExpanded, UploadViaIdentityExpanded, UploadViaIdentityPoolExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeOut
The maximum time that the server can spend processing the request, in seconds.
The default is 30 seconds.
If the value is larger than 30, the default will be used instead.".

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

### -UploadOption
The Azure Batch service log files upload parameters for a Compute Node.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IUploadBatchServiceLogsOptions
Parameter Sets: Upload, UploadViaIdentity, UploadViaIdentityPool
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IUploadBatchServiceLogsOptions

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IUploadBatchServiceLogsResult

## NOTES

## RELATED LINKS

