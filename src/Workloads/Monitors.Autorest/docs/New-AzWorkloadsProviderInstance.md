---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/new-azworkloadsproviderinstance
schema: 2.0.0
---

# New-AzWorkloadsProviderInstance

## SYNOPSIS
Creates a provider instance for the specified subscription, resource group, SAP monitor name, and resource name.

## SYNTAX

```
New-AzWorkloadsProviderInstance -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-ProviderSetting <IProviderSpecificProperties>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a provider instance for the specified subscription, resource group, SAP monitor name, and resource name.

## EXAMPLES

### Example 1: Create a new provider
```powershell
$providerSetting = New-AzWorkloadsProviderSqlServerInstanceObject -Password '<password>' -Port 1433 -Username '<username>' -Hostname 10.1.14.5 -SapSid X00 -SslPreference Disabled
        $providerSetting.ProviderType | Should -Be "MsSqlServer"
        
New-AzWorkloadsProviderInstance -MonitorName suha-0202-ams9 -Name sql-prov-1 -ResourceGroupName suha-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c -ProviderSetting $providerSetting
```

```output
Name       ResourceGroupName ProvisioningState IdentityType
----       ----------------- ----------------- ------------
sql-prov-1 suha-0802-rg1     Succeeded
```

Creates a new provider for a specific AMS instance

### Example 2: Create a new provider by Id
```powershell
New-AzWorkloadsProviderInstance -MonitorName suha-160323-ams4 -Name suha-sql-3 -ResourceGroupName suha-0802-rg1 -SubscriptionId 49d64d54-e966-4c46-a868-1999802b762c -ProviderSetting '{"sslPreference":"Disabled","providerType":"MsSqlServer","hostname":"10.1.14.5","sapSid":"X00","dbPort":"1433","dbUsername":"","dbPassword":""}'
```

```output
Name       ResourceGroupName ProvisioningState IdentityType
----       ----------------- ----------------- ------------
suha-sql-3 suha-0802-rg1     Succeeded
```

Creates a new provider for a specific AMS instance by Arm Id

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

### -IdentityType
Type of manage identity

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
User assigned identities dictionary

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

### -MonitorName
Name of the SAP monitor resource.

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

### -Name
Name of the provider instance.

```yaml
Type: System.String
Parameter Sets: (All)
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
To construct, see NOTES section for PROVIDERSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IProviderSpecificProperties
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IProviderInstance

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`PROVIDERSETTING <IProviderSpecificProperties>`: Defines the provider specific properties.
  - `ProviderType <String>`: The provider type. For example, the value can be SapHana.

## RELATED LINKS

