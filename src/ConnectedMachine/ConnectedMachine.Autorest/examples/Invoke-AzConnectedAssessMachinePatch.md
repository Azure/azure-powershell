### Example 1: Invoke assess patches
```powershell
Invoke-AzConnectedAssessMachinePatch -Name testMachine -ResourceGroupName az-sdk-test
```

```output
AssessmentActivityId                 LastModifiedDateTime OSType  PatchServiceUsed RebootPending StartDateTime       StartedBy  Status
--------------------                 -------------------- ------  ---------------- ------------- -------------       ---------  ------
********-****-****-****-********** 8/2/2023 7:59:25 AM  Windows WU               False         7/28/2023 7:56:18 AM User      Succeed
```
Invoke machine patches.

