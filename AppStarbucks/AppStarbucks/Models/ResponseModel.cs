using System;
using System.Collections.Generic;
using System.Text;

namespace AppStarbucks.Models
{
    public class ResponseModel
    {
        public bool IsSucces { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }
    }
}
