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

