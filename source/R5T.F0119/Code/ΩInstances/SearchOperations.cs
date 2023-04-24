using System;


namespace R5T.F0119
{
    public class SearchOperations : ISearchOperations
    {
        #region Infrastructure

        public static ISearchOperations Instance { get; } = new SearchOperations();


        private SearchOperations()
        {
        }

        #endregion
    }
}
