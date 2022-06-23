### Example 1: List the properties of a Container App.
```powershell
Get-AzContainerApp
```

```output
Location       Name               ResourceGroupName
--------       ----               -----------------
Canada Central azcli-containerapp azcli_gp
Canada Central azps-containerapp  azpstest_gp
```

List the properties of a Container App.

### Example 2: Get the properties of a Container App by Resource Group.
```powershell
Get-AzContainerApp -ResourceGroupName azpstest_gp
```

```output
Location       Name              ResourceGroupName
--------       ----              -----------------
Canada Central azps-containerapp azpstest_gp
```

Get the properties of a Container App by Resource Group.

### Example 3: Get the properties of a Container App by name.
```powershell
Get-AzContainerApp -ResourceGroupName azpstest_gp -Name azps-containerapp
```

```output
Location       Name              ResourceGroupName
--------       ----              -----------------
Canada Central azps-containerapp azpstest_gp
```

Get the properties of a Container App by name.