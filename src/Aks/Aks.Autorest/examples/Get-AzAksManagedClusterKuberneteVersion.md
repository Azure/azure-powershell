### Example 1: Get AKS Kubernete Version
```powershell
Get-AzAksManagedClusterKuberneteVersion -Location eastus
```

```output
IsDefault IsPreview Version
--------- --------- -------
          True      1.34
                    1.33
True                1.32
                    1.31
                    1.30
                    1.29
                    1.28
```

Get extra metadata on the version, including supported patch versions, capabilities, available upgrades, and details on preview status of the version

