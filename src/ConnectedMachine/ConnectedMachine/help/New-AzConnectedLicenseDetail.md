---
external help file: Az.ConnectedMachine-help.xml
Module Name: Az.ConnectedMachine
online version: https://learn.microsoft.com/powershell/module/Az.ConnectedMachine/new-azconnectedlicensedetail
schema: 2.0.0
---

# New-AzConnectedLicenseDetail

## SYNOPSIS
Create an in-memory object for LicenseDetails.

## SYNTAX

```
New-AzConnectedLicenseDetail [-Edition <String>] [-Processor <Int32>] [-State <String>] [-Target <String>]
 [-Type <String>] [-VolumeLicenseDetail <IVolumeLicenseDetails[]>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for LicenseDetails.

## EXAMPLES

### Example 1: get the detail of an ESU license
```powershell
New-AzConnectedLicenseDetail -State 'Activated' -Target 'Windows Server 2012' -Edition 'Datacenter' -Type 'pCore' -Processor 16
```

```output
AssignedLicense     :
Edition             : Datacenter
ImmutableId         :
Processor           : 16
State               : Activated
Target              : Windows Server 2012
Type                : pCore
VolumeLicenseDetail :
```

get the detail of an ESU license

## PARAMETERS

### -Edition
Describes the edition of the license.
The values are either Standard or Datacenter.

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

### -Processor
Describes the number of processors.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
Describes the state of the license.

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

### -Target
Describes the license target server.

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

### -Type
Describes the license core type (pCore or vCore).

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

### -VolumeLicenseDetail
A list of volume license details.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IVolumeLicenseDetails[]
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.LicenseDetails

## NOTES

## RELATED LINKS
