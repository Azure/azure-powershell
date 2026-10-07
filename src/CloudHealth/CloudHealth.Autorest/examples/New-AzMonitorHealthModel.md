### Example 1: Create a health model
```powershell
# Create the health model azpwsh-healthmodel1 with a system-assigned identity
# The new model will contain a root entity named after the model. On that entity, you can get the model's health state.
# Connect entities to the root entity with New-AzMonitorHealthModelRelationship so health rolls up.
# Next: create an authentication setting and grant its identity read access
New-AzMonitorHealthModel -Name azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Location eastus2 -EnableSystemAssignedIdentity
```

Creates a health model with a system-assigned managed identity.
