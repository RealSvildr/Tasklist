namespace Library {
    public class PriorityVO {
        public int PriorityID { get; set; }

        /* It`s also possible to create an enum for this one, 
         * but I only have lass than 15h, considering that I have other matters to attend */
        public int PriorityLevel { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}