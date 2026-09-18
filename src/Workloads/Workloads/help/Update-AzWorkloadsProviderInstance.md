---
external help file: Az.Workloads-help.xml
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/update-azworkloadsproviderinstance
schema: 2.0.0
---

# Update-AzWorkloadsProviderInstance

## SYNOPSIS
Update a provider instance for the specified subscription, resource group, SAP monitor name, and resource name.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzWorkloadsProviderInstance -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-EnableSystemAssignedIdentity <Boolean>]
 [-ProviderSetting <IProviderSpecificProperties>] [-UserAssignedIdentity <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityMonitorExpanded
```
Update-AzWorkloadsProviderInstance -Name <String> -MonitorInputObject <IMonitorsIdentity>
 [-EnableSystemAssignedIdentity <Boolean>] [-ProviderSetting <IProviderSpecificProperties>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzWorkloadsProviderInstance -InputObject <IMonitorsIdentity> [-EnableSystemAssignedIdentity <Boolean>]
 [-ProviderSetting <IProviderSpecificProperties>] [-UserAssignedIdentity <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update a provider instance for the specified subscription, resource group, SAP monitor name, and resource name.

## EXAMPLES

### Example 1: Update an existing provider
```powershell
$providerSetting = New-AzWorkloadsProviderSqlServerInstanceObject -Password '<password>' -Port 1433 -Username '<username>' -Hostname 10.1.14.5 -SapSid X00 -SslPreference Disabled

Update-AzWorkloadsProviderInstance -MonitorName sap-0202-ams9 -Name sql-prov-1 -ResourceGroupName sap-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c -ProviderSetting $providerSetting
```

```output
Name       ResourceGroupName ProvisioningState IdentityType
----       ----------------- ----------------- ------------
sql-prov-1 sap-0802-rg1     Succeeded
```

Update an existing provider for a specific AMS instance

### Example 2: Update an existing provider by Id
```powershell
Update-AzWorkloadsProviderInstance -MonitorName sap-160323-ams4 -Name sap-sql-3 -ResourceGroupName sap-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c -ProviderSetting '{"sslPreference":"Disabled","providerType":"MsSqlServer","hostname":"10.1.14.5","sapSid":"X00","dbPort":"1433","dbUsername":"","dbPassword":""}'
```

```output
Name       ResourceGroupName ProvisioningState IdentityType
----       ----------------- ----------------- ------------
sap-sql-3 sap-0802-rg1     Succeeded
```

Update an existing provider for a specific AMS instance by Arm Id

## PARAMETERS

### -AsJob
Run the command as a job

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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Monitors.Models.IMonitorsIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Monitors.Models.IMonitorsIdentity
Parameter Sets: UpdateViaIdentityMonitorExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorName
Name of the SAP monitor resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the provider instance.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityMonitorExpanded
Aliases: ProviderInstanceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ProviderSetting
Defines the provider specific properties.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Monitors.Models.IProviderSpecificProperties
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Monitors.Models.IMonitorsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Monitors.Models.IProviderInstance

## NOTES

## RELATED LINKS
