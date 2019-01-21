using System.Collections.Generic;

namespace Library {
    public class StatusBLL {
        private StatusDAL _statusDAL;

        public StatusBLL() {
            _statusDAL = new StatusDAL();
        }

        public List<StatusVO> GetList() {
            return _statusDAL.GetList();
        }
    }
}
