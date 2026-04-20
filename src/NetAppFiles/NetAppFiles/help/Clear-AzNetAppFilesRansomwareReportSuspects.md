---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/clear-aznetappfilesransomwarereportsuspects
schema: 2.0.0
---

# Clear-AzNetAppFilesRansomwareReportSuspects

## SYNOPSIS
Clears suspect file extensions on an Azure NetApp Files (ANF) Volume's Advanced Ransomware Protection (ARP) report by marking them as `PotentialThreat` or `FalsePositive`.

## SYNTAX

### ByFieldsParameterSet (Default)
```
Clear-AzNetAppFilesRansomwareReportSuspects -ResourceGroupName <String> -AccountName <String>
 -PoolName <String> -VolumeName <String> -Name <String> -Resolution <String> -Extension <String[]> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Clear-AzNetAppFilesRansomwareReportSuspects -Name <String> -Resolution <String> -Extension <String[]>
 -VolumeObject <PSNetAppFilesVolume> [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Clear-AzNetAppFilesRansomwareReportSuspects -Resolution <String> -Extension <String[]> -ResourceId <String>
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Clear-AzNetAppFilesRansomwareReportSuspects** cmdlet resolves one or more file extensions flagged by Advanced Ransomware Protection on an ANF Volume. Extensions can be marked either as `PotentialThreat` (confirmed malicious) or as `FalsePositive` (benign and should be ignored by the ARP engine going forward).
Use **-PassThru** to receive a boolean indicating whether the operation succeeded.

## EXAMPLES

### Example 1: Mark suspect extensions as a false positive
```powershell
Clear-AzNetAppFilesRansomwareReportSuspects -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -VolumeName "MyAnfVolume" -Name "MyReport" -Resolution "FalsePositive" -Extension @(".docx", ".xlsx") -PassThru
```

Marks the `.docx` and `.xlsx` extensions on the specified ARP report as false positives so the ARP engine will no longer flag them.

### Example 2: Confirm suspect extensions as a potential threat
```powershell
Clear-AzNetAppFilesRansomwareReportSuspects -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -VolumeName "MyAnfVolume" -Name "MyReport" -Resolution "PotentialThreat" -Extension @(".lockbit")
```

Confirms the `.lockbit` extension on the report as a potential threat.

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

### -Extension
List of file extensions to resolve (e.g.
'.enc', '.locked')

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the ANF ransomware report

```yaml
Type: String
Parameter Sets: ByFieldsParameterSet, ByParentObjectParameterSet
Aliases: RansomwareReportName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Return whether the suspects were successfully cleared

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resolution
The resolution for the suspects.
Possible values include: 'PotentialThreat', 'FalsePositive'

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
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
The resource id of the ANF ransomware report

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

### -VolumeName
The name of the ANF volume

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

### -VolumeObject
The volume object containing the ransomware report

```yaml
Type: PSNetAppFilesVolume
Parameter Sets: ByParentObjectParameterSet
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
Type: SwitchParameter
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
Type: SwitchParameter
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

### System.String

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolume

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
