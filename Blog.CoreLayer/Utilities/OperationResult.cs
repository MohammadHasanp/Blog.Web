namespace CodeYad_Blog.CoreLayer.Utilities
{
    public class OperationResult
    {
        public string Message { get; set; }
        public OperationResultStatus Status { get; set; }


        #region Error
        public static OperationResult Error()
        {
            return new OperationResult
            {
                Status = OperationResultStatus.Error,
                Message = "عملیات ناموفق",
            };
        }
        
        public static OperationResult Error(string Message)
        {
            return new OperationResult
            {
                Status = OperationResultStatus.Error,
                Message = Message,
            };
        }
# endregion

        #region NotFound
        public static OperationResult NotFound()
        {
            return new OperationResult
            {
                Status = OperationResultStatus.NotFound,
                Message = "اطلاعات درخواستی یافت نشد",
            };
        }

        public static OperationResult NotFound(string Message)
        {
            return new OperationResult
            {
                Status = OperationResultStatus.NotFound,
                Message = Message,
            };

        }
        #endregion

        #region Success
        public static OperationResult Success()
        {
            return new OperationResult
            {
                Status = OperationResultStatus.Success,
                Message = "عملیات با موفقیت انجام شد",
            };
        }

        public static OperationResult Success(string Message)
        {
            return new OperationResult
            {
                Status = OperationResultStatus.Success,
                Message = Message,
            };
        }
        #endregion
    }

    #region enum
    public enum OperationResultStatus
    {
        Error = 10,
        NotFound =404,
        Success =200
    }
    #endregion
}