import argparse
import json
import sys
from pathlib import Path

def load_missing_keys(filename):
    with open(filename, 'r') as f:
        return [line.strip() for line in f if line.strip()]

def find_success_status_entry(d):
    for k, v in d.items():
        # Heuristics: check if Response.StatusCode 200 AND 'Succeeded' or 'Completed' in Content or status
        resp = v.get("Response", {})
        if resp.get("StatusCode") == 200:
            content = resp.get("Content", "")
            if (
                "status" in content and '"Succeeded"' in content
                or '"Succeeded"' in content
                or '"Completed"' in content
                or '"status":"Succeeded"' in content
                or '"status":"Completed"' in content
            ):
                return v
    raise RuntimeError("No existing 'Succeeded' or 'Completed' operationStatuses entry found to clone.")

def main():
    parser = argparse.ArgumentParser(description="Patch AzVmCluster.Recording.json with missing operationStatuses keys for playback.")
    parser.add_argument('--json', required=True, help='Path to AzVmCluster.Recording.json')
    parser.add_argument('--missing-keys', required=True, help='Path to text file with one missing key per line.')
    parser.add_argument('--out', help='Output file (default: overwrite input)')
    args = parser.parse_args()

    path = Path(args.json)
    keys_path = Path(args.missing_keys)
    out_path = Path(args.out) if args.out else path

    with open(path, 'r') as f:
        data = json.load(f)

    missing_keys = load_missing_keys(keys_path)
    template_entry = find_success_status_entry(data)
    added = 0

    for key in missing_keys:
        if key not in data:
            data[key] = template_entry.copy()
            added += 1
            print(f"Injected missing operationStatus: {key}")
        else:
            print(f"Already present: {key}")

    with open(out_path, 'w') as f:
        json.dump(data, f, indent=2)

    print(f"Patched: {added} missing operationStatuses. Output: {out_path}")

if __name__ == '__main__':
    main()
