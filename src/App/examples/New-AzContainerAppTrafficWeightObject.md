### Example 1: Create an in-memory object for TrafficWeight.
```powershell
New-AzContainerAppTrafficWeightObject -Label "production" -RevisionName "testcontainerApp0-ab1234" -Weight 100 -LatestRevision:$True
```

```output
Label      LatestRevision RevisionName             Weight
-----      -------------- ------------             ------
production True           testcontainerApp0-ab1234 100
```

Create an in-memory object for TrafficWeight.