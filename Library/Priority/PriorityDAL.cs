using System.Collections.Generic;
using System.Linq;

namespace Library {
    internal class PriorityDAL : BaseDAL {
        /* No Filter */
        internal List<PriorityVO> GetList() {
            string sqlQuery = @"
                SELECT
                    PriorityID,
                    PriorityLevel,
                    Name,
                    Description
                FROM
                    Priority
            ";


            return _dbContext.SqlQuery<PriorityVO>(sqlQuery);
        }

        internal PriorityVO GetById(int priorityID) {
            string sqlQuery = @"
                SELECT
                    PriorityID,
                    PriorityLevel,
                    Name,
                    Description
                FROM
                    Priority
                WHERE
                    PriorityID = @p0
            ";


            return _dbContext.SqlQuery<PriorityVO>(sqlQuery, priorityID).FirstOrDefault();
        }

        internal void Create(PriorityVO item) {
            string sqlQuery = @"
                INSERT INTO
                    Priority
                (
                    PriorityLevel,
                    Name,
                    Description
                ) VALUES (
                    @p0,
                    @p1,
                    @p2
                )
            ";

            _dbContext.ExecuteSqlCommand(
               sqlQuery,
               item.PriorityLevel,
               item.Name,
               item.Description
           );
        }

        internal void Update(PriorityVO item) {
            string sqlQuery = @"
                UPDATE
                    Priority
                SET
                    PriorityLevel = @p1,
                    Name = @p2,
                    Description = @p3
                WHERE
                    PriorityID = @p0
            ";


            _dbContext.ExecuteSqlCommand(
                sqlQuery,
                item.PriorityID,
                item.PriorityLevel,
                item.Name,
                item.Description
            );
        }

        internal void Delete(PriorityVO item) {
            string sqlQuery = @"
                DELETE FROM
                    Priority
                WHERE
                    PriorityID = @p0
            ";

            _dbContext.ExecuteSqlCommand(sqlQuery, item.PriorityID);
        }
    }
}
