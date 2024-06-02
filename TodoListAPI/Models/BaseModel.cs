namespace TodoListAPI.Models
{
    public class BaseModel
    {
        public int RtnCode { get; set; }
        public string RtnMsg { get; set; }
        public bool IsSuccess
        {
            get { return RtnCode == 1; }
        }
    }
}
