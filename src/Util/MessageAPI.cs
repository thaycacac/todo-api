using System;

namespace ToDoAPI.Ultil 
{
    public class MessageAPI 
    {
        public string code { get; set; }

        public Object data { get; set; }

        public string message { get; set; }

        public MessageAPI()
        {

        }

        public MessageAPI(string code, Object data, string message)
        {
            this.code = code;
            this.data = data;
            this.message = message;
        }
    }
}