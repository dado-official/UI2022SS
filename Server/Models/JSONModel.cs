using System.Collections.Generic;

namespace UIServer.Models;

public class JSONModel
{
    public class ApplicationF
    {
        public string name { get; set; }
        public List<Shortcut> Shortcuts { get; set; }
    }

    public class Shortcut
    {
        public string keys { get; set; }
        public string imageURL { get; set; }
    }
    
}