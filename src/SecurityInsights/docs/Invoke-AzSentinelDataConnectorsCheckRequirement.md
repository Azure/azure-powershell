---
external help file:
Module Name: Az.SecurityInsights
online version: https://docs.microsoft.com/powershell/module/az.securityinsights/invoke-azsentineldataconnectorscheckrequirement
schema: 2.0.0
---

# Invoke-AzSentinelDataConnectorsCheckRequirement

## SYNOPSIS
Get requirements state for a data connector type.

## SYNTAX

### AzureActiveDirectory (Default)
```
Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName <String> -WorkspaceName <String>
 -Kind <DataConnectorKind> [-SubscriptionId <String>] [-TenantId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AzureAdvancedThreatProtection
```
Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName <String> -WorkspaceName <String>
 -Kind <DataConnectorKind> [-SubscriptionId <String>] [-TenantId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AzureSecurityCenter
```
Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName <String> -WorkspaceName <String>
 -ASCSubscriptionId <String> -Kind <DataConnectorKind> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Dynamics365
```
Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName <String> -WorkspaceName <String>
 -Kind <DataConnectorKind> [-SubscriptionId <String>] [-TenantId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MicrosoftCloudAppSecurity
```
Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName <String> -WorkspaceName <String>
 -Kind <DataConnectorKind> [-SubscriptionId <String>] [-TenantId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MicrosoftDefenderAdvancedThreatProtection
```
Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName <String> -WorkspaceName <String>
 -Kind <DataConnectorKind> [-SubscriptionId <String>] [-TenantId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MicrosoftThreatIntelligence
```
Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName <String> -WorkspaceName <String>
 -Kind <DataConnectorKind> [-SubscriptionId <String>] [-TenantId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MicrosoftThreatProtection
```
Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName <String> -WorkspaceName <String>
 -Kind <DataConnectorKind> [-SubscriptionId <String>] [-TenantId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### OfficeATP
```
Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName <String> -WorkspaceName <String>
 -Kind <DataConnectorKind> [-SubscriptionId <String>] [-TenantId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### OfficeIRM
```
Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName <String> -WorkspaceName <String>
 -Kind <DataConnectorKind> [-SubscriptionId <String>] [-TenantId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ThreatIntelligence
```
Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName <String> -WorkspaceName <String>
 -Kind <DataConnectorKind> [-SubscriptionId <String>] [-TenantId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ThreatIntelligenceTaxii
```
Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName <String> -WorkspaceName <String>
 -Kind <DataConnectorKind> [-SubscriptionId <String>] [-TenantId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Get requirements state for a data connector type.

## EXAMPLES

### Example 1: Check requirements for a Data Connector
```powershell
PS C:\> Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Kind OfficeATP -TenantId (Get-AzContext).Tenant.Id

AuthorizationState : Valid
LicenseState       : Valid
```

This example command checks the Data Connector Requirements for the Office 365 data connector.

Other -Kind values are:
AzureSecurityCenter
AzureActiveDirectory
AzureAdvancedThreatProtection
Dynamics365
MicrosoftCloudAppSecurity
MicrosoftDefenderAdvancedThreatProtection
MicrosoftThreatIntelligence
MicrosoftThreatProtection
OfficeATP
OfficeIRM
ThreatIntelligence
ThreatIntelligenceTaxii

## PARAMETERS

### -ASCSubscriptionId
ASC Subscription Id.

```yaml
Type: System.String
Parameter Sets: AzureSecurityCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
[Parameter(ParameterSetName = 'AmazonWebServicesCloudTrail', Mandatory)]
[Parameter(ParameterSetName = 'AmazonWebServicesS3', Mandatory)]
[Parameter(ParameterSetName = 'GenericUI', Mandatory)]
 The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Kind
Kind of the the data connection

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.DataConnectorKind
Parameter Sets: (All)
Aliases:

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

### -ResourceGroupName
The Resource Group Name.

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
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### -TenantId
The TenantId.

```yaml
Type: System.String
Parameter Sets: AzureActiveDirectory, AzureAdvancedThreatProtection, Dynamics365, MicrosoftCloudAppSecurity, MicrosoftDefenderAdvancedThreatProtection, MicrosoftThreatIntelligence, MicrosoftThreatProtection, OfficeATP, OfficeIRM, ThreatIntelligence, ThreatIntelligenceTaxii
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Tenant.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
[Alias('DataConnectionName')]
 The name of the workspace.

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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.DataConnectorsCheckRequirements

## NOTES

ALIASES

## RELATED LINKS

