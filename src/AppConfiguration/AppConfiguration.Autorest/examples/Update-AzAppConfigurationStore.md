### Example 1: Updates a configuration store with the specified parameters.
```powershell
Update-AzAppConfigurationStore -Name azpstest-appstore -ResourceGroupName azpstest_gp -DisableLocalAuth -EnablePurgeProtection -PublicNetworkAccess 'Enabled'
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azpstest-appstore azpstest_gp
```

Updates a configuration store with the specified parameters.

### Example 2: Updates a configuration store with the specified parameters.
```powershell
Get-AzAppConfigurationStore -Name azpstest-appstore -ResourceGroupName azpstest_gp | Update-AzAppConfigurationStore -DisableLocalAuth -EnablePurgeProtection -PublicNetworkAccess 'Enabled'
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azpstest-appstore azpstest_gp
```

Updates a configuration store with the specified parameters.