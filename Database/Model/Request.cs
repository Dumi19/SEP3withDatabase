
using System;

namespace Database.Model
{
    [Serializable]
    public class Request {

        public string Action{get; set;}
        public object Arg {get; set;}

namespace Database.Model
{
    public class Request {
        private string type;
        private object arg;

        public Request(string type, object arg) {
            this.type = type;
            this.arg = arg;
        }

        public string getType() {
            return type;
        }

        public object getArg() {
            return arg;
        }

    }
}

