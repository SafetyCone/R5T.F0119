using System;


namespace R5T.F0119
{
    public class InstanceDescriptorOperator : IInstanceDescriptorOperator
    {
        #region Infrastructure

        public static IInstanceDescriptorOperator Instance { get; } = new InstanceDescriptorOperator();


        private InstanceDescriptorOperator()
        {
        }

        #endregion
    }
}
