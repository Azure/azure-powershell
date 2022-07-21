// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.PowerShell.Common.Config;
using System;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    /// <summary>
    /// Base class for configs that have a typed value.
    /// </summary>
    /// <typeparam name="TValue">The type of the config value.</typeparam>
    internal abstract class TypedConfig<TValue> : ConfigDefinition
    {
        protected TypedConfig()
        {
        }

        public TValue TypedDefaultValue => (TValue)DefaultValue;

        /// <summary>
        /// Validates if the input value is type <see cref="ValueType"/>.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <exception cref="ArgumentException">Throws when the value in another type.</exception>
        public override void Validate(object value)
        {
            base.Validate(value);
            if (!(value is TValue))
            {
                throw new ArgumentException($"Unexpected value type [{value.GetType()}]. The value of config [{Key}] should be of type [{ValueType}]", nameof(value));
            }
        }

        /// <summary>
        /// Performs side effects before applying the config.
        /// </summary>
        /// <param name="value">The value to be applied to this typed config.</param>
        /// <remarks>
        /// This method is sealed.
        /// Derived types should override <see cref="ApplyTyped(TValue)"/>.
        /// </remarks>
        public override sealed void Apply(object value)
        {
            base.Apply(value);
            ApplyTyped((TValue)value);
        }

        /// <summary>
        /// Generic version of <see cref="Apply(object)"/>.
        /// Override in child classes to perform side effects before applying the config value.
        /// </summary>
        /// <param name="value">The value to be applied to this typed config, cast to the correct type.</param>
        protected virtual void ApplyTyped(TValue value) { }

        public override Type ValueType => typeof(TValue);
    }
}
