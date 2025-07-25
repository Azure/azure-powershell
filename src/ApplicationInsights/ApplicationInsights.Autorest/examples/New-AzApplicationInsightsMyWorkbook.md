### Example 1: Create a new private workbook
```powershell
# The value of the parameter name is the Guid type.
$name = (New-Guid).ToString()
New-AzApplicationInsightsMyWorkbook -ResourceGroupName appinsights-hkrs2v-test -Name $name -Location westus2  -DisplayName "$name-display" -SourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/appinsights-hkrs2v-test/providers/microsoft.insights/components/appinsights-48mah3-pwsh" -Category 'workbook' -SerializedData $null
```

```output
ResourceGroupName       Name                                 DisplayName Location Kind Category
-----------------       ----                                 ----------- -------- ---- --------
appinsights-hkrs2v-test 2e47417f-c136-44c0-b78f-7a4ca35fd9d1 pwsh01      westus2  user workbook
```

This command create a new private workbook