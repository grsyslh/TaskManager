using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Business.Abstract;
using TaskManager.DataAccess.Abstract;
using TaskManager.Entity;

namespace TaskManager.Business.Concrete
{
    public class TaskServiceManager : ITaskService
    {
        private ITaskRepository _taskRepository;
        public TaskServiceManager(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public void Create(Tasks entity)
        {
            _taskRepository.Create(entity);
        }

        public void Delete(Tasks entity)
        {
            _taskRepository.Delete(entity);
        }

        public List<Tasks> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }

        public Tasks GetById(int id)
        {
            return _taskRepository.GetById(id);
        }

        public void Update(Tasks entity)
        {
            _taskRepository.Update(entity);
        }
    }
}
