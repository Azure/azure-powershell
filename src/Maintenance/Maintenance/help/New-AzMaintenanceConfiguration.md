---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Maintenance.dll-Help.xml
Module Name: Az.Maintenance
online version: https://learn.microsoft.com/powershell/module/az.maintenance/new-azmaintenanceconfiguration
schema: 2.0.0
---

# New-AzMaintenanceConfiguration

## SYNOPSIS
Create or Update configuration record

## SYNTAX

```
New-AzMaintenanceConfiguration [-ResourceGroupName] <String> [-Name] <String> [-Location] <String>
 [-Tag <Hashtable>] [-ExtensionProperty <Hashtable>] [-MaintenanceScope <String>] [-StartDateTime <String>]
 [-ExpirationDateTime <String>] [-Timezone <String>] [-Duration <TimeSpan>] [-Visibility <String>]
 [-RecurEvery <String>]
 [-LinuxParameterPackageNameMaskToInclude <System.Collections.Generic.HashSet`1[System.String]>]
 [-LinuxParameterPackageNameMaskToExclude <System.Collections.Generic.HashSet`1[System.String]>]
 [-LinuxParameterClassificationToInclude <System.Collections.Generic.HashSet`1[System.String]>]
 [-WindowParameterKbNumberToInclude <System.Collections.Generic.HashSet`1[System.String]>]
 [-WindowParameterKbNumberToExclude <System.Collections.Generic.HashSet`1[System.String]>]
 [-WindowParameterClassificationToInclude <System.Collections.Generic.HashSet`1[System.String]>]
 [-WindowParameterExcludeKbRequiringReboot <Boolean>] [-InstallPatchRebootSetting <String>] [-PreTask <String>]
 [-PostTask <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create or Update configuration record

## EXAMPLES

### Example 1
```powershell
New-AzMaintenanceConfiguration -ResourceGroupName smdtest -Name workervmscentralus -MaintenanceScope Host -Location centralus -StartDateTime "2020-08-01 00:00" -ExpirationDateTime "2021-08-04 00:00" -Timezone "Pacific Standard Time" -Duration 05:00 -RecurEvery Day
```

```output
Location            : centralus
Tags                : {}
ExtensionProperties : {}
MaintenanceScope    : Host
StartDateTime       : 2020-08-01 00:00
ExpirationDateTime  : 2021-08-04 00:00
TimeZone            : Pacific Standard Time
RecurEvery          : Day
Duration            : 05:00
MaintenanceScope    : Host
Visibility          : Custom
Id                  : /subscriptions/42c974dd-2c03-4f1b-96ad-b07f050aaa74/resourcegroups/smdtest/providers/Microsoft.Maintenance/maintenanceConfigurations/workervmscentralus
Name                : workervmscentralus
Type                : Microsoft.Maintenance/maintenanceConfigurations
```

Create a maintenance configuration with scope Host

### Example 2
```powershell
New-AzMaintenanceConfiguration -ResourceGroupName sample-rg  -Name PatchSchedule -MaintenanceScope "InGuestPatch" -Location westeurope -Timezone "UTC" -StartDateTime "2025-10-09 12:30" -Duration "3:00" -RecurEvery "Day" -LinuxParameterClassificationToInclude @('Other') -LinuxParameterPackageNameMaskToInclude @('lib', 'kernel') -LinuxParameterPackageNameMaskToExclude @('curl', 'vim') -WindowParameterClassificationToInclude @('Critical', 'Security') -WindowParameterKbNumberToInclude @('5035849', '5035857') -WindowParameterKbNumberToExclude @('5034439')  -ExtensionProperty @{inGuestPatchMode="User"} -InstallPatchRebootSetting "IfRequired"  -Debug
```

```output
Location                               : westeurope
Tags                                   : {"resource":"test"}
ExtensionProperties                    : {"inGuestPatchMode":"User"}
MaintenanceScope                       : InGuestPatch
Id                                     : 
/subscriptions/783fd652-64f3-4680-81e9-0b978c542005/resourcegroups/sample-rg/providers/Microsoft.Maintenance/maintenanceConfigurations/PatchSchedule
Name                                   : PatchSchedule
Type                                   : Microsoft.Maintenance/maintenanceConfigurations
StartDateTime                          : 2025-10-09 12:30
Duration                               : 03:00
Timezone                               : UTC
Visibility                             : Custom
RecurEvery                             : Day
LinuxParameterClassificationToInclude  : 
LinuxParameterPackageNameMaskToExclude : 
LinuxParameterPackageNameMaskToInclude : apt
                                         httpd
WindowParameterKbNumberToInclude       : 
WindowParameterKbNumberToExclude       : 
WindowParameterClassificationToInclude : 
InstallPatchRebootSetting              : IfRequired
```

Create a maintenance configuration with scope InGuest

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -Duration
The duration


```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpirationDateTime
The expirationDateTime of the schedule in format YYYY-MM-DD hh:mm

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

### -ExtensionProperty
The Extension properties per resource.

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

### -InstallPatchRebootSetting
Install Patch Reboot Option. Allowed values Never, IfRequired, Always

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

### -LinuxParameterClassificationToInclude
List of linux patch classifications. Allowed values are 'Critical', 'Security', and 'Other'.

```yaml
Type: System.Collections.Generic.HashSet`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinuxParameterPackageNameMaskToExclude
List of packages to exclude during vm patch operation

```yaml
Type: System.Collections.Generic.HashSet`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinuxParameterPackageNameMaskToInclude
List of packages to include during vm patch operation

```yaml
Type: System.Collections.Generic.HashSet`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The maintenance configuration location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MaintenanceScope
The Maintenance Scope.

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

### -Name
The maintenance configuration Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PostTask
List of tasks executed after schedule. [{'source' :'runbook', 'taskScope': 'Resource', 'parameters': { 'arg1': 'value1'}}]. This parameter is used to specify a command or script that should be run after the maintenance tasks are performed. This can be used to perform any necessary follow-up actions after the maintenance tasks are completed. This parameter accepts a string value that specifies the command or script to be run. The command or script can be specified as a simple string or as an array of strings. If an array of strings is specified, each element in the array will be treated as a separate command or script.

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

### -PreTask
List of tasks executed before schedule. e.g. [{'source' :'runbook', 'taskScope': 'Global', 'parameters': { 'arg1': 'value1'}}]. This parameter is used to specify a command or script that should be run before the maintenance tasks are performed. This can be used to perform any necessary preparations or cleanup actions before the maintenance tasks are run. This parameter accepts a string value that specifies the command or script to be run. The command or script can be specified as a simple string or as an array of strings. If an array of strings is specified, each element in the array will be treated as a separate command or script.

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

### -RecurEvery
The schedule recurrence

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

### -ResourceGroupName
The resource Group Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StartDateTime
The StartDateTime of the schedule in format YYYY-MM-DD hh:mm

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

### -Tag
The ARM Tags.

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

### -Timezone
The timezone

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

### -Visibility
The visibility of the scope

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

### -WindowParameterClassificationToInclude
List of windows patch classification. Allowed values are 'Critical', 'Security', 'UpdateRollup', 'FeaturePack', 'ServicePack', 'Definition', 'Tools', and 'Updates'.

```yaml
Type: System.Collections.Generic.HashSet`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowParameterExcludeKbRequiringReboot
Exclude KBs which require reboot

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowParameterKbNumberToExclude
List of KBs to exclude during vm patch operation

```yaml
Type: System.Collections.Generic.HashSet`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowParameterKbNumberToInclude
List of KBs to include during vm patch operation

```yaml
Type: System.Collections.Generic.HashSet`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Maintenance.Models.PSMaintenanceConfiguration

## NOTES

## RELATED LINKS
