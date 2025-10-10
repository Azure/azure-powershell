# SQL SDK Architecture Diagram

## Current State (Az 12.x and earlier)

```
┌─────────────────────────────────────────────────────────────────┐
│                     Az.Sql PowerShell Module                     │
│                                                                   │
│  ┌─────────────────────────┐    ┌──────────────────────────┐   │
│  │   Legacy Features       │    │   Modern Features        │   │
│  │  (15+ cmdlets)          │    │   (100+ cmdlets)         │   │
│  │                         │    │                          │   │
│  │ • ServiceObjective      │    │ • Managed Instances      │   │
│  │ • Communication Links   │    │ • Job Agents             │   │
│  │ • DR Configuration      │    │ • Advanced Threat Prot   │   │
│  │ • Upgrade Hints         │    │ • Ledger Digest          │   │
│  │ • Index Recommendations │    │ • Failover Groups        │   │
│  │ • Pool Recommendations  │    │ • Modern Databases       │   │
│  └───────────┬─────────────┘    └────────────┬─────────────┘   │
│              │                                │                  │
│              │                                │                  │
│     ┌────────▼──────────┐          ┌─────────▼──────────┐      │
│     │  Sql.LegacySdk    │          │ Sql.Management.Sdk │      │
│     │                   │          │                    │      │
│     │ • Hyak.Common     │          │ • Microsoft.Rest   │      │
│     │ • 33 operations   │          │ • 95+ operations   │      │
│     │ • API: 2014-04-01 │          │ • API: 2021+       │      │
│     └────────┬──────────┘          └─────────┬──────────┘      │
│              │                                │                  │
└──────────────┼────────────────────────────────┼──────────────────┘
               │                                │
               │                                │
       ┌───────▼────────┐              ┌───────▼────────┐
       │  Azure SQL API │              │  Azure SQL API │
       │  (Deprecated)  │              │   (Modern)     │
       │  2014-04-01    │              │   2021+        │
       └────────────────┘              └────────────────┘
```

## Target State (Az 14.x - Future)

```
┌─────────────────────────────────────────────────────────────────┐
│                     Az.Sql PowerShell Module                     │
│                                                                   │
│  ┌───────────────────────────────────────────────────────────┐  │
│  │              All Features (Modern)                        │  │
│  │              (100+ cmdlets)                               │  │
│  │                                                           │  │
│  │  • Managed Instances      • Databases                    │  │
│  │  • Job Agents            • Elastic Pools                 │  │
│  │  • Advanced Threat Prot  • Failover Groups               │  │
│  │  • Ledger Digest         • Replication                   │  │
│  │  • Sensitivity Labels    • Security                      │  │
│  │  • Vulnerability Assess  • Auditing                      │  │
│  │                                                           │  │
│  │  (Legacy cmdlets removed - see migration guide)          │  │
│  └───────────────────────────┬───────────────────────────────┘  │
│                              │                                   │
│                     ┌────────▼──────────┐                       │
│                     │ Sql.Management.Sdk│                       │
│                     │                   │                       │
│                     │ • Microsoft.Rest  │                       │
│                     │ • 95+ operations  │                       │
│                     │ • API: 2021+      │                       │
│                     └────────┬──────────┘                       │
│                              │                                   │
└──────────────────────────────┼───────────────────────────────────┘
                               │
                       ┌───────▼────────┐
                       │  Azure SQL API │
                       │   (Modern)     │
                       │   2021+        │
                       └────────────────┘
```

## Migration Timeline

```
Current              Az 12.x              Az 13.x              Az 14.x
  │                    │                    │                    │
  │                    │                    │                    │
  ├─ Both SDKs        ├─ Both SDKs        ├─ Both SDKs        ├─ Management.Sdk
  │  No warnings      │  + Warnings        │  + Strong Warn     │    ONLY
  │                    │  + Migration       │  + Monitor usage   │  - LegacySdk
  │                    │    guides          │                    │  - Legacy cmdlets
  │                    │                    │                    │
  ▼                    ▼                    ▼                    ▼
Now                 3-6 mo              6-12 mo             18-24 mo
```

## Data Flow Comparison

### LegacySdk Flow (Current)

```
PowerShell Cmdlet
      │
      ├─> Adapter Layer
      │        │
      │        ├─> Communicator
      │                 │
      │                 ├─> Sql.LegacySdk
      │                          │
      │                          ├─> Hyak.Common HttpClient
      │                                   │
      │                                   └─> Azure SQL API 2014-04-01
      │
      └─> [Response] ─> Model ─> PSObject
```

### Management.Sdk Flow (Modern)

```
PowerShell Cmdlet
      │
      ├─> Adapter Layer
      │        │
      │        ├─> Communicator
      │                 │
      │                 ├─> Sql.Management.Sdk
      │                          │
      │                          ├─> Microsoft.Rest HttpClient
      │                                   │
      │                                   └─> Azure SQL API 2021+
      │
      └─> [Response] ─> Model ─> PSObject
```

## Operation Coverage Venn Diagram

```
        ┌──────────────────────────────────────┐
        │                                      │
        │        LegacySdk Operations          │
        │                                      │
        │  ┌────────────────────────────┐     │
        │  │                            │     │
        │  │  Shared Operations:        │     │
        │  │  • Databases (old API)     │     │
        │  │  • Elastic Pools (old)     │     │
        │  │  • Failover Groups (old)   │     │
        │  │  • Firewall Rules (old)    │     │
        │  │  • Replication (old)       │     │
        │  │  • Auditing (old)          │     │
        │  │  • Transparent Data Enc    │     │
        │  │                            │     │
        │  └────────────────────────────┘     │
        │                                      │
        │  Unique to Legacy:                   │
        │  • ServiceObjective                  │
        │  • ServiceTierAdvisor                │
        │  • ServerCommunicationLink           │
        │  • ServerDisasterRecoveryConfig      │
        │  • ServerUpgrade                     │
        │  • RecommendedElasticPool            │
        │  • RecommendedIndex                  │
        │  • DatabaseActivation                │
        │                                      │
        └──────────────────────────────────────┘

                         ┌─────────────────────────────────────┐
                         │                                     │
                         │   Management.Sdk Operations         │
                         │                                     │
                         │  ┌─────────────────────────────┐   │
                         │  │                             │   │
                         │  │  Shared Operations:         │   │
                         │  │  • Databases (new API)      │   │
                         │  │  • Elastic Pools (new)      │   │
                         │  │  • Failover Groups (new)    │   │
                         │  │  • Firewall Rules (new)     │   │
                         │  │  • Replication (new)        │   │
                         │  │  • Auditing (new)           │   │
                         │  │  • Transparent Data Enc     │   │
                         │  │                             │   │
                         │  └─────────────────────────────┘   │
                         │                                     │
                         │  Unique to Modern:                  │
                         │  • Managed Instances (40+ ops)      │
                         │  • Job Agents (10+ ops)             │
                         │  • Advanced Threat Protection       │
                         │  • Ledger Digest Uploads            │
                         │  • Sensitivity Labels               │
                         │  • Vulnerability Assessments        │
                         │  • IPv6 Firewall Rules              │
                         │  • Server Trust Groups              │
                         │  • ... and 35+ more                 │
                         │                                     │
                         └─────────────────────────────────────┘
```

## Dependency Graph

```
Az.Sql Module
    │
    ├─── Modern Cmdlets (100+)
    │        │
    │        └──> Sql.Management.Sdk
    │                  │
    │                  └──> Microsoft.Rest
    │                           │
    │                           └──> Azure SQL Modern APIs
    │
    └─── Legacy Cmdlets (15+)
             │
             └──> Sql.LegacySdk
                      │
                      └──> Hyak.Common
                               │
                               └──> Azure SQL Deprecated APIs
```

## Breaking Change Impact

```
If we remove LegacySdk TODAY:

┌────────────────────────────────────────┐
│   Broken Cmdlets (15+)                 │
├────────────────────────────────────────┤
│ ✗ Get-AzSqlServerServiceObjective      │
│ ✗ Get-AzSqlUpgradeDatabaseHint         │
│ ✗ Get-AzSqlUpgradeServerHint           │
│ ✗ New-AzSqlServerCommunicationLink     │
│ ✗ Get-AzSqlServerCommunicationLink     │
│ ✗ Remove-AzSqlServerCommunicationLink  │
│ ✗ New-AzSqlServerDRConfiguration       │
│ ✗ Get-AzSqlServerDRConfiguration       │
│ ✗ Set-AzSqlServerDRConfiguration       │
│ ✗ Remove-AzSqlServerDRConfiguration    │
│ ✗ Get-AzSqlServerDRConfigActivity      │
│ ✗ Get-AzSqlElasticPoolRecommendation   │
│ ✗ [Index recommendation cmdlets]       │
│ ✗ [Database activation cmdlets]        │
│ ✗ [Server upgrade cmdlets]             │
└────────────────────────────────────────┘
                  │
                  ▼
┌────────────────────────────────────────┐
│   Customer Impact                      │
├────────────────────────────────────────┤
│ • Broken automation scripts            │
│ • No warning or migration period       │
│ • Production incidents                 │
│ • Support tickets                      │
│ • Customer frustration                 │
└────────────────────────────────────────┘
```

---

**See also:**
- [Full Analysis](./sql-sdk-comparison-analysis.md)
- [Executive Summary](./sql-sdk-comparison-summary.md)
- [Feature Matrix](./sql-sdk-feature-matrix.md)
