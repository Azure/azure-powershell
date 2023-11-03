### Example 1: Update a Container App.
```powershell
$secretObject = Get-AzContainerAppSecret -ContainerAppName azps-containerapp -ResourceGroupName azpstest_gp
$newSecretObject = @(0..($secretObject.Count-1))
[array]::copy($secretObject,$newSecretObject,$secretObject.Count)
$secretObject += New-AzContainerAppSecretObject -Name "yourkey" -Value "yourvalue"

Update-AzContainerApp -ContainerAppName azps-containerapp -ResourceGroupName azpstest_gp -Location canadacentral -ConfigurationSecret $secretObject -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-1" -DaprAppPort 8080
```

```output
Location       Name              ResourceGroupName
--------       ----              -----------------
Canada Central azps-containerapp azpstest_gp
```

Update a Container App.