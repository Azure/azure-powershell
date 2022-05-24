### Example 1: Create a TrafficWeight object for ContainerApp.
```powershell
New-AzTrafficWeight -Label production -LatestRevision:$True -Weight 100
```

```output
Label      LatestRevision RevisionName Weight
-----      -------------- ------------ ------
production True                        100
```

Create a TrafficWeight object for ContainerApp.