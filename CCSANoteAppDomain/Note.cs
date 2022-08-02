using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSANoteApp.Domain
{
    public class Note
    {
        
            public Note()
            {
                Id = Guid.NewGuid();
            }
            public Guid Id { get; set; }
            public Guid UserId { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public string GroupName { get; set; }
            public DateTime CreatedDate { get; set; } = DateTime.Now;
            public DateTime UpdatedDate { get; set; } = DateTime.Now;
        
    }

    public enum GroupName
    {
        Personal =0,
        Public =1,
        General = 2

    }
}
