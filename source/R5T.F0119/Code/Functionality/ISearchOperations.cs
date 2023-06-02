using System;
using System.Collections.Generic;
using System.Linq;

using R5T.F0119.Extensions;
using R5T.T0132;
using R5T.T0161;
using R5T.T0161.Extensions;
using R5T.T0170;


namespace R5T.F0119
{
    [FunctionalityMarker]
    public partial interface ISearchOperations : IFunctionalityMarker
    {
        /// <summary>
        /// Find all values with names containing a search term.
        /// </summary>
        public InstanceDescriptor[] List_Instances_WithOutputTypesWithNameContaining(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText,
            bool capitalizationSensitive = false)
        {
            var stringComparison = Instances.StringOperator.Get_StringComparison(capitalizationSensitive);

            var propertyAndMethodKinds = new[]
            {
                Instances.KindMarkers.Method,
                Instances.KindMarkers.Property
            };

            var instanceVarietyNames = new[]
            {
                Instances.InstanceVarietyNames.Functions,
                Instances.InstanceVarietyNames.FunctionDrafts,
                Instances.InstanceVarietyNames.Values,
                Instances.InstanceVarietyNames.ValueDrafts,
            };

            var output = instanceDescriptors
                //// For debugging.
                //.Where(x => x.ProjectFilePath.Value == @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.W0002.Private\source\R5T.W0002.Z001\R5T.W0002.Z001.csproj")
                .WhereIsOneOf(instanceVarietyNames)
                .Where(x =>
                {
                    // Values might be either methods or properties (used to just be properties, but with operations values, values can also be methods).
                    var kindMarkedFullMemberName = x.KindMarkedFullMemberName;

                    // Error if the kind is not a method or property.
                    Instances.MemberNameOperator.Verify_Is_KindOneOf(
                        kindMarkedFullMemberName,
                        propertyAndMethodKinds);

                    // We know that both methods and properties have output types, so conversion is ok.
                    var outputTypeNamed = kindMarkedFullMemberName.Value.ToOutputTypeNamed();

                    // Get the output type.
                    var outputTypeName = Instances.MemberNameOperator.Get_OutputTypeName(
                        outputTypeNamed,
                        x => x.ToNamespacedTypeName());

                    // Finally, do the search on the output type name.
                    var output = outputTypeName.Value.Contains(
                        typeNameSearchText,
                        stringComparison);

                    return output;
                })
                .Now();

            return output;
        }

        /// <summary>
        /// Find all methods with parameters of types where the type name contains some search text.
        /// </summary>
        public InstanceDescriptor[] List_Functions_WithParametersOfTypesWithNameContaining(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText,
            bool capitalizationSensitive = false)
        {
            var stringComparison = Instances.StringOperator.Get_StringComparison(capitalizationSensitive);

            var propertyAndMethodKinds = new[]
            {
                Instances.KindMarkers.Method,
            };

            var output = instanceDescriptors
                //// For debugging.
                //.Where(x => x.ProjectFilePath.Value == @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.W0002.Private\source\R5T.W0002.Z001\R5T.W0002.Z001.csproj")
                .WhereIsFunction()
                .Where(x =>
                {
                    // Values might be either methods or properties (used to just be properties, but with operations values, values can also be methods).
                    var kindMarkedFullMemberName = x.KindMarkedFullMemberName;

                    // Error if the kind is not a method.
                    Instances.MemberNameOperator.Verify_Is_KindOneOf(
                        kindMarkedFullMemberName,
                        propertyAndMethodKinds);

                    var kindMarkedFullMethodName = kindMarkedFullMemberName.Value.ToKindMarkedFullMethodName();

                    var (parameters, _, _, _) = Instances.MemberNameOperator.Get_Parameters(kindMarkedFullMethodName);

                    var output = parameters
                        .Where(parameter =>
                        {
                            var parameterTypeName = Instances.ParameterOperator.Get_TypeName(parameter);

                            var output = parameterTypeName.Value.Contains(
                                typeNameSearchText,
                                stringComparison);

                            return output;
                        })
                        .Any();

                    return output;
                })
                .Now();

            return output;
        }

        /// <summary>
        /// Find all values with names containing a search term.
        /// </summary>
        public InstanceDescriptor[] List_Values_OfTypeWithNameContaining(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText,
            bool capitalizationSensitive = false)
        {
            var stringComparison = Instances.StringOperator.Get_StringComparison(capitalizationSensitive);

            var propertyAndMethodKinds = new[]
            {
                Instances.KindMarkers.Method,
                Instances.KindMarkers.Property,
            };

            var output = instanceDescriptors
                //// For debugging.
                //.Where(x => x.ProjectFilePath.Value == @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.W0002.Private\source\R5T.W0002.Z001\R5T.W0002.Z001.csproj")
                .WhereIsValue()
                .Where(x =>
                {
                    // Values might be either methods or properties (used to just be properties, but with operations values, values can also be methods).
                    var kindMarkedFullMemberName = x.KindMarkedFullMemberName;

                    // Error if the kind is not a method or property.
                    Instances.MemberNameOperator.Verify_Is_KindOneOf(
                        kindMarkedFullMemberName,
                        propertyAndMethodKinds);

                    // We know that both methods and properties have output types, so conversion is ok.
                    var outputTypeNamed = kindMarkedFullMemberName.Value.ToOutputTypeNamed();

                    // Get the output type.
                    var outputTypeName = Instances.MemberNameOperator.Get_OutputTypeName(
                        outputTypeNamed,
                        x => x.ToNamespacedTypeName());

                    // Finally, do the search on the output type name.
                    var output = outputTypeName.Value.Contains(
                        typeNameSearchText,
                        stringComparison);

                    return output;
                })
                .Now();

            return output;
        }

        /// <summary>
        /// List all functionality with a method name containing a search term.
        /// </summary>
        public InstanceDescriptor[] List_Functionality_WithMethodNameContaining(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string methodNameSearchTerm,
            bool capitalizationSensitive = false)
        {
            var stringComparison = Instances.StringOperator.Get_StringComparison(capitalizationSensitive);

            var output = instanceDescriptors
                .WhereIsFunction()
                .Where(x =>
                {
                    var methodName = x.KindMarkedFullMemberName.Value.ToKindMarkedFullMethodName();

                    var (simplestMethodName, _, _, _, _) = Instances.MemberNameOperator.Get_SimplestMethodName(methodName);

                    var output = simplestMethodName.Value.Contains(
                        methodNameSearchTerm,
                        stringComparison);

                    return output;
                })
                .Now();

            return output;
        }

        /// <summary>
        /// Find all values of instances with a name containing a search term.
        /// </summary>
        public InstanceDescriptor[] List_Values_OfInstancesWithNameContaining(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string valueInstanceNameSearchTerm,
            bool capitalizationSensitive = false)
        {
            var stringComparison = Instances.StringOperator.Get_StringComparison(capitalizationSensitive);

            var output = instanceDescriptors
                .WhereIsValue()
                .Where(x =>
                {
                    var kindMarkedFullPropertyName = x.KindMarkedFullMemberName.Value.ToKindMarkedFullPropertyName();

                    var (simpleTypeName, namespacedTypeName, namespacedTypedPropertyName, fullPropertyName)
                    = Instances.MemberNameOperator.Get_SimpleTypeName(kindMarkedFullPropertyName);

                    var output = simpleTypeName.Value.Contains(
                        valueInstanceNameSearchTerm,
                        stringComparison);

                    return output;
                })
                .Now();

            return output;
        }

        /// <summary>
        /// Find all values with names containing a search term.
        /// </summary>
        public InstanceDescriptor[] List_Values_WithNameContaining(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string valueNameSearchTerm,
            bool capitalizationSensitive = false)
        {
            var stringComparison = Instances.StringOperator.Get_StringComparison(capitalizationSensitive);

            var output = instanceDescriptors
                .WhereIsValue()
                .Where(x =>
                {
                    var kindMarkedFullPropertyName = x.KindMarkedFullMemberName.Value.ToKindMarkedFullPropertyName();

                    var (_, _, namespacedTypedPropertyName, _)
                        = Instances.MemberNameOperator.Get_SimpleTypeName(kindMarkedFullPropertyName);

                    var propertyName = Instances.MemberNameOperator.Get_SimplePropertyName(namespacedTypedPropertyName);

                    var output = propertyName.Value.Contains(
                        valueNameSearchTerm,
                        stringComparison);

                    return output;
                })
                .Now();

            return output;
        }

        /// <summary>
        /// Find all values with names containing a search term.
        /// </summary>
        public InstanceDescriptor[] List_Values_OfType(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            INamespacedTypeName namespacedTypeName)
        {
            var output = instanceDescriptors
                //// For debugging.
                //.Where(x => x.ProjectFilePath.Value == @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.W0002.Private\source\R5T.W0002.Z001\R5T.W0002.Z001.csproj")
                .WhereIsValue()
                .Where(x =>
                {
                    var kindMarkedFullPropertyName = x.KindMarkedFullMemberName.Value.ToKindMarkedFullPropertyName();

                    var (_, _, _, fullPropertyName)
                        = Instances.MemberNameOperator.Get_SimpleTypeName(kindMarkedFullPropertyName);

                    var outputTypeName = Instances.MemberNameOperator.Get_OutputTypeName<INamespacedTypeName>(
                        fullPropertyName,
                        x => x.ToNamespacedTypeName());

                    var output = namespacedTypeName.Equals(outputTypeName);
                    return output;
                })
                .Now();

            return output;
        }
    }
}
