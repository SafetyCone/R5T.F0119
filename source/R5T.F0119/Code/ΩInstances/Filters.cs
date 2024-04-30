using System;


namespace R5T.F0119
{
    public class Filters : IFilters
    {
        #region Infrastructure

        public static IFilters Instance { get; } = new Filters();


        private Filters()
        {
        }

        #endregion
    }
}
