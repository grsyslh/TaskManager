using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DataAccess.Abstract;
using TaskManager.Entity;

namespace TaskManager.DataAccess.Concrete.EFCore
{
    public class EFCoreTaskRepository:EFCoreGenericRepository<Tasks,TaskManagerContext>,ITaskRepository
    {
    }
}
