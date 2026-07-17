### Example 1: Create a dashboard using a dashboard template file
```powershell
New-AzPortalDashboard -DashboardPath .\resources\dash1.json -ResourceGroupName mydash-rg -DashboardName my-dashboard03
```

```output
Location Name           Type
-------- ----           ----
eastasia my-dashboard03 Microsoft.Portal/dashboards
```

Create a new dashboard using the provided dashboard template file.

### Example 2: Workaround for dashboard creation issues using Invoke-AzRestMethod
```powershell
$SubscriptionId = (Get-AzContext).Subscription.Id
$ResourceGroupName = 'mydash-rg'
$DashboardName = 'my-dashboard03'
$DashboardPath = ".\resources\dash1.json"
$Location = "East US"
$ApiVersion = "2022-12-01-preview"
$Dashboard = Get-Content -Path $DashboardPath -Raw | ConvertFrom-Json
$Payload = @{
    properties = $Dashboard.properties
    location = $Location
} | ConvertTo-Json -Depth 10
Invoke-AzRestMethod -SubscriptionId $SubscriptionId -ResourceGroupName $ResourceGroupName -ResourceProviderName "Microsoft.Portal" -ResourceType "dashboards" -Name $DashboardName -ApiVersion $ApiVersion -Method PUT -Payload $Payload
```

```output
StatusCode        : 200
Content           : {"id":"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/mydash-rg/providers/Microsoft.Portal/dashboards/my-dashboard03","name":"my-dashboard03","type":"Microsoft.Portal/dashboards","location":"East US","properties":{...}}
Headers           : {[Content-Length, 1234], [Content-Type, application/json; charset=utf-8], [Date, Wed, 01 Jan 2025 00:00:00 GMT]}
```

Use this workaround when `New-AzPortalDashboard` succeeds but the dashboard fails to render with "Dashboard not found" error. This issue is with the underlying REST API and this method provides a reliable alternative.


