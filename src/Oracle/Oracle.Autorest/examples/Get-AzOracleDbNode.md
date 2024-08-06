### Example 1: Get a list of the Database Nodes for a Cloud VM Cluster resource
```powershell
Get-AzOracleDbNode -Cloudvmclustername "OFake_PowerShellTestVmCluster" -ResourceGroupName "PowerShellTestRg"
```

```output
Name                                                                              SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                                                              ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
ocid1.dbnode.oc1.iad.anuwcljrnirvylqapfxspunpsxyaehha5wwz22lazevdaoiye7bh4iy2nwfa                                                                                                                                                PowerShellTestRg
ocid1.dbnode.oc1.iad.anuwcljrnirvylqaqm24luvmhsaaz2wtiq3ggddpsemx6gn66vff5rulsgnq                                                                                                                                                PowerShellTestRg
```

Get a list of the Database Nodes for a Cloud VM Cluster resource.
For more information, execute `Get-Help Get-AzOracleDbNode`