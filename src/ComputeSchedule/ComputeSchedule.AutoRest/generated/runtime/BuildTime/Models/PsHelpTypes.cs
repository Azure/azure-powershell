/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.PowerShell
{
    internal class PsHelpInfo
    {
        public string CmdletName { get; }
        public string ModuleName { get; }
        public string Synopsis { get; }
        public string Description { get; }
        public string AlertText { get; }
        public string Category { get; }
        public PsHelpLinkInfo OnlineVersion { get; }
        public PsHelpLinkInfo[] RelatedLinks { get; }
        public bool? HasCommonParameters { get; }
        public bool? HasWorkflowCommonParameters { get; }

        public PsHelpTypeInfo[] InputTypes { get; }
        public PsHelpTypeInfo[] OutputTypes { get; }
        public PsHelpExampleInfo[] Examples { get; set; }
        public string[] Aliases { get; }

        public PsParameterHelpInfo[] Parameters { get; }
        public PsHelpSyntaxInfo[] Syntax { get; }

        public object Component { get; }
        public object Functionality { get; }
        public object PsSnapIn { get; }
        public object Role { get; }
        public string NonTerminatingErrors { get; }

        public PsHelpInfo(PSObject helpObject = null)
        {
            helpObject = helpObject ?? new PSObject();
            CmdletName = helpObject.GetProperty<string>("Name").NullIfEmpty() ?? helpObject.GetNestedProperty<string>("details", "name");
            ModuleName = helpObject.GetProperty<string>("ModuleName");
            Synopsis = helpObject.GetProperty<string>("Synopsis");
            Description = helpObject.GetProperty<PSObject[]>("description").EmptyIfNull().ToDescriptionText().NullIfEmpty() ??
                          helpObject.GetNestedProperty<PSObject[]>("details", "description").EmptyIfNull().ToDescriptionText();
            AlertText = helpObject.GetNestedProperty<PSObject[]>("alertSet", "alert").EmptyIfNull().ToDescriptionText();
            Category = helpObject.GetProperty<string>("Category");
            HasCommonParameters = helpObject.GetProperty<string>("CommonParameters").ToNullableBool();
            HasWorkflowCommonParameters = helpObject.GetProperty<string>("WorkflowCommonParameters").ToNullableBool();

            var links = helpObject.GetNestedProperty<PSObject[]>("relatedLinks", "navigationLink").EmptyIfNull().Select(nl => nl.ToLinkInfo()).ToArray();
            OnlineVersion = links.FirstOrDefault(l => l.Text?.ToLowerInvariant().StartsWith("online version:") ?? links.Length == 1);
            RelatedLinks = links.Where(l => !l.Text?.ToLowerInvariant().StartsWith("online version:") ?? links.Length != 1).ToArray();

            InputTypes = helpObject.GetNestedProperty<PSObject[]>("inputTypes", "inputType").EmptyIfNull().Select(it => it.ToTypeInfo()).ToArray();
            OutputTypes = helpObject.GetNestedProperty<PSObject[]>("returnValues", "returnValue").EmptyIfNull().Select(rv => rv.ToTypeInfo()).ToArray();
            Examples = helpObject.GetNestedProperty<PSObject[]>("examples", "example").EmptyIfNull().Select(e => e.ToExampleInfo()).ToArray();
            Aliases = helpObject.GetProperty<string>("aliases").EmptyIfNull().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            Parameters = helpObject.GetNestedProperty<PSObject[]>("parameters", "parameter").EmptyIfNull().Select(p => p.ToPsParameterHelpInfo()).ToArray();
            Syntax = helpObject.GetNestedProperty<PSObject[]>("syntax", "syntaxItem").EmptyIfNull().Select(si => si.ToSyntaxInfo()).ToArray();

            Component = helpObject.GetProperty<object>("Component");
            Functionality = helpObject.GetProperty<object>("Functionality");
            PsSnapIn = helpObject.GetProperty<object>("PSSnapIn");
            Role = helpObject.GetProperty<object>("Role");
            NonTerminatingErrors = helpObject.GetProperty<string>("nonTerminatingErrors");
        }
    }

    internal class PsHelpTypeInfo
    {
        public string Name { get; }
        public string Description { get; }

        public PsHelpTypeInfo(PSObject typeObject)
        {
            Name = typeObject.GetNestedProperty<string>("type", "name").EmptyIfNull().Trim();
            Description = typeObject.GetProperty<PSObject[]>("description").EmptyIfNull().ToDescriptionText();
        }
    }

    internal class PsHelpLinkInfo
    {
        public string Uri { get; }
        public string Text { get; }

        public PsHelpLinkInfo(PSObject linkObject)
        {
            Uri = linkObject.GetProperty<string>("uri");
            Text = linkObject.GetProperty<string>("linkText");
        }
    }

    internal class PsHelpSyntaxInfo
    {
        public string CmdletName { get; }
        public PsParameterHelpInfo[] Parameters { get; }

        public PsHelpSyntaxInfo(PSObject syntaxObject)
        {
            CmdletName = syntaxObject.GetProperty<string>("name");
            Parameters = syntaxObject.GetProperty<PSObject[]>("parameter").EmptyIfNull().Select(p => p.ToPsParameterHelpInfo()).ToArray();
        }
    }

    internal class PsHelpExampleInfo
    {
        public string Title { get; }
        public string Code { get; }
        public string Output { get; }
        public string Remarks { get; }

        public PsHelpExampleInfo(PSObject exampleObject)
        {
            Title = exampleObject.GetProperty<string>("title");
            Code = exampleObject.GetProperty<string>("code");
            Output = exampleObject.GetProperty<string>("output");
            Remarks = exampleObject.GetProperty<PSObject[]>("remarks").EmptyIfNull().ToDescriptionText();
        }
        public PsHelpExampleInfo(MarkdownExampleHelpInfo markdownExample)
        {
            Title = markdownExample.Name;
            Code = markdownExample.Code;
            Output = markdownExample.Output;
            Remarks = markdownExample.Description;
        }

        public static implicit operator PsHelpExampleInfo(MarkdownExampleHelpInfo markdownExample) => new PsHelpExampleInfo(markdownExample);
    }

    internal class PsParameterHelpInfo
    {
        public string DefaultValueAsString { get; }

        public string Name { get; }
        public string TypeName { get; }
        public string Description { get; }
        public string SupportsPipelineInput { get; }
        public string PositionText { get; }
        public string[] ParameterSetNames { get; }
        public string[] Aliases { get; }

        public bool? SupportsGlobbing { get; }
        public bool? IsRequired { get; }
        public bool? IsVariableLength { get; }
        public bool? IsDynamic { get; }

        public PsParameterHelpInfo(PSObject parameterHelpObject = null)
        {
            parameterHelpObject = parameterHelpObject ?? new PSObject();
            DefaultValueAsString = parameterHelpObject.GetProperty<string>("defaultValue");
            Name = parameterHelpObject.GetProperty<string>("name");
            TypeName = parameterHelpObject.GetProperty<string>("parameterValue").NullIfEmpty() ?? parameterHelpObject.GetNestedProperty<string>("type", "name");
            Description = parameterHelpObject.GetProperty<PSObject[]>("Description").EmptyIfNull().ToDescriptionText();
            SupportsPipelineInput = parameterHelpObject.GetProperty<string>("pipelineInput");
            PositionText = parameterHelpObject.GetProperty<string>("position");
            ParameterSetNames = parameterHelpObject.GetProperty<string>("parameterSetName").EmptyIfNull().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            Aliases = parameterHelpObject.GetProperty<string>("aliases").EmptyIfNull().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            SupportsGlobbing = parameterHelpObject.GetProperty<string>("globbing").ToNullableBool();
            IsRequired = parameterHelpObject.GetProperty<string>("required").ToNullableBool();
            IsVariableLength = parameterHelpObject.GetProperty<string>("variableLength").ToNullableBool();
            IsDynamic = parameterHelpObject.GetProperty<string>("isDynamic").ToNullableBool();
        }
    }

    internal class PsModuleHelpInfo
    {
        public string Name { get; }
        public Guid Guid { get; }
        public string Description { get; }

        public PsModuleHelpInfo(PSModuleInfo moduleInfo)
            : this(moduleInfo?.Name ?? String.Empty, moduleInfo?.Guid ?? Guid.NewGuid(), moduleInfo?.Description ?? String.Empty)
        {
        }

        public PsModuleHelpInfo(string name, Guid guid, string description)
        {
            Name = name;
            Guid = guid;
            Description = description;
        }
    }

    internal static class HelpTypesExtensions
    {
        public static PsHelpInfo ToPsHelpInfo(this PSObject helpObject) => new PsHelpInfo(helpObject);
        public static PsParameterHelpInfo ToPsParameterHelpInfo(this PSObject parameterHelpObject) => new PsParameterHelpInfo(parameterHelpObject);

        public static string ToDescriptionText(this IEnumerable<PSObject> descriptionObject) => descriptionObject != null
            ? String.Join(Environment.NewLine, descriptionObject.Select(dl => dl.GetProperty<string>("Text").EmptyIfNull())).NullIfWhiteSpace()
            : null;
        public static PsHelpTypeInfo ToTypeInfo(this PSObject typeObject) => new PsHelpTypeInfo(typeObject);
        public static PsHelpExampleInfo ToExampleInfo(this PSObject exampleObject) => new PsHelpExampleInfo(exampleObject);
        public static PsHelpLinkInfo ToLinkInfo(this PSObject linkObject) => new PsHelpLinkInfo(linkObject);
        public static PsHelpSyntaxInfo ToSyntaxInfo(this PSObject syntaxObject) => new PsHelpSyntaxInfo(syntaxObject);
        public static PsModuleHelpInfo ToModuleInfo(this PSModuleInfo moduleInfo) => new PsModuleHelpInfo(moduleInfo);
    }
}
