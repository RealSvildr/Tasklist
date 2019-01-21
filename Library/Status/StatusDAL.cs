using System.Collections.Generic;
using System.Linq;

namespace Library {
    internal class StatusDAL : BaseDAL {
        /* No Filter */
        public List<StatusVO> GetList() {
            string sqlQuery = @"
                SELECT
                    StatusID,
                    Name,
                    Description
                FROM
                    Status
            ";


            return _dbContext.SqlQuery<StatusVO>(sqlQuery);
        }

        internal StatusVO GetById(int statusID) {
            string sqlQuery = @"
                SELECT
                    StatusID,
                    Name,
                    Description
                FROM
                    Status
                WHERE
                    StatusID = @p0
            ";


            return _dbContext.SqlQuery<StatusVO>(sqlQuery, statusID).FirstOrDefault();
        }
    }
}
