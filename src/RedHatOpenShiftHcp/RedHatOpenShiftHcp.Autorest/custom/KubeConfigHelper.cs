// ----------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the Apache License, Version 2.0 (the "License"); see LICENSE for details.
// ----------------------------------------------------------------------------------
//
// C1 customization helper for the custom Request-AzRedHatOpenShiftHcpClusterAdminCredential cmdlet.
//
// Pure string -> string transforms (no file I/O — the PowerShell cmdlet does the I/O):
//   * PrepareKubeconfig : embed the locally-generated private key into the returned kubeconfig and
//                         rename the cluster/user/context to a stable, collision-free name.
//   * MergeKubeConfig   : AKS-style merge of our prepared kubeconfig into an existing one.
//
// Implemented with the BCL only (no third-party YAML package) because this is an AutoRest-generated
// module and the regenerated project cannot carry an extra NuGet PackageReference. kubeconfig is regular
// block-style YAML, so these transforms work at the line/block level:
//   * We only ever PARSE content WE produced/received from the RP (regular, single-entry block YAML).
//   * We NEVER fully parse or re-serialize the user's existing kubeconfig. MergeKubeConfig splices our
//     named blocks into the existing text, preserving every byte we do not replace (comments, quoting,
//     exec auth-plugin arg/env lists, ordering). This is the safety invariant.
//
// Out of scope (kubeconfigs are block-style in practice): YAML anchors/aliases, flow style ({a: b}),
// and multi-document streams in the EXISTING file are not interpreted.
//
// Targets netstandard2.0 / C# 7.1 (module csproj).

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Custom
{
    public static class KubeConfigHelper
    {
        private static readonly string[] Sections = { "clusters", "users", "contexts" };
        private const string CurrentContext = "current-context";

        // A list item within a clusters/users/contexts section, located by indentation.
        private sealed class Item
        {
            public int Start;          // absolute index of the "- ..." line
            public int End;            // exclusive absolute index where the item ends
            public int ItemIndent;     // leading spaces before "-"
            public int ContentIndent;  // indent of the item's own keys (ItemIndent + 2)
            public int NameLineIndex;  // line holding the item's own "name:" (-1 if none)
            public string NamePrefix;  // everything up to and including "name: " on that line
            public string Name;        // the item's name value (null if none)
        }

        /// <summary>
        /// Embed the private key into the admin user and give the single cluster/user/context a stable,
        /// collision-free name so multiple HCP clusters can coexist in one kubeconfig.
        /// </summary>
        public static string PrepareKubeconfig(string kubeconfigYaml, string privateKeyPem, string name)
        {
            if (string.IsNullOrWhiteSpace(kubeconfigYaml))
            {
                throw new ArgumentException("The returned kubeconfig was empty.", nameof(kubeconfigYaml));
            }

            string nl;
            var lines = SplitLines(kubeconfigYaml, out nl);
            var keyData = Convert.ToBase64String(Encoding.UTF8.GetBytes(privateKeyPem ?? string.Empty));

            foreach (var section in Sections)
            {
                var items = FindSectionItems(lines, section);
                if (items.Count == 0)
                {
                    throw new InvalidOperationException("The returned kubeconfig is missing its '" + section + "' section.");
                }

                var item = items[0];
                SetItemName(lines, item, name);

                if (section == "users")
                {
                    EmbedClientKey(lines, item, keyData);
                }
                else if (section == "contexts")
                {
                    SetContextReferences(lines, item, name);
                }
            }

            SetCurrentContext(lines, name);
            return string.Join(nl, lines);
        }

        /// <summary>
        /// Merge <paramref name="additions"/> (our prepared, regular kubeconfig) into
        /// <paramref name="original"/> (the user's existing, arbitrary kubeconfig) by name for clusters, users
        /// and contexts (additions win on name collision), and adopt the new current-context. The existing
        /// content is spliced, not re-serialized, so unrelated entries are preserved verbatim.
        /// </summary>
        public static string MergeKubeConfig(string original, string additions)
        {
            if (string.IsNullOrWhiteSpace(original))
            {
                return additions;
            }

            string nl;
            var originalLines = SplitLines(original, out nl);
            string nlA;
            var additionLines = SplitLines(additions, out nlA);

            foreach (var section in Sections)
            {
                var addItems = FindSectionItems(additionLines, section);
                if (addItems.Count == 0)
                {
                    continue;
                }

                var addBlocks = new List<List<string>>();
                var addNames = new HashSet<string>(StringComparer.Ordinal);
                foreach (var it in addItems)
                {
                    addBlocks.Add(additionLines.GetRange(it.Start, it.End - it.Start));
                    if (it.Name != null)
                    {
                        addNames.Add(it.Name);
                    }
                }

                originalLines = SpliceSection(originalLines, section, addBlocks, addNames);
            }

            var newCurrent = GetCurrentContextValue(additionLines);
            if (newCurrent != null)
            {
                SetCurrentContext(originalLines, newCurrent);
            }

            return string.Join(nl, originalLines);
        }

        // --- section/item splicing -------------------------------------------------------------------

        // Replace colliding items in the section by name and append the additions, preserving all other
        // lines of the original verbatim. Only line BLOCKS are cut/appended; nothing is re-serialized.
        private static List<string> SpliceSection(List<string> lines, string section, List<List<string>> addBlocks, HashSet<string> addNames)
        {
            int headerIdx = FindSectionHeader(lines, section);
            if (headerIdx < 0)
            {
                // Section absent in the original: append it (header + reindented items) at the end.
                var appended = new List<string>(lines);
                appended.Add(section + ":");
                foreach (var block in addBlocks)
                {
                    appended.AddRange(Reindent(block, 0));
                }
                return appended;
            }

            int bodyStart = headerIdx + 1;
            int bodyEnd = SectionBodyEnd(lines, bodyStart);
            var items = ParseItems(lines, bodyStart, bodyEnd);
            int targetIndent = items.Count > 0 ? items[0].ItemIndent : 0;

            var removeLines = new HashSet<int>();
            foreach (var it in items)
            {
                if (it.Name != null && addNames.Contains(it.Name))
                {
                    for (int k = it.Start; k < it.End; k++)
                    {
                        removeLines.Add(k);
                    }
                }
            }

            var result = new List<string>(lines.Count + 8);
            for (int i = 0; i <= lines.Count; i++)
            {
                if (i == bodyEnd)
                {
                    foreach (var block in addBlocks)
                    {
                        result.AddRange(Reindent(block, targetIndent));
                    }
                }
                if (i < lines.Count && !removeLines.Contains(i))
                {
                    result.Add(NormalizeEmptyCollectionHeader(lines[i], i == headerIdx, section));
                }
            }
            return result;
        }

        // "clusters: []" / "clusters: {}" must become "clusters:" once we append block items under it.
        private static string NormalizeEmptyCollectionHeader(string line, bool isHeader, string section)
        {
            if (!isHeader)
            {
                return line;
            }
            var m = Regex.Match(line, @"^(\s*)" + Regex.Escape(section) + @":\s*(\[\s*\]|\{\s*\})\s*$");
            if (m.Success)
            {
                return m.Groups[1].Value + section + ":";
            }
            return line;
        }

        private static List<Item> FindSectionItems(List<string> lines, string section)
        {
            int headerIdx = FindSectionHeader(lines, section);
            if (headerIdx < 0)
            {
                return new List<Item>();
            }
            int bodyStart = headerIdx + 1;
            int bodyEnd = SectionBodyEnd(lines, bodyStart);
            return ParseItems(lines, bodyStart, bodyEnd);
        }

        private static int FindSectionHeader(List<string> lines, string section)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                var m = Regex.Match(lines[i], @"^([A-Za-z0-9_.-]+):\s*(.*)$");
                if (m.Success && m.Groups[1].Value == section)
                {
                    return i;
                }
            }
            return -1;
        }

        // The section body runs until the next top-level key (column-0 "key:") or end of file.
        private static int SectionBodyEnd(List<string> lines, int bodyStart)
        {
            int j = bodyStart;
            while (j < lines.Count && !IsTopLevelKey(lines[j]))
            {
                j++;
            }
            return j;
        }

        private static bool IsTopLevelKey(string line)
        {
            return Regex.IsMatch(line, @"^[A-Za-z0-9_.-]+:(\s|$)");
        }

        // Parse list items in [start, end). Items begin with "- " at the first item's indent; an item ends at
        // the next "- " at that same indent, or at end. The item's own name is the "name:" key at the item's
        // content indent (either on the "- name:" line itself or a sibling "  name:" line) — never a deeper
        // nested "- name:" (e.g. inside an exec plugin's env list).
        private static List<Item> ParseItems(List<string> lines, int start, int end)
        {
            var items = new List<Item>();
            int itemIndent = -1;
            int i = start;
            while (i < end)
            {
                var m = Regex.Match(lines[i], @"^(\s*)-\s");
                if (m.Success)
                {
                    int indent = m.Groups[1].Length;
                    if (itemIndent < 0)
                    {
                        itemIndent = indent;
                    }
                    if (indent == itemIndent)
                    {
                        int j = i + 1;
                        while (j < end)
                        {
                            var mm = Regex.Match(lines[j], @"^(\s*)-\s");
                            if (mm.Success && mm.Groups[1].Length == itemIndent)
                            {
                                break;
                            }
                            j++;
                        }
                        items.Add(BuildItem(lines, i, j, itemIndent));
                        i = j;
                        continue;
                    }
                }
                i++;
            }
            return items;
        }

        private static Item BuildItem(List<string> lines, int start, int end, int itemIndent)
        {
            var item = new Item
            {
                Start = start,
                End = end,
                ItemIndent = itemIndent,
                ContentIndent = itemIndent + 2,
                NameLineIndex = -1,
                NamePrefix = null,
                Name = null
            };

            // Case 1: "- name: value" on the item's first line.
            var first = Regex.Match(lines[start], @"^(\s*-\s+)(.*)$");
            if (first.Success)
            {
                var rest = first.Groups[2].Value;
                var nm = Regex.Match(rest, @"^name:\s*(.*)$");
                if (nm.Success)
                {
                    item.NameLineIndex = start;
                    item.NamePrefix = first.Groups[1].Value + "name: ";
                    item.Name = nm.Groups[1].Value.Trim();
                    return item;
                }
            }

            // Case 2: a sibling "  name: value" line at the item's content indent.
            for (int k = start + 1; k < end; k++)
            {
                var nm = Regex.Match(lines[k], @"^( *)name:\s*(.*)$");
                if (nm.Success && nm.Groups[1].Length == item.ContentIndent)
                {
                    item.NameLineIndex = k;
                    item.NamePrefix = nm.Groups[1].Value + "name: ";
                    item.Name = nm.Groups[2].Value.Trim();
                    break;
                }
            }
            return item;
        }

        // --- PrepareKubeconfig field edits (operate on the controlled, single-entry RP output) ----------

        private static void SetItemName(List<string> lines, Item item, string name)
        {
            if (item.NameLineIndex >= 0)
            {
                lines[item.NameLineIndex] = item.NamePrefix + name;
            }
        }

        private static void EmbedClientKey(List<string> lines, Item item, string keyData)
        {
            for (int k = item.Start; k < item.End; k++)
            {
                var m = Regex.Match(lines[k], @"^(\s*)client-key(-data)?:\s");
                if (m.Success)
                {
                    lines[k] = m.Groups[1].Value + "client-key-data: " + keyData;
                    return;
                }
            }
        }

        private static void SetContextReferences(List<string> lines, Item item, string name)
        {
            for (int k = item.Start; k < item.End; k++)
            {
                var m = Regex.Match(lines[k], @"^(\s*)(cluster|user):\s");
                if (m.Success && m.Groups[1].Length == item.ContentIndent + 2)
                {
                    lines[k] = m.Groups[1].Value + m.Groups[2].Value + ": " + name;
                }
            }
        }

        private static void SetCurrentContext(List<string> lines, string value)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (Regex.IsMatch(lines[i], @"^current-context:(\s|$)"))
                {
                    lines[i] = CurrentContext + ": " + value;
                    return;
                }
            }
            lines.Add(CurrentContext + ": " + value);
        }

        private static string GetCurrentContextValue(List<string> lines)
        {
            foreach (var line in lines)
            {
                var m = Regex.Match(line, @"^current-context:\s*(.*)$");
                if (m.Success)
                {
                    return m.Groups[1].Value.Trim();
                }
            }
            return null;
        }

        // --- text helpers ---------------------------------------------------------------------------

        private static List<string> SplitLines(string text, out string nl)
        {
            nl = text.IndexOf("\r\n", StringComparison.Ordinal) >= 0 ? "\r\n" : "\n";
            return new List<string>(text.Replace("\r\n", "\n").Split('\n'));
        }

        private static int LeadingSpaces(string s)
        {
            int n = 0;
            while (n < s.Length && s[n] == ' ')
            {
                n++;
            }
            return n;
        }

        // Shift a whole block's indentation so its "- " line sits at targetIndent, keeping relative structure.
        private static List<string> Reindent(List<string> block, int targetIndent)
        {
            if (block.Count == 0)
            {
                return block;
            }
            int delta = targetIndent - LeadingSpaces(block[0]);
            if (delta == 0)
            {
                return new List<string>(block);
            }

            var result = new List<string>(block.Count);
            foreach (var line in block)
            {
                if (line.Length == 0)
                {
                    result.Add(line);
                }
                else if (delta > 0)
                {
                    result.Add(new string(' ', delta) + line);
                }
                else
                {
                    int remove = Math.Min(-delta, LeadingSpaces(line));
                    result.Add(line.Substring(remove));
                }
            }
            return result;
        }
    }
}
