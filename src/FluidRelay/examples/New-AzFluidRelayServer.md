### Example 1: Create or Update a Fluid Relay server.
```powershell
New-AzFluidRelayServer -Name azps-fluidrelay -ResourceGroup azpstest-gp -Location westus2 -KeyEncryptionKeyIdentityUserAssignedIdentityResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/azpstest-gp/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azpstest-uami" -KeyEncryptionKeyIdentityType 'SystemAssigned' -Storagesku 'basic' -ProvisioningState 'Succeeded' -IdentityUserAssignedIdentity "SystemAssigned"
```

```output
Location Name            ResourceGroupName
-------- ----            -----------------
westus2  azps-fluidrelay azpstest-gp
```

Create or Update a Fluid Relay server.