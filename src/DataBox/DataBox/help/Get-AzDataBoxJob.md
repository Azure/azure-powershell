---
external help file:
Module Name: Az.DataBox
online version: https://learn.microsoft.com/powershell/module/az.databox/get-azdataboxjob
schema: 2.0.0
---

# Get-AzDataBoxJob

## SYNOPSIS
Gets information about the specified job.

## SYNTAX

### List (Default)
```
Get-AzDataBoxJob [-SubscriptionId <String[]>] [-SkipToken <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDataBoxJob -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Expand <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzDataBoxJob -ResourceGroupName <String> [-SubscriptionId <String[]>] [-SkipToken <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets information about the specified job.

## EXAMPLES

### Example 1: Gets a particular job 
```powershell
Get-AzDataBoxJob -Name "Powershell10" -ResourceGroupName "resourceGroupName"  -SubscriptionId "SubscriptionId"
```

```output
Name         Location Status        TransferType  SkuName IdentityType DeliveryType Detail
----         -------- ------        ------------  ------- ------------ ------------ ------
Powershell10 WestUS   DeviceOrdered ImportToAzure DataBox None         NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

Gets a particular job

### Example 2: List all job under a subscription 
```powershell
Get-AzDataBoxJob -SubscriptionId "SubscriptionId"
```

```output
Name        Location      Status        TransferType    SkuName    IdentityType  DeliveryType Detail
----        --------      ------        ------------    -------    ------------  ------------ ------
brtestdbd  brazilsouth   DeviceOrdered ImportToAzure   DataBoxDisk None          NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxDiskJobDetails
testorder  uksouth       Cancelled     ImportToAzure   DataBoxDisk None          NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxDiskJobDetails
```

List all job under a subscription

### Example 3: List all job under a resourcegroup 
```powershell
Get-AzDataBoxJob -ResourceGroupName "resourceGroupName"
```

```output
Name                   Location Status        TransferType    SkuName IdentityType   DeliveryType Detail
----                   -------- ------        ------------    ------- ------------   ------------ ------
abcbnkndnkndn          westus   DeviceOrdered ImportToAzure   DataBox None           NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
abcbnkndnkndn-Clone    westus   DeviceOrdered ImportToAzure   DataBox None           NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
abcOrder               westus   Cancelled     ImportToAzure   DataBox None           NonScheduled Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxJobDetails
```

List all job under a resource group

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

### -Expand
$expand is supported on details parameter for job, which provides details on the job stages.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the job Resource within the specified resource group.
job names must be between 3 and 24 characters in length and use any alphanumeric and underscore only

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
The Resource Group Name

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

### -SkipToken
$skipToken is supported on Get list of jobs, which provides the next page in the list of jobs.

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

### -SubscriptionId
The Subscription Id

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20221201.IJobResource

## NOTES

ALIASES

## RELATED LINKS

