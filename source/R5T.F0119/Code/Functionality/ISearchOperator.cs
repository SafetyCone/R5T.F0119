using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using R5T.L0065.T000;
using R5T.T0132;
using R5T.T0170;

using R5T.F0119.Extensions;


namespace R5T.F0119
{
    [FunctionalityMarker]
    public partial interface ISearchOperator : IFunctionalityMarker
    {
        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_Values_WithInstanceTypeNameContainingText(
            string searchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_Values_WithInstanceTypeNameContainingText(
                instanceDescriptors,
                searchText,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_Values_WithInstanceTypeNameContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var instanceTypeNameContainsTypeNameSearchText = this.Get_InstanceTypeNameContains_ForValue(
                typeNameSearchText);

            var output = instanceDescriptors
                .Of_InstanceVariety(
                    Instances.InstanceVarietyNames.Values,
                    Instances.InstanceVarietyNames.ValueDrafts,
                    includeObsolete,
                    includeDrafts)
                .Select(Instances.Selectors.SignatureAndInstanceDescriptor_ForValues)
                .Where(instanceTypeNameContainsTypeNameSearchText)
                .Select(x => x.InstanceDescriptor)
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_Functions_WithInstanceTypeNameContainingText(
            string searchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_Functions_WithInstanceTypeNameContainingText(
                instanceDescriptors,
                searchText,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_Functions_WithInstanceTypeNameContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var instanceTypeNameContainsTypeNameSearchText = this.Get_InstanceTypeNameContains(
                typeNameSearchText);

            var output = instanceDescriptors
                .Of_InstanceVariety(
                    Instances.InstanceVarietyNames.Functions,
                    Instances.InstanceVarietyNames.FunctionDrafts,
                    includeObsolete,
                    includeDrafts)
                .Select(Instances.Selectors.MethodSignatureAndInstanceDescriptor_ForFunctions)
                .Where(instanceTypeNameContainsTypeNameSearchText)
                .Select(x => x.InstanceDescriptor)
                .Now()
                ;

            return output;
        }

        public Func<(Signature Signature, InstanceDescriptor InstanceDescriptor), bool> Get_InstanceTypeNameContains_ForValue(
            string typeNameSearchText)
            => tuple =>
            {
                var declaringTypeSignature = tuple.Signature switch
                {
                    PropertySignature propertySignature => propertySignature.DeclaringType,
                    MethodSignature methodSignature => methodSignature.DeclaringType,
                    _ => throw Instances.SwitchOperator.Get_UnrecognizedSwitchTypeExpression(tuple.Signature)
                };

                var instanceTypeNamespacedTypeName = Instances.SignatureOperator.Get_SignatureStringValue(declaringTypeSignature);

                var output = instanceTypeNamespacedTypeName.Contains(typeNameSearchText, StringComparison.InvariantCultureIgnoreCase);
                return output;
            };

        /// <summary>
        /// Does the instance type (declaring type) name contain the search text?
        /// </summary>
        public Func<(MethodSignature MethodSignature, InstanceDescriptor InstanceDescriptor), bool> Get_InstanceTypeNameContains(
            string typeNameSearchText)
            => tuple =>
            {
                var instanceTypeNamespacedTypeName = Instances.SignatureOperator.Get_SignatureStringValue(
                    tuple.MethodSignature.DeclaringType);

                var output = instanceTypeNamespacedTypeName.Contains(typeNameSearchText, StringComparison.InvariantCultureIgnoreCase);
                return output;
            };

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_Functions_WithInputTypeNamesContainingText(
            string searchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_Functions_WithInputTypeNamesContainingText(
                instanceDescriptors,
                searchText,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_Functions_WithInputTypeNamesContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var inputTypeNamesContainsTypeNameSearchText = this.Get_InputTypeNamesContain(
                typeNameSearchText);

            var output = instanceDescriptors
                .Of_InstanceVariety(
                    Instances.InstanceVarietyNames.Functions,
                    Instances.InstanceVarietyNames.FunctionDrafts,
                    includeObsolete,
                    includeDrafts)
                .Select(Instances.Selectors.MethodSignatureAndInstanceDescriptor_ForFunctions)
                .Where(inputTypeNamesContainsTypeNameSearchText)
                .Select(x => x.InstanceDescriptor)
                .Now()
                ;

            return output;
        }

        /// <summary>
        /// Do any of the input parameter namespaced type names contain the search text?
        /// </summary>
        public Func<(MethodSignature MethodSignature, InstanceDescriptor InstanceDescriptor), bool> Get_InputTypeNamesContain(
            string typeNameSearchText)
            => tuple =>
            {
                var inputTypeNamespacedTypeNames = tuple.MethodSignature.Parameters
                    .Select(parameter => Instances.SignatureOperator.Get_SignatureStringValue(parameter.ParameterType))
                    .Where(namespacedTypeName => namespacedTypeName.Contains(typeNameSearchText, StringComparison.InvariantCultureIgnoreCase))
                    ;

                var output = inputTypeNamespacedTypeNames.Any();
                return output;
            };

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_Functions_WithReturnTypeNameContainingText(
            string searchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_Functions_WithReturnTypeNameContainingText(
                instanceDescriptors,
                searchText,
                includeObsolete,
                includeDrafts);

        public Func<(MethodSignature MethodSignature, InstanceDescriptor InstanceDescriptor), bool> Get_ReturnTypeNameContains(
            string typeNameSearchText)
            => tuple =>
            {
                var returnTypeNamespacedTypeName = Instances.SignatureOperator.Get_SignatureStringValue(
                    tuple.MethodSignature.ReturnType);

                var output = returnTypeNamespacedTypeName.Contains(typeNameSearchText, StringComparison.InvariantCultureIgnoreCase);
                return output;
            };

        public InstanceDescriptor[] List_Functions_WithReturnTypeNameContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var returnTypeNameContainsTypeNameSearchText = this.Get_ReturnTypeNameContains(
                typeNameSearchText);

            var output = instanceDescriptors
                .Of_InstanceVariety(
                    Instances.InstanceVarietyNames.Functions,
                    Instances.InstanceVarietyNames.FunctionDrafts,
                    includeObsolete,
                    includeDrafts)
                .Select(Instances.Selectors.MethodSignatureAndInstanceDescriptor_ForFunctions)
                .Where(returnTypeNameContainsTypeNameSearchText)
                .Select(x => x.InstanceDescriptor)
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_Functions_ContainingText_ByRegex(
            string regexPattern,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_Functions_ContainingText_ByRegex(
                instanceDescriptors,
                regexPattern,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_Functions_ContainingText_ByRegex(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string regexPattern,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var regex = new Regex(regexPattern, RegexOptions.IgnoreCase);

            var output = instanceDescriptors
                .Of_InstanceVariety(
                    Instances.InstanceVarietyNames.Functions,
                    Instances.InstanceVarietyNames.FunctionDrafts,
                    includeObsolete,
                    includeDrafts)
                .Where(instanceDescriptor =>
                {
                    var output = regex.IsMatch(instanceDescriptor.SignatureString.Value);
                    return output;
                })
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_Functions_ContainingText(
            string searchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_Functions_ContainingText(
                instanceDescriptors,
                searchText,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_Functions_ContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string searchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var signatureStringValueContainsSearchText = Instances.InstanceDescriptorOperator.Get_SignatureStringValue_Contains(searchText);

            var output = instanceDescriptors
                .Of_InstanceVariety(
                    Instances.InstanceVarietyNames.Functions,
                    Instances.InstanceVarietyNames.FunctionDrafts,
                    includeObsolete,
                    includeDrafts)
                .Where(signatureStringValueContainsSearchText)
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_Demonstrations_ContainingText(
            string searchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_Demonstrations_ContainingText(
                instanceDescriptors,
                searchText,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_Demonstrations_ContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string searchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var signatureStringValueContainsSearchText = Instances.InstanceDescriptorOperator.Get_SignatureStringValue_Contains(searchText);

            var output = instanceDescriptors
                .Of_InstanceVariety(
                    Instances.InstanceVarietyNames.Demonstrations,
                    Instances.InstanceVarietyNames.DemonstrationDrafts,
                    includeObsolete,
                    includeDrafts)
                .Where(signatureStringValueContainsSearchText)
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_Scripts_ContainingText(
            string searchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_Scripts_ContainingText(
                instanceDescriptors,
                searchText,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_Scripts_ContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string searchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var signatureStringValueContainsSearchText = Instances.InstanceDescriptorOperator.Get_SignatureStringValue_Contains(searchText);

            var output = instanceDescriptors
                .Of_InstanceVariety(
                    Instances.InstanceVarietyNames.Scripts,
                    includeObsolete,
                    includeDrafts)
                .Where(signatureStringValueContainsSearchText)
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_StrongTypes_ContainingText(
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_StrongTypes_ContainingText(
                instanceDescriptors,
                typeNameSearchText,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_StrongTypes_ContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var signatureStringValueContainsSearchText = Instances.InstanceDescriptorOperator.Get_SignatureStringValue_Contains(typeNameSearchText);

            var output = instanceDescriptors
                .Of_InstanceVariety(
                    Instances.InstanceVarietyNames.StrongTypeInterfaces,
                    Instances.InstanceVarietyNames.StrongTypeInterfaceDrafts,
                    includeObsolete,
                    includeDrafts)
                .Where(signatureStringValueContainsSearchText)
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_UtilityTypes_ContainingText(
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_UtilityTypes_ContainingText(
                instanceDescriptors,
                typeNameSearchText,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_UtilityTypes_ContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var signatureStringValueContainsSearchText = Instances.InstanceDescriptorOperator.Get_SignatureStringValue_Contains(typeNameSearchText);

            var output = instanceDescriptors
                .Of_InstanceVariety(
                    Instances.InstanceVarietyNames.UtilityTypes,
                    Instances.InstanceVarietyNames.UtilityTypeDrafts,
                    includeObsolete,
                    includeDrafts)
                .Where(signatureStringValueContainsSearchText)
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_DataTypes_ContainingText(
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_DataTypes_ContainingText(
                instanceDescriptors,
                typeNameSearchText,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_DataTypes_ContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var signatureStringValueContainsSearchText = Instances.InstanceDescriptorOperator.Get_SignatureStringValue_Contains(typeNameSearchText);

            var output = instanceDescriptors
                .Of_InstanceVariety(
                    Instances.InstanceVarietyNames.DataTypes,
                    Instances.InstanceVarietyNames.DataTypeDrafts,
                    includeObsolete,
                    includeDrafts)
                .Where(signatureStringValueContainsSearchText)
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_Checks_ContainingText(
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_Checks_ContainingText(
                instanceDescriptors,
                typeNameSearchText,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_Checks_ContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var signatureStringValueContainsSearchText = Instances.InstanceDescriptorOperator.Get_SignatureStringValue_Contains(typeNameSearchText);

            var output = instanceDescriptors
                .Of_InstanceVariety(
                    Instances.InstanceVarietyNames.Checks,
                    includeObsolete,
                    includeDrafts)
                .Where(signatureStringValueContainsSearchText)
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_RazorPages_ContainingText(
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_RazorPages_ContainingText(
                instanceDescriptors,
                typeNameSearchText,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_RazorPages_ContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var signatureStringValueContainsSearchText = Instances.InstanceDescriptorOperator.Get_SignatureStringValue_Contains(typeNameSearchText);

            var output = instanceDescriptors
                .Of_InstanceVariety(
                    Instances.InstanceVarietyNames.RazorPages,
                    includeObsolete,
                    includeDrafts)
                .Where(signatureStringValueContainsSearchText)
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_RazorLayouts_ContainingText(
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_RazorLayouts_ContainingText(
                instanceDescriptors,
                typeNameSearchText,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_RazorLayouts_ContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var signatureStringValueContainsSearchText = Instances.InstanceDescriptorOperator.Get_SignatureStringValue_Contains(typeNameSearchText);

            var output = instanceDescriptors
                .Of_InstanceVariety(
                    Instances.InstanceVarietyNames.RazorLayouts,
                    includeObsolete,
                    includeDrafts)
                .Where(signatureStringValueContainsSearchText)
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_RazorComponents_ContainingText(
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_RazorComponents_ContainingText(
                instanceDescriptors,
                typeNameSearchText,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_RazorComponents_ContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var signatureStringValueContainsSearchText = Instances.InstanceDescriptorOperator.Get_SignatureStringValue_Contains(typeNameSearchText);

            var output = instanceDescriptors
                .Of_InstanceVariety(
                    Instances.InstanceVarietyNames.RazorComponents,
                    Instances.InstanceVarietyNames.RazorComponentDrafts,
                    includeObsolete,
                    includeDrafts)
                .Where(signatureStringValueContainsSearchText)
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_ServiceImplementations_ContainingText(
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_ServiceImplementations_ContainingText(
                instanceDescriptors,
                typeNameSearchText,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_ServiceImplementations_ContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var signatureStringValueContainsSearchText = Instances.InstanceDescriptorOperator.Get_SignatureStringValue_Contains(typeNameSearchText);

            var output = instanceDescriptors
                .Of_InstanceVariety(
                    Instances.InstanceVarietyNames.ServiceImplementations,
                    Instances.InstanceVarietyNames.ServiceImplementationDrafts,
                    includeObsolete,
                    includeDrafts)
                .Where(signatureStringValueContainsSearchText)
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_ServiceDefinitions_ContainingText(
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_ServiceDefinitions_ContainingText(
                instanceDescriptors,
                typeNameSearchText,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_ServiceDefinitions_ContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var signatureStringValueContainsSearchText = Instances.InstanceDescriptorOperator.Get_SignatureStringValue_Contains(typeNameSearchText);

            var output = instanceDescriptors
                .Of_InstanceVariety(
                    Instances.InstanceVarietyNames.ServiceDefinitions,
                    Instances.InstanceVarietyNames.ServiceDefinitionDrafts,
                    includeObsolete,
                    includeDrafts)
                .Where(signatureStringValueContainsSearchText)
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_Markers_ContainingText(
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_Markers_ContainingText(
                instanceDescriptors,
                typeNameSearchText,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_Markers_ContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var signatureStringValueContainsSearchText = Instances.InstanceDescriptorOperator.Get_SignatureStringValue_Contains(typeNameSearchText);

            var output = instanceDescriptors
                .Markers(includeObsolete, includeDrafts)
                .Where(signatureStringValueContainsSearchText)
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, InstanceDescriptor[]> Get_List_Values_ContainingText(
            string searchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_Values_ContainingText(
                instanceDescriptors,
                searchText,
                includeObsolete,
                includeDrafts);

        public InstanceDescriptor[] List_Values_ContainingText(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string searchText,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var output = instanceDescriptors
                .Values(includeObsolete, includeDrafts)
                .Where(x => x.SignatureString.Value.Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, TypeSignature[]> Get_List_DeclarationTypes_OfValues_Distinct(
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_DeclarationTypes_OfValues_Distinct(
                instanceDescriptors,
                includeObsolete,
                includeDrafts);

        public TypeSignature[] List_DeclarationTypes_OfValues_Distinct(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var output = instanceDescriptors
                .Values(includeObsolete, includeDrafts)
                .Select(Instances.Selectors.SignatureSelector_ForValues)
                .Select(Instances.Selectors.DeclaringTypeSignatureSelector_ForValues)
                .DistinctBy(Instances.Selectors.NamespacedTypeNameSelector)
                .Now()
                ;

            return output;
        }

        public Func<IEnumerable<InstanceDescriptor>, TypeSignature[]> Get_List_ImplementationTypes_OfValues_Distinct(
            bool includeObsolete = true,
            bool includeDrafts = true)
            => instanceDescriptors => this.List_ImplementationTypes_OfValues_Distinct(
                instanceDescriptors,
                includeObsolete,
                includeDrafts);

        public TypeSignature[] List_ImplementationTypes_OfValues_Distinct(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var output = instanceDescriptors
                .Values(includeObsolete, includeDrafts)
                .Select(Instances.Selectors.SignatureSelector_ForValues)
                .Select(Instances.Selectors.ImplementationTypeSignatureSelector_ForValues)
                .DistinctBy(Instances.Selectors.NamespacedTypeNameSelector)
                .Now()
                ;

            return output;
        }

        public Func<InstanceDescriptor, bool> Get_InstanceVarietyPredicate(
            T0171.IInstanceVarietyName instanceVarietyName,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var instanceVarietyPredicate = Instances.InstanceDescriptorOperator.Get_Is_InstanceVarietyPredicate(
                instanceVarietyName);

            var output = Instances.PredicateOperator.And(
                instanceVarietyPredicate,
                this.Get_IncludeObsoleteInstancesPredicate(includeObsolete));

            return output;
        }

        public Func<InstanceDescriptor, bool> Get_InstanceVarietyPredicate(
            T0171.IInstanceVarietyName instanceVarietyName,
            T0171.IInstanceVarietyName instanceVarietyName_Draft,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var output = Instances.PredicateOperator.And(
                this.Get_IncludeDraftsPredicate(
                    instanceVarietyName,
                    instanceVarietyName_Draft,
                    includeDrafts),
                this.Get_IncludeObsoleteInstancesPredicate(includeObsolete));

            return output;
        }

        public Func<InstanceDescriptor, bool> Get_MarkersPredicate(
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var output = Instances.PredicateOperator.And(
                this.Get_IncludeMarkersPredicate(includeDrafts),
                this.Get_IncludeObsoleteInstancesPredicate(includeObsolete));

            return output;
        }

        public Func<InstanceDescriptor, bool> Get_ValuesPredicate(
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var output = Instances.PredicateOperator.And(
                this.Get_IncludeValuesPredicate(includeDrafts),
                this.Get_IncludeObsoleteInstancesPredicate(includeObsolete));

            return output;
        }

        public Func<TypeSignature, bool> Get_TypeNamespacedTypeName_Is(
            string typeNamespacedTypeName)
        {
            var namespaceName = Instances.NamespacedTypeNameOperator.Get_NamespaceName(typeNamespacedTypeName);
            var typeName = Instances.NamespacedTypeNameOperator.Get_TypeName(typeNamespacedTypeName);

            return typeSignature =>
            {
                var output = typeSignature.NamespaceName == namespaceName
                    && typeSignature.TypeName == typeName
                    ;

                return output;
            };
        }

        public Func<string, bool> Get_TextContainsSearchTermPredicate(
            string searchTerm,
            bool capitalizationSensitive)
        {
            var stringComparison = Instances.StringOperator.Get_StringComparison(capitalizationSensitive);

            return text =>
            {
                var output = Instances.StringOperator.Contains(
                    text,
                    searchTerm,
                    stringComparison);

                return output;
            };
        }

        public Func<InstanceDescriptor, bool> Get_IncludeDraftsPredicate(
            T0171.IInstanceVarietyName instanceVarietyName,
            T0171.IInstanceVarietyName instanceVarietyName_Draft,
            bool includeDrafts = true)
        {
            var instanceVarietyNamePredicate = Instances.InstanceDescriptorOperator.Get_Is_InstanceVarietyPredicate(
                instanceVarietyName);

            var output = includeDrafts
                ? Instances.PredicateOperator.Or(
                    instanceVarietyNamePredicate,
                    Instances.InstanceDescriptorOperator.Get_Is_InstanceVarietyPredicate(
                        instanceVarietyName_Draft))
                : instanceVarietyNamePredicate
                ;

            return output;
        }

        public Func<InstanceDescriptor, bool> Get_IncludeMarkersPredicate(bool includeDrafts = true)
        {
            var output = includeDrafts
                ? Instances.PredicateOperator.Or(
                    Instances.InstanceDescriptorPredicates.Is_Markers,
                    Instances.InstanceDescriptorPredicates.Is_MarkerDrafts)
                : Instances.InstanceDescriptorPredicates.Is_Markers
                ;

            return output;
        }

        public Func<InstanceDescriptor, bool> Get_IncludeValuesPredicate(bool includeDrafts = true)
        {
            var output = includeDrafts
                ? Instances.PredicateOperator.Or(
                    Instances.InstanceDescriptorPredicates.Is_Values,
                    Instances.InstanceDescriptorPredicates.Is_ValueDrafts)
                : Instances.InstanceDescriptorPredicates.Is_Values
                ;

            return output;
        }

        /// <summary>
        /// Get the predicate to include obsolete instances based on an override value.
        /// </summary>
        public Func<InstanceDescriptor, bool> Get_IncludeObsoleteInstancesPredicate(bool includeObsolete = true)
        {
            var output = includeObsolete
                // If we include obsoletes, it doesn't matter if the instance descriptor is obsolete or not.
                ? Instances.InstanceDescriptorPredicates.True
                // Else, only include the instance descriptor if it is not obsolete.
                : Instances.InstanceDescriptorPredicates.Not_Obsolete
                ;

            return output;
        }
    }
}
