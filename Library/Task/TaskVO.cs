using System;

namespace Library {
    public class TaskVO {
        public int TaskID { get; set; }
        public int PriorityID { get; set; }
        public int StatusID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        //public bool Deleted { get; set; }

        /* To go as far as save every update date as well as the log of which user, 
         * I would need to create a different table with the columns being old data, new data, userId, date
         * Although, I don't have enought time, or will to go that far just for a test.
         */
        public DateTime CreateDate { get; set; }
        public DateTime DeleteDate { get; set; }

        public virtual PriorityVO Priority { get; set; }
        public virtual StatusVO Status { get; set; }
    }
}
