using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner_Assignment
{
    // Declare an enum in the namespace so it can be used throughout the class and methods
    public enum ActivityType { Air, Water, Land}
    class Activity
    {
        // Declare Properties
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }
        private string _description;

        public string Description
        {
            get
            {
                return $"{_description} Cost - {Cost:C}";
            }
            set
            {
                _description = value;
            }
        }

        public static decimal TotalCost;
        public ActivityType TypeOfActivity { get; set; }

        // Constructors
        public Activity(string name, DateTime activityDate, decimal cost, string description, ActivityType typeOfActivity)
        {
            Name = name;
            ActivityDate = activityDate;
            Cost = cost;
            Description = description;
            TypeOfActivity = typeOfActivity;
        }
        public Activity():this("Unknown", DateTime.Now, 0, "Unknown", ActivityType.Air)
        {

        }


    }
}
