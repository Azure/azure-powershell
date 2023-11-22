/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json
{
    

    internal sealed class JsonMember
    {
        private readonly TypeDetails type;

        private readonly Func<object, object> getter;
        private readonly Action<object, object> setter;

        internal JsonMember(PropertyInfo property, int defaultOrder)
        {
            getter = property.GetValue;
            setter = property.SetValue;

            var dataMember = property.GetCustomAttribute<DataMemberAttribute>();

            Name = dataMember?.Name ?? property.Name;
            Order = dataMember?.Order ?? defaultOrder;
            EmitDefaultValue = dataMember?.EmitDefaultValue ?? true;

            this.type = TypeDetails.Get(property.PropertyType);

            CanRead = property.CanRead;
        }

        internal JsonMember(FieldInfo field, int defaultOrder)
        {
            getter = field.GetValue;
            setter = field.SetValue;

            var dataMember = field.GetCustomAttribute<DataMemberAttribute>();

            Name = dataMember?.Name ?? field.Name;
            Order = dataMember?.Order ?? defaultOrder;
            EmitDefaultValue = dataMember?.EmitDefaultValue ?? true;

            this.type = TypeDetails.Get(field.FieldType);

            CanRead = true;
        }

        internal string Name { get; }

        internal int Order { get; }

        internal TypeDetails TypeDetails => type;

        internal Type Type => type.NonNullType;

        internal bool IsList => type.IsList;

        // Arrays, Sets, ...
        internal Type ElementType => type.ElementType;

        internal IJsonConverter Converter => type.JsonConverter;

        internal bool EmitDefaultValue { get; }

        internal bool IsStringLike => type.IsStringLike;

        internal object DefaultValue => type.DefaultValue;

        internal bool CanRead { get; }

        #region Helpers

        internal object GetValue(object instance) => getter(instance);

        internal void SetValue(object instance, object value) => setter(instance, value);

        #endregion
    }
}