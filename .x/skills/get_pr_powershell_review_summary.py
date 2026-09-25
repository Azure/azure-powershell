"""Select evidence-backed Azure PowerShell review rules."""


def get_pr_powershell_review_summary(pr_number):
    """Return confirmed findings, semantic checks and missing review context."""
    repository = "Azure/azure-powershell"
    pr = get_pr(owner="Azure", repo="azure-powershell", pr_number=pr_number)
    changes = get_pr_file_changes(
        owner="Azure", repo="azure-powershell", pr_number=pr_number,
    )
    head_sha = (pr.get("head") or {}).get("sha")
    base_sha = (pr.get("base") or {}).get("sha")
    if not head_sha or not base_sha:
        raise ValueError("PowerShell review requires the PR base and head SHAs.")

    paths = []
    module_files = []
    production_files = []
    code_files = []
    test_files = []
    help_files = []
    manifest_files = []
    changelog_files = []
    generated_files = []
    autorest_files = []
    dependency_files = []
    formatting_files = []
    suppression_files = []
    projects = {}
    modules = {}
    findings = []
    context_gaps = []

    def added_lines(change):
        line_number = None
        for line in str(change.get("patch") or "").splitlines():
            if line.startswith("@@ "):
                fields = line.split()
                if len(fields) >= 4 and fields[2].startswith("+"):
                    start = fields[2][1:].split(",")[0]
                    line_number = int(start) if start.isdigit() else None
                else:
                    line_number = None
            elif line_number is not None:
                if line.startswith("+"):
                    yield line_number, line[1:]
                    line_number += 1
                elif line.startswith(" "):
                    line_number += 1

    for change in changes:
        if not isinstance(change, dict) or not isinstance(
            change.get("filename"), str,
        ) or not change["filename"]:
            raise ValueError("PR file changes must contain a filename.")
        filename = change["filename"].replace("\\", "/")
        related_paths = [filename]
        previous = change.get("previous_filename")
        if previous:
            related_paths.append(previous.replace("\\", "/"))
        for path in related_paths:
            if path in paths:
                continue
            paths.append(path)
            parts = path.split("/")
            lowered = path.casefold()
            folded_parts = [part.casefold() for part in parts]
            name = folded_parts[-1]
            if lowered.startswith("generated/"):
                generated_files.append(path)
            if (
                len(parts) >= 4
                and folded_parts[0] in {"src", "generated"}
                and folded_parts[2].endswith(".autorest")
            ):
                autorest_files.append(path)
                root = "/".join(parts[:3])
                projects[root] = {
                    "path": root,
                    "module": parts[1],
                    "kind": "autorest",
                    "source": "unverified",
                }
            if (
                lowered.startswith("tools/localfeed/")
                or name.endswith((".csproj", ".props", ".targets"))
            ):
                dependency_files.append(path)
            if name.endswith(".ps1xml"):
                formatting_files.append(path)
            if lowered.startswith("tools/staticanalysis/") and name.endswith(
                "issues.csv",
            ):
                suppression_files.append(path)
            if len(parts) < 3 or folded_parts[0] != "src":
                continue
            module_files.append(path)
            modules.setdefault(folded_parts[1], parts[1])
            is_autorest = folded_parts[2].endswith(".autorest")
            is_test_tree = (
                folded_parts[2].endswith((".test", ".tests"))
                or folded_parts[2] == "livetests"
                or (
                    is_autorest
                    and len(parts) >= 5
                    and folded_parts[3] in {"test", "tests"}
                )
            )
            is_documentation = (
                name.endswith((".md", ".rst", ".txt"))
                or (
                    len(parts) >= 5
                    and folded_parts[3] in {"help", "docs", "examples"}
                )
            )
            if len(parts) >= 4 and not is_autorest and not is_test_tree:
                root = "/".join(parts[:3])
                projects[root] = {
                    "path": root,
                    "module": parts[1],
                    "kind": "non-autorest",
                }
            if is_test_tree:
                test_files.append(path)
            elif not is_documentation:
                production_files.append(path)
                if name.endswith((".cs", ".ps1", ".psm1")):
                    code_files.append(path)
            if (
                not is_test_tree
                and len(parts) >= 5
                and name.endswith(".md")
                and (
                    folded_parts[3] == "help"
                    or (
                        is_autorest
                        and len(parts) == 5
                        and folded_parts[3] in {"docs", "examples"}
                        and "-" in name
                    )
                )
            ):
                help_files.append(path)
            if not is_test_tree and name == "changelog.md":
                changelog_files.append(path)
            if (
                not is_test_tree
                and name.startswith("az.")
                and name.endswith(".psd1")
            ):
                manifest_files.append(path)

        if filename in help_files:
            for line_number, text in added_lines(change):
                placeholders = [
                    " ".join(fragment.split("}}", 1)[0].split()).casefold()
                    for fragment in text.split("{{")[1:]
                    if "}}" in fragment
                ]
                if any(
                    description.startswith("fill ")
                    and description != "fill progressaction description"
                    for description in placeholders
                ):
                    findings.append({
                        "rule_id": "ps-help-placeholder",
                        "skill": "command-help",
                        "skill_title": "PowerShell help and examples",
                        "mode": "deterministic",
                        "severity": "blocking",
                        "file": filename,
                        "line": line_number,
                        "summary": "Added help still contains a platyPS placeholder.",
                        "remediation": (
                            "Replace the placeholder with the actual parameter, "
                            "behavior or output description."
                        ),
                        "verification": (
                            "Regenerate the affected help and confirm its "
                            "descriptions and examples match the cmdlet."
                        ),
                    })

    files_complete = pr.get("changed_files") == len(changes)
    if not files_complete:
        context_gaps.append({
            "rule_id": "ps-change-context",
            "summary": "The changed-file list is not confirmed complete.",
            "required_evidence": (
                "A file list for this head matching the PR changed_files count; "
                "do not conclude that unlisted artifacts or tests are absent."
            ),
        })
    context_files = set(
        code_files + test_files + help_files + changelog_files + manifest_files
        + dependency_files + formatting_files + suppression_files
    )
    incomplete_patches = [
        change["filename"].replace("\\", "/")
        for change in changes
        if (
            change["filename"].replace("\\", "/")
            in context_files
            and (
                not change.get("patch")
                or len(change["patch"]) >= 20_000
            )
        )
    ]
    if incomplete_patches:
        context_gaps.append({
            "rule_id": "ps-change-context",
            "files": incomplete_patches[:50],
            "file_count": len(incomplete_patches),
            "summary": "Relevant patches are missing or may be truncated.",
            "required_evidence": (
                "Read the affected base/head files through approved read "
                "primitives before making absence or compatibility claims."
            ),
        })
    autorest_roots = sorted(
        root for root, project in projects.items()
        if project["kind"] == "autorest" and root.casefold().startswith("src/")
    )
    if autorest_roots:
        context_gaps.append({
            "rule_id": "ps-project-triage",
            "files": autorest_roots[:50],
            "file_count": len(autorest_roots),
            "summary": "AutoRest source provenance is not established by a diff.",
            "required_evidence": (
                "Check tsp-location.yaml, or defensively tsp-location.yml, in "
                "the complete base and head trees. An unchanged marker will "
                "not appear in the diff. Do not infer Swagger from its absence "
                "in changed files or infer TypeSpec from openapi.json alone."
            ),
        })

    title = str(pr.get("title") or "").strip().casefold()
    archive_candidate = (
        title == "[skip ci] archive"
        or title.startswith("[skip ci] archive ")
    )
    base_branch = str((pr.get("base") or {}).get("ref") or "")
    branch = base_branch.casefold()
    likely_oob = (
        (branch.startswith("az.") or branch.endswith("-preview"))
        and not branch.startswith("release-")
        and branch not in {"main", "preview"}
    )
    review_targets = []
    checks = []

    def target(rule_id, skill, title, files, questions):
        selected = sorted(set(files))
        checks.append({
            "rule_id": rule_id,
            "skill": skill,
            "skill_title": title,
            "status": "review" if selected else "not_applicable",
        })
        if selected:
            review_targets.append({
                "rule_id": rule_id,
                "skill": skill,
                "skill_title": title,
                "mode": "agent_review",
                "files": selected[:50],
                "file_count": len(selected),
                "checks": questions,
            })

    target("ps-project-triage", "scope-consistency", "PowerShell project triage",
           module_files, [
        "Identify SDK, AutoRest and test projects separately. A hybrid module "
        "can contain several projects with different ownership and test layouts.",
        "Establish TypeSpec or Swagger provenance from complete base/head "
        "trees, not only changed files. For a Swagger-sourced project, request "
        "Codegen Squad migration rather than handwritten generated-code fixes.",
        "Determine whether the module existed at the base SHA. A large diff "
        "or an added cmdlet does not prove a new module. Check new or rebranded "
        "distributable identity against manifests, projects and module mappings.",
        "For a confirmed new/rebranded module, verify the linked microsoft/mcr "
        "onboarding PR for teams/psresource/azurepsmar.yaml and MAR approval; "
        "missing approval requires human handoff.",
    ])
    target("ps-generated-ownership", "generated-ownership",
           "PowerShell generation and archives", autorest_files + generated_files, [
        "Distinguish generator-owned inputs/output from handwritten custom "
        "code, tests and documentation. Custom-only changes do not inherently "
        "require regeneration or generate-info.json.",
        "For actual regeneration, verify the approved generator produced "
        "generate-info.json and the applicable solution, help, manifest and "
        "changelog artifacts; new/rebranded modules also need mappings. Do not "
        "accept a hand-edited marker as proof or require unchanged artifacts.",
        "Contributor edits to generated output require the repository archive "
        "or protected-branch synchronization exception. Verify the source and "
        "target repositories/branches; a title alone is not proof of an exception.",
        "For an archive candidate, verify changes stay under generated/ and "
        "include the relevant generated generate-info.json. Do not require "
        "source-module live tests or changelog edits for a valid archive.",
        "Check archive follow-up only when source generate-info.json changed. "
        "Verify the target branch's archive flow; do not expect another archive "
        "for custom-only changes or an archive PR itself.",
    ])
    target("ps-release-artifacts", "release-artifact",
           "PowerShell changelog and versioning",
           production_files + changelog_files, [
        "For user-visible changes, verify each affected module's ChangeLog.md "
        "has the entry under ## Upcoming Release. Read section context: a "
        "conflict resolution can put an entry into an older released section.",
        "Apply explicit documentation-only and repository-tooling exceptions "
        "rather than demanding module release notes for every file change.",
        "Check manual changes to ModuleVersion, manifest ReleaseNotes, "
        "AssemblyInfo versions and released-version headers against the release "
        "process. An initial new-module manifest is not a version bump.",
    ])
    target("ps-public-contract", "user-intent", "PowerShell public contracts",
           code_files + manifest_files + suppression_files, [
        "For public cmdlet additions/removals/changes, verify approved design "
        "review and service-owner decisions. Inspect BreakingChangeAnalyzer, "
        "BreakingChangeIssues.csv, SignatureIssues.csv and other suppressions.",
        "Stable modules must not introduce unapproved breaking changes; preview "
        "suppressions still need justification and owner confirmation. Do not "
        "confuse internal generated SDK signatures with supported cmdlet APIs.",
        "Check aliases, parameter names/types, mandatory state, positions, "
        "parameter sets, pipeline binding, output types and defaults. Multiple "
        "parameter sets need an interactive DefaultParameterSetName.",
        "Trace each accepted parameter into actual behavior or request mapping; "
        "do not accept ignored inputs, silent defaults or lost user intent.",
    ])
    target("ps-cmdlet-behavior", "domain-edge-cases",
           "PowerShell cmdlet behavior", code_files, [
        "For server mutations, verify SupportsShouldProcess and trace the "
        "actual network mutation to ShouldProcess or ConfirmAction. WhatIf "
        "must make no service request and Confirm must prompt; an attribute "
        "alone is insufficient. Distinguish in-memory helper cmdlets.",
        "Check that Remove cmdlets with no normal output support PassThru, "
        "sensitive values use SecureString, output types match behavior and "
        "collections use WriteObject(collection, true) where appropriate.",
        "Exercise wildcard/list branches, continuation pagination, all parameter "
        "sets and pipeline input rather than exact-name-only paths.",
        "Check New overwrite and Set create-if-missing/upsert against established "
        "module semantics. Trace full PUT and read-modify-write mappings for "
        "loss of omitted fields or write-back of service-managed fields.",
        "Surface service errors explicitly; verify real exception text and "
        "output shapes instead of success-shaped fallbacks.",
    ])
    target("ps-help-manifest-sdk", "command-help",
           "PowerShell help, packaging and dependencies",
           code_files + help_files + manifest_files + formatting_files
           + dependency_files, [
        "Public cmdlet changes need regenerated help. Verify parameter metadata, "
        "aliases, pipeline support, behavior and output against code; new "
        "commands need realistic examples and no platyPS placeholders.",
        "Ignore temporary -ProgressAction parameter placeholders removed by "
        "the build tooling; other unfilled descriptions still need correction.",
        "Check example semantics for replace, append, remove and upsert, and "
        "make sure headings and descriptions describe the demonstrated command.",
        "Maintain CmdletsToExport, AliasesToExport and RequiredAssemblies; "
        "manifest tags must not contain spaces. Check formatting regeneration "
        "when Ps1Xml annotations change.",
        "Use published NuGet SDK packages; inspect tools/LocalFeed additions, "
        "cross-service management SDK references in command projects and "
        "shared-assembly conflicts. Test-only dependencies can differ.",
    ])
    target("ps-test-evidence", "test-strength", "PowerShell regression evidence",
           code_files + test_files, [
        "For a new cmdlet, require help, a PowerShell live/scenario test and "
        "playback recordings. Mock-only C# tests do not replace these artifacts.",
        "Distinguish TestFx .Test/SessionRecords from AutoRest test/*.Tests.ps1 "
        "and *.Recording.json. File presence is evidence to inspect, not proof "
        "that the changed behavior is covered or that tests executed.",
        "Map evidence to each affected project and cmdlet. One project's tests "
        "or recordings do not establish coverage for other projects in a "
        "hybrid module or for other modules.",
        "Cover every parameter set, pipeline input, wildcard/list and pagination "
        "paths, WhatIf and successful service calls, partial-update preservation, "
        "New overwrite and Set-missing behavior where applicable.",
        "An empty recording, WhatIf-only test, or null/default-only assertion "
        "does not validate serialization, service acceptance, long-running "
        "operations or returned values. Check LiveOnly and skipped test behavior.",
        "Do not count deleted tests as added coverage. Existing focused tests "
        "and re-recorded fixtures may cover a fix; trace them before demanding "
        "new test code. TestFx neutral skip is not a successful Pester run.",
        "Require reproducible resource setup/cleanup and sanitized recordings; "
        "reject NotImplementedException stubs, newly skipped existing tests and "
        "personal or unreproducible hardcoded environments.",
    ])
    target("ps-review-process", "scope-consistency",
           "PowerShell review evidence and handoff", paths, [
        "Check target branch, complete PR template and consistency between title, "
        "description and actual behavior. Require an issue link when applicable, "
        "not Fixes #N on every human-requested PR.",
        "Inspect current-head commits, checks, open/resolved review threads and "
        "suppressed comments. Confirm a resolved issue was fixed; reference "
        "existing equivalent feedback rather than posting it again.",
        "Report only confirmed current-change findings with exact evidence, "
        "user impact, a practical correction and focused verification. Treat "
        "review targets as questions, not automatic blockers.",
        "Preserve decisive human change requests and CI/live-test gates. Draft "
        "state and do-not-merge labels are workflow context, not code defects.",
        "Suggest only verified existing labels: the affected service, "
        "needs-revision for confirmed blockers, Cmdlet Review Required :warning: "
        "for missing design review, Contains Breaking Change for a verified "
        "public break, Generator, Test Debt, ps1xml or Service Attention when "
        "supported by evidence. Suggest Merge Conflicts only when GitHub "
        "reports a conflict. Preserve unrelated labels.",
        "Use human handoff for Codegen, MAR onboarding, design/owner approval "
        "and OOB release. Labels are suggestions only; never approve, merge, "
        "apply labels or start these processes from this skill.",
    ])
    for check in checks:
        if any(finding["skill"] == check["skill"] for finding in findings):
            check["status"] = "finding"

    return {
        "repository": repository,
        "base_sha": base_sha,
        "head_sha": head_sha,
        "files_complete": files_complete,
        "triage": {
            "modules": [modules[key] for key in sorted(modules)],
            "projects": [projects[key] for key in sorted(projects)],
            "archive_candidate": archive_candidate,
            "likely_out_of_band": likely_oob,
        },
        "finding_count": len(findings),
        "findings": findings,
        "review_targets": review_targets,
        "checks": checks,
        "context_gaps": context_gaps,
        "handoff_items": [
            {
                "kind": "oob_release",
                "summary": (
                    "The module-specific target branch may require an OOB "
                    "release. Ask the Scrum Master to confirm the release flow."
                ),
            },
        ] if likely_oob else [],
    }
