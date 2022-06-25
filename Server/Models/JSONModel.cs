using System.Collections.Generic;

namespace UIServer.Models;

public class JSONModel
{
    public class ApplicationF
    {
        public string name { get; set; }
        public List<Shortcut> commands { get; set; }
    }

    public class Shortcut
    {
        public string shortCut { get; set; }
        public string imageUrl { get; set; }
    }
}