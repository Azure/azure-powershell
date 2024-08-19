### Example 1: List information about topic type.
```powershell
Get-AzEventGridTopicType
```

```output
Name                                            ResourceGroupName
----                                            -----------------
Microsoft.Eventhub.Namespaces
......
Microsoft.EventGrid.Namespaces
```

List information about topic type.

### Example 2: Get information about a topic type.
```powershell
Get-AzEventGridTopicType -Name Microsoft.EventGrid.Namespaces
```

```output
Name                           ResourceGroupName
----                           -----------------
Microsoft.EventGrid.Namespaces
```

Get information about a topic type.