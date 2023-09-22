### Example 1: Create an in-memory object for TrafficWeight.
```powershell
New-AzContainerAppTrafficWeightObject -Label "production" -Weight 100 -LatestRevision:$True
```

```output
Label      LatestRevision RevisionName Weight
-----      -------------- ------------ ------
production True                        100
```

Create an in-memory object for TrafficWeight.