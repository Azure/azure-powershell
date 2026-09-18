---
external help file:
Module Name: Az.HanaOnAzure
online version: https://learn.microsoft.com/powershell/module/az.hanaonazure/update-azsapmonitorproviderinstance
schema: 2.0.0
---

# Update-AzSapMonitorProviderInstance

## SYNOPSIS
update a provider instance for the specified subscription, resource group, SapMonitor name, and resource name.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSapMonitorProviderInstance -Name <String> -ResourceGroupName <String> -SapMonitorName <String>
 [-SubscriptionId <String>] [-Metadata <String>] [-ProviderInstanceProperty <String>] [-ProviderType <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSapMonitorProviderInstance -InputObject <IHanaOnAzureIdentity> [-Metadata <String>]
 [-ProviderInstanceProperty <String>] [-ProviderType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentitySapMonitorExpanded
```
Update-AzSapMonitorProviderInstance -Name <String> -SapMonitorInputObject <IHanaOnAzureIdentity>
 [-Metadata <String>] [-ProviderInstanceProperty <String>] [-ProviderType <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
update a provider instance for the specified subscription, resource group, SapMonitor name, and resource name.

## EXAMPLES

### Example 1: Update an instance of SAP monitor by string for HANA
```powershell
$jsonString = '{
  "HanaHostname": "hdb1-0",
  "HanaDatabaseUsername": "SYSTEM",
  "HanaDatabaseName": "SYSTEMDB",
  "HanaDatabaseSqlPort": "30015",
  "HanaDatabasePassword": "*****"
}'
Update-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -Name ps-sapmonitorins-t01 -SapMonitorName yemingmonitor -ProviderType SapHana -ProviderInstanceProperty $jsonString
```

```output
Name                 Type
----                 ----
ps-sapmonitorins-t01 Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command updates an instance of SAP monitor by string for HANA.

### Example 2: Update an instance of SAP monitor by key vault for HANA
```powershell
$jsonString = '{
  "HanaDatabaseName": "SYSTEMDB",
  "HanaDatabasePasswordSecretId": "https://kv-9gosjc-test.vault.azure.net/secrets/hanaPassword/************",
  "HanaHostname": "hdb1-0",
  "HanaDatabaseUsername": "SYSTEM",
  "HanaDatabaseSqlPort": "30015",
  "HanaDatabasePasswordKeyVaultResourceId": "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/costmanagement-rg-8p50xe/providers/Microsoft.KeyVault/vaults/kv-9gosjc-test"
}'
Update-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -Name sapins-kv-test -SapMonitorName sapMonitor-vayh7q-test -ProviderType SapHana -ProviderInstanceProperty $jsonString
```

```output
Name           Type
----           ----
sapins-kv-test Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command updates an instance of SAP monitor by key vault for HANA.

### Example 3: Update an instance of SAP monitor by dictionary for PrometheusHaCluster
```powershell
Update-AzSapMonitorProviderInstance -ResourceGroupName donaliu-HN1 -Name dolauli-instance-promclt -SapMonitorName dolauli-test04 -ProviderType PrometheusHaCluster -ProviderInstanceProperty '{"prometheusUrl"="http://10.4.1.10:9664/metrics"}'
```

```output
Name                     Type
----                     ----
dolauli-instance-promclt Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command updates an instance of SAP monitor by dictionary for PrometheusHaCluster.

### Example 4: Update an instance of SAP monitor by dictionary for PrometheusOS
```powershell
Update-AzSapMonitorProviderInstance -ResourceGroupName donaliu-HN1 -Name dolauli-instance-prom   -SapMonitorName dolauli-test04 -ProviderType PrometheusOS -ProviderInstanceProperty '{"prometheusUrl"="http://10.3.1.6:9100/metrics"}'
```

```output
Name                  Type
----                  ----
dolauli-instance-prom Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command updates an instance of SAP monitor by dictionary for PrometheusOS.

### Example 5: Update an instance of SAP monitor by dictionary for MsSqlServer
```powershell
$jsonString = '{
  "sqlPort": 1433,
  "sqlPassword": "fakepassword",
  "sqlUsername": "AMFSS",
  "sqlHostname": "10.4.8.90"
}'
Update-AzSapMonitorProviderInstance -ResourceGroupName donaliu-HN1 -Name dolauli-instance-ms -SapMonitorName dolauli-test04 -ProviderType MsSqlServer -ProviderInstanceProperty $jsonString
```

```output
Name                Type
----                ----
dolauli-instance-ms Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command updates an instance of SAP monitor by dictionary for MsSqlServer.

### Example 6: Update an instance of SAP monitor by dictionary for SapHana
```powershell
$jsonString = '{
  "hanaHostname": "10.1.2.6",
  "hanaDbPassword": "Manager1",
  "hanaDbUsername": "SYSTEM",
  "hanaDbSqlPort": 30113,
  "hanaDbName": "SYSTEMDB"
}'
Update-AzSapMonitorProviderInstance -ResourceGroupName donaliu-HN1 -Name dolauli-instance-hana -SapMonitorName dolauli-test04 -ProviderType SapHana -ProviderInstanceProperty $jsonString
```

```output
Name                  Type
----                  ----
dolauli-instance-hana Microsoft.HanaOnAzure/sapMonitors/providerInstances
```

This command updates an instance of SAP monitor by dictionary for SapHana.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.IHanaOnAzureIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Metadata
A JSON string containing metadata of the provider instance.

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
Name of the provider instance.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentitySapMonitorExpanded
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

### -ProviderInstanceProperty
A JSON string containing the properties of the provider instance.

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

### -ProviderType
The type of provider instance.

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
Name of the resource group.

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

### -SapMonitorInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.IHanaOnAzureIdentity
Parameter Sets: UpdateViaIdentitySapMonitorExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SapMonitorName
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

### -SubscriptionId
Subscription ID which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.IHanaOnAzureIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.IProviderInstance

## NOTES

## RELATED LINKS

