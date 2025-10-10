# Azure PowerShell SQL SDK Analysis Documentation

This directory contains analysis and documentation comparing the two SQL SDKs used in the Az.Sql PowerShell module.

## Documents

### 📄 [SQL SDK Comparison - Executive Summary](./sql-sdk-comparison-summary.md)
**Quick 5-minute read** answering the key question: "Can we remove the legacy SDK?"

- ✅ Quick facts comparison table
- ✅ Simple yes/no answer with rationale
- ✅ Recommended actions and timeline
- ✅ Key takeaways

**Start here** if you need a quick answer.

---

### 📊 [SQL SDK Feature Matrix](./sql-sdk-feature-matrix.md)
**Quick reference guide** for developers and architects.

- ✅ Feature-by-feature comparison table
- ✅ Cmdlets organized by SDK dependency
- ✅ API version mapping
- ✅ Decision tree for choosing SDK
- ✅ Migration checklist

**Use this** when deciding which SDK to use for a feature or planning migrations.

---

### 📖 [SQL SDK Comparison Analysis (Full)](./sql-sdk-comparison-analysis.md)
**Complete technical analysis** with detailed recommendations.

- ✅ Technical architecture comparison
- ✅ Complete API coverage analysis
- ✅ Detailed usage statistics
- ✅ Migration paths with code examples
- ✅ Impact assessment
- ✅ Phased removal plan
- ✅ Complete operation lists

**Read this** for complete understanding and planning detailed migrations.

---

### 📐 [SQL SDK Architecture Diagrams](./sql-sdk-architecture-diagram.md)
**Visual representation** of SDK architecture and relationships.

- ✅ Current vs target state diagrams
- ✅ Migration timeline visualization
- ✅ Data flow comparison
- ✅ Operation coverage Venn diagrams
- ✅ Dependency graphs
- ✅ Breaking change impact visualization

**Use this** to understand the architecture visually and communicate with stakeholders.

---

## Quick Answer

### Can we remove Sql.LegacySdk?

**NO** - Not without breaking changes.

The legacy SDK supports **8 deprecated Azure SQL operations** that have no modern API equivalents. These operations are used by **15+ cmdlets** across **75 files** in the codebase.

### What should we do?

**Short-term (Az 12.x)**: Add deprecation warnings  
**Medium-term (Az 13.x)**: Monitor usage and refine guidance  
**Long-term (Az 14.x)**: Remove after 18-24 month deprecation period

---

## Key Statistics

| Metric | Sql.LegacySdk | Sql.Management.Sdk |
|--------|---------------|-------------------|
| **Framework** | Hyak.Common (deprecated) | Microsoft.Rest (modern) |
| **API Version** | 2014-04-01 | 2021+ (multiple) |
| **Operations** | 33 types | 95+ types |
| **Files** | 66 | 190 |
| **References** | 211 in Az.Sql | Extensive |
| **Status** | Maintenance only | Active development |

---

## Critical Dependencies (LegacySdk Only)

These operations **ONLY** exist in LegacySdk:

1. **ServiceObjective** - Get-AzSqlServerServiceObjective
2. **ServiceTierAdvisor** - Get-AzSqlUpgrade*Hint  
3. **ServerCommunicationLink** - *-AzSqlServerCommunicationLink
4. **ServerDisasterRecoveryConfiguration** - *-AzSqlServerDisasterRecoveryConfiguration
5. **ServerUpgrade** - Server upgrade operations
6. **RecommendedElasticPool** - Get-AzSqlElasticPoolRecommendation
7. **RecommendedIndex** - Index recommendation cmdlets
8. **DatabaseActivation** - Pause/Resume Data Warehouse

---

## Migration Alternatives

| Legacy Feature | Modern Alternative |
|----------------|-------------------|
| Service Objectives | `Get-AzSqlCapability` or Azure Portal |
| Communication Links | `*-AzSqlDatabaseFailoverGroup` |
| DR Configuration | `*-AzSqlDatabaseFailoverGroup` |
| Upgrade Hints | Azure Portal upgrade reports |
| Elastic Pool Recommendations | Azure Advisor |

---

## Timeline

```
Now (Az 12.x)          6-12 months (Az 13.x)    18-24 months (Az 14.x)
     │                          │                          │
     ├─ Keep both SDKs         ├─ Keep both SDKs          ├─ REMOVE LegacySdk
     ├─ Add warnings           ├─ Increase warnings       ├─ Delete project
     └─ Create guides          └─ Monitor usage           └─ Remove cmdlets
```

---

## For More Information

- **Full Analysis**: See [sql-sdk-comparison-analysis.md](./sql-sdk-comparison-analysis.md)
- **Quick Reference**: See [sql-sdk-feature-matrix.md](./sql-sdk-feature-matrix.md)
- **Azure SQL Docs**: https://docs.microsoft.com/azure/azure-sql/

---

## Analysis Metadata

- **Created**: 2025-10-10
- **Version**: 1.0
- **Scope**: Az.Sql module SDK architecture
- **Method**: Repository code analysis, API comparison, usage statistics

---

## Contributing

If you find issues or have suggestions for this analysis:

1. Check the [full analysis document](./sql-sdk-comparison-analysis.md) for details
2. Open an issue with your findings
3. Update documentation as the situation evolves

This analysis is based on the current state of the repository. As Azure SQL APIs and the PowerShell module evolve, this analysis should be periodically reviewed and updated.
