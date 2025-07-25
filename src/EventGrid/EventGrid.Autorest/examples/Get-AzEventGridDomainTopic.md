### Example 1: List properties of domain topic.
```powershell
Get-AzEventGridDomainTopic -DomainName azps-domain -ResourceGroupName azps_test_group_eventgrid
```

```output
Name             ResourceGroupName
----             -----------------
azps-domaintopic azps_test_group_eventgrid
```

List properties of domain topic.

### Example 2: List properties of domain topic.
```powershell
Get-AzEventGridDomainTopic -DomainName azps-domain -ResourceGroupName azps_test_group_eventgrid -Name azps-domaintopics
```

```output
Name             ResourceGroupName
----             -----------------
azps-domaintopic azps_test_group_eventgrid
```

List properties of domain topic.

### Example 3: Get properties of a domain topic.
```powershell
$domain = Get-AzEventGridDomain -ResourceGroupName azps_test_group_eventgrid -Name azps-domain
Get-AzEventGridDomainTopic -DomainInputObject $domain -Name azps-domaintopics
```

```output
Name             ResourceGroupName
----             -----------------
azps-domaintopic azps_test_group_eventgrid
```

Get properties of a domain topic.