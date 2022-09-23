### Example 1: List all environment containers under a workspace
```powershell
Get-AzMLWorkspaceEnvironmentContainer  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01
```

```output
Name                                                             SystemDataCreatedAt   SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy            SystemDataLastModifiedByType ResourceGroupName
----                                                             -------------------   -------------------                 ----------------------- ------------------------ ------------------------            ---------------------------- -----------------
pwshenv01                                                        5/11/2022 2:31:25 AM  Lucas Yao (Wicresoft North America) User                    5/11/2022 2:31:25 AM     Lucas Yao (Wicresoft North America) User                         ml-rg-test
lightgbm-environment                                             5/5/2022 2:25:41 AM   Lucas Yao (Wicresoft North America) User                    5/5/2022 2:25:41 AM      Lucas Yao (Wicresoft North America) User                         ml-rg-test
env04                                                            5/5/2022 2:13:02 AM   Lucas Yao (Wicresoft North America) User                    5/5/2022 2:13:02 AM      Lucas Yao (Wicresoft North America) User                         ml-rg-test
env03                                                            5/5/2022 2:11:34 AM   Lucas Yao (Wicresoft North America) User                    5/5/2022 2:11:34 AM      Lucas Yao (Wicresoft North America) User                         ml-rg-test
env02                                                            5/5/2022 2:11:08 AM   Lucas Yao (Wicresoft North America) User                    5/5/2022 2:11:08 AM      Lucas Yao (Wicresoft North America) User                         ml-rg-test
env01                                                            5/5/2022 2:10:35 AM   Lucas Yao (Wicresoft North America) User                    5/5/2022 2:10:35 AM      Lucas Yao (Wicresoft North America) User                         ml-rg-test
docker-image-example                                             5/5/2022 1:57:13 AM   Lucas Yao (Wicresoft North America) User                    5/5/2022 1:57:13 AM      Lucas Yao (Wicresoft North America) User                         ml-rg-test
test                                                             5/5/2022 1:51:43 AM   Lucas Yao                           User                    5/5/2022 1:51:43 AM      Lucas Yao                           User                         ml-rg-test
AzureML-responsibleai-0.18-ubuntu20.04-py38-cpu                  5/18/2022 11:07:16 PM Microsoft                           User                    5/18/2022 11:07:16 PM    Microsoft                           User                         ml-rg-test
```

List all environment containers under a workspace

### Example 2: Gets a environment container by name
```powershell
Get-AzMLWorkspaceEnvironmentContainer  -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-portal01 -Name pwshenv01
```

```output
Name      SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy            SystemDataLastModifiedByType ResourceGroupName
----      -------------------  -------------------                 ----------------------- ------------------------ ------------------------            ---------------------------- -----------------
pwshenv01 5/11/2022 2:31:25 AM Lucas Yao (Wicresoft North America) User                    5/11/2022 2:31:25 AM     Lucas Yao (Wicresoft North America) User                         ml-rg-test
```

Gets a environment container by name
