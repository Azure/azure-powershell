# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------

"""Azure PowerShell module target discovery and inference."""

import re

import requests

from repository_tools.settings import _PS_CMDLET_PATTERN, _PS_PATH_PATTERN
from x_engineering_agent.tools.targets.discovery import (
    _list_repo_dirs,
    _target_list_cache,
)


def list_azure_powershell_modules(branch="main", token=None, refresh=False):
    """Names of service modules in Azure/azure-powershell."""
    key = ("ps-modules", branch)
    if refresh or key not in _target_list_cache:
        _target_list_cache[key] = _list_repo_dirs(
            "Azure", "azure-powershell", "src", branch, token,
        )
    return _target_list_cache[key]


def _normalize_name(name):
    return re.sub(r"[^a-z0-9]", "", (name or "").lower())


def resolve_ps_target(candidate, token=None):
    """Map a candidate service or cmdlet noun to a PowerShell module."""
    if not candidate:
        return {"kind": "unknown", "name": None, "repo": None}
    try:
        modules = list_azure_powershell_modules(token=token)
    except requests.HTTPError:
        return {"kind": "unknown", "name": candidate, "repo": None}
    repo = "Azure/azure-powershell"
    if candidate in modules:
        return {"kind": "psmodule", "name": candidate, "repo": repo}
    norm = _normalize_name(candidate)
    for module in modules:
        if _normalize_name(module) == norm:
            return {"kind": "psmodule", "name": module, "repo": repo}
    best = None
    for module in modules:
        normalized_module = _normalize_name(module)
        if (
            norm.startswith(normalized_module)
            or normalized_module.startswith(norm)
        ) and len(normalized_module) >= 3:
            if (
                best is None
                or len(normalized_module) > len(_normalize_name(best))
            ):
                best = module
    if best:
        return {"kind": "psmodule", "name": best, "repo": repo}
    return {"kind": "unknown", "name": candidate, "repo": None}


def _ps_candidate_scores(text, weight=1):
    scores = {}
    if not text:
        return scores
    for match in _PS_PATH_PATTERN.finditer(text):
        name = match.group(1)
        scores[name] = scores.get(name, 0) + weight * 2
    for match in _PS_CMDLET_PATTERN.finditer(text):
        name = match.group(1)
        scores[name] = scores.get(name, 0) + weight
    return scores


def infer_ps_target(text=None, pr_files=None, token=None):
    """Infer an Azure PowerShell module from file paths or issue text."""
    if pr_files:
        file_scores = _ps_candidate_scores("\n".join(pr_files), weight=5)
        for name in sorted(file_scores, key=lambda item: -file_scores[item]):
            target = resolve_ps_target(name, token=token)
            if target["kind"] != "unknown":
                return target
        return {"kind": "none", "name": None, "repo": None}
    text_scores = _ps_candidate_scores(text or "", weight=1)
    for name in sorted(text_scores, key=lambda item: -text_scores[item]):
        target = resolve_ps_target(name, token=token)
        if target["kind"] != "unknown":
            return target
    return {"kind": "unknown", "name": None, "repo": None}