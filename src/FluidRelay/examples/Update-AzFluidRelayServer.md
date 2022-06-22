### Example 1: Update a Fluid Relay server.
```powershell
Update-AzFluidRelayServer -Name azps-fluidrelay -ResourceGroup azpstest-gp -KeyEncryptionKeyIdentityUserAssignedIdentityResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/azpstest-gp/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azpstest-uami" -KeyEncryptionKeyIdentityType 'SystemAssigned' -Tag @{"Category"="sales"} -IdentityUserAssignedIdentity @{"/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/azpstest-gp/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azpstest-uami" = @{};} -IdentityType 'UserAssigned'
```

```output
Location Name            ResourceGroupName
-------- ----            -----------------
westus2  azps-fluidrelay azpstest-gp
```

Update a Fluid Relay server.