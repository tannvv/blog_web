using System;

namespace blog_web{

    public class PagingModel{
        public int CurrentPage { get; set; }
        public int CountPage { get; set; }
        public Func<int?,string> GenerateUrl{set;get;}
    }
}