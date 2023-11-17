### Example 1: Remove activity log alert by name
```powershell
Remove-AzActivityLogAlert -ResourceGroupName $ResourceGroupName -Name $AlertName
```

Remove activity log alert by name

### Example 2: Remove activity log alert by pipeline input object
```powershell
$alert = Get-AzActivityLogAlert -ResourceGroupName $ResourceGroupName -Name $AlertName
$alert | Remove-AzActivityLogAlert
```

Remove activity log alert by pipeline input object