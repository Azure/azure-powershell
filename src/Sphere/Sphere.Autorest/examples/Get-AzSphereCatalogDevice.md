### Example 1: List for the specified catalog with resource group
```powershell
Get-AzSphereCatalogDevice -CatalogName test2024 -ResourceGroupName group-test
```

```output
Name                                                                                                                             SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy System 
                                                                                                                                                                                                                                                   DataLa 
                                                                                                                                                                                                                                                   stModi 
                                                                                                                                                                                                                                                   fiedBy 
                                                                                                                                                                                                                                                   Type   
----                                                                                                                             ------------------- ------------------- ----------------------- ------------------------ ------------------------ ------ 
device1b8bd961a6129096e1e8a1375ac1fa274f030c08161b37ae3bc5a94f443bdb628cf257bc5bc810d8768c03b6f5ca301a35cd0169f56a49624255964560
deivce203ba55fb52b00fec8549fdaa46b7fb6ba35694bc8943131ccb4b302846d224580a27880a2996b9fd4f1b2699400b1627059b6a90d67dd29e2984ee147
device3cf76a5853832122d9b0e2410daa1438e3c1cde005162a837a7535c08973cc819a50cf8eb724ffc88dada06b40bee6010e82a8f84d2fef0fc263061d67
```

This command gets list of device resources for the specified catalog with resource group.

