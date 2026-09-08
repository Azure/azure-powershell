"""Infer an Azure PowerShell module from trusted repository structure."""


def infer_ps_target(text, pr_files):
    """Resolve sanitized issue text or PR files to a live service module."""
    modules = list_repository_directories(
        source_repository="Azure/azure-powershell",
    )

    def normalize(value):
        return "".join(
            character
            for character in str(value or "").casefold()
            if character.isalnum()
        )

    def resolve(candidate):
        normalized_candidate = normalize(candidate)
        if not normalized_candidate:
            return None
        exact = None
        best = None
        for module in modules:
            normalized_module = normalize(module)
            if normalized_module == normalized_candidate:
                exact = module
                break
            if (
                len(normalized_module) >= 3
                and (
                    normalized_candidate.startswith(normalized_module)
                    or normalized_module.startswith(normalized_candidate)
                )
                and (
                    best is None
                    or len(normalized_module) > len(normalize(best))
                )
            ):
                best = module
        name = exact or best
        if name is None:
            return None
        return {
            "kind": "psmodule",
            "name": name,
            "repo": "Azure/azure-powershell",
        }

    scores = {}
    for path in pr_files or []:
        parts = str(path).replace("\\", "/").split("/")
        if len(parts) > 1 and parts[0].casefold() == "src":
            candidate = parts[1]
            scores[candidate] = scores.get(candidate, 0) + 10
    if pr_files:
        for candidate in sorted(scores, key=lambda item: (-scores[item], item)):
            target = resolve(candidate)
            if target is not None:
                return target

    cleaned = "".join(
        character if character.isalnum() or character in "-./" else " "
        for character in str(text or "").casefold()
    )
    for word in cleaned.split():
        if word.startswith("src/"):
            parts = word.split("/")
            if len(parts) > 1:
                candidate = parts[1]
                scores[candidate] = scores.get(candidate, 0) + 5
        if "-az" in word:
            candidate = word.split("-az", 1)[1]
            if candidate:
                scores[candidate] = scores.get(candidate, 0) + 2
    for candidate in sorted(scores, key=lambda item: (-scores[item], item)):
        target = resolve(candidate)
        if target is not None:
            return target
    return {
        "kind": "none" if pr_files else "unknown",
        "name": None,
        "repo": None,
    }
