using System;
using System.Collections.Generic;

using R5T.T0170;
using R5T.T0171;


namespace R5T.F0119.Extensions
{
    public static class InstanceDescriptorExtensions
    {
        public static IEnumerable<InstanceDescriptor> WhereIsOneOf(this IEnumerable<InstanceDescriptor> instanceDescriptors,
            IEnumerable<IInstanceVarietyName> instanceVarietyNames)
        {
            return Instances.InstanceDescriptorOperator.WhereIsOneOf(
                instanceDescriptors,
                instanceVarietyNames);
        }

        public static IEnumerable<InstanceDescriptor> WhereIs(this IEnumerable<InstanceDescriptor> instanceDescriptors,
            IInstanceVarietyName instanceVarietyName)
        {
            return Instances.InstanceDescriptorOperator.WhereIs(
                instanceDescriptors,
                instanceVarietyName);
        }

        public static IEnumerable<InstanceDescriptor> WhereIsFunction(this IEnumerable<InstanceDescriptor> instanceDescriptors)
        {
            return Instances.InstanceDescriptorOperator.WhereIsFunction(instanceDescriptors);
        }

        public static IEnumerable<InstanceDescriptor> WhereIsValue(this IEnumerable<InstanceDescriptor> instanceDescriptors)
        {
            return Instances.InstanceDescriptorOperator.WhereIsValue(instanceDescriptors);
        }
    }
}
