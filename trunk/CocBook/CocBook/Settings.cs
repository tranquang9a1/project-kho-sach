using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocBook
{
    class Settings
    {
        [global::System.Configuration.UserScopedSettingAttribute()]
        public string ConnectionString
        {
            get { return (string)this["ConnectionString"]; }
            set { this["ConnectionString"] = value; }
        }

    }
}
