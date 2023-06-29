param templateSpecName string
param specVersionName string
param location string = resourceGroup().location

resource ts 'Microsoft.Resources/templateSpecs@2022-02-01' = {
  name: templateSpecName
  location: location
  properties: {
    displayName: 'MyTemplateSpec'
    description: 'Template Spec for testing RG stacks.'
  }
}

resource version 'Microsoft.Resources/templateSpecs/versions@2022-02-01' = {
  parent: ts
  name: specVersionName
  location: location 
  properties: {
    description: 'generated version number for testing stacks'
    mainTemplate: {
      '$schema': 'https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#'
      contentVersion: '1.0.0.0'
      parameters: {}
      functions: []
      variables: {}
      resources: []
      outputs: {}
    }
  }
}
