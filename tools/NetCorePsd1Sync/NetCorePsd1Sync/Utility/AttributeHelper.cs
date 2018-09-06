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

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NetCorePsd1Sync.Utility
{
    public static class AttributeHelper
    {
        // https://stackoverflow.com/a/32501356/294804
        public static bool TryGetPropertyAttributeValue<TClass, TProp, TAttribute, TValue>(Expression<Func<TClass, TProp>> propertyExpression, Func<TAttribute, TValue> valueSelector, out TValue value) where TAttribute : Attribute
        {
            var expression = (MemberExpression)propertyExpression.Body;
            var propertyInfo = (PropertyInfo)expression.Member;
            var attributes = propertyInfo.GetCustomAttributes(typeof(TAttribute), true).OfType<TAttribute>().ToArray();
            var isFound = attributes.Any();
            value = isFound ? valueSelector(attributes.First()) : default;
            return isFound;
        }

        public static TValue GetPropertyAttributeValue<TClass, TProp, TAttribute, TValue>(Expression<Func<TClass, TProp>> propertyExpression, Func<TAttribute, TValue> valueSelector, TValue defaultValue) where TAttribute : Attribute => 
            TryGetPropertyAttributeValue(propertyExpression, valueSelector, out var value) ? value : defaultValue;
    }
}
