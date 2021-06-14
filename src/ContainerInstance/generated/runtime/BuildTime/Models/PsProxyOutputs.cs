/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Text.RegularExpressions;
using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell.PsProxyOutputExtensions;
using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell.PsProxyTypeExtensions;

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell
{
    internal class OutputTypeOutput
    {
        public PSTypeName[] OutputTypes { get; }

        public OutputTypeOutput(IEnumerable<PSTypeName> outputTypes)
        {
            OutputTypes = outputTypes.ToArray();
        }

        public override string ToString() => OutputTypes != null && OutputTypes.Any() ? $"[OutputType({OutputTypes.Select(ot => $"[{ot}]").JoinIgnoreEmpty(ItemSeparator)})]{Environment.NewLine}" : String.Empty;
    }

    internal class CmdletBindingOutput
    {
        public VariantGroup VariantGroup { get; }

        public CmdletBindingOutput(VariantGroup variantGroup)
        {
            VariantGroup = variantGroup;
        }

        public override string ToString()
        {
            var dpsText = VariantGroup.DefaultParameterSetName.IsValidDefaultParameterSetName() ? $"DefaultParameterSetName='{VariantGroup.DefaultParameterSetName}'" : String.Empty;
            var sspText = VariantGroup.SupportsShouldProcess ? $"SupportsShouldProcess{ItemSeparator}ConfirmImpact='Medium'" : String.Empty;
            var pbText = $"PositionalBinding={false.ToPsBool()}";
            var propertyText = new[] { dpsText, pbText, sspText }.JoinIgnoreEmpty(ItemSeparator);
            return $"[CmdletBinding({propertyText})]{Environment.NewLine}";
        }
    }

    internal class ParameterOutput
    {
        public Parameter Parameter { get; }
        public bool HasMultipleVariantsInVariantGroup { get; }
        public bool HasAllVariantsInParameterGroup { get; }

        public ParameterOutput(Parameter parameter, bool hasMultipleVariantsInVariantGroup, bool hasAllVariantsInParameterGroup)
        {
            Parameter = parameter;
            HasMultipleVariantsInVariantGroup = hasMultipleVariantsInVariantGroup;
            HasAllVariantsInParameterGroup = hasAllVariantsInParameterGroup;
        }

        public override string ToString()
        {
            var psnText = HasMultipleVariantsInVariantGroup && !HasAllVariantsInParameterGroup ? $"ParameterSetName='{Parameter.VariantName}'" : String.Empty;
            var positionText = Parameter.Position != null ? $"Position={Parameter.Position}" : String.Empty;
            var mandatoryText = Parameter.IsMandatory ? "Mandatory" : String.Empty;
            var dontShowText = Parameter.DontShow ? "DontShow" : String.Empty;
            var vfpText = Parameter.ValueFromPipeline ? "ValueFromPipeline" : String.Empty;
            var vfpbpnText = Parameter.ValueFromPipelineByPropertyName ? "ValueFromPipelineByPropertyName" : String.Empty;
            var propertyText = new[] { psnText, positionText, mandatoryText, dontShowText, vfpText, vfpbpnText }.JoinIgnoreEmpty(ItemSeparator);
            return $"{Indent}[Parameter({propertyText})]{Environment.NewLine}";
        }
    }

    internal class AliasOutput
    {
        public string[] Aliases { get; }
        public bool IncludeIndent { get; }

        public AliasOutput(string[] aliases, bool includeIndent = false)
        {
            Aliases = aliases;
            IncludeIndent = includeIndent;
        }

        public override string ToString() => Aliases?.Any() ?? false ? $"{(IncludeIndent ? Indent : String.Empty)}[Alias({Aliases.Select(an => $"'{an}'").JoinIgnoreEmpty(ItemSeparator)})]{Environment.NewLine}" : String.Empty;
    }

    internal class ValidateNotNullOutput
    {
        public bool HasValidateNotNull { get; }

        public ValidateNotNullOutput(bool hasValidateNotNull)
        {
            HasValidateNotNull = hasValidateNotNull;
        }

        public override string ToString() => HasValidateNotNull ? $"{Indent}[ValidateNotNull()]{Environment.NewLine}" : String.Empty;
    }

    internal class ArgumentCompleterOutput
    {
        public CompleterInfo CompleterInfo { get; }

        public ArgumentCompleterOutput(CompleterInfo completerInfo)
        {
            CompleterInfo = completerInfo;
        }

        public override string ToString() => CompleterInfo != null
            ? $"{Indent}[ArgumentCompleter({(CompleterInfo.IsTypeCompleter ? $"[{CompleterInfo.Type.Unwrap().ToPsType()}]" : $"{{{CompleterInfo.Script.ToPsSingleLine("; ")}}}")})]{Environment.NewLine}"
            : String.Empty;
    }

    internal class DefaultInfoOutput
    {
        public bool HasDefaultInfo { get; }
        public DefaultInfo DefaultInfo { get; }

        public DefaultInfoOutput(ParameterGroup parameterGroup)
        {
            HasDefaultInfo = parameterGroup.HasDefaultInfo;
            DefaultInfo = parameterGroup.DefaultInfo;
        }

        public override string ToString()
        {
            var nameText = !String.IsNullOrEmpty(DefaultInfo?.Name) ? $"Name='{DefaultInfo?.Name}'" : String.Empty;
            var descriptionText = !String.IsNullOrEmpty(DefaultInfo?.Description) ? $"Description='{DefaultInfo?.Description.ToPsStringLiteral()}'" : String.Empty;
            var scriptText = !String.IsNullOrEmpty(DefaultInfo?.Script) ? $"Script='{DefaultInfo?.Script.ToPsSingleLine("; ")}'" : String.Empty;
            var propertyText = new[] { nameText, descriptionText, scriptText }.JoinIgnoreEmpty(ItemSeparator);
            return HasDefaultInfo ? $"{Indent}[{typeof(DefaultInfoAttribute).ToPsAttributeType()}({propertyText})]{Environment.NewLine}" : String.Empty;
        }
    }

    internal class ParameterTypeOutput
    {
        public Type ParameterType { get; }

        public ParameterTypeOutput(Type parameterType)
        {
            ParameterType = parameterType;
        }

        public override string ToString() => $"{Indent}[{ParameterType.ToPsType()}]{Environment.NewLine}";
    }

    internal class ParameterNameOutput
    {
        public string ParameterName { get; }
        public bool IsLast { get; }

        public ParameterNameOutput(string parameterName, bool isLast)
        {
            ParameterName = parameterName;
            IsLast = isLast;
        }

        public override string ToString() => $"{Indent}${{{ParameterName}}}{(IsLast ? String.Empty : $",{Environment.NewLine}")}{Environment.NewLine}";
    }

    internal class BeginOutput
    {
        public VariantGroup VariantGroup { get; }

        public BeginOutput(VariantGroup variantGroup)
        {
            VariantGroup = variantGroup;
        }

        public override string ToString() => $@"begin {{
{Indent}try {{
{Indent}{Indent}$outBuffer = $null
{Indent}{Indent}if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {{
{Indent}{Indent}{Indent}$PSBoundParameters['OutBuffer'] = 1
{Indent}{Indent}}}
{Indent}{Indent}$parameterSet = $PSCmdlet.ParameterSetName
{GetParameterSetToCmdletMapping()}{GetDefaultValuesStatements()}
{Indent}{Indent}$wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
{Indent}{Indent}$scriptCmd = {{& $wrappedCmd @PSBoundParameters}}
{Indent}{Indent}$steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
{Indent}{Indent}$steppablePipeline.Begin($PSCmdlet)
{Indent}}} catch {{
{Indent}{Indent}throw
{Indent}}}
}}

";

        private string GetParameterSetToCmdletMapping()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Indent}{Indent}$mapping = @{{");
            foreach (var variant in VariantGroup.Variants)
            {
                sb.AppendLine($@"{Indent}{Indent}{Indent}{variant.VariantName} = '{variant.PrivateModuleName}\{variant.PrivateCmdletName}';");
            }
            sb.Append($"{Indent}{Indent}}}");
            return sb.ToString();
        }

        private string GetDefaultValuesStatements()
        {
            var defaultInfos = VariantGroup.ParameterGroups.Where(pg => pg.HasDefaultInfo).Select(pg => pg.DefaultInfo).ToArray();
            var sb = new StringBuilder();

            foreach (var defaultInfo in defaultInfos)
            {
                var variantListString = defaultInfo.ParameterGroup.VariantNames.ToPsList();
                var parameterName = defaultInfo.ParameterGroup.ParameterName;
                sb.AppendLine();
                sb.AppendLine($"{Indent}{Indent}if (({variantListString}) -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('{parameterName}')) {{");
                sb.AppendLine($"{Indent}{Indent}{Indent}$PSBoundParameters['{parameterName}'] = {defaultInfo.Script}");
                sb.Append($"{Indent}{Indent}}}");
            }
            return sb.ToString();
        }
    }

    internal class ProcessOutput
    {
        public override string ToString() => $@"process {{
{Indent}try {{
{Indent}{Indent}$steppablePipeline.Process($_)
{Indent}}} catch {{
{Indent}{Indent}throw
{Indent}}}
}}

";
    }

    internal class EndOutput
    {
        public override string ToString() => $@"end {{
{Indent}try {{
{Indent}{Indent}$steppablePipeline.End()
{Indent}}} catch {{
{Indent}{Indent}throw
{Indent}}}
}}
";
    }

    internal class HelpCommentOutput
    {
        public VariantGroup VariantGroup { get; }
        public CommentInfo CommentInfo { get; }

        public HelpCommentOutput(VariantGroup variantGroup)
        {
            VariantGroup = variantGroup;
            CommentInfo = variantGroup.CommentInfo;
        }

        public override string ToString()
        {
            var inputs = String.Join(Environment.NewLine, CommentInfo.Inputs.Select(i => $".Inputs{Environment.NewLine}{i}"));
            var inputsText = !String.IsNullOrEmpty(inputs) ? $"{Environment.NewLine}{inputs}" : String.Empty;
            var outputs = String.Join(Environment.NewLine, CommentInfo.Outputs.Select(o => $".Outputs{Environment.NewLine}{o}"));
            var outputsText = !String.IsNullOrEmpty(outputs) ? $"{Environment.NewLine}{outputs}" : String.Empty;
            var notes = String.Join($"{Environment.NewLine}{Environment.NewLine}", VariantGroup.ComplexInterfaceInfos.Select(cii => cii.ToNoteOutput()));
            var notesText = !String.IsNullOrEmpty(notes) ? $"{Environment.NewLine}.Notes{Environment.NewLine}{ComplexParameterHeader}{notes}" : String.Empty;
            var relatedLinks = String.Join(Environment.NewLine, CommentInfo.RelatedLinks.Select(l => $".Link{Environment.NewLine}{l}"));
            var relatedLinksText = !String.IsNullOrEmpty(relatedLinks) ? $"{Environment.NewLine}{relatedLinks}" : String.Empty;
            var examples = "";
            foreach (var example in VariantGroup.HelpInfo.Examples)
            {
                examples = examples + ".Example" + "\r\n" + example.Code + "\r\n";
            }
            return $@"<#
.Synopsis
{CommentInfo.Synopsis.ToDescriptionFormat(false)}
.Description
{CommentInfo.Description.ToDescriptionFormat(false)}
{examples}{inputsText}{outputsText}{notesText}
.Link
{CommentInfo.OnlineVersion}{relatedLinksText}
#>
";
        }
    }

    internal class ParameterDescriptionOutput
    {
        public string Description { get; }

        public ParameterDescriptionOutput(string description)
        {
            Description = description;
        }

        public override string ToString() => !String.IsNullOrEmpty(Description)
            ? Description.ToDescriptionFormat(false).NormalizeNewLines()
                .Split(new [] { Environment.NewLine }, StringSplitOptions.None)
                .Aggregate(String.Empty, (c, n) => c + $"{Indent}# {n}{Environment.NewLine}")
            : String.Empty;
    }

    internal class ProfileOutput
    {
        public string ProfileName { get; }

        public ProfileOutput(string profileName)
        {
            ProfileName = profileName;
        }

        public override string ToString() => ProfileName != NoProfiles ? $"[{typeof(ProfileAttribute).ToPsAttributeType()}('{ProfileName}')]{Environment.NewLine}" : String.Empty;
    }

    internal class DescriptionOutput
    {
        public string Description { get; }

        public DescriptionOutput(string description)
        {
            Description = description;
        }

        public override string ToString() => !String.IsNullOrEmpty(Description) ? $"[{typeof(DescriptionAttribute).ToPsAttributeType()}('{Description.ToPsStringLiteral()}')]{Environment.NewLine}" : String.Empty;
    }

    internal class ParameterCategoryOutput
    {
        public ParameterCategory Category { get; }

        public ParameterCategoryOutput(ParameterCategory category)
        {
            Category = category;
        }

        public override string ToString() => $"{Indent}[{typeof(CategoryAttribute).ToPsAttributeType()}('{Category}')]{Environment.NewLine}";
    }

    internal class InfoOutput
    {
        public InfoAttribute Info { get; }
        public Type ParameterType { get; }

        public InfoOutput(InfoAttribute info, Type parameterType)
        {
            Info = info;
            ParameterType = parameterType;
        }

        public override string ToString()
        {
            // Rendering of InfoAttribute members that are not used currently
            /*var serializedNameText = Info.SerializedName != null ? $"SerializedName='{Info.SerializedName}'" : String.Empty;
            var readOnlyText = Info.ReadOnly ? "ReadOnly" : String.Empty;
            var descriptionText = !String.IsNullOrEmpty(Info.Description) ? $"Description='{Info.Description.ToPsStringLiteral()}'" : String.Empty;*/

            var requiredText = Info.Required ? "Required" : String.Empty;
            var unwrappedType = ParameterType.Unwrap();
            var hasValidPossibleTypes = Info.PossibleTypes.Any(pt => pt != unwrappedType);
            var possibleTypesText = hasValidPossibleTypes
                ? $"PossibleTypes=({Info.PossibleTypes.Select(pt => $"[{pt.ToPsType()}]").JoinIgnoreEmpty(ItemSeparator)})"
                : String.Empty;
            var propertyText = new[] { /*serializedNameText, */requiredText,/* readOnlyText,*/ possibleTypesText/*, descriptionText*/ }.JoinIgnoreEmpty(ItemSeparator);
            return hasValidPossibleTypes ? $"{Indent}[{typeof(InfoAttribute).ToPsAttributeType()}({propertyText})]{Environment.NewLine}" : String.Empty;
        }
    }

    internal class PropertySyntaxOutput
    {
        public string ParameterName { get; }
        public Type ParameterType { get; }
        public bool IsMandatory { get; }
        public int? Position { get; }
        
        public bool IncludeSpace { get; }
        public bool IncludeDash { get; }

        public PropertySyntaxOutput(Parameter parameter)
        {
            ParameterName = parameter.ParameterName;
            ParameterType = parameter.ParameterType;
            IsMandatory = parameter.IsMandatory;
            Position = parameter.Position;
            IncludeSpace = true;
            IncludeDash = true;
        }

        public PropertySyntaxOutput(ComplexInterfaceInfo complexInterfaceInfo)
        {
            ParameterName = complexInterfaceInfo.Name;
            ParameterType = complexInterfaceInfo.Type;
            IsMandatory = complexInterfaceInfo.Required;
            Position = null;
            IncludeSpace = false;
            IncludeDash = false;
        }

        public override string ToString()
        {
            var leftOptional = !IsMandatory ? "[" : String.Empty;
            var leftPositional = Position != null ? "[" : String.Empty;
            var rightPositional = Position != null ? "]" : String.Empty;
            var type = ParameterType != typeof(SwitchParameter) ? $" <{ParameterType.ToSyntaxTypeName()}>" : String.Empty;
            var rightOptional = !IsMandatory ? "]" : String.Empty;
            var space = IncludeSpace ? " " : String.Empty;
            var dash = IncludeDash ? "-" : String.Empty;
            return $"{space}{leftOptional}{leftPositional}{dash}{ParameterName}{rightPositional}{type}{rightOptional}";
        }
    }

    internal static class PsProxyOutputExtensions
    {
        public const string NoParameters = "__NoParameters";

        public const string AllParameterSets = "__AllParameterSets";

        public const string HalfIndent = "  ";

        public const string Indent = HalfIndent + HalfIndent;

        public const string ItemSeparator = ", ";

        public static readonly string ComplexParameterHeader = $"COMPLEX PARAMETER PROPERTIES{Environment.NewLine}{Environment.NewLine}To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.{Environment.NewLine}{Environment.NewLine}";

        public static string ToPsBool(this bool value) => $"${value.ToString().ToLowerInvariant()}";

        public static string ToPsType(this Type type)
        {
            var regex = new Regex(@"^(.*)`{1}\d+(.*)$");
            var typeText = type.ToString();
            var match = regex.Match(typeText);
            return match.Success ? $"{match.Groups[1]}{match.Groups[2]}" : typeText;
        }

        public static string ToPsAttributeType(this Type type) => type.ToPsType().RemoveEnd("Attribute");

        // https://stackoverflow.com/a/5284606/294804
        private static string RemoveEnd(this string text, string suffix) => text.EndsWith(suffix) ? text.Substring(0, text.Length - suffix.Length) : text;

        public static string ToPsSingleLine(this string value, string replacer = " ") => value.ReplaceNewLines(replacer, new []{"<br>", "\r\n", "\n"});

        public static string ToPsStringLiteral(this string value) => value?.Replace("'", "''").Replace("‘", "''").Replace("’", "''").ToPsSingleLine().Trim() ?? String.Empty;

        public static string JoinIgnoreEmpty(this IEnumerable<string> values, string separator) => String.Join(separator, values?.Where(v => !String.IsNullOrEmpty(v)));

        // https://stackoverflow.com/a/41961738/294804
        public static string ToSyntaxTypeName(this Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return $"{type.GetGenericArguments().First().ToSyntaxTypeName()}?";
            }

            if (type.IsGenericType)
            {
                var genericTypes = String.Join(ItemSeparator, type.GetGenericArguments().Select(ToSyntaxTypeName));
                return $"{type.Name.Split('`').First()}<{genericTypes}>";
            }

            return type.Name;
        }

        public static OutputTypeOutput ToOutputTypeOutput(this IEnumerable<PSTypeName> outputTypes) => new OutputTypeOutput(outputTypes);

        public static CmdletBindingOutput ToCmdletBindingOutput(this VariantGroup variantGroup) => new CmdletBindingOutput(variantGroup);

        public static ParameterOutput ToParameterOutput(this Parameter parameter, bool hasMultipleVariantsInVariantGroup, bool hasAllVariantsInParameterGroup) => new ParameterOutput(parameter, hasMultipleVariantsInVariantGroup, hasAllVariantsInParameterGroup);

        public static AliasOutput ToAliasOutput(this string[] aliases, bool includeIndent = false) => new AliasOutput(aliases, includeIndent);

        public static ValidateNotNullOutput ToValidateNotNullOutput(this bool hasValidateNotNull) => new ValidateNotNullOutput(hasValidateNotNull);

        public static ArgumentCompleterOutput ToArgumentCompleterOutput(this CompleterInfo completerInfo) => new ArgumentCompleterOutput(completerInfo);

        public static DefaultInfoOutput ToDefaultInfoOutput(this ParameterGroup parameterGroup) => new DefaultInfoOutput(parameterGroup);

        public static ParameterTypeOutput ToParameterTypeOutput(this Type parameterType) => new ParameterTypeOutput(parameterType);

        public static ParameterNameOutput ToParameterNameOutput(this string parameterName, bool isLast) => new ParameterNameOutput(parameterName, isLast);

        public static BeginOutput ToBeginOutput(this VariantGroup variantGroup) => new BeginOutput(variantGroup);

        public static ProcessOutput ToProcessOutput(this VariantGroup variantGroup) => new ProcessOutput();

        public static EndOutput ToEndOutput(this VariantGroup variantGroup) => new EndOutput();

        public static HelpCommentOutput ToHelpCommentOutput(this VariantGroup variantGroup) => new HelpCommentOutput(variantGroup);

        public static ParameterDescriptionOutput ToParameterDescriptionOutput(this string description) => new ParameterDescriptionOutput(description);

        public static ProfileOutput ToProfileOutput(this string profileName) => new ProfileOutput(profileName);

        public static DescriptionOutput ToDescriptionOutput(this string description) => new DescriptionOutput(description);

        public static ParameterCategoryOutput ToParameterCategoryOutput(this ParameterCategory category) => new ParameterCategoryOutput(category);

        public static PropertySyntaxOutput ToPropertySyntaxOutput(this Parameter parameter) => new PropertySyntaxOutput(parameter);

        public static PropertySyntaxOutput ToPropertySyntaxOutput(this ComplexInterfaceInfo complexInterfaceInfo) => new PropertySyntaxOutput(complexInterfaceInfo);

        public static InfoOutput ToInfoOutput(this InfoAttribute info, Type parameterType) => new InfoOutput(info, parameterType);

        public static string ToNoteOutput(this ComplexInterfaceInfo complexInterfaceInfo, string currentIndent = "", bool includeDashes = false, bool includeBackticks = false, bool isFirst = true)
        {
            string RenderProperty(ComplexInterfaceInfo info, string indent, bool dash, bool backtick) => 
                $"{indent}{(dash ? "- " : String.Empty)}{(backtick ? "`" : String.Empty)}{info.ToPropertySyntaxOutput()}{(backtick ? "`" : String.Empty)}: {info.Description}";

            var nested = complexInterfaceInfo.NestedInfos.Select(ni =>
            {
                var nestedIndent = $"{currentIndent}{HalfIndent}";
                return ni.IsComplexInterface
                    ? ni.ToNoteOutput(nestedIndent, includeDashes, includeBackticks, false)
                    : RenderProperty(ni, nestedIndent, includeDashes, includeBackticks);
            }).Prepend(RenderProperty(complexInterfaceInfo, currentIndent, !isFirst && includeDashes, !isFirst && includeBackticks));
            return String.Join(Environment.NewLine, nested);
        }
    }
}
