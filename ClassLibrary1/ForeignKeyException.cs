using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnterpriseWebSite.Exceptions
{
    public class ForeignKeyException:ApplicationException
    {
        private string myMessage;

        public ForeignKeyException()
        {
            this.myMessage = "外键约束异常";
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
