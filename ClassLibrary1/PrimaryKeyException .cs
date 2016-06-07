using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnterpriseWebSite.Exceptions
{
    public  class PrimaryKeyException:ApplicationException
    {
        private string myMessage;

        public PrimaryKeyException()
        {
            this.myMessage = "主键重复。";

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
