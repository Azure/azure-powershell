### Example 1: List the changes of a subscription within the specified time range
```powershell
$start = Get-Date -Date "2021-07-16T12:09:03.141Z" -AsUTC
$end = Get-Date -Date "2021-07-18T12:09:03.141Z" -AsUTC
Get-AzChangeAnalysis -StartTime $start -EndTime $end
```

```output
Name                                                                                                                Type
----                                                                                                                ----
ARG_96668df8-baa3-443a-b65e-e473b73a7df0_3671a03a-262c-4470-8abf-0691873f2e20_132709991319090106_132710115679840000 Microsoft.ChangeAnalysis/changes
ARG_6650f699-c589-47d0-8a0c-986747e0da51_02beafb4-a45d-4d2e-b6db-39f78b9c8cdb_132710114132810000_132710114396490000 Microsoft.ChangeAnalysis/changes
ARG_d365ea34-8582-4fb3-8c52-dba9a19f0f33_6650f699-c589-47d0-8a0c-986747e0da51_132709991313340016_132710114132810000 Microsoft.ChangeAnalysis/changes
ARG_3296a3bc-12bd-4fef-946f-43ff2eb355f0_325d8891-9a17-44ef-9c75-adf689a3e472_132709991313810987_132710113966730000 Microsoft.ChangeAnalysis/changes
ARG_311e76ea-5d00-467e-9429-91832bd0a00e_f5eb3b00-1e8c-4e77-9f94-9f9f20a068f7_132709991315140000_132710113635160000 Microsoft.ChangeAnalysis/changes
ARG_0cd19d15-f5e8-4183-8490-c5b46346eb4d_eaa165ed-1312-44cd-857b-dca369af4b9b_132709991311839973_132710113347940000 Microsoft.ChangeAnalysis/changes
ARG_5d07079f-beb6-4c9f-9a6c-c7cc9eb3d99f_7c6d7121-386d-47af-a123-d3780e078917_132709991321439966_132710113013580000 Microsoft.ChangeAnalysis/changes
ARG_041b62e5-7f3d-4f4d-bed7-8a9d3edc2966_f59b6207-b612-4a4d-9a62-03bfd182bc46_132709991316390202_132710112707510000 Microsoft.ChangeAnalysis/changes
ARG_9329dbeb-b807-4a6f-9d74-6918e65f2ff3_41d93e62-7dc3-46e8-9a75-848a1f3a0bda_132709573823920000_132709991325440351 Microsoft.ChangeAnalysis/changes
ARG_dc780601-b504-4649-bf25-0fee0e50c3f4_619618f3-549a-49c3-950a-9b731fc4fb34_132708911328790410_132709991323840381 Microsoft.ChangeAnalysis/changes
ARG_bc844a9d-8694-475b-bc9c-21196773b9f1_9e961411-f05d-4b7a-9b2d-ab8503ca9248_132709579070980000_132709991323240660 Microsoft.ChangeAnalysis/changes
ARG_2b07803b-55c3-41d9-a462-580300f28109_1a1b0c72-b1b7-45e6-b1aa-580164de757a_132708911329840382_132709991321590403 Microsoft.ChangeAnalysis/changes
ARG_1ba3852e-6de7-471d-834f-3ad286131028_271f7c65-8cc4-4652-afcf-c10989594edc_132709572690200000_132709991319040058 Microsoft.ChangeAnalysis/changes
ARG_acc8b899-73e5-4f5d-aaf4-ea27e9a8d784_fb0ec72d-4144-45be-8b21-fd2881dae433_132709572599140000_132709991317290006 Microsoft.ChangeAnalysis/changes
ARG_87e6da89-6a5b-44ff-9897-fdb576be48a3_c5983237-6f04-4091-a720-cfb76c9511c6_132709573194030000_132709991315990351 Microsoft.ChangeAnalysis/changes
ARG_af2eab01-5a60-4032-a73f-3b163ef913f9_5383297e-2aa5-43a5-88b5-df1ad59106bf_132709574410220000_132709991315640327 Microsoft.ChangeAnalysis/changes
ARG_9e2c2860-c8ca-4370-801d-1067ad05985f_08b5431b-7cee-43fb-8212-14bf8dd30818_132709575348480000_132709991314390001 Microsoft.ChangeAnalysis/changes
ARG_89d2c8ed-366f-4478-9a8e-d0d1f9ed111a_e1596920-1b50-4ca6-89be-536ce8fe6517_132709574386530000_132709991314139974 Microsoft.ChangeAnalysis/changes
ARG_8806183f-1dd1-431d-a3c9-4387b867378f_65131d9c-db4e-4598-b57b-c3f6ea74888a_132708911335140459_132709991313289972 Microsoft.ChangeAnalysis/changes
ARG_63783fae-93a4-4cbb-bb28-746b9e0062d1_6caab52f-0b43-4b34-a931-3a4be8408cfc_132709573223190000_132709991312489989 Microsoft.ChangeAnalysis/changes
ARG_8e4b8e63-5039-4552-a710-c7ae939ca5d5_2d066d89-be9d-4ff1-8aea-6894ea6ac5cd_132709572977720000_132709991312389997 Microsoft.ChangeAnalysis/changes
ARG_56379e0a-387c-4a82-bf89-85c5ef8a2197_3d47d3ca-df04-4328-83a9-a9aa4674d50d_132709251496760000_132709356771270000 Microsoft.ChangeAnalysis/changes
ARG_d7f5bba0-bbb1-423b-9104-e29a7417fcad_56173ed6-c09a-4e7a-a45e-1d5d5db60672_132708911330290427_132709252270260000 Microsoft.ChangeAnalysis/changes
ARG_3aba1b22-c4f6-4c11-bb9a-3338ea3119bb_7a15a4cd-7ae3-451c-900e-31da8ccda055_132708911334940487_132709252007650000 Microsoft.ChangeAnalysis/changes
ARG_b2ccb71d-624f-4069-92ca-758f1fda8a83_d76cd7a6-edeb-46f7-88f4-8a5e990f4b46_132708911328490377_132709251682950000 Microsoft.ChangeAnalysis/changes
ARG_da145a0d-cf0e-404c-a19e-d06ce8cea1a3_17adf639-a63f-4b13-8f16-f9f979b5d22d_132709044024690000_132709251657920000 Microsoft.ChangeAnalysis/changes
ARG_8476fa81-cc46-48a2-aa76-e7f6c44e8e95_56379e0a-387c-4a82-bf89-85c5ef8a2197_132708911331540433_132709251496760000 Microsoft.ChangeAnalysis/changes
ARG_c01ccacb-4b92-46bb-adc3-c4149b25a179_204ad6a5-95e8-484c-aa93-59d3144304ac_132708911329890708_132709250915520000 Microsoft.ChangeAnalysis/changes
ARG_c55dc8dc-6b31-4e05-926c-c4d1194fcbc3_dacb205b-3dd6-4c67-bc59-d6ce0789e695_132708911330190400_132709250255420000 Microsoft.ChangeAnalysis/changes
ARG_bd65a427-a683-4c89-bdd2-957596912e47_693e5c36-e7f4-44b0-9806-52d471a818f8_132708911329790438_132709249648610000 Microsoft.ChangeAnalysis/changes
```

This command lists the changes of a subscription within the specified time range.
`StartTime` and `EndTime` are UTC date formats.

### Example 2: List the changes of a resource group within the specified time range
```powershell
$start = Get-Date -Date "2021-07-16T12:09:03.141Z" -AsUTC
$end = Get-Date -Date "2021-07-18T12:09:03.141Z" -AsUTC
Get-AzChangeAnalysis -StartTime $start -EndTime $end -ResourceGroupName azpssmokerg1268133cx4
```

```output
Name                                                                                                                Type
----                                                                                                                ----
ARG_3dd199c6-cfec-421a-bcd3-797c08de63bc_0ee1aacb-523b-40bd-96a0-00fed2f47380_132711384626690000_132712151317657566 Microsoft.ChangeAnalysis/changes
```

This command lists the changes of a resource group within the specified time range.
`StartTime` and `EndTime` are UTC date formats.

### Example 3: List the changes of a resource within the specified time range
```powershell
$start = Get-Date -Date "2021-07-16T12:09:03.141Z" -AsUTC
$end = Get-Date -Date "2021-07-18T12:09:03.141Z" -AsUTC
Get-AzChangeAnalysis -StartTime $start -EndTime $end -ResourceId '/subscriptions/xxxxxx-xxxxx-xxxx-xxxx-xxxxxxf/resourceGroups/azpssmokerg1268133cx4/providers/Microsoft.Storage/storageAccounts/azpssmokesa1268133cx4'
```

```output
Name                                                                                                                Type
----                                                                                                                ----
ARG_3dd199c6-cfec-421a-bcd3-797c08de63bc_0ee1aacb-523b-40bd-96a0-00fed2f47380_132711384626690000_132712151317657566 Microsoft.ChangeAnalysis/changes
```

This command lists the changes of a resource within the specified time range.
`StartTime` and `EndTime` are UTC date formats.
