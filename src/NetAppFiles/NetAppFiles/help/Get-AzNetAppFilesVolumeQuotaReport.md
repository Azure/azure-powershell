---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/get-aznetappfilesvolumequotareport
schema: 2.0.0
---

# Get-AzNetAppFilesVolumeQuotaReport

## SYNOPSIS
Gets a quota report for an Azure NetApp Files (ANF) volume.

## SYNTAX

### ByFieldsParameterSet (Default)
```
Get-AzNetAppFilesVolumeQuotaReport -ResourceGroupName <String> -AccountName <String> -PoolName <String>
 -Name <String> [-QuotaType <String>] [-QuotaTarget <String>] [-UsageThresholdPercentage <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Get-AzNetAppFilesVolumeQuotaReport -Name <String> [-QuotaType <String>] [-QuotaTarget <String>]
 [-UsageThresholdPercentage <Int32>] -PoolObject <PSNetAppFilesPool> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Get-AzNetAppFilesVolumeQuotaReport [-QuotaType <String>] [-QuotaTarget <String>]
 [-UsageThresholdPercentage <Int32>] -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByObjectParameterSet
```
Get-AzNetAppFilesVolumeQuotaReport [-QuotaType <String>] [-QuotaTarget <String>]
 [-UsageThresholdPercentage <Int32>] -InputObject <PSNetAppFilesVolume>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetAppFilesVolumeQuotaReport** cmdlet gets a quota report for an ANF volume. The report includes quota usage information for users and groups. You can optionally filter the results by QuotaType, QuotaTarget, and UsageThresholdPercentage.

## EXAMPLES

### Example 1: Get a quota report for a volume
```powershell
Get-AzNetAppFilesVolumeQuotaReport -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -Name "MyAnfVolume"
```

This command gets the quota report for the volume "MyAnfVolume".

### Example 2: Get a quota report filtered by quota type
```powershell
Get-AzNetAppFilesVolumeQuotaReport -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -Name "MyAnfVolume" -QuotaType "IndividualUserQuota" -QuotaTarget "1001"
```

This command gets the quota report for the volume "MyAnfVolume" filtered to show only individual user quotas for the user with ID "1001".

### Example 3: Get a quota report for users exceeding a usage threshold
```powershell
Get-AzNetAppFilesVolumeQuotaReport -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -Name "MyAnfVolume" -UsageThresholdPercentage 80
```

This command gets the quota report for the volume "MyAnfVolume" returning only records where usage is at or above 80%.

## PARAMETERS

### -AccountName
The name of the ANF account

```yaml
Type: String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The volume object to return the quota report for

```yaml
Type: PSNetAppFilesVolume
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the ANF volume

```yaml
Type: String
Parameter Sets: ByFieldsParameterSet, ByParentObjectParameterSet
Aliases: VolumeName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolName
The name of the ANF pool

```yaml
Type: String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolObject
The pool object containing the volume to return the quota report for

```yaml
Type: PSNetAppFilesPool
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -QuotaTarget
UserID/GroupID/SID based on the quota target type.
If provided, QuotaType must also be specified.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QuotaType
Type of quota.
If provided, QuotaTarget must also be specified.
Possible values include: 'DefaultUserQuota', 'DefaultGroupQuota', 'IndividualUserQuota', 'IndividualGroupQuota'

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group of the ANF volume

```yaml
Type: String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of the ANF volume

```yaml
Type: String
Parameter Sets: ByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UsageThresholdPercentage
Returns records where the usage is greater than or equal to this percentage value (1-100).

```yaml
Type: Int32
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

### System.String

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesPool

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolume

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesListQuotaReportResponse

## NOTES

## RELATED LINKS
