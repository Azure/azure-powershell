/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DescriptionAttribute : Attribute
    {
        public string Description { get; }

        public DescriptionAttribute(string description)
        {
            Description = description;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class DoNotExportAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class InternalExportAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class GeneratedAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class DoNotFormatAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class ProfileAttribute : Attribute
    {
        public string[] Profiles { get; }

        public ProfileAttribute(params string[] profiles)
        {
            Profiles = profiles;
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CategoryAttribute : Attribute
    {
        public ParameterCategory[] Categories { get; }

        public CategoryAttribute(params ParameterCategory[] categories)
        {
            Categories = categories;
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ExportAsAttribute : Attribute
    {
        public Type Type { get; set; }

        public ExportAsAttribute(Type type)
        {
            Type = type;
        }
    }

    public enum ParameterCategory
    {
        // Note: Order is significant
        Uri = 0,
        Path,
        Query,
        Header,
        Cookie,
        Body,
        Azure,
        Runtime
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class OriginAttribute : Attribute
    {
        public PropertyOrigin Origin { get; }

        public OriginAttribute(PropertyOrigin origin)
        {
            Origin = origin;
        }
    }

    public enum PropertyOrigin
    {
        // Note: Order is significant
        Inherited = 0,
        Owned,
        Inlined
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class FormatTableAttribute : Attribute
    {
        public int Index { get; set; } = -1;
        public bool HasIndex => Index != -1;
        public string Label { get; set; }
        public int Width { get; set; } = -1;
        public bool HasWidth => Width != -1;
    }
}
