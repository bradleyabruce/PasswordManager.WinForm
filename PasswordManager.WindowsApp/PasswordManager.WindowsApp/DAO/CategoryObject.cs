namespace PasswordManager.WindowsApp.DAO
{
    class CategoryObject
    {
        #region Operators

        public CategoryObject(string categoryName, string status)
        {
            CategoryName = categoryName;
            Status = status;
        }

        public CategoryObject()
        {
            CategoryName = null;
            Status = null;
        }

        #endregion

        #region Properties

        public string CategoryName;
        public string Status;

        #endregion
    }
}
