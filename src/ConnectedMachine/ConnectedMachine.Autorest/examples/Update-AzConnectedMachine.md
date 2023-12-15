### Example 1: Update a machine using parameters
```powershell
Update-AzConnectedMachine -Name surface -ResourceGroupName rg -PrivateLinkScopeResourceId privateLinkScopeId -WindowsConfigurationPatchSettingsAssessmentMode AutomaticByOS -Tag @{"key"="value"}
```

```output
ResourceGroupName Name    Location    OSType  Status    ProvisioningState
----------------- ----    --------    ------  ------    -----------------
rg               surface    eastus2euap windows Connected Updating
```

Update a machine

### Example 2: Update a machine - cleaning a field
```powershell
Update-AzConnectedMachine -Name surface -ResourceGroupName rg -PrivateLinkScopeResourceId $null
```

```output
ResourceGroupName Name    Location    OSType  Status    ProvisioningState
----------------- ----    --------    ------  ------    -----------------
rg               surface eastus2euap windows Connected Updating
```

Update a machine to clean a field

