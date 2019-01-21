using System;
using System.Collections.Generic;

namespace Library {
    public class TaskBLL {
        private TaskDAL _taskDAL;
        private StatusDAL _statusDAL;
        private PriorityDAL _priorityDAL;

        public TaskBLL() {
            _taskDAL = new TaskDAL();
            _statusDAL = new StatusDAL();
            _priorityDAL = new PriorityDAL();
        }

        public List<TaskVO> GetList() {
            List<TaskVO> listTask = _taskDAL.GetList();

            for(int i = 0; i< listTask.Count; i++) {
                listTask[i].Status = _statusDAL.GetById(listTask[i].StatusID);
                listTask[i].Priority = _priorityDAL.GetById(listTask[i].PriorityID);

            }

            return listTask;
        }

        public TaskVO GetById(int taskId) {
            return _taskDAL.GetById(taskId);
        }

        public void Create(TaskVO item) {
            item.CreateDate = DateTime.Now;

            _taskDAL.Create(item);
        }

        public void Update(TaskVO item) {
            _taskDAL.Update(item);
        }

        public void Delete(TaskVO item) {
            item.DeleteDate = DateTime.Now;

            _taskDAL.Delete(item);
        }
    }
}
