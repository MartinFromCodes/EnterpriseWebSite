using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnterpriseWebSite.Exceptions
{
    public class UniqueKeyException : ApplicationException
    {
        private string myMessage;

        public UniqueKeyException()
        {
            this.myMessage = "索引键重复。";
        }
        public override string ToString()
        {
            return this.myMessage;
        }
        public override string Message
        {
            get
            {
                return this.myMessage;
            }
        }
    }
}
