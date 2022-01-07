namespace ToDo.Web
{
    public static class SD
    {
        public static string ToDoAPIListBase { get; set; }
        public static string UserManagementAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
