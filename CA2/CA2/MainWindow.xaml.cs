using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //lists
        List<Activity> AllActivities;//List on the left that contains all the activities
        List<Activity> SelectedActivities;//list on the right that has all the selected activities
        public decimal total = 0;
        public MainWindow()
        {
            AllActivities = new List<Activity>();
            SelectedActivities = new List<Activity>();
            //Activites
            Activity l1 = new Activity()
            {
                Name = "Treking",
                _description = "Instructor led group trek through local mountains.",
                ActivityDate = new DateTime(2019, 06, 01),
                Type_of_Activity = Activity.Types.Land,
                Cost = 20m
            };

            Activity l2 = new Activity()
            {
                Name = "Mountain Biking",
                _description = "Instructor led half day mountain biking.  All equipment provided.",
                ActivityDate = new DateTime(2019, 06, 02),
                Type_of_Activity = Activity.Types.Land,
                Cost = 30m
            };

            Activity l3 = new Activity()
            {
                Name = "Abseiling",
                _description = "Experience the rush of adrenaline as you descend cliff faces from 10-500m.",
                ActivityDate = new DateTime(2019, 06, 03),
                Type_of_Activity = Activity.Types.Land,
                Cost = 40m
            };

            Activity w1 = new Activity()
            {
                Name = "Kayaking",
                _description = "Half day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 01),
                Type_of_Activity = Activity.Types.Water,
                Cost = 40m
            };

            Activity w2 = new Activity()
            {
                Name = "Surfing",
                _description = "2 hour surf lesson on the wild atlantic way",
                ActivityDate = new DateTime(2019, 06, 02),
                Type_of_Activity = Activity.Types.Water,
                Cost = 25m
            };

            Activity w3 = new Activity()
            {
                Name = "Sailing",
                _description = "Full day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 03),
                Type_of_Activity = Activity.Types.Water,
                Cost = 50m
            };

            Activity a1 = new Activity()
            {
                Name = "Parachuting",
                _description = "Experience the thrill of free fall while you tandem jump from an airplane.",
                ActivityDate = new DateTime(2019, 06, 01),
                Type_of_Activity = Activity.Types.Air,
                Cost = 100m
            };

            Activity a2 = new Activity()
            {
                Name = "Hang Gliding",
                _description = "Soar on hot air currents and enjoy spectacular views of the coastal region.",
                ActivityDate = new DateTime(2019, 06, 02),
                Type_of_Activity = Activity.Types.Air,
                Cost = 80m
            };

            Activity a3 = new Activity()
            {
                Name = "Helicopter Tour",
                _description = "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters",
                ActivityDate = new DateTime(2019, 06, 03),
                Type_of_Activity = Activity.Types.Air,
                Cost = 200m
            };
            //Adding activites to the "All" list
            AllActivities.Add(l1);
            AllActivities.Add(l2);
            AllActivities.Add(l3);
            AllActivities.Add(w1);
            AllActivities.Add(w2);
            AllActivities.Add(w3);
            AllActivities.Add(a1);
            AllActivities.Add(a2);
            AllActivities.Add(a3);
            InitializeComponent();

            AllActivities.Sort();
            LST_List1.ItemsSource = AllActivities;
        }

        private void B_Left_Click(object sender, RoutedEventArgs e)//Removing activities from right list and displaying total cost
        {
            Activity selectedactivity = SelectedActivities[LST_List2.SelectedIndex];
            //removing from the list
            SelectedActivities.Remove(selectedactivity);
            SelectedActivities.Sort();
            //Adding the the ALL list
            AllActivities.Add(selectedactivity);
            AllActivities.Sort();
            LST_List2.ItemsSource = null;
            LST_List2.ItemsSource = SelectedActivities;
            LST_List1.ItemsSource = null;
            LST_List1.ItemsSource = AllActivities;
            TBLK_Error_Message.Text = "Activity was removed";
            //Changing the total cost
            total = total - selectedactivity.Cost;
            TBLK_Total.Text = $"Total is {total}";
        }
        //checking for data conflict(Can't choose two activities with the same date)
        private bool checkifdateconflict(DateTime date1, List<Activity> Activities)
        {
            for (int i = 0; i < Activities.Count; i++)
            {
                if (date1 == Activities[i].ActivityDate)//If dates are same it will return true 
                {
                    return true;
                }
            }
            
            return false;
        }
        private void B_Right_Click(object sender, RoutedEventArgs e)//Adding activities to the list on the right
        {
            if (LST_List1.SelectedIndex != -1)
            {
                Activity selectedactivity = AllActivities[LST_List1.SelectedIndex];
                if (!checkifdateconflict(selectedactivity.ActivityDate, SelectedActivities))//if statement to chesck for data conflict
                {
                    AllActivities.Remove(selectedactivity);
                    AllActivities.Sort();
                    SelectedActivities.Add(selectedactivity);
                    SelectedActivities.Sort();
                    LST_List2.ItemsSource = null;
                    LST_List2.ItemsSource = SelectedActivities;
                    LST_List1.ItemsSource = null;
                    LST_List1.ItemsSource = AllActivities;
                    //changing the total cost
                    total = total + selectedactivity.Cost;
                    TBLK_Total.Text = $"Total is {total}";
                    TBLK_Error_Message.Text = " ";
                }
                else//error message in case of data conflict
                    TBLK_Error_Message.Text = "There are date conflicts";
            }
            else//error if no activity was choosen
                TBLK_Error_Message.Text = "Nothing was selected";
        }






        private void ORB_All_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void ORB_Land_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void ORB_Water_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ORB_Air_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void LST_List1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LST_List1.SelectedIndex!=-1)
            {            
              Activity selectedactivity = AllActivities[LST_List1.SelectedIndex];
              TBLK_Description.Text = selectedactivity.Description;
            }
        }
    }
}
