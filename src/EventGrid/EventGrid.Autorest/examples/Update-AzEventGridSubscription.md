### Example 1: Asynchronously updates an existing event subscription.
```powershell
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net/api/updates"
Update-AzEventGridSubscription -Name azps-eventsub -Scope "subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX" -Destination $obj -FilterIsSubjectCaseSensitive:$false
```

```output
Name          ResourceGroupName
----          -----------------
azps-eventsub
```

Asynchronously updates an existing event subscription.