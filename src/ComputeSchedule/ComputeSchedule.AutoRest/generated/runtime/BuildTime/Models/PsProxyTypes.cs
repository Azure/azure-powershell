/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using static Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.PowerShell.PsProxyOutputExtensions;
using static Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.PowerShell.PsProxyTypeExtensions;

namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.PowerShell
{
    internal class ProfileGroup
    {
        public string ProfileName { get; }
        public Variant[] Variants { get; }
        public string ProfileFolder { get; }

        public ProfileGroup(Variant[] variants, string profileName = NoProfiles)
        {
            ProfileName = profileName;
            Variants = variants;
            ProfileFolder = ProfileName != NoProfiles ? ProfileName : String.Empty;
        }
    }

    internal class VariantGroup
    {
        public string ModuleName { get; }

        public string RootModuleName { get => @""; }
        public string CmdletName { get; }
        public string CmdletVerb { get; }
        public string CmdletNoun { get; }
        public string ProfileName { get; }
        public Variant[] Variants { get; }
        public ParameterGroup[] ParameterGroups { get; }
        public ComplexInterfaceInfo[] ComplexInterfaceInfos { get; }

        public string[] Aliases { get; }
        public PSTypeName[] OutputTypes { get; }
        public bool SupportsShouldProcess { get; }
        public bool SupportsPaging { get; }
        public string DefaultParameterSetName { get; }
        public bool HasMultipleVariants { get; }
        public PsHelpInfo HelpInfo { get; }
        public bool IsGenerated { get; }
        public bool IsInternal { get; }
        public string OutputFolder { get; }
        public string FileName { get; }
        public string FilePath { get; }

        public CommentInfo CommentInfo { get; }

        public VariantGroup(string moduleName, string cmdletName, Variant[] variants, string outputFolder, string profileName = NoProfiles, bool isTest = false, bool isInternal = false)
        {
            ModuleName = moduleName;
            CmdletName = cmdletName;
            var cmdletNameParts = CmdletName.Split('-');
            CmdletVerb = cmdletNameParts.First();
            CmdletNoun = cmdletNameParts.Last();
            ProfileName = profileName;
            Variants = variants;
            ParameterGroups = Variants.ToParameterGroups().OrderBy(pg => pg.OrderCategory).ThenByDescending(pg => pg.IsMandatory).ToArray();
            var aliasDuplicates = ParameterGroups.SelectMany(pg => pg.Aliases)
                //https://stackoverflow.com/a/18547390/294804
                .GroupBy(a => a).Where(g => g.Count() > 1).Select(g => g.Key).ToArray();
            if (aliasDuplicates.Any())
            {
                throw new ParsingMetadataException($"The alias(es) [{String.Join(", ", aliasDuplicates)}] are defined on multiple parameters for cmdlet '{CmdletName}', which is not supported.");
            }
            ComplexInterfaceInfos = ParameterGroups.Where(pg => !pg.DontShow && pg.IsComplexInterface).OrderBy(pg => pg.ParameterName).Select(pg => pg.ComplexInterfaceInfo).ToArray();

            Aliases = Variants.SelectMany(v => v.Attributes).ToAliasNames().ToArray();
            OutputTypes = Variants.SelectMany(v => v.Info.OutputType).Where(ot => ot.Type != null).GroupBy(ot => ot.Type).Select(otg => otg.First()).ToArray();
            SupportsShouldProcess = Variants.Any(v => v.SupportsShouldProcess);
            SupportsPaging = Variants.Any(v => v.SupportsPaging);
            DefaultParameterSetName = DetermineDefaultParameterSetName();
            HasMultipleVariants = Variants.Length > 1;
            HelpInfo = Variants.Select(v => v.HelpInfo).FirstOrDefault() ?? new PsHelpInfo();
            IsGenerated = Variants.All(v => v.Attributes.OfType<GeneratedAttribute>().Any());
            IsInternal = isInternal;
            OutputFolder = outputFolder;
            FileName = $"{CmdletName}{(isTest ? ".Tests" : String.Empty)}.ps1";
            FilePath = Path.Combine(OutputFolder, FileName);

            CommentInfo = new CommentInfo(this);
        }

        private string DetermineDefaultParameterSetName()
        {
            var defaultParameterSet = Variants
                .Select(v => v.Metadata.DefaultParameterSetName)
                .LastOrDefault(dpsn => dpsn.IsValidDefaultParameterSetName());

            if (String.IsNullOrEmpty(defaultParameterSet))
            {
                var variantParamCountGroups = Variants
                    .Where(v => !v.IsNotSuggestDefaultParameterSet)
                    .Select(v => (
                        variant: v.VariantName,
                        paramCount: v.CmdletOnlyParameters.Count(p => p.IsMandatory),
                        isSimple: v.CmdletOnlyParameters.Where(p => p.IsMandatory).All(p => p.ParameterType.IsPsSimple())))
                    .GroupBy(vpc => vpc.isSimple)
                    .ToArray();
                if (variantParamCountGroups.Length == 0)
                {
                    variantParamCountGroups = Variants
                        .Select(v => (
                            variant: v.VariantName,
                            paramCount: v.CmdletOnlyParameters.Count(p => p.IsMandatory),
                            isSimple: v.CmdletOnlyParameters.Where(p => p.IsMandatory).All(p => p.ParameterType.IsPsSimple())))
                        .GroupBy(vpc => vpc.isSimple)
                        .ToArray();
                }
                var variantParameterCounts = (variantParamCountGroups.Any(g => g.Key) ? variantParamCountGroups.Where(g => g.Key) : variantParamCountGroups).SelectMany(g => g).ToArray();
                var smallestParameterCount = variantParameterCounts.Min(vpc => vpc.paramCount);
                defaultParameterSet = variantParameterCounts.First(vpc => vpc.paramCount == smallestParameterCount).variant;
            }

            return defaultParameterSet;
        }
    }

    internal class Variant
    {
        public string CmdletName { get; }
        public string VariantName { get; }
        public CommandInfo Info { get; }
        public CommandMetadata Metadata { get; }
        public PsHelpInfo HelpInfo { get; }
        public bool HasParameterSets { get; }
        public bool IsFunction { get; }
        public string PrivateModuleName { get; }
        public string PrivateCmdletName { get; }
        public bool SupportsShouldProcess { get; }
        public bool SupportsPaging { get; }

        public Attribute[] Attributes { get; }
        public Parameter[] Parameters { get; }
        public Parameter[] CmdletOnlyParameters { get; }
        public bool IsInternal { get; }
        public bool IsDoNotExport { get; }
        public bool IsNotSuggestDefaultParameterSet { get; }
        public string[] Profiles { get; }

        public Variant(string cmdletName, string variantName, CommandInfo info, CommandMetadata metadata, bool hasParameterSets = false, PsHelpInfo helpInfo = null)
        {
            CmdletName = cmdletName;
            VariantName = variantName;
            Info = info;
            HelpInfo = helpInfo ?? new PsHelpInfo();
            Metadata = metadata;
            HasParameterSets = hasParameterSets;
            IsFunction = Info.CommandType == CommandTypes.Function;
            PrivateModuleName = Info.Source;
            PrivateCmdletName = Metadata.Name;
            SupportsShouldProcess = Metadata.SupportsShouldProcess;
            SupportsPaging = Metadata.SupportsPaging;

            Attributes = this.ToAttributes();
            Parameters = this.ToParameters().OrderBy(p => p.OrderCategory).ThenByDescending(p => p.IsMandatory).ToArray();
            IsInternal = Attributes.OfType<InternalExportAttribute>().Any();
            IsDoNotExport = Attributes.OfType<DoNotExportAttribute>().Any();
            IsNotSuggestDefaultParameterSet = Attributes.OfType<NotSuggestDefaultParameterSetAttribute>().Any();
            CmdletOnlyParameters = Parameters.Where(p => !p.Categories.Any(c => c == ParameterCategory.Azure || c == ParameterCategory.Runtime)).ToArray();
            Profiles = Attributes.OfType<ProfileAttribute>().SelectMany(pa => pa.Profiles).ToArray();
        }
    }

    internal class ParameterGroup
    {
        public string ParameterName { get; }
        public Parameter[] Parameters { get; }

        public string[] VariantNames { get; }
        public string[] AllVariantNames { get; }
        public bool HasAllVariants { get; }
        public Type ParameterType { get; }
        public string Description { get; }

        public string[] Aliases { get; }
        public bool HasValidateNotNull { get; }
        public bool HasAllowEmptyArray { get; }
        public CompleterInfo CompleterInfo { get; }
        public DefaultInfo DefaultInfo { get; }
        public bool HasDefaultInfo { get; }
        public ParameterCategory OrderCategory { get; }
        public bool DontShow { get; }
        public bool IsMandatory { get; }
        public bool SupportsWildcards { get; }
        public bool IsComplexInterface { get; }
        public ComplexInterfaceInfo ComplexInterfaceInfo { get; }
        public InfoAttribute InfoAttribute { get; }

        public int? FirstPosition { get; }
        public bool ValueFromPipeline { get; }
        public bool ValueFromPipelineByPropertyName { get; }
        public bool IsInputType { get; }

        public ParameterGroup(string parameterName, Parameter[] parameters, string[] allVariantNames)
        {
            ParameterName = parameterName;
            Parameters = parameters;

            VariantNames = Parameters.Select(p => p.VariantName).ToArray();
            AllVariantNames = allVariantNames;
            HasAllVariants = VariantNames.Any(vn => vn == AllParameterSets) || !AllVariantNames.Except(VariantNames).Any();
            var types = Parameters.Select(p => p.ParameterType).Distinct().ToArray();
            if (types.Length > 1)
            {
                throw new ParsingMetadataException($"The parameter '{ParameterName}' has multiple parameter types [{String.Join(", ", types.Select(t => t.Name))}] defined, which is not supported.");
            }
            ParameterType = types.First();
            Description = Parameters.Select(p => p.Description).FirstOrDefault(d => !String.IsNullOrEmpty(d)).EmptyIfNull();

            Aliases = Parameters.SelectMany(p => p.Attributes).ToAliasNames().ToArray();
            HasValidateNotNull = Parameters.SelectMany(p => p.Attributes.OfType<ValidateNotNullAttribute>()).Any();
            HasAllowEmptyArray = Parameters.SelectMany(p => p.Attributes.OfType<AllowEmptyCollectionAttribute>()).Any();
            CompleterInfo = Parameters.Select(p => p.CompleterInfoAttribute).FirstOrDefault()?.ToCompleterInfo()
                            ?? Parameters.Select(p => p.PSArgumentCompleterAttribute).FirstOrDefault()?.ToPSArgumentCompleterInfo()
                            ?? Parameters.Select(p => p.ArgumentCompleterAttribute).FirstOrDefault()?.ToCompleterInfo();
            DefaultInfo = Parameters.Select(p => p.DefaultInfoAttribute).FirstOrDefault()?.ToDefaultInfo(this)
                            ?? Parameters.Select(p => p.DefaultValueAttribute).FirstOrDefault(dv => dv != null)?.ToDefaultInfo(this);
            HasDefaultInfo = DefaultInfo != null && !String.IsNullOrEmpty(DefaultInfo.Script);
            // When DefaultInfo is present, force all parameters from this group to be optional.
            if (HasDefaultInfo)
            {
                foreach (var parameter in Parameters)
                {
                    parameter.IsMandatory = false;
                }
            }
            OrderCategory = Parameters.Select(p => p.OrderCategory).Distinct().DefaultIfEmpty(ParameterCategory.Body).Min();
            DontShow = Parameters.All(p => p.DontShow);
            IsMandatory = HasAllVariants && Parameters.Any(p => p.IsMandatory);
            SupportsWildcards = Parameters.Any(p => p.SupportsWildcards);
            IsComplexInterface = Parameters.Any(p => p.IsComplexInterface);
            ComplexInterfaceInfo = Parameters.Where(p => p.IsComplexInterface).Select(p => p.ComplexInterfaceInfo).FirstOrDefault();
            InfoAttribute = Parameters.Select(p => p.InfoAttribute).First();

            FirstPosition = Parameters.Select(p => p.Position).FirstOrDefault(p => p != null);
            ValueFromPipeline = Parameters.Any(p => p.ValueFromPipeline);
            ValueFromPipelineByPropertyName = Parameters.Any(p => p.ValueFromPipelineByPropertyName);
            IsInputType = ValueFromPipeline || ValueFromPipelineByPropertyName;
        }
    }

    internal class Parameter
    {
        public string VariantName { get; }
        public string ParameterName { get; }
        public ParameterMetadata Metadata { get; }
        public PsParameterHelpInfo HelpInfo { get; }
        public Type ParameterType { get; }
        public Attribute[] Attributes { get; }
        public ParameterCategory[] Categories { get; }
        public ParameterCategory OrderCategory { get; }
        public PSDefaultValueAttribute DefaultValueAttribute { get; }
        public DefaultInfoAttribute DefaultInfoAttribute { get; }
        public ParameterAttribute ParameterAttribute { get; }
        public bool SupportsWildcards { get; }
        public CompleterInfoAttribute CompleterInfoAttribute { get; }
        public ArgumentCompleterAttribute ArgumentCompleterAttribute { get; }
        public PSArgumentCompleterAttribute PSArgumentCompleterAttribute { get; }

        public bool ValueFromPipeline { get; }
        public bool ValueFromPipelineByPropertyName { get; }
        public int? Position { get; }
        public bool DontShow { get; }
        public bool IsMandatory { get; set; }

        public InfoAttribute InfoAttribute { get; }
        public ComplexInterfaceInfo ComplexInterfaceInfo { get; }
        public bool IsComplexInterface { get; }
        public string Description { get; }

        public Parameter(string variantName, string parameterName, ParameterMetadata metadata, PsParameterHelpInfo helpInfo = null)
        {
            VariantName = variantName;
            ParameterName = parameterName;
            Metadata = metadata;
            HelpInfo = helpInfo ?? new PsParameterHelpInfo();

            Attributes = Metadata.Attributes.ToArray();
            ParameterType = Attributes.OfType<ExportAsAttribute>().FirstOrDefault()?.Type ?? Metadata.ParameterType;
            Categories = Attributes.OfType<CategoryAttribute>().SelectMany(ca => ca.Categories).Distinct().ToArray();
            OrderCategory = Categories.DefaultIfEmpty(ParameterCategory.Body).Min();
            DefaultValueAttribute = Attributes.OfType<PSDefaultValueAttribute>().FirstOrDefault();
            DefaultInfoAttribute = Attributes.OfType<DefaultInfoAttribute>().FirstOrDefault();
            ParameterAttribute = Attributes.OfType<ParameterAttribute>().FirstOrDefault(pa => pa.ParameterSetName == VariantName || pa.ParameterSetName == AllParameterSets);
            if (ParameterAttribute == null)
            {
                throw new ParsingMetadataException($"The variant '{VariantName}' has multiple parameter sets defined, which is not supported.");
            }
            SupportsWildcards = Attributes.OfType<SupportsWildcardsAttribute>().Any();
            CompleterInfoAttribute = Attributes.OfType<CompleterInfoAttribute>().FirstOrDefault();
            PSArgumentCompleterAttribute = Attributes.OfType<PSArgumentCompleterAttribute>().FirstOrDefault();
            ArgumentCompleterAttribute = Attributes.OfType<ArgumentCompleterAttribute>().FirstOrDefault(attr => !attr.GetType().Equals(typeof(PSArgumentCompleterAttribute)));

            ValueFromPipeline = ParameterAttribute.ValueFromPipeline;
            ValueFromPipelineByPropertyName = ParameterAttribute.ValueFromPipelineByPropertyName;
            Position = ParameterAttribute.Position == Int32.MinValue ? (int?)null : ParameterAttribute.Position;
            DontShow = ParameterAttribute.DontShow;
            IsMandatory = ParameterAttribute.Mandatory;

            var complexParameterName = ParameterName.ToUpperInvariant();
            var complexMessage = $"{Environment.NewLine}";
            var description = ParameterAttribute.HelpMessage.NullIfEmpty() ?? HelpInfo.Description.NullIfEmpty() ?? InfoAttribute?.Description.NullIfEmpty() ?? String.Empty;
            // Remove the complex type message as it will be reinserted if this is a complex type
            description = description.NormalizeNewLines();
            // Make an InfoAttribute for processing only if one isn't provided
            InfoAttribute = Attributes.OfType<InfoAttribute>().FirstOrDefault() ?? new InfoAttribute { PossibleTypes = new[] { ParameterType.Unwrap() }, Required = IsMandatory };
            // Set the description if the InfoAttribute does not have one since they are exported without a description
            InfoAttribute.Description = String.IsNullOrEmpty(InfoAttribute.Description) ? description : InfoAttribute.Description;
            ComplexInterfaceInfo = InfoAttribute.ToComplexInterfaceInfo(complexParameterName, ParameterType, true);
            IsComplexInterface = ComplexInterfaceInfo.IsComplexInterface;
            Description = $"{description}{(IsComplexInterface ? complexMessage : String.Empty)}";
        }
    }

    internal class ComplexInterfaceInfo
    {
        public InfoAttribute InfoAttribute { get; }

        public string Name { get; }
        public Type Type { get; }
        public bool Required { get; }
        public bool ReadOnly { get; }
        public string Description { get; }

        public ComplexInterfaceInfo[] NestedInfos { get; }
        public bool IsComplexInterface { get; }

        public ComplexInterfaceInfo(string name, Type type, InfoAttribute infoAttribute, bool? required, List<Type> seenTypes)
        {
            Name = name;
            Type = type;
            InfoAttribute = infoAttribute;

            Required = required ?? InfoAttribute.Required;
            ReadOnly = InfoAttribute.ReadOnly;
            Description = InfoAttribute.Description.ToPsSingleLine();

            var unwrappedType = Type.Unwrap();
            var hasBeenSeen = seenTypes?.Contains(unwrappedType) ?? false;
            (seenTypes ?? (seenTypes = new List<Type>())).Add(unwrappedType);
            NestedInfos = hasBeenSeen ? new ComplexInterfaceInfo[] { } :
                unwrappedType.GetInterfaces()
                .Concat(InfoAttribute.PossibleTypes)
                .SelectMany(pt => pt.GetProperties()
                    .SelectMany(pi => pi.GetCustomAttributes(true).OfType<InfoAttribute>()
                        .Select(ia => ia.ToComplexInterfaceInfo(pi.Name, pi.PropertyType, seenTypes: seenTypes))))
                .Where(cii => !cii.ReadOnly).OrderByDescending(cii => cii.Required).ToArray();
            // https://stackoverflow.com/a/503359/294804
            var associativeArrayInnerType = Type.GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IAssociativeArray<>))
                ?.GetTypeInfo().GetGenericArguments().First();
            if (!hasBeenSeen && associativeArrayInnerType != null)
            {
                var anyInfo = new InfoAttribute { Description = "This indicates any property can be added to this object." };
                NestedInfos = NestedInfos.Prepend(anyInfo.ToComplexInterfaceInfo("(Any)", associativeArrayInnerType)).ToArray();
            }
            IsComplexInterface = NestedInfos.Any();
        }
    }

    internal class CommentInfo
    {
        public string Description { get; }
        public string Synopsis { get; }

        public string[] Examples { get; }
        public string[] Inputs { get; }
        public string[] Outputs { get; }

        public string OnlineVersion { get; }
        public string[] RelatedLinks { get; }
        public string[] ExternalUrls { get; }

        private const string HelpLinkPrefix = @"https://learn.microsoft.com/powershell/module/";

        public CommentInfo(VariantGroup variantGroup)
        {
            var helpInfo = variantGroup.HelpInfo;
            Description = variantGroup.Variants.SelectMany(v => v.Attributes).OfType<DescriptionAttribute>().FirstOrDefault()?.Description.NullIfEmpty()
                          ?? helpInfo.Description.EmptyIfNull();
            // If there is no Synopsis, PowerShell may put in the Syntax string as the Synopsis. This seems unintended, so we remove the Synopsis in this situation.
            var synopsis = helpInfo.Synopsis.EmptyIfNull().Trim().StartsWith(variantGroup.CmdletName) ? String.Empty : helpInfo.Synopsis;
            Synopsis = synopsis.NullIfEmpty() ?? Description;

            Examples = helpInfo.Examples.Select(rl => rl.Code).ToArray();

            Inputs = (variantGroup.ParameterGroups.Where(pg => pg.IsInputType).Select(pg => pg.ParameterType.FullName).ToArray().NullIfEmpty() ??
                      helpInfo.InputTypes.Where(it => it.Name.NullIfWhiteSpace() != null).Select(it => it.Name).ToArray())
                .Where(i => i != "None").Distinct().OrderBy(i => i).ToArray();
            Outputs = (variantGroup.OutputTypes.Select(ot => ot.Type.FullName).ToArray().NullIfEmpty() ??
                       helpInfo.OutputTypes.Where(it => it.Name.NullIfWhiteSpace() != null).Select(ot => ot.Name).ToArray())
                .Where(o => o != "None").Distinct().OrderBy(o => o).ToArray();

            // Use root module name in the help link
            var moduleName = variantGroup.RootModuleName == "" ? variantGroup.ModuleName.ToLowerInvariant() : variantGroup.RootModuleName.ToLowerInvariant();
            OnlineVersion = helpInfo.OnlineVersion?.Uri.NullIfEmpty() ?? $@"{HelpLinkPrefix}{moduleName}/{variantGroup.CmdletName.ToLowerInvariant()}";
            RelatedLinks = helpInfo.RelatedLinks.Select(rl => rl.Text).ToArray();

            // Get external urls from attribute
            ExternalUrls = variantGroup.Variants.SelectMany(v => v.Attributes).OfType<ExternalDocsAttribute>()?.Select(e => e.Url)?.Distinct()?.ToArray();
        }
    }

    internal class CompleterInfo
    {
        public string Name { get; }
        public string Description { get; }
        public string Script { get; }
        public Type Type { get; }
        public bool IsTypeCompleter { get; }

        public CompleterInfo(CompleterInfoAttribute infoAttribute)
        {
            Name = infoAttribute.Name;
            Description = infoAttribute.Description;
            Script = infoAttribute.Script;
        }

        public CompleterInfo(ArgumentCompleterAttribute completerAttribute)
        {
            Script = completerAttribute.ScriptBlock?.ToString();
            if (completerAttribute.Type != null)
            {
                Type = completerAttribute.Type;
                IsTypeCompleter = true;
            }
        }
    }

    internal class PSArgumentCompleterInfo : CompleterInfo
    {
        public string[] ResourceTypes { get; }

        public PSArgumentCompleterInfo(PSArgumentCompleterAttribute completerAttribute) : base(completerAttribute)
        {
            ResourceTypes = completerAttribute.ResourceTypes;
        }
    }

    internal class DefaultInfo
    {
        public string Name { get; }
        public string Description { get; }
        public string Script { get; }
        public string SetCondition { get; }
        public ParameterGroup ParameterGroup { get; }

        public DefaultInfo(DefaultInfoAttribute infoAttribute, ParameterGroup parameterGroup)
        {
            Name = infoAttribute.Name;
            Description = infoAttribute.Description;
            Script = infoAttribute.Script;
            SetCondition = infoAttribute.SetCondition;
            ParameterGroup = parameterGroup;
        }

        public DefaultInfo(PSDefaultValueAttribute defaultValueAttribute, ParameterGroup parameterGroup)
        {
            Description = defaultValueAttribute.Help;
            ParameterGroup = parameterGroup;
            if (defaultValueAttribute.Value != null)
            {
                Script = defaultValueAttribute.Value.ToString();
            }
        }
    }

    internal static class PsProxyTypeExtensions
    {
        public const string NoProfiles = "__NoProfiles";

        public static bool IsValidDefaultParameterSetName(this string parameterSetName) =>
            !String.IsNullOrEmpty(parameterSetName) && parameterSetName != AllParameterSets;

        public static Variant[] ToVariants(this CommandInfo info, PsHelpInfo helpInfo)
        {
            var metadata = new CommandMetadata(info);
            var privateCmdletName = metadata.Name.Split('!').First();
            var parts = privateCmdletName.Split('_');
            return parts.Length > 1
                ? new[] { new Variant(parts[0], parts[1], info, metadata, helpInfo: helpInfo) }
                // Process multiple parameter sets, so we declare a variant per parameter set.
                : info.ParameterSets.Select(ps => new Variant(privateCmdletName, ps.Name, info, metadata, true, helpInfo)).ToArray();
        }

        public static Variant[] ToVariants(this CmdletAndHelpInfo info) => info.CommandInfo.ToVariants(info.HelpInfo);

        public static Variant[] ToVariants(this CommandInfo info, PSObject helpInfo = null) => info.ToVariants(helpInfo?.ToPsHelpInfo());

        public static Parameter[] ToParameters(this Variant variant)
        {
            var parameters = variant.Metadata.Parameters.AsEnumerable();
            var parameterHelp = variant.HelpInfo.Parameters.AsEnumerable();

            if (variant.HasParameterSets)
            {
                parameters = parameters.Where(p => p.Value.ParameterSets.Keys.Any(k => k == variant.VariantName || k == AllParameterSets));
                parameterHelp = parameterHelp.Where(ph => (!ph.ParameterSetNames.Any() || ph.ParameterSetNames.Any(psn => psn == variant.VariantName || psn == AllParameterSets)) && ph.Name != "IncludeTotalCount");
            }
            var result = parameters.Select(p => new Parameter(variant.VariantName, p.Key, p.Value, parameterHelp.FirstOrDefault(ph => ph.Name == p.Key)));
            if (variant.SupportsPaging)
            {
                // If supportsPaging is set, we will need to add First and Skip parameters since they are treated as common parameters which as not contained on Metadata>parameters
                variant.Info.Parameters["First"].Attributes.OfType<ParameterAttribute>().FirstOrDefault(pa => pa.ParameterSetName == variant.VariantName || pa.ParameterSetName == AllParameterSets).HelpMessage = "Gets only the first 'n' objects.";
                variant.Info.Parameters["Skip"].Attributes.OfType<ParameterAttribute>().FirstOrDefault(pa => pa.ParameterSetName == variant.VariantName || pa.ParameterSetName == AllParameterSets).HelpMessage = "Ignores the first 'n' objects and then gets the remaining objects.";
                result = result.Append(new Parameter(variant.VariantName, "First", variant.Info.Parameters["First"], parameterHelp.FirstOrDefault(ph => ph.Name == "First")));
                result = result.Append(new Parameter(variant.VariantName, "Skip", variant.Info.Parameters["Skip"], parameterHelp.FirstOrDefault(ph => ph.Name == "Skip")));
            }
            return result.ToArray();
        }

        public static Attribute[] ToAttributes(this Variant variant) => variant.IsFunction
            ? ((FunctionInfo)variant.Info).ScriptBlock.Attributes.ToArray()
            : variant.Metadata.CommandType.GetCustomAttributes(false).Cast<Attribute>().ToArray();

        public static IEnumerable<ParameterGroup> ToParameterGroups(this Variant[] variants)
        {
            var allVariantNames = variants.Select(vg => vg.VariantName).ToArray();
            return variants
                .SelectMany(v => v.Parameters)
                .GroupBy(p => p.ParameterName, StringComparer.InvariantCultureIgnoreCase)
                .Select(pg => new ParameterGroup(pg.Key, pg.Select(p => p).ToArray(), allVariantNames));
        }

        public static ComplexInterfaceInfo ToComplexInterfaceInfo(this InfoAttribute infoAttribute, string name, Type type, bool? required = null, List<Type> seenTypes = null)
            => new ComplexInterfaceInfo(name, type, infoAttribute, required, seenTypes);

        public static CompleterInfo ToCompleterInfo(this CompleterInfoAttribute infoAttribute) => new CompleterInfo(infoAttribute);
        public static CompleterInfo ToCompleterInfo(this ArgumentCompleterAttribute completerAttribute) => new CompleterInfo(completerAttribute);
        public static PSArgumentCompleterInfo ToPSArgumentCompleterInfo(this PSArgumentCompleterAttribute completerAttribute) => new PSArgumentCompleterInfo(completerAttribute);
        public static DefaultInfo ToDefaultInfo(this DefaultInfoAttribute infoAttribute, ParameterGroup parameterGroup) => new DefaultInfo(infoAttribute, parameterGroup);
        public static DefaultInfo ToDefaultInfo(this PSDefaultValueAttribute defaultValueAttribute, ParameterGroup parameterGroup) => new DefaultInfo(defaultValueAttribute, parameterGroup);
    }
}
