# Azure/azure-powershell agent package

This repository owns its agents, domain settings, review/title policy, and tooling implementations. Edit `definitions/`, `tools/` and `x.yml` here; the engine discovers the complete package from its approved upstream ref at the start of each loop round.

Agents and tools are discovered from their directories; no file or function inventory is needed in `x.yml`. Put each Python tool module under its owning role in `tools/<role>/`. Functions named with `_` are private; other functions are public. Dedicated execution validators are always private Coordinator tools.

`x.yml` is the only configuration file and uses the same engine-validated schema in every repository. It contains repository identity, a `profile` mapping for workflow/target/routing settings and optional Python pins. Optional feature fields are omitted when unused, not replaced with repository-specific keys or dummy values.

A round and its durable jobs retain the original verified commit and source digest. Candidate edits cannot replace their agents or repository checks. A later upstream commit applies only to a later round. An unavailable enabled package blocks explicitly; it never selects a sibling repository or central implementation as a fallback.

Azure CLI and Extensions started from the same preservation baseline but own independent copies and versions. A shared fix needs separate reviewed commits in both repositories; there is no sibling import, shared mutable cache, or automatic synchronisation.

Authentication, generic helper authorization, operator identities, execution images, generic syntax checks and publication remain central. Do not copy generic C#/PowerShell validation assets into this package. Dependency declarations cannot install software, change those constraints, or remove mandatory checks. The operator may explicitly select `legacy` as a rollback; existing jobs still retain their recorded package or legacy contract.

Validate from an environment with the approved engine installed:

```sh
python -m x_engineering_agent.repository_packages --root .x --repository Azure/azure-powershell --revision "$(git rev-parse HEAD)"
```

Local validation checks the source-only contract; it does not authorize a new runtime ref. Maintain these implementations here rather than regenerating them from central specialist copies.

Onboarding: keep identity, workflow/routing settings under `profile`, and optional Python pins in the single `x.yml`. Put agent definitions in `definitions/` and Python tools under `tools/<role>/`. Do not create a separate `profile.yml`. Do not maintain duplicate agent, tool or file lists. Validation checks under `tools/validation/` are private Coordinator tools.
