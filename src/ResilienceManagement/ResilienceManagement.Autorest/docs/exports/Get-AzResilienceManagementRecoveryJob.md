---
external help file:
Module Name: Az.ResilienceManagement
online version: https://learn.microsoft.com/powershell/module/az.resiliencemanagement/get-azresiliencemanagementrecoveryjob
schema: 2.0.0
---

# Get-AzResilienceManagementRecoveryJob

## SYNOPSIS
Get a RecoveryJob

## SYNTAX

### List (Default)
```
Get-AzResilienceManagementRecoveryJob -RecoveryPlanName <String> -ServiceGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzResilienceManagementRecoveryJob -Name <String> -RecoveryPlanName <String> -ServiceGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzResilienceManagementRecoveryJob -InputObject <IResilienceManagementIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityRecoveryPlan
```
Get-AzResilienceManagementRecoveryJob -Name <String> -RecoveryPlanInputObject <IResilienceManagementIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityServiceGroup
```
Get-AzResilienceManagementRecoveryJob -Name <String> -RecoveryPlanName <String>
 -ServiceGroupInputObject <IResilienceManagementIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a RecoveryJob

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
{{ Add code here }}
```



### -------------------------- EXAMPLE 2 --------------------------
```powershell
{{ Add code here }}
```



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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The unique name (GUID) of the recovery job.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityRecoveryPlan, GetViaIdentityServiceGroup
Aliases: RecoveryJobName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryPlanInputObject
Identity Parameter
To construct, see NOTES section for RECOVERYPLANINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity
Parameter Sets: GetViaIdentityRecoveryPlan
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RecoveryPlanName
The name of the recovery orchestration plan.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityServiceGroup, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceGroupInputObject
Identity Parameter
To construct, see NOTES section for SERVICEGROUPINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity
Parameter Sets: GetViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServiceGroupName
The name of the service group.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IRecoveryJob

## NOTES

## RELATED LINKS

