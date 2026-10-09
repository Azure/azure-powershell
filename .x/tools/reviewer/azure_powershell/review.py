# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------

"""Azure PowerShell AutoRest review policy."""

import json
import os
import re


_AZURE_POWERSHELL_AUTOREST_ROOT = re.compile(
    r"^((?:src|generated)/[^/]+/[^/]+\.Autorest)(?:/|$)",
    re.I,
)
_AZURE_POWERSHELL_CODEGEN_ID = re.compile(
    r"[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-"
    r"[0-9a-f]{12}",
    re.I,
)
_AZURE_POWERSHELL_GENERATED_ROOT_ENTRIES = {
    "check-dependencies.ps1",
    "generate-help.ps1",
    "pack-module.ps1",
    "run-module.ps1",
    "test-module.ps1",
}
_AZURE_POWERSHELL_GENERATED_ROOT_SUFFIXES = (
    ".csproj",
    ".format.ps1xml",
    ".psd1",
    ".psm1",
)


def _is_powershell_production_file(path):
    return path.startswith("src/") and path.endswith((".cs", ".ps1", ".psm1", ".psd1"))


def _powershell_review_component(parts):
    if len(parts) > 1 and parts[0].casefold() == "src":
        return parts[1].casefold()
    return None


def _is_powershell_autorest_path(path):
    return bool(_AZURE_POWERSHELL_AUTOREST_ROOT.match(path))


def _powershell_command_checks():
    return (
        "Validate approved PowerShell verbs, reserved/common "
        "parameters, parameter sets and singular/plural naming."
    )


def _review_codegen_id_from_patch(patch, side):
    """Reconstruct one side of a generate info JSON document from its diff."""
    document_lines = []
    for line in str(patch or "").splitlines():
        if line.startswith(("@@", "---", "+++")):
            continue
        if line.startswith(" "):
            document_lines.append(line[1:])
        elif side == "base" and line.startswith("-"):
            document_lines.append(line[1:])
        elif side == "head" and line.startswith("+"):
            document_lines.append(line[1:])
    try:
        document = json.loads("\n".join(document_lines))
    except (TypeError, ValueError):
        return None
    if not isinstance(document, dict):
        return None
    generation_id = document.get("generate_Id")
    if (
        isinstance(generation_id, str)
        and _AZURE_POWERSHELL_CODEGEN_ID.fullmatch(generation_id)
    ):
        return generation_id.casefold()
    return None


def _powershell_codegen_owned_change(root, change):
    """Whether a .Autorest path is owned by AutoRest rather than a human."""
    filename = str(change.get("filename") or "")
    relative = filename[len(root):].lstrip("/")
    relative_folded = relative.casefold()
    if not relative or relative_folded == "generate-info.json":
        return False
    if root.casefold().startswith("generated/"):
        return True
    if relative_folded == "readme.md":
        return True
    if relative_folded.startswith((
        "docs/", "exports/", "generated/", "internal/", "properties/",
        "resources/",
    )):
        return True
    basename = os.path.basename(relative_folded)
    if "/" not in relative_folded:
        if basename in _AZURE_POWERSHELL_GENERATED_ROOT_ENTRIES:
            return True
        if basename.endswith(_AZURE_POWERSHELL_GENERATED_ROOT_SUFFIXES):
            return True
    return bool(
        relative_folded.startswith("custom/")
        and re.fullmatch(r"az\..+\.custom\.psm1", basename, re.I)
    )


def _review_powershell_autorest(changes, head_repo, head_sha, make_finding):
    """Validate AutoRest-generated changes and return findings and affected files."""
    findings = []
    autorest_target_files = []
    changes_by_path = {
        change["filename"].casefold(): change for change in changes
    }
    autorest_roots = {}
    for change in changes:
        match = _AZURE_POWERSHELL_AUTOREST_ROOT.match(
            change["filename"],
        )
        if match:
            autorest_roots.setdefault(match.group(1), []).append(change)
    for root, root_changes in sorted(autorest_roots.items()):
        generation_marker = f"{root}/generate-info.json"
        marker_change = changes_by_path.get(
            generation_marker.casefold(),
        )
        codegen_changes = [
            change for change in root_changes
            if _powershell_codegen_owned_change(root, change)
        ]
        if not codegen_changes and marker_change:
            codegen_changes = [marker_change]
        if not codegen_changes:
            continue
        change = codegen_changes[0]
        autorest_target_files.extend(
            item["filename"] for item in root_changes
        )
        if marker_change:
            autorest_target_files.append(generation_marker)
        marker_patch = str(
            (marker_change or {}).get("patch") or "",
        )
        added_id = _review_codegen_id_from_patch(marker_patch, "head")
        removed_id = _review_codegen_id_from_patch(marker_patch, "base")
        marker_added = (
            marker_change
            and str(marker_change.get("status") or "").casefold()
            == "added"
        )
        valid_marker = (
            marker_change
            and str(marker_change.get("status") or "").casefold()
            != "removed"
            and added_id
            and (
                marker_added
                or (removed_id and removed_id != added_id)
            )
        )
        if valid_marker:
            continue
        findings.append(make_finding(
            "generated-ownership",
            change,
            "Azure PowerShell AutoRest project changed without Codegen "
            f"regeneration evidence in `{generation_marker}`. The marker "
            "must contain a changed Codegen generation ID and must not be "
            "deleted.",
            "Run the repository's approved Codegen flow for "
            f"`{root}` and include all resulting artifacts, including "
            f"the changed `{generation_marker}`. Do not hand-edit the "
            "generation marker.",
            "Confirm the Codegen run updates `generate-info.json` and "
            "that the complete regenerated diff is committed.",
            head_repo=head_repo,
            head_sha=head_sha,
        ))
    return findings, autorest_target_files
