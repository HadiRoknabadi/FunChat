namespace FunChat.Application.DTOs.Common
{
    public class ApplicationResultDTO<TData> where TData : class
    {
        public string Message { get; set; }
        public ResultStatus Status { get; set; }
        public TData Data { get; set; } = default;
    }
}
