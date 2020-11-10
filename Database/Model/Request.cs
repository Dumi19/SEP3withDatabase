
using System;

namespace Database.Model
{
    [Serializable]
    public class Request {

        public string Action{get; set;}
        public object Arg {get; set;}
    }
}

