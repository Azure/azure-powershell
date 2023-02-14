### Example 1: Regenerate either the primary or secondary key for use with the Maps APIs
```powershell
<<<<<<< HEAD
New-AzMapsAccountKey -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01 -KeyType primary
```

```output
=======
PS C:\> New-AzMapsAccountKey -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01 -KeyType primary

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
PrimaryKey                                  PrimaryKeyLastUpdated        SecondaryKey                                SecondaryKeyLastUpdated
----------                                  ---------------------        ------------                                -----------------------
W5VYcbrpyt4urV2-4C-lXepnHoy6EIOHnoLL_wjEtaw 2021-05-20T05:50:27.1509422Z zi6W1bw4zIYLjDj_DRRrC3jBkX-APgBebwx4cZBKJOU 2021-05-20T05:41:03.452571Z
```

This command regenerate either the primary or secondary key for use with the Maps APIs.
The old key will stop working immediately.

### Example 2: Regenerate either the primary or secondary key for use with the Maps APIs by pipeline
```powershell
<<<<<<< HEAD
Get-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01 | New-AzMapsAccountKey -KeyType primary
```

```output
=======
PS C:\> Get-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01 | New-AzMapsAccountKey -KeyType primary

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
PrimaryKey                                  PrimaryKeyLastUpdated        SecondaryKey                                SecondaryKeyLastUpdated
----------                                  ---------------------        ------------                                -----------------------
xoGsuTFWuG6xq0re7EdA7nCbDhvRoisZfLHvKfdzIhQ 2021-05-20T05:55:21.7797268Z zi6W1bw4zIYLjDj_DRRrC3jBkX-APgBebwx4cZBKJOU 2021-05-20T05:41:03.452571Z
```

This command regenerate either the primary or secondary key for use with the Maps APIs by pipeline.
The old key will stop working immediately.

