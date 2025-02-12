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
