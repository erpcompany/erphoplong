using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SYSTEM_MANAGEMENT.Models
{
    public class PermissionAction
    {
        public int PERMISSION_ID { get; set; }
        public String PERMISSION_NAME { get; set; }
        public String DESCRIPTION { get; set; }
        public bool IS_GRANTED { get; set; }
    }
}