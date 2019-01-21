using System.Collections.Generic;
using System.Linq;

namespace Library {
    internal class TaskDAL : BaseDAL {
        /* No Filter */
        public List<TaskVO> GetList() {
            string sqlQuery = @"
                SELECT
                    A.TaskID,
                    A.PriorityID,
                    A.StatusID,
                    A.Name,
                    A.Description,
                    A.CreateDate
                FROM
                    Task AS A WITH (NOLOCK)
                JOIN
                    Priority AS B WITH (NOLOCK) ON B.PriorityID = A.PriorityID
                WHERE
                    A.Deleted = 0
                ORDER BY
                    B.PriorityLevel DESC,
                    A.CreateDate
            ";


            return _dbContext.SqlQuery<TaskVO>(sqlQuery);
        }


        public TaskVO GetById(int taskId) {
            string sqlQuery = @"
                SELECT
                    TaskID,
                    PriorityID,
                    StatusID,
                    Name,
                    Description,
                    CreateDate
                FROM
                    Task WITH (NOLOCK)
                WHERE
                    TaskID = @p0
            ";


            return _dbContext.SqlQuery<TaskVO>(sqlQuery, taskId).FirstOrDefault();
        }

        public void Create(TaskVO item) {
            string sqlQuery = @"
                INSERT INTO
                    Task
                (
                    PriorityID,
                    StatusID,
                    Name,
                    Description,
                    CreateDate,
                    Deleted
                ) VALUES (
                    @p0,
                    @p1,
                    @p2,
                    @p3,
                    @p4,
                    0
                )
            ";

            _dbContext.ExecuteSqlCommand(
               sqlQuery,
               item.PriorityID,
               item.StatusID,
               item.Name,
               item.Description,
               item.CreateDate
           );
        }

        public void Update(TaskVO item) {
            string sqlQuery = @"
                UPDATE
                    Task
                SET
                    PriorityID = @p1,
                    StatusID = @p2,
                    Name = @p3,
                    Description = @p4
                WHERE
                    TaskID = @p0
            ";


            _dbContext.ExecuteSqlCommand(
                sqlQuery,
                item.TaskID,
                item.PriorityID,
                item.StatusID,
                item.Name,
                item.Description
            );
        }

        public void Delete(TaskVO item) {
            string sqlQuery = @"
                UPDATE
                    Task
                SET
                    Deleted = 1,
                    DeleteDate = @p1
                WHERE
                    TaskID = @p0
            ";


            _dbContext.ExecuteSqlCommand(
                sqlQuery,
                item.TaskID,
                item.DeleteDate
            );
        }
    }
}
