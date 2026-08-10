### Example 1: List the upgrade history of an Application Network member
```powershell
Get-AzAppNetworkUpgradeHistory -AppLinkMemberName member-01 -AppLinkName appnet-test-01 -ResourceGroupName test_rg
```

```output
FromVersion ToVersion InitiatedBy StartTimestamp        EndTimestamp
----------- --------- ----------- --------------        ------------
1.3         1.4       Admin       2025-09-24T10:30:00Z  2025-09-25T00:00:00Z
```

Lists the upgrade history of the `member-01` member of the `appnet-test-01` Application Network resource.
