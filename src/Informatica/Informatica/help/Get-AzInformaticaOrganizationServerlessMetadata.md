---
external help file: Az.Informatica-help.xml
Module Name: Az.Informatica
online version: https://learn.microsoft.com/powershell/module/az.informatica/get-azinformaticaorganizationserverlessmetadata
schema: 2.0.0
---

# Get-AzInformaticaOrganizationServerlessMetadata

## SYNOPSIS
Gets Metadata of the serverless runtime environment.

## SYNTAX

### Get (Default)
```
Get-AzInformaticaOrganizationServerlessMetadata -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzInformaticaOrganizationServerlessMetadata -InputObject <IInformaticaIdentity>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Gets Metadata of the serverless runtime environment.

## EXAMPLES

### Example 1: Get Serverless Metadata for an Informatica Organization
```powershell
Get-AzInformaticaOrganizationServerlessMetadata -OrganizationName "Demo-Org" -ResourceGroupName "InformaticaTestRg"
```

```output
Type                                           : SERVERLESS,
ServerlessConfigPropertiesApplicationTypes     : [{"name": "CDI-E", "value": "Advanced Data Integration"}, {"name": "CDI", "value": "Data Integration"}],
Platform                                       : AZURE,
ExecutionTimeout                               : 3600,
ComputeUnits                                   : [{"name": "CDI", "value": ["1", "2", "4"]}, {"name": "CDI-E", "value": ["4", "8", "12", "16", "20", "24", "28", "32", "36", "40"]}],
Regions                                        : [{"id": "westus", "name": "West US"}, {"id": "eastus2", "name": "East US 2"}],
ServerlessRuntimeConfigPropertiesCdiConfigProps: [{"engineName": "Data_Integration_Server", "engineVersion": "68.0", "applicationConfigs": [{"type": "TOMCAT_CFG", "name": "INFA_DTM_STAGING_ENABLED_CONNECTORS", "value": "''", "platform": "all", "customized": "false", "defaultValue": "''"}]}],
ServerlessRuntimeConfigPropertiesCdiEConfigProps: [{"engineName": "Data_Integration_Server", "engineVersion": "68.0", "applicationConfigs": [{"type": "TOMCAT_CFG", "name": "INFA_DTM_STAGING_ENABLED_CONNECTORS", "value": "''", "platform": "all", "customized": "false", "defaultValue": "''"}]}]
```

This command will get serverless metadata for an Informatica organization.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OrganizationName
Name of the Organizations resource

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
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
Parameter Sets: Get
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
Type: System.String[]
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IServerlessMetadataResponse

## NOTES

## RELATED LINKS
