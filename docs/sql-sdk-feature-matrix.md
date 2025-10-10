# SQL SDK Feature Matrix

## Quick Reference: Which SDK for Which Feature?

| Feature Category | LegacySdk | Management.Sdk | Notes |
|------------------|-----------|----------------|-------|
| **Core Database Operations** | ✅ (old) | ✅ (modern) | Use Management.Sdk |
| **Elastic Pools** | ✅ (old) | ✅ (modern) | Use Management.Sdk |
| **Firewall Rules** | ✅ (old) | ✅ (modern) | Use Management.Sdk |
| **Managed Instances** | ❌ | ✅ | Management.Sdk only |
| **Job Agents** | ❌ | ✅ | Management.Sdk only |
| **Service Objectives** | ✅ | ❌ | **LegacySdk only** |
| **Service Tier Advisor** | ✅ | ❌ | **LegacySdk only** |
| **Server Communication Link** | ✅ | ❌ | **LegacySdk only** |
| **Server DR Configuration** | ✅ | ❌ | **LegacySdk only** |
| **Server Upgrade** | ✅ | ❌ | **LegacySdk only** |
| **Recommended Elastic Pools** | ✅ | ❌ | **LegacySdk only** |
| **Index Recommendations** | ✅ | ❌ | **LegacySdk only** |
| **Database Activation (DW)** | ✅ | Partial | LegacySdk for legacy |
| **Failover Groups** | ✅ (old) | ✅ (modern) | Use Management.Sdk |
| **Replication Links** | ✅ (old) | ✅ (modern) | Use Management.Sdk |
| **Auditing** | ✅ (old) | ✅ (modern) | Use Management.Sdk |
| **Advanced Threat Protection** | ❌ | ✅ | Management.Sdk only |
| **Vulnerability Assessments** | ❌ | ✅ | Management.Sdk only |
| **Sensitivity Labels** | ❌ | ✅ | Management.Sdk only |
| **Ledger Digest Uploads** | ❌ | ✅ | Management.Sdk only |
| **IPv6 Firewall Rules** | ❌ | ✅ | Management.Sdk only |

## Legend
- ✅ = Supported
- ❌ = Not Supported
- Partial = Some functionality available

---

## Cmdlets by SDK Dependency

### Cmdlets ONLY Using LegacySdk (Must Keep Until Removed)

| Cmdlet | Feature | Modern Alternative |
|--------|---------|-------------------|
| `Get-AzSqlServerServiceObjective` | Service Objectives | `Get-AzSqlCapability` or Portal |
| `Get-AzSqlUpgradeDatabaseHint` | Service Tier Advisor | Azure Portal reports |
| `Get-AzSqlUpgradeServerHint` | Service Tier Advisor | Azure Portal reports |
| `New-AzSqlServerCommunicationLink` | Server Comm Link | `New-AzSqlDatabaseFailoverGroup` |
| `Get-AzSqlServerCommunicationLink` | Server Comm Link | `Get-AzSqlDatabaseFailoverGroup` |
| `Remove-AzSqlServerCommunicationLink` | Server Comm Link | `Remove-AzSqlDatabaseFailoverGroup` |
| `New-AzSqlServerDisasterRecoveryConfiguration` | DR Configuration | `New-AzSqlDatabaseFailoverGroup` |
| `Get-AzSqlServerDisasterRecoveryConfiguration` | DR Configuration | `Get-AzSqlDatabaseFailoverGroup` |
| `Set-AzSqlServerDisasterRecoveryConfiguration` | DR Configuration | `Set-AzSqlDatabaseFailoverGroup` |
| `Remove-AzSqlServerDisasterRecoveryConfiguration` | DR Configuration | `Remove-AzSqlDatabaseFailoverGroup` |
| `Get-AzSqlServerDisasterRecoveryConfigurationActivity` | DR Configuration | Failover Group operations |
| `Get-AzSqlElasticPoolRecommendation` | Recommended Pools | Azure Advisor |
| Index recommendation cmdlets | Index Recommendations | Azure Advisor |
| Database activation cmdlets | Pause/Resume DW | Modern DW operations |
| Server upgrade cmdlets | Server Upgrades | Portal-based upgrades |

### Cmdlets Using BOTH SDKs (Complex Migration)

| Cmdlet Category | Legacy Usage | Modern Usage | Migration Status |
|-----------------|--------------|--------------|------------------|
| Data Sync | Legacy sync operations | Modern sync groups | Partial overlap |
| Databases | Some legacy operations | Primary modern operations | Mostly migrated |
| Firewall Rules | Legacy CRUD | Modern CRUD | Can migrate |
| Failover Groups | Legacy operations | Modern operations | Can migrate |

### Cmdlets ONLY Using Management.Sdk (Modern)

- All Managed Instance cmdlets (40+)
- All Job Agent cmdlets (10+)
- Advanced Threat Protection cmdlets
- Vulnerability Assessment cmdlets
- Sensitivity Label cmdlets
- Ledger Digest Upload cmdlets
- Modern security and compliance features

---

## API Version Mapping

| LegacySdk API | Management.Sdk API | Feature Set |
|---------------|-------------------|-------------|
| 2014-04-01 | ➡️ 2014-04-01-preview | Basic operations |
| 2014-04-01 | ➡️ 2017-03-01-preview | Databases, Elastic Pools |
| 2015-05-01-preview | ➡️ 2020-11-01-preview | Managed Instances |
| 2015-05-01-preview | ➡️ 2021-11-01 | Modern features |
| *(No equivalent)* | ➡️ 2022-05-01-preview | Latest features |

---

## Decision Tree: Which SDK Should New Features Use?

```
Is this a NEW feature?
│
├─ YES ──➡️ Use Management.Sdk
│           (Modern framework, active development)
│
└─ NO ── Is the feature deprecated by Azure?
         │
         ├─ YES ─➡️ Keep using LegacySdk
         │          (Backward compatibility)
         │
         └─ NO ── Does it have a modern API?
                  │
                  ├─ YES ─➡️ Migrate to Management.Sdk
                  │          (Better long-term support)
                  │
                  └─ NO ─➡️ Keep using LegacySdk
                            (No alternative available)
```

---

## Migration Checklist for Teams

When planning to remove LegacySdk:

### Phase 1: Assessment
- [ ] Identify all cmdlets using LegacySdk (75 files identified)
- [ ] Categorize by migration complexity
- [ ] Document customer usage patterns (if telemetry available)
- [ ] Create migration guide for each deprecated cmdlet

### Phase 2: Deprecation
- [ ] Add `[Obsolete]` attributes with clear messages
- [ ] Update help documentation with warnings
- [ ] Create blog post announcing deprecation
- [ ] Update Azure PowerShell documentation
- [ ] Monitor customer feedback

### Phase 3: Communication
- [ ] Announce in release notes (Az 12.x)
- [ ] Update migration guide based on feedback
- [ ] Provide example scripts for common scenarios
- [ ] Offer support through GitHub issues

### Phase 4: Removal
- [ ] Wait minimum 18-24 months from deprecation
- [ ] Verify telemetry shows declining usage
- [ ] Remove LegacySdk project reference
- [ ] Delete deprecated cmdlets
- [ ] Update all tests
- [ ] Clean up codebase

---

## Customer Impact by Scenario

| Customer Scenario | Impact | Migration Effort | Timeline |
|-------------------|--------|------------------|----------|
| Basic database management | Low | Easy | Immediate |
| Elastic pool operations | Low | Easy | Immediate |
| Using Service Objectives | High | Medium | Az 12-14 |
| Using Communication Links | High | Medium | Az 12-14 |
| Using DR Configuration | High | Medium | Az 12-14 |
| Using upgrade hints | Medium | Easy | Az 12-14 |
| Using index recommendations | Medium | Medium | Az 12-14 |

---

## Resources

- **Full Analysis**: [sql-sdk-comparison-analysis.md](./sql-sdk-comparison-analysis.md)
- **Executive Summary**: [sql-sdk-comparison-summary.md](./sql-sdk-comparison-summary.md)
- **Azure SQL Documentation**: https://docs.microsoft.com/azure/azure-sql/
- **Failover Groups Guide**: https://docs.microsoft.com/azure/azure-sql/database/failover-group-overview

---

**Last Updated**: 2025-10-10  
**Version**: 1.0
