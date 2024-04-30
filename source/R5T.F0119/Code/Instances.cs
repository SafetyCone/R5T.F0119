using System;

using R5T.T0170;


namespace R5T.F0119
{
    public static class Instances
    {
        public static L0053.IExceptionOperator ExceptionOperator => L0053.ExceptionOperator.Instance;
        public static IFilters Filters => F0119.Filters.Instance;
        public static IInstanceDescriptorOperator InstanceDescriptorOperator => F0119.InstanceDescriptorOperator.Instance;
        public static IInstanceDescriptorPredicates InstanceDescriptorPredicates => F0119.InstanceDescriptorPredicates.Instance;
        public static Z0037.IInstanceVarietyNames InstanceVarietyNames => Z0037.InstanceVarietyNames.Instance;
        public static F0121.IKindMarkers KindMarkers => F0121.KindMarkers.Instance;
        public static F0121.IMemberNameOperator MemberNameOperator => F0121.MemberNameOperator.Instance;
        public static L0053.INamespacedTypeNameOperator NamespacedTypeNameOperator => L0053.NamespacedTypeNameOperator.Instance;
        public static IOperations Operations => F0119.Operations.Instance;
        public static F0121.IParameterOperator ParameterOperator => F0121.ParameterOperator.Instance;
        public static IPredicateOperator PredicateOperator => F0119.PredicateOperator.Instance;
        public static ISearchOperations SearchOperations => F0119.SearchOperations.Instance;
        public static ISearchOperator SearchOperator => F0119.SearchOperator.Instance;
        public static ISelectors Selectors => F0119.Selectors.Instance;
        public static L0065.ISignatureOperator SignatureOperator => L0065.SignatureOperator.Instance;
        public static L0065.ISignatureStringOperator SignatureStringOperator => L0065.SignatureStringOperator.Instance;
        public static F0000.IStringOperator StringOperator => F0000.StringOperator.Instance;
        public static L0053.ISwitchOperator SwitchOperator => L0053.SwitchOperator.Instance;
    }
}