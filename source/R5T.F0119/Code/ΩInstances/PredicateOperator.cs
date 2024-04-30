using System;


namespace R5T.F0119
{
    public class PredicateOperator : IPredicateOperator
    {
        #region Infrastructure

        public static IPredicateOperator Instance { get; } = new PredicateOperator();


        private PredicateOperator()
        {
        }

        #endregion
    }
}
