using FunChat.Application.Extensions;

namespace FunChat.Application.DTOs.Common
{
    public class ApplicationResultDTO
    {
        public ApplicationResultDTO()
        {
            Status=ResultStatus.Success;
        }
        private string _resultMessage;

        public ResultStatus Status { get; set; }
        public string StatusMessage
        {
            get { return _resultMessage; }
            set
            {
                if (string.IsNullOrEmpty(StatusMessage))
                {
                    _resultMessage = Status.GetEnumName();
                }
            }
        }
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
    public class ApplicationResultDTO<TData> :ApplicationResultDTO where TData : class
    {

        public TData Data { get; set; } = default;
    }
}
