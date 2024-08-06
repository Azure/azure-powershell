---
external help file:
Module Name: Az.ImportExport
online version: https://learn.microsoft.com/powershell/module/az.importexport/get-azimportexport
schema: 2.0.0
---

# Get-AzImportExport

## SYNOPSIS
Gets information about an existing job.

## SYNTAX

### List (Default)
```
Get-AzImportExport [-SubscriptionId <String[]>] [-Filter <String>] [-Top <Int64>] [-AcceptLanguage <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzImportExport -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-AcceptLanguage <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzImportExport -InputObject <IImportExportIdentity> [-AcceptLanguage <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzImportExport -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Filter <String>] [-Top <Int64>]
 [-AcceptLanguage <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets information about an existing job.

## EXAMPLES

### Example 1: Get ImportExport job with default context
```powershell
Get-AzImportExport
```

```output
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
```

This cmdlet gets ImportExport job with default context.

### Example 2: Get ImportExport job by resource group and job name
```powershell
Get-AzImportExport -Name test-job -ResourceGroupName ImportTestRG
```

```output
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
```

This cmdlet gets ImportExport job by resource group and job name.

### Example 3: Lists all the ImportExport jobs in specified resource group
```powershell
Get-AzImportExport -ResourceGroupName ImportTestRG
```

```output
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
```

This cmdlet lists all the ImportExport jobs in specified resource group.

### Example 4: Get ImportExport job by identity
```powershell
$Id = "/subscriptions/<SubscriptionId>/resourceGroups/ImportTestRG/providers/Microsoft.ImportExport/jobs/test-job"
Get-AzImportExport -InputObject $Id
```

```output
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
```

This cmdlet lists gets ImportExport job by identity.

## PARAMETERS

### -AcceptLanguage
Specifies the preferred language for the response.

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

### -Filter
Can be used to restrict the results to certain conditions.

```yaml
Type: System.String
Parameter Sets: List, List1
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IImportExportIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the import/export job.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: JobName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name uniquely identifies the resource group within the user subscription.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID for the Azure user.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
An integer value that specifies how many jobs at most should be returned.
The value cannot exceed 100.

```yaml
Type: System.Int64
Parameter Sets: List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.IImportExportIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api202101.IJobResponse

## NOTES

## RELATED LINKS

