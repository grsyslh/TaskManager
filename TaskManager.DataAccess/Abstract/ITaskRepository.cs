using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Entity;

namespace TaskManager.DataAccess.Abstract
{
    public interface ITaskRepository:IRepository<Tasks>
    {
    }
}
