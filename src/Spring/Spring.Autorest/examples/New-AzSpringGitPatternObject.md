### Example 1: Create an in-memory object for GitPatternRepository.
```powershell
New-AzSpringGitPatternObject -Name "gitPatternName" -Uri "uriString" -HostKey "hostKeyString" -HostKeyAlgorithm "hostKeyAlgorithmString" -Label "labelString" -Password "password" -Pattern "patternString" -PrivateKey "privateKeyString" -SearchPath "searchPathString" -StrictHostKeyChecking:$true -Username "xxx"
```

```output
HostKey               : hostKeyString
HostKeyAlgorithm      : hostKeyAlgorithmString
Label                 : labelString
Name                  : gitPatternName
Password              : password
Pattern               : {patternString}
PrivateKey            : privateKeyString
SearchPath            : {searchPathString}
StrictHostKeyChecking : True
Uri                   : uriString
Username              : xxx
```

Create an in-memory object for GitPatternRepository.