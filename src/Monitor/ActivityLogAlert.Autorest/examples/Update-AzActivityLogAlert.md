### Example 1: Update activity log alert
```powershell
Update-AzActivityLogAlert -ResourceGroupName $ResourceGroupName -Name $AlertName -Tag @{"key"="val"} -Enabled $false
```

Disable activity log alert, add tag "key":"val"