### Example 1: Create MatchCondition Object for WAF policy creation
```powershell
New-AzFrontDoorWafMatchConditionObject -MatchVariable RequestHeader -OperatorProperty Contains -Selector "User-Agent" -MatchValue "Windows"
```

```output
MatchValue       : {Windows}
MatchVariable    : RequestHeader
NegateCondition  :
OperatorProperty : Contains
Selector         : User-Agent
Transform        :

```

Create MatchCondition Object for WAF policy creation

### Example 2: Create MatchCondition Object for WAF policy creation

```powershell
New-AzFrontDoorWafMatchConditionObject -MatchVariable RequestHeader -OperatorProperty Contains -Selector "User-Agent" -MatchValue "WINDOWS" -Transform Uppercase
```

```output
MatchValue       : {WINDOWS}
MatchVariable    : RequestHeader
NegateCondition  :
OperatorProperty : Contains
Selector         : User-Agent
Transform        : {Uppercase}
```

Create a MatchCondition object