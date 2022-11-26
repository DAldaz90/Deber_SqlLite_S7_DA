using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SqlLite
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
