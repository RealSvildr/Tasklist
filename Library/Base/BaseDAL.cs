using SqlMinimal;

namespace Library {
    internal partial class BaseDAL {
        internal DBContext _dbContext = new DBContext("LAPTOP-530LI779\\SQLEXPRESS", "Tasklist");

        public BaseDAL() {
        }
    }
}
