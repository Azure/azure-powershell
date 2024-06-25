targetScope = 'subscription'

param rgname string
param location string = deployment().location

resource rg 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: rgname
  location: location
}