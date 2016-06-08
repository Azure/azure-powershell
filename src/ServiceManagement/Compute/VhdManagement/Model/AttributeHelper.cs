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

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model
{
    public class AttributeHelper<T>
    {
        private readonly Type type;
        public AttributeHelper()
        {
            type = typeof(T);
        }

        public VhdEntityAttribute GetEntityAttribute()
        {
            var attributes = type.GetCustomAttributes(typeof(VhdEntityAttribute), false);
            if (attributes.Length == 0)
            {
                throw new InvalidOperationException(String.Format("Entity must have the attribute:{0}", typeof(VhdEntityAttribute).Name));
            }
            return (VhdEntityAttribute)attributes[0];
        }

        public VhdPropertyAttribute GetAttribute(Expression<Func<object>> propertyNameProvider)
        {
            MemberExpression me;
            if (propertyNameProvider.Body is UnaryExpression)
            {
                me = ((UnaryExpression)propertyNameProvider.Body).Operand as MemberExpression;
            }
            else
            {
                me = propertyNameProvider.Body as MemberExpression;
            }

            if (me == null || me.Expression.Type != type)
            {
                throw new InvalidOperationException("Not a valid expression, must be a VhdFooter property access");
            }

            var propertyName = me.Member.Name;

            var attributes = from p in type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                             let vhdPropertyAttributes = p.GetCustomAttributes(typeof(VhdPropertyAttribute), false)
                             let exists = vhdPropertyAttributes.Length > 0
                             where p.Name == propertyName
                             select (VhdPropertyAttribute)(vhdPropertyAttributes[0]);
            return attributes.FirstOrDefault();
        }

        public VhdPropertyAttribute GetAttribute(Expression<Func<T, object>> propertyNameProvider)
        {
            MemberExpression me;
            if (propertyNameProvider.Body is UnaryExpression)
            {
                me = ((UnaryExpression)propertyNameProvider.Body).Operand as MemberExpression;
            }
            else
            {
                me = propertyNameProvider.Body as MemberExpression;
            }

            if (me == null || me.Expression.Type != type)
            {
                throw new InvalidOperationException("Not a valid expression, must be a VhdFooter property access");
            }

            var propertyName = me.Member.Name;

            var attributes = from p in type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                             let vhdPropertyAttributes = p.GetCustomAttributes(typeof(VhdPropertyAttribute), false)
                             let exists = vhdPropertyAttributes.Length > 0
                             where p.Name == propertyName
                             select (VhdPropertyAttribute)(vhdPropertyAttributes[0]);
            return attributes.FirstOrDefault();
        }
    }
}