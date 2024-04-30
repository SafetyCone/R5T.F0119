using System;


namespace R5T.F0119
{
    public class SearchOperator : ISearchOperator
    {
        #region Infrastructure

        public static ISearchOperator Instance { get; } = new SearchOperator();


        private SearchOperator()
        {
        }

        #endregion
    }
}
