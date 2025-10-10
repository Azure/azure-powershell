# SQL SDK Comparison - Executive Summary

## Question
**Can we remove Sql.LegacySdk and use only Sql.Management.Sdk?**

## Answer
**NO - Not without breaking changes to existing cmdlets**

---

## Quick Facts

| Aspect | Sql.LegacySdk | Sql.Management.Sdk |
|--------|---------------|-------------------|
| Framework | Hyak.Common (deprecated) | Microsoft.Rest (modern) |
| API Version | 2014-04-01, 2015-05-01 | 2021+ (multiple) |
| Operations | 33 types | 95+ types |
| Files | 66 | 190 |
| Status | Maintenance only | Active development |
| References in Sql module | 211 | Extensive |

---

## Why LegacySdk Still Exists

### Primary Reason: **Backward Compatibility**

The LegacySdk supports **8 deprecated Azure SQL operations** that have no modern API equivalents:

1. **ServiceObjective** - List available database performance tiers
2. **ServiceTierAdvisor** - Get upgrade recommendations  
3. **ServerCommunicationLink** - Cross-subscription geo-replication
4. **ServerDisasterRecoveryConfiguration** - Legacy DR setup
5. **ServerUpgrade** - Server version upgrades
6. **RecommendedElasticPool** - Elastic pool recommendations
7. **RecommendedIndex** - Database index recommendations
8. **DatabaseActivation** - Pause/Resume Data Warehouse

### Impact
- **75 C# files** depend on LegacySdk
- **15+ cmdlets** would break if LegacySdk is removed
- **Unknown number** of customer scripts rely on these cmdlets

---

## Recommended Actions

### ✅ Keep LegacySdk (Current State)
- Maintain backward compatibility
- Support existing customer scripts
- Continue maintenance for critical fixes

### ⚠️ Deprecate Legacy Cmdlets (Next Release - Az 12.x)
Add `[Obsolete]` warnings:
```csharp
[Obsolete("This cmdlet uses deprecated Azure SQL API. Use Failover Groups instead. Will be removed in Az 14.0.")]
public class GetAzSqlServerCommunicationLinkCommand : AzureSqlServerCommunicationLinkCmdletBase
```

### 🗑️ Remove LegacySdk (Future Release - Az 14.0+)
After appropriate deprecation period:
- Remove Sql.LegacySdk project
- Remove 75 dependent files
- Remove legacy cmdlets
- Clean up 211 references

---

## Migration Timeline

```
Az 12.x (Now)          Az 13.x (6-12 mo)      Az 14.x (18-24 mo)
    │                        │                        │
    ├─ Keep LegacySdk       ├─ Keep LegacySdk       ├─ REMOVE LegacySdk
    ├─ Add warnings         ├─ Increase warnings    ├─ Delete project
    └─ Document migration   └─ Monitor usage        └─ Remove cmdlets
```

---

## Modern Alternatives

| Legacy Operation | Modern Alternative |
|------------------|-------------------|
| ServiceObjective | `Get-AzSqlCapability` or Azure Portal |
| ServerCommunicationLink | `*-AzSqlDatabaseFailoverGroup` |
| ServerDisasterRecoveryConfiguration | `*-AzSqlDatabaseFailoverGroup` |
| UpgradeHints | Azure Portal upgrade reports |
| RecommendedElasticPool | Azure Advisor recommendations |

---

## Key Takeaways

1. **Cannot remove immediately** - would break customer scripts
2. **Deprecation path exists** - modern alternatives available for most scenarios
3. **Timeline is reasonable** - 18-24 months allows customer migration
4. **Benefits are clear** - reduce maintenance, simplify codebase
5. **Risk is manageable** - well-defined scope, clear migration path

---

## Detailed Analysis

For complete analysis, see: [sql-sdk-comparison-analysis.md](./sql-sdk-comparison-analysis.md)

---

**Recommendation**: Proceed with deprecation warnings in Az 12.x, plan removal for Az 14.x
