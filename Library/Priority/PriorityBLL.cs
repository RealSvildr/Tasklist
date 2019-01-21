using System;
using System.Collections.Generic;

namespace Library {
    public class PriorityBLL {
        private PriorityDAL _priorityDAL;

        public PriorityBLL() {
            _priorityDAL = new PriorityDAL();
        }

        public List<PriorityVO> GetList() {
            return _priorityDAL.GetList();
        }

        public PriorityVO GetById(int priorityId) {
            return _priorityDAL.GetById(priorityId);
        }

        public void Create(PriorityVO item) {
            _priorityDAL.Create(item);
        }

        public void Update(PriorityVO item) {
            _priorityDAL.Update(item);
        }

        public void Delete(PriorityVO item) {
            _priorityDAL.Delete(item);
        }
    }
}
