### Example 1: List discovered GitLab subgroups
```powershell
Get-AzSecurityConnectorGitLabSubgroup -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-gl-01 -GroupFqName dfdsdktests
```

```output
Name                                         ResourceGroupName
----                                         -----------------
dfdsdktests$testsubgroup1$testsubgroupNested dfdtest-sdk
dfdsdktests$testsubgroup1                    dfdtest-sdk
```


