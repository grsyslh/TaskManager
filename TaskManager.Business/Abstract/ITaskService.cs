using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Entity;

namespace TaskManager.Business.Abstract
{
    public interface ITaskService
    {
        Tasks GetById(int id);
        List<Tasks> GetAllTasks();
        void Create(Tasks entity);
        void Delete(Tasks entity);
        void Update(Tasks entity);
    }
}
