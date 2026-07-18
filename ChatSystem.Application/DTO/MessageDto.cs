using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatSystem.Application.DTO
{
    public class MessageDto
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content { get; set; }

        public string? FileUrl { get; set; }

        public string? FileName { get; set; }

        public long? FileSize { get; set; }

        public MessageType Type { get; set; }
        public DateTime SentAt { get; set;}
    }
    public enum MessageType
    {
        Text,

        Image,

        File,

        Audio,

        Video
    }
}
