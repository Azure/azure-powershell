### Example 1: Regenerate a shared access key for a domain.
```powershell
New-AzEventGridDomainKey -DomainName azps-domain -ResourceGroupName azps_test_group_eventgrid -KeyName key1
```

```output
Key1        Key2
----        ----
JF0co*****= BG*****=
```

Regenerate a shared access key for a domain.