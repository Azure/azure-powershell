using './test-resources.bicep'

param capacityName = 'mycapacityresource'
param location = 'westus'
param skuTier = 'Fabric'
param skuName = 'F2'
param administrationMembers = ['VsavTest@pbiotest.onmicrosoft.com']
param tags = { env: 'dev' }

