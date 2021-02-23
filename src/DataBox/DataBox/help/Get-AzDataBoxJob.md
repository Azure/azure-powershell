---
external help file: Microsoft.Azure.PowerShell.Cmdlets.DataBox.dll-Help.xml
Module Name: Az.DataBox
online version: https://docs.microsoft.com/powershell/module/az.databox/get-azdataboxjob
schema: 2.0.0
---

# Get-AzDataBoxJob

## SYNOPSIS
Gets information about Databox Jobs

## SYNTAX

### ListParameterSet (Default)
```
Get-AzDataBoxJob [-ResourceGroupName <String>] [-Completed] [-CompletedWithError] [-Cancelled] [-Aborted]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByNameParameterSet
```
Get-AzDataBoxJob -ResourceGroupName <String> -Name <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzDataBoxJob -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzDataBoxJobs** cmdlet gets information about databox jobs in an Azure subscription.
If you specify the Resource Group, this cmdlet gets all the databox jobs under that resource group. If you specify the Name of the job along with the resource group name, this cmdlet gets information about that specific databox job.
If you do not specify anything other than subscription id, this cmdlet gets information about all of the databox jobs under that subscription.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzDataBoxJob

jobResource.Name        jobResource.Sku.Name jobResource.Status  jobResource.StartTime jobResource.Location ResourceGroup
----------------        -------------------- ------------------  --------------------- -------------------- -------------
testtip2                DataBox              Cancelled           10-09-2018 06:34:53   westus               TestRg1
cleanbox                DataBox              Aborted             04-12-2018 16:07:41   westus               TestRg2
cleanbox-Clone          DataBox              Cancelled           25-04-2019 11:31:36   westus               TestRg2
.
.
.
```

Get-AzDataBoxJob without any parameter fetches all the databox jobs under the subscription

### Example 2
```powershell
PS C:\> Get-AzDataBoxJob -ResourceGroupName TestRg1

jobResource.Name        jobResource.Sku.Name jobResource.Status  jobResource.StartTime jobResource.Location ResourceGroup
----------------        -------------------- ------------------  --------------------- -------------------- -------------
testtip2                DataBox              Cancelled           10-09-2018 06:34:53   westus               TestRg1
.
.
.
```

Get-AzDataBoxJob with ResourceGroupName parameter fetches all the databox jobs under the specified resource group

### Example 3
```powershell
PS C:\> Get-AzDataBoxJob -ResourceGroupName TestRg1 -Name testtip2

jobResource.Name        jobResource.Sku.Name jobResource.Status  jobResource.StartTime jobResource.Location ResourceGroup
----------------        -------------------- ------------------  --------------------- -------------------- -------------
testtip2                DataBox              Cancelled           10-09-2018 06:34:53   westus               TestRg1

```

Get-AzDataBoxJob with ResourceGroupName and Name specified will fetch that specific databox job

### Example 4
```powershell
PS C:\> Get-AzDataBoxJob -ResourceId "/subscriptions/05b5dd1c-793d-41de-be9f-6f9ed142f695/resourceGroups/TestRg1/providers/Microsoft.DataBox/jobs/testtip2"

jobResource.Name        jobResource.Sku.Name jobResource.Status  jobResource.StartTime jobResource.Location ResourceGroup
----------------        -------------------- ------------------  --------------------- -------------------- -------------
testtip2                DataBox              Cancelled           10-09-2018 06:34:53   westus               TestRg1

```

Get-AzDataBoxJob with ResourceId specified will fetch that specific databox job

## PARAMETERS

### -Aborted
Switch Parameter to fetch Aborted jobs

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Cancelled
Switch Parameter to fetch Cancelled jobs

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Completed
Switch Parameter to fetch Completed jobs

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompletedWithError
Switch Parameter to fetch jobs completed with errors

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListParameterSet
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

### -Name
Databox Job Name

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Databox Job Resource Group Name

```yaml
Type: System.String
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Databox Job Resource Id

```yaml
Type: System.String
Parameter Sets: GetByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.PSDataBoxJob

## NOTES

## RELATED LINKS
