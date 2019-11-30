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

namespace ActivityPlanner_Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Activity> allActivities = new List<Activity>();
        List<Activity> selectedActivities = new List<Activity>();
        List<Activity> filteredActivities = new List<Activity>();
        public static decimal totalCost;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // automatically have the All radio button checked
            rbAll.IsChecked = true;

            // Declare all Land activities
            Activity l1 = new Activity()
            {
                Name = "Treking",
                Description = "Instructor led group trek through local mountains.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Land,
                Cost = 20m
            };

            Activity l2 = new Activity()
            {
                Name = "Mountain Biking",
                Description = "Instructor led half day mountain biking.  All equipment provided.",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Land,
                Cost = 30m
            };

            Activity l3 = new Activity()
            {
                Name = "Abseiling",
                Description = "Experience the rush of adrenaline as you descend cliff faces from 10-500m.",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Land,
                Cost = 40m
            };

            // Declare all Water activities
            Activity w1 = new Activity()
            {
                Name = "Kayaking",
                Description = "Half day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Water,
                Cost = 40m
            };

            Activity w2 = new Activity()
            {
                Name = "Surfing",
                Description = "2 hour surf lesson on the wild atlantic way",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Water,
                Cost = 25m
            };

            Activity w3 = new Activity()
            {
                Name = "Sailing",
                Description = "Full day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Water,
                Cost = 50m
            };

            // Declare all Air activities
            Activity a1 = new Activity()
            {
                Name = "Parachuting",
                Description = "Experience the thrill of free fall while you tandem jump from an airplane.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Air,
                Cost = 100m
            };

            Activity a2 = new Activity()
            {
                Name = "Hang Gliding",
                Description = "Soar on hot air currents and enjoy spectacular views of the coastal region.",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Air,
                Cost = 80m
            };

            Activity a3 = new Activity()
            {
                Name = "Helicopter Tour",
                Description = "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Air,
                Cost = 200m
            };

            // Add all activities to the List of allActivities
            allActivities.Add(l1);
            allActivities.Add(l2);
            allActivities.Add(l3);

            allActivities.Add(w1);
            allActivities.Add(w2);
            allActivities.Add(w3);

            allActivities.Add(a1);
            allActivities.Add(a2);
            allActivities.Add(a3);

            // Sort the activities by date
            allActivities.Sort();

            // Store all the activities in the list box
            lbxActivities.ItemsSource = allActivities;
        }

        // Method to refresh the screen everytime an activity is added or removed
        private void RefreshScreen()
        {
            lbxActivities.ItemsSource = null;
            lbxActivities.ItemsSource = allActivities;

            lbxSelectedActivities.ItemsSource = null;
            lbxSelectedActivities.ItemsSource = selectedActivities;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // figure out what item is selected
            Activity selectedActivity = lbxActivities.SelectedItem as Activity;

            /*if (selectedActivity.ActivityDate != selectedActivity.ActivityDate)
            {*/
                // null check
                if (selectedActivity != null)
                {
                    // Remove and add the activity to the new list box
                    allActivities.Remove(selectedActivity);
                    selectedActivities.Add(selectedActivity);

                    // refresh the screen method
                    RefreshScreen();

                    // Add to the total cost
                    totalCost = totalCost + selectedActivity.Cost;

                    tblkTotal.Text = totalCost.ToString("C");

                    // Sort the dates
                    allActivities.Sort();
                    selectedActivities.Sort();
                }
                else if (selectedActivity == null)
                {
                    tbxDescription.Text = "No Activity has been selected to add.";
                }
            }
        /*else
        {
            tbxDescription.Text = "Conflict in dates";
        }
    }*/

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            // figure out what item is selected
            Activity selectedActivity = lbxSelectedActivities.SelectedItem as Activity;

            // null check
            if (selectedActivity != null)
            {
                // Remove and add the activity to the new list box
                allActivities.Add(selectedActivity);
                selectedActivities.Remove(selectedActivity);

                // refresh the screen method
                RefreshScreen();

                // Add to the total cost
                totalCost = totalCost - selectedActivity.Cost;

                tblkTotal.Text = totalCost.ToString("C");

                // Sort the dates
                allActivities.Sort();
                selectedActivities.Sort();
            }
            else
            {
                tbxDescription.Text = "No Activity has been selected to remove.";
            }
        }

        private void RbAll_Click(object sender, RoutedEventArgs e)
        {
            // Clear the list at the start
            filteredActivities.Clear();

            // Clear all of the lists, then filter
            if(rbAll.IsChecked == false && rbLand.IsChecked == false && rbWater.IsChecked == false && rbAir.IsChecked == false)
            {
                allActivities.Clear();
                selectedActivities.Clear();
                filteredActivities.Clear();
                lbxActivities.ItemsSource = filteredActivities;
            }
            else if(rbAll.IsChecked == true)
            {
                RefreshScreen();
            }
            else if(rbLand.IsChecked == true)
            {
                foreach(Activity activity in allActivities)
                {
                    if(activity.TypeOfActivity == ActivityType.Land)
                    {
                        filteredActivities.Add(activity);
                        lbxActivities.ItemsSource = null;
                        lbxActivities.ItemsSource = filteredActivities;
                    }
                }
            }
            else if (rbWater.IsChecked == true)
            {
                foreach (Activity activity in allActivities)
                {
                    if (activity.TypeOfActivity == ActivityType.Water)
                    {
                        filteredActivities.Add(activity);
                        lbxActivities.ItemsSource = null;
                        lbxActivities.ItemsSource = filteredActivities;
                    }
                }
            }
            else if (rbAir.IsChecked == true)
            {
                foreach (Activity activity in allActivities)
                {
                    if (activity.TypeOfActivity == ActivityType.Air)
                    {
                        filteredActivities.Add(activity);
                        lbxActivities.ItemsSource = null;
                        lbxActivities.ItemsSource = filteredActivities;
                    }
                }
            }
        }

        // Displays the description of the activity selected in the box on the left
        private void LbxActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activity selectedActivity = lbxActivities.SelectedItem as Activity;
            if(selectedActivity != null)
            {
                tbxDescription.Text = selectedActivity.Description;
            }
        }

        // Displays the description of the activity selected in the box on the right
        private void LbxSelectedActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activity selectedActivity = lbxSelectedActivities.SelectedItem as Activity;
            if (selectedActivity != null)
            {
                tbxDescription.Text = selectedActivity.Description;
            }
        }
    }
}
