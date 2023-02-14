### Example 1: Get all HealthBot
```powershell
<<<<<<< HEAD
Get-AzHealthBot
```

```output
=======
PS C:\> Get-AzHealthBot

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                 SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType Type
-------- ----                 ------------------- -------------------   ----------------------- ------------------------ ------------------------             ---------------------------- ----
eastus   yourihealthbot       2020/12/29 5:54:14  test@microsoft.com User                    2020/12/29 5:54:19       ********-****-****-****-********** Application                  Microsoft.HealthBot/healthBots
eastus   yourihealthbotmemory 2020/12/29 6:54:32  test@microsoft.com User                    2020/12/29 6:54:36       ********-****-****-****-********** Application                  Microsoft.HealthBot/healthBots
```

Get all HealthBot

### Example 2: Get all HealthBot by ResourceGroupName
```powershell
<<<<<<< HEAD
Get-AzHealthBot -ResourceGroupName youriTest
```

```output
=======
PS C:\> Get-AzHealthBot -ResourceGroupName youriTest

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                 SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType Type
-------- ----                 ------------------- -------------------   ----------------------- ------------------------ ------------------------             ---------------------------- ----
eastus   yourihealthbot       2020/12/29 5:54:14  test@microsoft.com User                    2020/12/29 5:54:19       ********-****-****-****-********** Application                  Microsoft.HealthBot/healthBots
eastus   yourihealthbotmemory 2020/12/29 6:54:32  test@microsoft.com User                    2020/12/29 6:54:36       ********-****-****-****-********** Application                  Microsoft.HealthBot/healthBots
```

Get all HealthBot by ResourceGroupName

### Example 3: Get HealthBot by ResourceGroupName and Name
```powershell
<<<<<<< HEAD
Get-AzHealthBot -ResourceGroupName youriTest -name yourihealthbot
```

```output
=======
PS C:\> Get-AzHealthBot -ResourceGroupName youriTest -name yourihealthbot

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                 SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType Type
-------- ----                 ------------------- -------------------   ----------------------- ------------------------ ------------------------             ---------------------------- ----
eastus   yourihealthbot       2020/12/29 5:54:14  test@microsoft.com User                    2020/12/29 5:54:19       ********-****-****-****-********** Application                  Microsoft.HealthBot/healthBots
```

Get HealthBot by ResourceGroupName and Name

### Example 4: Get HealthBot by InputObject
```powershell
<<<<<<< HEAD
$getAzHealthBot = Get-AzHealthBot -ResourceGroupName youriTest -name yourihealthbot
Get-AzHealthBot -InputObject $getAzHealthBot
```

```output
=======
PS C:\> $getAzHealthBot = Get-AzHealthBot -ResourceGroupName youriTest -name yourihealthbot
Get-AzHealthBot -InputObject $getAzHealthBot

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name                 SystemDataCreatedAt SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType Type
-------- ----                 ------------------- -------------------   ----------------------- ------------------------ ------------------------             ---------------------------- ----
eastus   yourihealthbot       2020/12/29 5:54:14  test@microsoft.com User                    2020/12/29 5:54:19       ********-****-****-****-********** Application                  Microsoft.HealthBot/healthBots
```

Get HealthBot by InputObject
