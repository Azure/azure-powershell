---
external help file:
Module Name: Az.Informatica
online version: https://learn.microsoft.com/powershell/module/az.informatica/update-azinformaticaserverlessruntime
schema: 2.0.0
---

# Update-AzInformaticaServerlessRuntime

## SYNOPSIS
Update a InformaticaServerlessRuntimeResource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzInformaticaServerlessRuntime -Name <String> -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AdvancedCustomProperty <IAdvancedCustomProperties[]>]
 [-ApplicationType <String>] [-ComputeUnit <String>] [-Description <String>] [-ExecutionTimeout <String>]
 [-NetworkInterfaceConfigurationSubnetId <String>] [-NetworkInterfaceConfigurationVnetId <String>]
 [-NetworkInterfaceConfigurationVnetResourceGuid <String>] [-Platform <String>]
 [-ServerlessAccountLocation <String>] [-ServerlessRuntimeConfigCdiConfigProp <ICdiConfigProps[]>]
 [-ServerlessRuntimeConfigCdieConfigProp <ICdiConfigProps[]>]
 [-ServerlessRuntimeTag <IServerlessRuntimeTag[]>]
 [-ServerlessRuntimeUserContextPropertyUserContextToken <String>] [-SupplementaryFileLocation <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzInformaticaServerlessRuntime -InputObject <IInformaticaIdentity>
 [-AdvancedCustomProperty <IAdvancedCustomProperties[]>] [-ApplicationType <String>] [-ComputeUnit <String>]
 [-Description <String>] [-ExecutionTimeout <String>] [-NetworkInterfaceConfigurationSubnetId <String>]
 [-NetworkInterfaceConfigurationVnetId <String>] [-NetworkInterfaceConfigurationVnetResourceGuid <String>]
 [-Platform <String>] [-ServerlessAccountLocation <String>]
 [-ServerlessRuntimeConfigCdiConfigProp <ICdiConfigProps[]>]
 [-ServerlessRuntimeConfigCdieConfigProp <ICdiConfigProps[]>]
 [-ServerlessRuntimeTag <IServerlessRuntimeTag[]>]
 [-ServerlessRuntimeUserContextPropertyUserContextToken <String>] [-SupplementaryFileLocation <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityOrganizationExpanded
```
Update-AzInformaticaServerlessRuntime -Name <String> -OrganizationInputObject <IInformaticaIdentity>
 [-AdvancedCustomProperty <IAdvancedCustomProperties[]>] [-ApplicationType <String>] [-ComputeUnit <String>]
 [-Description <String>] [-ExecutionTimeout <String>] [-NetworkInterfaceConfigurationSubnetId <String>]
 [-NetworkInterfaceConfigurationVnetId <String>] [-NetworkInterfaceConfigurationVnetResourceGuid <String>]
 [-Platform <String>] [-ServerlessAccountLocation <String>]
 [-ServerlessRuntimeConfigCdiConfigProp <ICdiConfigProps[]>]
 [-ServerlessRuntimeConfigCdieConfigProp <ICdiConfigProps[]>]
 [-ServerlessRuntimeTag <IServerlessRuntimeTag[]>]
 [-ServerlessRuntimeUserContextPropertyUserContextToken <String>] [-SupplementaryFileLocation <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzInformaticaServerlessRuntime -Name <String> -OrganizationName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzInformaticaServerlessRuntime -Name <String> -OrganizationName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update a InformaticaServerlessRuntimeResource

## EXAMPLES

### Example 1: Update Informatica Serverless Runtime
```powershell
Update-AzInformaticaServerlessRuntime `
    -OrganizationName "Demo-Org" `
    -ResourceGroupName "InformaticaTestRg" `
    -ServerlessRuntimeName "serverlessRuntimeDemo" `
    -NetworkInterfaceConfigurationVnetId "/subscriptions/ce37d538-dfa3-49c3-b3cd-149b4b7db48a/resourceGroups/InformaticaTestRg/providers/Microsoft.Network/virtualNetworks/liftr-vnet-serverless" `
    -NetworkInterfaceConfigurationSubnetId "/subscriptions/ce37d538-dfa3-49c3-b3cd-149b4b7db48a/resourceGroups/InformaticaTestRg/providers/Microsoft.Network/virtualNetworks/liftr-vnet-serverless/subnets/default" `
    -ServerlessAccountLocation "westus2" `
    -Platform "AZURE" `
    -ApplicationType "CDI" `
    -ExecutionTimeout 3600 `
    -ServerlessRuntimeConfigCdieConfigProp @(
        @{
            EngineName = "Data_Integration_Server"
            EngineVersion = "68.0"
            ApplicationConfigs = @(
                @{
                    Type = "TOMCAT_CFG"
                    Name = "INFA_DTM_STAGING_ENABLED_CONNECTORS"
                    Value = ""
                    Platform = "all"
                    Customized = $false
                    DefaultValue = ""
                }
            )
        }
    )

```

```output
Id                                         : /subscriptions/ce37d538-dfa3-49c3-b3cd-149b4b7db48a/resourceGroups/InformaticaTestRg/providers/Informatica.DataManagement/organizations/Demo-Org/serverlessRuntimes/serverlessRuntimeDemo,
Name                                       : serverlessRuntimeDemo,
Type                                       : Informatica.Datamanagement/organizations/serverlessRuntimes,
Location                                   : westus2,
Tags                                       : {},
NetworkInterfaceConfigurationVnetId        : /subscriptions/ce37d538-dfa3-49c3-b3cd-149b4b7db48a/resourceGroups/InformaticaTestRg/providers/Microsoft.Network/virtualNetworks/liftr-vnet-serverless,
NetworkInterfaceConfigurationSubnetId      : /subscriptions/ce37d538-dfa3-49c3-b3cd-149b4b7db48a/resourceGroups/InformaticaTestRg/providers/Microsoft.Network/virtualNetworks/liftr-vnet-serverless/subnets/default,
ServerlessAccountLocation                  : westus2,
Platform                                   : AZURE,
ApplicationType                            : CDI,
ExecutionTimeout                           : 3600,
ComputeUnits                               : 4,
ServerlessRuntimeConfigCdieConfigProp      : { EngineName: Data_Integration_Server, EngineVersion: 68.0, ApplicationConfigs: [{ Type: TOMCAT_CFG, Name: INFA_DTM_STAGING_ENABLED_CONNECTORS, Value: '', Platform: all, Customized: false, DefaultValue: '' }] }

```

This command will update an existing Informatica Serverless Runtime.

## PARAMETERS

### -AdvancedCustomProperty
String KV pairs indicating Advanced custom properties.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IAdvancedCustomProperties[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationType
Application type of the Serverless Runtime environment.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeUnit
Compute units of the serverless runtime.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityOrganizationExpanded
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

### -Description
description of the serverless runtime.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExecutionTimeout
Serverless Execution timeout

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityOrganizationExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Serverless Runtime resource

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityOrganizationExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: ServerlessRuntimeName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkInterfaceConfigurationSubnetId
Virtual network subnet resource id

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkInterfaceConfigurationVnetId
Virtual network resource id

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkInterfaceConfigurationVnetResourceGuid
Virtual network resource guid

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrganizationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaIdentity
Parameter Sets: UpdateViaIdentityOrganizationExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Platform
Platform type of the Serverless Runtime.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityOrganizationExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerlessAccountLocation
Serverless account creation location

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerlessRuntimeConfigCdiConfigProp
The List of Informatica Serverless Runtime CDI Config Properties.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.ICdiConfigProps[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerlessRuntimeConfigCdieConfigProp
The List of Informatica Serverless Runtime CDIE Config Properties.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.ICdiConfigProps[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerlessRuntimeTag
Serverless Runtime Tags

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IServerlessRuntimeTag[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerlessRuntimeUserContextPropertyUserContextToken
User context token for OBO flow.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupplementaryFileLocation
Supplementary file location.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityOrganizationExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaServerlessRuntimeResource

## NOTES

## RELATED LINKS

