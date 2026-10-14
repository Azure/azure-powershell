### Example 1: Delete a ChangeRecord by name
```powershell
Remove-AzChangeSafetyChangeRecord -Name "storageAccountCleanup" -ResourceGroupName "rg-changeops"
```

Deletes the specified ChangeRecord. This will also cascade delete any associated StageProgressions.

### Example 2: Delete a ChangeRecord with confirmation prompt suppressed
```powershell
Remove-AzChangeSafetyChangeRecord -Name "storageAccountCleanup" -ResourceGroupName "rg-changeops" -Confirm:$false
```

Deletes the specified ChangeRecord without prompting for confirmation.

### Example 3: Delete a ChangeRecord using pipeline
```powershell
Get-AzChangeSafetyChangeRecord -Name "storageAccountCleanup" -ResourceGroupName "rg-changeops" | Remove-AzChangeSafetyChangeRecord
```

Retrieves a ChangeRecord and deletes it using pipeline input.

