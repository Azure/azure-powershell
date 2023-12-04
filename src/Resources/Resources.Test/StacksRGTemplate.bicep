param templateSpecName string 
param location string = resourceGroup().location

resource ts 'Microsoft.Resources/templateSpecs@2022-02-01' = {
  name: templateSpecName
  location: location
  properties: {
    displayName: 'MyTemplateSpec'
    description: 'Template Spec for testing RG stacks.'
  }
}
