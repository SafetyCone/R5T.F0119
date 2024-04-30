using System;
using System.Collections.Generic;

using R5T.T0170;


namespace R5T.F0119.Extensions
{
    public static class InstanceDescriptorExtensions
    {
        public static IEnumerable<InstanceDescriptor> Of_InstanceVariety(this IEnumerable<InstanceDescriptor> instanceDescriptors,
            T0171.IInstanceVarietyName instanceVarietyName,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var output = Instances.Filters.For_InstanceVariety(
                instanceDescriptors,
                instanceVarietyName,
                includeObsolete,
                includeDrafts);

            return output;
        }

        public static IEnumerable<InstanceDescriptor> Of_InstanceVariety(this IEnumerable<InstanceDescriptor> instanceDescriptors,
            T0171.IInstanceVarietyName instanceVarietyName,
            T0171.IInstanceVarietyName instanceVarietyName_Draft,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var output = Instances.Filters.For_InstanceVariety(
                instanceDescriptors,
                instanceVarietyName,
                instanceVarietyName_Draft,
                includeObsolete,
                includeDrafts);

            return output;
        }

        public static IEnumerable<InstanceDescriptor> Markers(this IEnumerable<InstanceDescriptor> instanceDescriptors,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var output = Instances.Filters.For_InstanceVariety(
                instanceDescriptors,
                Instances.InstanceVarietyNames.Markers,
                Instances.InstanceVarietyNames.MarkerDrafts,
                includeObsolete,
                includeDrafts);

            return output;
        }

        public static IEnumerable<InstanceDescriptor> Markers_OLD(this IEnumerable<InstanceDescriptor> instanceDescriptors,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var output = Instances.Filters.For_Markers(
                instanceDescriptors,
                includeObsolete,
                includeDrafts);

            return output;
        }

        public static IEnumerable<InstanceDescriptor> Values(this IEnumerable<InstanceDescriptor> instanceDescriptors,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var output = Instances.Filters.For_Values(
                instanceDescriptors,
                includeObsolete,
                includeDrafts);

            return output;
        }

        public static IEnumerable<InstanceDescriptor> WhereIsOneOf(this IEnumerable<InstanceDescriptor> instanceDescriptors,
            IEnumerable<T0171.IInstanceVarietyName> instanceVarietyNames)
        {
            return Instances.InstanceDescriptorOperator.WhereIsOneOf(
                instanceDescriptors,
                instanceVarietyNames);
        }

        public static IEnumerable<InstanceDescriptor> WhereIs(this IEnumerable<InstanceDescriptor> instanceDescriptors,
            T0171.IInstanceVarietyName instanceVarietyName)
        {
            return Instances.InstanceDescriptorOperator.WhereIs(
                instanceDescriptors,
                instanceVarietyName);
        }

        public static IEnumerable<InstanceDescriptor> WhereIsFunction(this IEnumerable<InstanceDescriptor> instanceDescriptors)
        {
            return Instances.InstanceDescriptorOperator.WhereIsFunction(instanceDescriptors);
        }

        /// <inheritdoc cref="IInstanceDescriptorOperator.WhereIsValue(IEnumerable{InstanceDescriptor})"/>
        public static IEnumerable<InstanceDescriptor> WhereIsValue(this IEnumerable<InstanceDescriptor> instanceDescriptors)
        {
            return Instances.InstanceDescriptorOperator.WhereIsValue(instanceDescriptors);
        }
    }
}
