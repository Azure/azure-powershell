### Example 1: Install assess patches
```powershell
Install-AzConnectedMachinePatch -ResourceGroupName az-sdk-test -Name testMachine -MaximumDuration 'PT4H' -RebootSetting 'IfRequired' -WindowParameterClassificationsToInclude 'Critical'
```

```output
ExcludedPatchCount FailedPatchCount InstallationActivityId               InstalledPatchCount LastModifiedDateTime Maint
                                                                                                                  enanc
                                                                                                                  eWind
                                                                                                                  owExc
                                                                                                                  eeded
------------------ ---------------- ----------------------               ------------------- -------------------- -----
0                  0                ********-****-****-****-********** 0                   7/28/2023 7:55:08 AM  False
```

Install machine patches.
