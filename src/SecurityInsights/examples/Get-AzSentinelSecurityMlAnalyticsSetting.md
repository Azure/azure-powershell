### Example 1: Get list of SecurityMlAnalyticsSetting
```powershell
Get-AzSentinelSecurityMlAnalyticsSetting -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-w4"
```

```output
Etag Kind    Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLa 
                                                                                                                                                                    stModifiedBy 
                                                                                                                                                                    Type
---- ----    ----                                 ------------------- ------------------- ----------------------- ------------------------ ------------------------ ------------ 
     Anomaly f209187f-1d17-4431-94af-c141bf5f23db
     Anomaly b40a7a5b-5d39-46fe-a79e-2acdb38e1ce7
     Anomaly 29094df8-e0c7-4475-a74c-bda74a07affb
     Anomaly 3f8fa297-1fbb-4515-98af-b77be2c873a1
     Anomaly ffe3625d-a933-4f63-b192-7e6ebf3be5fb
     Anomaly c9053c76-c6cd-409a-a10f-e20b05cc91f5
     Anomaly e7277475-4e31-41c7-9997-0b8b3d7f00cd
     Anomaly 622844c2-fc11-4efc-91e6-c05b06ab3008
     Anomaly 543c9254-eb6f-4fdd-858d-783e0e3d5cb9
     Anomaly 9c712bb2-08dc-44d3-b66b-af154dfc1c4f
     Anomaly 200f05a2-db6e-4ff7-be83-bbc30b44755f
     Anomaly 8a12afde-ed27-46ac-a5ef-392e3d4f071f
     Anomaly d7309cb9-b16b-4c7a-9e4b-3e9009bd373d
     Anomaly 1d10c95d-ef32-41cd-aca0-c6a7f4523494
     Anomaly 7e38a3e4-ccb9-4c73-b4ee-290b3bed077c
     Anomaly 95514e77-1b23-4f05-817c-ae363c53aad3
     Anomaly d4f9d54b-6dec-4655-8631-0fa8d4954fea
     Anomaly 0c804654-63b9-4241-89f8-1cddd7e9cacd
     Anomaly c097bfdb-8b4b-4a98-b74d-1871ffd50a03
     Anomaly 9c27cee8-0a33-4abe-8683-212c0a98fc28
     Anomaly 8bada072-c58c-4df3-a17e-e02392b48240
     Anomaly 32686052-5bed-48ef-9ffa-39fc7699f085
     Anomaly 23850aa1-37d3-4b4b-9f39-4ebf5feb59fd
     Anomaly edc946ae-cba8-419f-8e90-309966895956
     Anomaly 8a602940-4153-4045-a741-3bf15591ae29
     Anomaly 16d55bbb-8c54-4c1d-8537-521824e76bb6
     Anomaly 38781e25-924e-4c9d-9a76-8703077be83d
     Anomaly 8595d264-2f64-442d-b293-4e16dffc9882
     Anomaly fc1b7e7a-bc24-42c3-ad67-5c76c8fcb2d6
     Anomaly a3863d8b-8be1-4f52-8ba2-d6cec98b606b
     Anomaly 93c4b361-ea7d-40f4-9ca6-e501cdef9c53
     Anomaly 67722b33-6ac1-485c-ad6f-9418f360d1d5
     Anomaly b783df9c-4088-452e-a791-0c4fca47a109
     Anomaly 61a45b42-5fe8-47ef-9b16-c61e6b76ab8e
     Anomaly c5644575-4982-4a07-8884-b11ec2866dc3
     Anomaly 30dea201-74da-4141-8d21-8a18f0861d60
     Anomaly bb32dc8a-4f6b-4274-a28f-50f3400070b4
     Anomaly 1de6460f-30dc-4e8c-8086-8100d8e2b461
     Anomaly a255ca7d-ea19-4b7b-8d88-a51ce1c72c29
     Anomaly 36f191f8-d1d1-4a22-8ba7-22c9b64a651a
     Anomaly 2bb167bf-3951-435b-a932-8b03bfde0a2b
     Anomaly 3dccf381-2bb2-40c6-81a0-ab878bdf323f
     Anomaly 2d3e33c6-d8e6-4b51-92d6-dbe8bd9efb05
     Anomaly db58d592-4e64-4800-825e-12c09622dd47
     Anomaly 5020e404-9768-4364-98f6-679940c21362
     Anomaly 25bf2f45-1cf0-47d2-b394-a7b331d707b3
     Anomaly 8546330c-e1fb-422a-9388-5c09e9a8f4ca
     Anomaly d0bd9611-2fc1-42cb-af4e-793b6f28ba92
     Anomaly 7faf4218-3769-4f05-bbd1-f32ca00489bb
     Anomaly 06107abb-1b68-4fdc-841b-8a1ff9301467
     Anomaly 03401f05-5c45-4f2d-9295-092764090e02
     Anomaly 1f6d7abe-2cb7-4a4c-aeca-91fe6bfad0b2
     Anomaly 8d19b599-3c58-41ea-8db1-7ed22f80561e
     Anomaly ae9128e8-2740-4b62-8bde-54e62b183fca
     Anomaly af7fd11a-f305-44e1-8f46-f31580a15eab
     Anomaly 213252f1-497c-4124-91da-6cb43902d5b1
     Anomaly 467a1afd-68e1-4b4a-864f-5aa1ae505ad8

```

This command lists SecurityMlAnalyticsSettings.

### Example 2: Get specific SecurityMlAnalyticsSetting with specified resource group and workspace
```powershell
Get-AzSentinelSecurityMlAnalyticsSetting -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-w4" -SettingsResourceName "f209187f-1d17-4431-94af-c141bf5f23db"
```

```output
AnomalySettingsVersion       : 0
AnomalyVersion               : 1.0.5
CustomizableObservation      : {
                               }
Description                  : 
DisplayName                  : Login from unusual region
Enabled                      : False
Etag                         : "0a003319-0000-0300-0000-64d4c4510000"
Frequency                    : 01:00:00
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-w4/provi 
                               ders/Microsoft.SecurityInsights/securityMLAnalyticsSettings/f209187f-1d17-4431-94af-c141bf5f23db
IsDefaultSetting             : True
Kind                         : Anomaly
LastModifiedUtc              : 8/10/2023 11:04:47 AM
Name                         : f209187f-1d17-4431-94af-c141bf5f23db
RequiredDataConnector        : {}
SettingsDefinitionId         : f209187f-1d17-4431-94af-c141bf5f23db
SettingsStatus               : Production
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tactic                       : {}
Technique                    : {}
Type                         : Microsoft.SecurityInsights/securityMLAnalyticsSettings
```

This command gets specific SecurityMlAnalyticsSetting with specified resource group and workspace.

