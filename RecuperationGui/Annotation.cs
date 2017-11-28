using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecuperationGui
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class NotifyPropertyChangedInvocatorAttribute : Attribute
    {
        public NotifyPropertyChangedInvocatorAttribute()
        {
        }

        public NotifyPropertyChangedInvocatorAttribute([NotNull] string parameterName)
        {
            ParameterName = parameterName;
        }

        [CanBeNull]
        public string ParameterName { get; private set; }

        [AttributeUsage(
            AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property |
            AttributeTargets.Delegate | AttributeTargets.Field | AttributeTargets.Event |
            AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.GenericParameter)]
        public sealed class NotNullAttribute : Attribute
        {
        }

        [AttributeUsage(
            AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property |
            AttributeTargets.Delegate | AttributeTargets.Field | AttributeTargets.Event |
            AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.GenericParameter)]
        public sealed class CanBeNullAttribute : Attribute
        {
        }
    }
}
