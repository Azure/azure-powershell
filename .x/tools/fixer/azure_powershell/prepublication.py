# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------

"""Azure PowerShell pre-publication checks run by the engine before a change is published."""

import os
import re

from repository_tools.reviewer.azure_powershell.review import (
    _AZURE_POWERSHELL_AUTOREST_ROOT,
    _powershell_codegen_owned_change,
)
from repository_tools.reviewer.policy import analysis
from repository_tools.settings import AUTOREST_FIX_ROUTE

REPOSITORY = "Azure/azure-powershell"

# Hand-maintained AutoRest inputs of a src/<Service>/<Project>.Autorest project.
_AUTOREST_SOURCE = re.compile(r"^(?:readme\.md|examples/.+|custom/(?!az\.[^/]+\.custom\.psm1$).+)$", re.I)
_PS_HELP_PLACEHOLDER = re.compile(r"\{\{\s*(?:Fill|Add|Manually)\b[^}]*\}\}", re.I)
_UPCOMING_RELEASE = re.compile(r"^\s*##\s+Upcoming Release\s*$", re.I)
_SECTION_HEADER = re.compile(r"^\s*##\s+\S")
_VERSION_HEADER = re.compile(r"^\s*##\s+Version\b", re.I)


def finding(summary, remediation, path=None, line=None):
    item = {"summary": summary, "remediation": remediation}
    if path:
        item["file"] = path
    if line is not None:
        item["line"] = line
    return item


def added_lines(change):
    return list(analysis._review_added_lines(change))


def _wire(items):
    return [
        finding(item["summary"], item["remediation"], item.get("file"), item.get("line"))
        for item in items or []
    ]


def generated_path(path):
    """AutoRest ownership of path as (kind, reason), else None.

    The project README.md holds directives and counts as source.
    """
    match = _AZURE_POWERSHELL_AUTOREST_ROOT.match(path)
    if (
        match and path[match.end(1):].strip("/").casefold() != "readme.md"
        and _powershell_codegen_owned_change(match.group(1), {"filename": path})
    ):
        return "autorest", "Azure PowerShell AutoRest generated output"
    if path.casefold().startswith("generated/"):
        return "autorest", "Azure PowerShell top-level generated tree"
    return None


def generated_paths(paths):
    """AutoRest classification; project paths are checked by generated_ownership_findings."""
    owned = {}
    for path in paths:
        found = generated_path(path)
        checked = bool(_AZURE_POWERSHELL_AUTOREST_ROOT.match(path))
        if found or checked:
            kind, reason = found or (None, None)
            owned[path] = {"kind": kind, "reason": reason, "checked": checked}
    return owned


def production_changes(changes):
    return [change for change in changes if analysis._review_is_production_file(REPOSITORY, change["filename"])]


def autorest_ownership_findings(changes):
    """Regenerated AutoRest output needs a matching durable input change."""
    projects = {}
    for change in changes:
        path = change["filename"]
        match = _AZURE_POWERSHELL_AUTOREST_ROOT.match(path)
        if not match:
            continue
        root = match.group(1)
        generated_tree = root.casefold().startswith("generated/")
        source_root = "src/" + root.split("/", 1)[1] if generated_tree else root
        project = projects.setdefault(source_root.casefold(), {"root": source_root, "output": [], "source": False})
        relative = path[len(root):].lstrip("/")
        if not generated_tree and _AUTOREST_SOURCE.match(relative):
            project["source"] = True
        elif (generated_path(path) or (None,))[0] == "autorest":
            project["output"].append(path)
    return [
        finding(
            f"AutoRest output of `{project['root']}` changed without a matching change "
            "to its `README.md` directives, `custom/` code or `examples/`.",
            AUTOREST_FIX_ROUTE, project["output"][0],
        )
        for project in projects.values() if project["output"] and not project["source"]
    ]


def generated_ownership_findings(pr, changes):
    items, _ = analysis._generated_ownership_check(
        REPOSITORY, pr, changes, production_changes(changes), None, None, generation_source_prs=[],
    )
    return _wire(items) + autorest_ownership_findings(changes)


def changelog_findings(changes, read_file):
    """ChangeLog.md entries belong under "## Upcoming Release"."""
    findings = []
    for change in changes:
        path = change["filename"]
        if os.path.basename(path).casefold() != "changelog.md" or not path.startswith("src/"):
            continue
        text = read_file(path)
        if text is None:
            continue
        lines = text.splitlines()
        start = next((index + 1 for index, line in enumerate(lines) if _UPCOMING_RELEASE.match(line)), None)
        if start is None:
            findings.append(finding(
                "ChangeLog.md has no `## Upcoming Release` section.",
                "Add the entry under `## Upcoming Release`; never add a version header.", path,
            ))
            continue
        end = next((index + 1 for index in range(start, len(lines)) if _SECTION_HEADER.match(lines[index])), len(lines) + 1)
        for number, added in added_lines(change):
            if _VERSION_HEADER.match(added):
                findings.append(finding(
                    "A ChangeLog.md version header was added.",
                    "Remove the version header; release tooling adds it.", path, number,
                ))
                break
            if added.strip() and not start < number < end:
                findings.append(finding(
                    "A ChangeLog.md entry was added outside `## Upcoming Release`.",
                    "Move the entry under `## Upcoming Release`; never edit released sections.", path, number,
                ))
                break
    return findings


def release_artifact_findings(pr, changes, read_file):
    items, _ = analysis._release_artifact_check(REPOSITORY, pr, changes, production_changes(changes), None, None)
    return _wire(items) + changelog_findings(changes, read_file)


def command_help_findings(changes, base, read_file):
    findings = []
    for change in changes:
        path = change["filename"]
        if "/help/" not in path or not path.endswith(".md"):
            continue
        for number, text in added_lines(change):
            if _PS_HELP_PLACEHOLDER.search(text):
                findings.append(finding(
                    "Cmdlet help still contains a platyPS `{{ Fill ... }}` placeholder.",
                    "Write the description, parameter help and examples.", path, number,
                ))
                break
    return findings


def title_findings(title, prefix, rest, changed_paths):
    if len(rest) < 4:
        return [finding("PR title has no summary.", "Describe the change after the `[Module]` prefix.")]
    return []
