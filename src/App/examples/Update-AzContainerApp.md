### Example 1: Update a Container App.
```powershell
Update-AzContainerApp -Name azps-containerapp -ResourceGroupName azpstest_gp -Location canadacentral -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-1" -DaprAppPort 8080
```

```output
Location       Name              ResourceGroupName
--------       ----              -----------------
Canada Central azps-containerapp azpstest_gp
```

Update a Container App.