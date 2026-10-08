# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# --------------------------------------------------------------------------
import importlib
import sys
import types
from pathlib import Path


PACKAGE = Path(__file__).resolve().parents[1]
TOOLS = PACKAGE / "tools"
module = sys.modules.get("repository_tools")
if module is None:
    module = types.ModuleType("repository_tools")
    module.__path__ = [str(TOOLS)]
    sys.modules["repository_tools"] = module
elif str(TOOLS) not in module.__path__:
    module.__path__.append(str(TOOLS))

analysis = importlib.import_module("repository_tools.reviewer.policy.analysis")


def test_powershell_custom_change_does_not_require_codegen_marker():
    change = {
        "filename": (
            "src/RedisEnterpriseCache/RedisEnterpriseCache.Autorest/"
            "custom/Update-AzRedisEnterpriseCacheDatabase.ps1"
        ),
        "additions": 1,
        "deletions": 1,
        "patch": "@@ -1 +1 @@\n-old\n+new\n",
    }

    findings, _ = analysis._generated_ownership_check(
        "Azure/azure-powershell", {}, [change], [change], None, None,
    )

    assert findings == []


def test_powershell_autorest_readme_requires_codegen_marker():
    change = {
        "filename": (
            "src/RedisEnterpriseCache/"
            "RedisEnterpriseCache.Autorest/README.md"
        ),
        "additions": 1,
        "deletions": 1,
        "patch": "@@ -1 +1 @@\n-old\n+new\n",
    }

    findings, _ = analysis._generated_ownership_check(
        "Azure/azure-powershell", {}, [change], [change], None, None,
    )

    assert len(findings) == 1
    assert "Codegen" in findings[0]["summary"]
    assert "RedisEnterpriseCache.Autorest/generate-info.json" in findings[0]["summary"]


def test_powershell_generated_autorest_requires_codegen_marker():
    change = {
        "filename": "generated/Aks/Aks.Autorest/exports/Update-Aks.ps1",
        "status": "modified",
        "patch": "@@ -1 +1 @@\n-old\n+new\n",
    }

    findings, target = analysis._generated_ownership_check(
        "Azure/azure-powershell",
        {},
        [change],
        [change],
        None,
        None,
        [{"repository": "Azure/azure-rest-api-specs", "valid": True}],
    )

    assert len(findings) == 1
    assert "generated/Aks/Aks.Autorest/generate-info.json" in findings[0]["summary"]
    assert change["filename"] in target["files"]


def test_powershell_nested_handwritten_module_is_not_codegen_owned():
    root = "src/Aks/Aks.Autorest"
    for relative in ("custom/Helpers.psm1", "test/loadEnv.psd1"):
        change = {
            "filename": f"{root}/{relative}",
            "status": "modified",
            "patch": "@@ -1 +1 @@\n-old\n+new\n",
        }

        findings, target = analysis._generated_ownership_check(
            "Azure/azure-powershell", {}, [change], [change], None, None, [],
        )

        assert findings == []
        assert target is None


def test_powershell_autorest_codegen_marker_satisfies_policy():
    root = "src/RedisEnterpriseCache/RedisEnterpriseCache.Autorest"
    changes = [
        {
            "filename": f"{root}/custom/Update-AzRedisEnterpriseCacheDatabase.ps1",
            "additions": 1,
            "deletions": 1,
            "patch": "@@ -1 +1 @@\n-old\n+new\n",
        },
        {
            "filename": f"{root}/generate-info.json",
            "status": "modified",
            "additions": 1,
            "deletions": 1,
            "patch": (
                "@@ -1,3 +1,3 @@\n"
                " {\n"
                '-  "generate_Id": "11111111-1111-1111-1111-'
                '111111111111"\n'
                '+  "generate_Id": "22222222-2222-2222-2222-'
                '222222222222"\n'
                " }\n"
            ),
        },
    ]

    findings, _ = analysis._generated_ownership_check(
        "Azure/azure-powershell", {}, changes, changes, None, None,
    )

    assert findings == []


def test_powershell_new_autorest_codegen_marker_satisfies_policy():
    root = "src/NewService/NewService.Autorest"
    changes = [
        {
            "filename": f"{root}/README.md",
            "status": "added",
            "patch": "@@ -0,0 +1 @@\n+# New service\n",
        },
        {
            "filename": f"{root}/generate-info.json",
            "status": "added",
            "patch": (
                "@@ -0,0 +1,3 @@\n"
                "+{\n"
                '+  "generate_Id": "22222222-2222-2222-2222-'
                '222222222222"\n'
                "+}\n"
            ),
        },
    ]

    findings, _ = analysis._generated_ownership_check(
        "Azure/azure-powershell", {}, changes, changes, None, None,
    )

    assert findings == []


def test_powershell_autorest_rejects_deleted_codegen_marker():
    root = "src/RedisEnterpriseCache/RedisEnterpriseCache.Autorest"
    changes = [
        {
            "filename": f"{root}/custom/Update-Database.ps1",
            "status": "modified",
            "patch": "@@ -1 +1 @@\n-old\n+new\n",
        },
        {
            "filename": f"{root}/generate-info.json",
            "status": "removed",
            "patch": (
                "@@ -1,3 +0,0 @@\n"
                "-{\n"
                '-  "generate_Id": "11111111-1111-1111-1111-'
                '111111111111"\n'
                "-}\n"
            ),
        },
    ]

    findings, _ = analysis._generated_ownership_check(
        "Azure/azure-powershell", {}, changes, changes, None, None,
    )

    assert len(findings) == 1
    assert "must not be deleted" in findings[0]["summary"]


def test_powershell_autorest_rejects_unchanged_codegen_id():
    root = "src/RedisEnterpriseCache/RedisEnterpriseCache.Autorest"
    generation_id = "11111111-1111-1111-1111-111111111111"
    changes = [
        {
            "filename": f"{root}/custom/Update-Database.ps1",
            "status": "modified",
            "patch": "@@ -1 +1 @@\n-old\n+new\n",
        },
        {
            "filename": f"{root}/generate-info.json",
            "status": "modified",
            "patch": (
                "@@ -1,3 +1,3 @@\n"
                " {\n"
                f'-  "generate_Id": "{generation_id}"\n'
                f'+  "generate_Id": "{generation_id}"\n'
                " }\n"
            ),
        },
    ]

    findings, _ = analysis._generated_ownership_check(
        "Azure/azure-powershell", {}, changes, changes, None, None,
    )

    assert len(findings) == 1
    assert "changed Codegen generation ID" in findings[0]["summary"]


def test_powershell_autorest_rejects_malformed_codegen_marker():
    root = "src/RedisEnterpriseCache/RedisEnterpriseCache.Autorest"
    changes = [
        {
            "filename": f"{root}/custom/Update-Database.ps1",
            "status": "modified",
            "patch": "@@ -1 +1 @@\n-old\n+new\n",
        },
        {
            "filename": f"{root}/generate-info.json",
            "status": "modified",
            "patch": (
                "@@ -1,3 +1,3 @@\n"
                " {\n"
                '-  "generate_Id": "11111111-1111-1111-1111-'
                '111111111111"\n'
                '+NOT JSON "generate_Id":"22222222-2222-2222-2222-'
                '222222222222"\n'
                " }\n"
            ),
        },
    ]

    findings, _ = analysis._generated_ownership_check(
        "Azure/azure-powershell", {}, changes, changes, None, None,
    )

    assert len(findings) == 1


def test_powershell_autorest_targets_complete_project_diff():
    root = "src/RedisEnterpriseCache/RedisEnterpriseCache.Autorest"
    changes = [
        {
            "filename": f"{root}/custom/Update-Database.ps1",
            "status": "modified",
            "patch": "@@ -1 +1 @@\n-old\n+new\n",
        },
        {
            "filename": f"{root}/docs/Update-Database.md",
            "status": "modified",
            "patch": "@@ -1 +1 @@\n-old\n+new\n",
        },
        {
            "filename": f"{root}/generate-info.json",
            "status": "modified",
            "patch": (
                "@@ -1,3 +1,3 @@\n"
                " {\n"
                '-  "generate_Id": "11111111-1111-1111-1111-'
                '111111111111"\n'
                '+  "generate_Id": "22222222-2222-2222-2222-'
                '222222222222"\n'
                " }\n"
            ),
        },
    ]

    findings, target = analysis._generated_ownership_check(
        "Azure/azure-powershell", {}, changes, changes, None, None,
    )

    assert findings == []
    assert target["files"] == [item["filename"] for item in changes]
