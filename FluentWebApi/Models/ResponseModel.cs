using System.Collections.Generic;

namespace FluentWebApi.Models
{
    public class ResponseModel
    {
        public bool IsValid { get; set; }
        public List<string> ValidationMessages { get; set; }

        public ResponseModel()
        {
            IsValid = true;
            ValidationMessages = new List<string>();
        }
    }
}
