using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    public class Activity : IComparable
    {
        //enums and properties
        public enum Types { Land, Water, Air }
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }
        public Types Type_of_Activity {get;set;}
        public string Description
        {
            get { return _description +" "+"$"+ Cost; }
            set { }
        }
        public string _description { get; set; }


        public Activity(string Name, DateTime ActivityDate, decimal Cost, Types Type_of_Activity,string _description)
        {
            this.Name = Name;
            this.ActivityDate = ActivityDate;
            this.Cost = Cost;
            this.Type_of_Activity = Type_of_Activity;
            this._description = _description;
        }
        public Activity() {} 

        public int CompareTo(object obj)
        {
            Activity that = (Activity)obj;
            return ActivityDate.CompareTo(that.ActivityDate);
        }
        public override string ToString()
        {
            return string.Format(Name + " - " + ActivityDate.ToShortDateString());
        }
    }
}
