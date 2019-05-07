using System;

namespace Arkano.Azure.Discovery.Day.Models
{
    public class InputMessage
    {
        public string Message { get; set; }

        public string Username { get; set; }

        public DateTime SentDate { get; set; }
    }
}