using System;


namespace R5T.F0119
{
    public static class Instances
    {
        public static F0000.IStringOperator StringOperator => F0000.StringOperator.Instance;
        public static IInstanceDescriptorOperator InstanceDescriptorOperator => F0119.InstanceDescriptorOperator.Instance;
        public static Z0037.IInstanceVarietyNames InstanceVarietyNames => Z0037.InstanceVarietyNames.Instance;
        public static F0121.IMemberNameOperator MemberNameOperator => F0121.MemberNameOperator.Instance;
    }
}