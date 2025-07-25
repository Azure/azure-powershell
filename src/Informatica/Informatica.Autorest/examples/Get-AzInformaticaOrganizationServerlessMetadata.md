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
