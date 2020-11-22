using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1.entity
{
    class ReturnEntity
    {
        private string code;
        private string msg;
        private List<Object> data;

        public string Code { get => code; set => code = value; }
        public string Msg { get => msg; set => msg = value; }
        public List<object> Data { get => data; set => data = value; }
    }
}
